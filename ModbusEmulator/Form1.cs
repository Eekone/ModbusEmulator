using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using ExtensionMethods;
using System.Threading;

namespace ModbusEmulator
{
    public partial class Form1 : Form
    {
        #region LocalVarialbles;
        private SerialPort pulsarCOM = new SerialPort();
        private SerialPort tracemodeCOM = new SerialPort();       
        private byte[] tracemodeCommand = { 0x01, 0x03, 0x00, 0x01, 0x00, 0x09, 0xD4, 0x0C};
        private byte[] pulsarCommand = { 0x55, 0x55, 0x55, 0x55, 0x55, 0x55, 0x55, 0x55, 0x55, 0x55, 0x55,
                                         0x7E, 0x01, 0x3F, 0x41, 0x27, 0x00, 0xDA, 0x27, 0x07, 0x30, 0x12,
                                         0x21, 0x48, 0xEF, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                         0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00,
                                         0x00, 0x00, 0x00, 0x00, 0x20, 0x9C,
                                         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        List<byte> dataEnder = new List<byte>() { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        List<byte> incomingBytes = new List<byte>();
        List<byte> tracemodeIncoming = new List<byte>();
        List<byte> lastDataAnswer = new List<byte>();
        List<byte> lastData = new List<byte>() { 0,0,0,0,0,0,0,0,0};
        byte device = 1;
        byte lastCommand=0;
      


        #endregion
        public Form1()
        {
            InitializeComponent();
            SetUpComboBoxes();
            cmbParity.Text = "None";
            cmbStopBits.Text = "1";
            cmbDataBits.Text = "8";
            //cmbParity.Text = settings.Parity.ToString();
            cmbBaudRate.Text = "1200";
            pulsarCOM.DataReceived += new SerialDataReceivedEventHandler(pulsar_DataReceived);
            tracemodeCOM.DataReceived += new SerialDataReceivedEventHandler(tracemode_DataReceived);
           
        }
        #region DataRecievedListeners

        private void pulsar_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           
                if (!pulsarCOM.IsOpen) return;

                byte[] buffer = new byte[pulsarCOM.BytesToRead];
                pulsarCOM.Read(buffer, 0, pulsarCOM.BytesToRead);

                pulsarTB.Invoke(new EventHandler(delegate
                {
                    pulsarTB.AppendText("Принято: " + HexConverter.toString(buffer) + "\n");
                }));

                incomingBytes.AddRange(buffer);

                if (lastCommand == 3 && parseDataForAnswer())
                {
                    byte[] tracemodeR = Modbus.func3Response(lastData.ToArray(), device);
                    tracemodeCOM.Write(tracemodeR, 0, tracemodeR.Length);
                tracemodeTB.Invoke(new EventHandler(delegate
                {
                    tracemodeTB.AppendText("Отправлены данные: " + HexConverter.toString(Modbus.func3Response(lastData.ToArray(), device)) + "\n");
                }));
                incomingBytes.Clear();
                } 
        }     
        private void tracemode_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           
            if (!tracemodeCOM.IsOpen) return;

            int bytes = tracemodeCOM.BytesToRead;
            byte[] buffer = new byte[bytes];
            tracemodeCOM.Read(buffer, 0, bytes);
            tracemodeIncoming.AddRange(buffer);
            tracemodeTB.Invoke(new EventHandler(delegate {
                tracemodeTB.AppendText("Получено: "+HexConverter.toString(buffer) + "\n");
            }));

            if (tracemodeIncoming.Count > 2)
            {
                byte[] CRC = Modbus.CRC(tracemodeIncoming.GetRange(0, tracemodeIncoming.Count - 2).ToArray());//Modbus.CRC(buffer.SubArray(0, buffer.Length - 2));
                if (tracemodeIncoming[tracemodeIncoming.Count-1] == CRC[1] && tracemodeIncoming[tracemodeIncoming.Count - 2] == CRC[0])
                {
                    if (tracemodeIncoming[1] == 3)
                    {
                        lastCommand = 3;
                        device = tracemodeIncoming[0];
                        byte[] command = Pulsar.OneTimeProgrammCommBufferFormer(tracemodeIncoming[0]);
                        tracemodeTB.Invoke(new EventHandler(delegate
                        {
                            tracemodeTB.AppendText("Это команда на опрос!" + " Отправляем запрос на СКЗ (см. окно Пульсар) \n");
                        }));
                        if(checkBox1.Checked)
                            pulsarCOM.Parity = Parity.Even;
                        if (chkRTS.Checked)
                        {
                            pulsarCOM.RtsEnable = true;
                            Thread.Sleep(int.Parse(timeout.Text));
                        }
                        pulsarCOM.Write(command, 0, command.Length);
                        pulsarCOM.Parity = Parity.None;
                        pulsarCOM.RtsEnable = false;
                        pulsarTB.Invoke(new EventHandler(delegate
                        {
                            pulsarTB.AppendText("Отправлена команда на разовый опрос" + (chkRTS.Checked? " с RTS\n" : "\n") +
                        HexConverter.toString(command) + "\nОжидайте минуту\n");
                        }));
                        tracemodeIncoming.Clear();
                    }
                    else if (tracemodeIncoming[1] == 16)
                    {
                        lastCommand = 16;
                        device = tracemodeIncoming[0];
                        byte[] command = Pulsar.NewProgrammCommBufferFormer(tracemodeIncoming[0], tracemodeIncoming.GetRange(7, 20).ToArray());
                        pulsarTB.Invoke(new EventHandler(delegate
                        {
                            pulsarTB.AppendText("Это команда на запись данных!\n" + HexConverter.toString(command) + "\n");
                        }));
                        pulsarCOM.Parity = Parity.Even;

                        pulsarCOM.Write(command, 0, command.Length);
                        pulsarCOM.Parity = Parity.None;
                        tracemodeIncoming.Clear();
                    }
                }
            }
        }
        #endregion
      
