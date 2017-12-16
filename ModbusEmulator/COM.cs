using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModbusEmulator
{
    public static class COM
    {
        public static bool openComPort(SerialPort port, string name, int baudRate = 9600, int dataBits = 8, StopBits stopbits = StopBits.One, Parity parity = Parity.None, int threshold = 1)
        {
            if (port.IsOpen) port.Close();
            
            port.BaudRate = baudRate;
            port.DataBits = dataBits;
            port.StopBits = stopbits;
            port.Parity = parity;
            port.PortName = name;
            port.ReceivedBytesThreshold = threshold;

            try
            {
                port.Open();
            }
            catch (UnauthorizedAccessException) { return false; }
            catch (IOException) { return false; }
            catch (ArgumentException) { return false; }

            return true;   
        }

        public static string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {

            string selected = null;
            string[] ports = SerialPort.GetPortNames();

            // First determain if there was a change (any additions or removals)
            bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

            // If there was a change, then select an appropriate default port
            if (updated)
            {
                // Use the correctly ordered set of port names
                ports = OrderedPortNames();

                // Find newest port if one or more were added
                string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                // If the port was already open... (see logic notes and reasoning in Notes.txt)
                if (PortOpen)
                {
                    if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else selected = ports.LastOrDefault();
                }
                else
                {
                    if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else selected = ports.LastOrDefault();
                }
            }

            // If there was a change to the port list, return the recommended default selection
            return selected;
        }

        public static string[] OrderedPortNames()
        {
            int num;
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }
    }
}