        #region ButtonListeners
        private void pulsarTextClear_Click(object sender, EventArgs e)
        {
            pulsarTB.Clear();
        }

        private void traceModeTextClear_Click(object sender, EventArgs e)
        {
            tracemodeTB.Clear();
        }

        private void pulsarComOpen_Click(object sender, EventArgs e)
        {
            if (pulsarCOM.IsOpen)
            {
                pulsarCOM.Close();
                pulsarComOpen.Text = "Открыть";
            }
            else
            {
                pulsarCOM.BaudRate = int.Parse(cmbBaudRate.Text);
                pulsarCOM.DataBits = int.Parse(cmbDataBits.Text);
                pulsarCOM.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
                pulsarCOM.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
                pulsarCOM.PortName = pulsarComCB.Text;
                pulsarComOpen.Text = "Открыт";
                try {pulsarCOM.Open(); }
                catch (Exception ex)
                {
                    pulsarComOpen.Text = "Открыть";
                    MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }        
        }

        private void traceModeComOpen_Click(object sender, EventArgs e)
        {
            if (pulsarCOM.IsOpen)
            {
                pulsarCOM.Close();
                pulsarComOpen.Text = "Открыть";
            }
            else
            {
                if (COM.openComPort(tracemodeCOM, tracemodeComCB.Text, 9600))
                {
                    traceModeComOpen.Text = "Открыт";
                }
                else
                {
                    MessageBox.Show(this, "Could not open the COM port.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    traceModeComOpen.Text = "Открыть";
                }
            }
        }
        #endregion
        #region Utils
        private bool parseDataForAnswer()
        {
            int dataEnderPosition = incomingBytes.SubListIndex(0, dataEnder);
            if (dataEnderPosition != -1)
            {
                lastDataAnswer.Clear();
                lastData.Clear();
                int count95 = 0;

                for (int j = dataEnderPosition+4; count95 != 5; j--)
                {
                    lastDataAnswer.Add(incomingBytes[j]);
                    if (incomingBytes[j] == 0x95) count95++;
                }
                lastDataAnswer.Reverse();
                lastData = lastDataAnswer.GetRange(31, 10);

                pulsarTB.Invoke(new EventHandler(delegate {
                    pulsarTB.AppendText("Получены данные!:\n" + HexConverter.toString(lastDataAnswer.ToArray()) + "\n" +
                                        "Биты данных: " + HexConverter.toString(lastData.ToArray()) + "\n");
                }));
                return true;
            }
            return false;
        }
        private void SetUpComboBoxes()
        {

            string selectedP = COM.RefreshComPortList(pulsarComCB.Items.Cast<string>(), pulsarComCB.SelectedItem as string, pulsarCOM.IsOpen);
            if (!String.IsNullOrEmpty(selectedP))
            {
                pulsarComCB.Items.Clear();
                pulsarComCB.Items.AddRange(COM.OrderedPortNames());
                pulsarComCB.SelectedItem = selectedP;
            }

            string selectedT = COM.RefreshComPortList(tracemodeComCB.Items.Cast<string>(), tracemodeComCB.SelectedItem as string, tracemodeCOM.IsOpen);
            if (!String.IsNullOrEmpty(selectedT))
            {
                tracemodeComCB.Items.Clear();
                tracemodeComCB.Items.AddRange(COM.OrderedPortNames());
                tracemodeComCB.SelectedItem = selectedT;
            }
        }
        #endregion

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
