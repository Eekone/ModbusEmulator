using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModbusEmulator
{
    public static class Modbus
    {
        public static byte[] CRC(byte[] buf)
        {
            int crc = 0xFFFF;
            for (int pos = 0; pos < buf.Length; pos++)
            {
                crc ^= (int)buf[pos] & 0xFF;   // XOR byte into least sig. byte of crc

                for (int i = 8; i != 0; i--)
                {    // Loop over each bit
                    if ((crc & 0x0001) != 0)
                    {      // If the LSB is set
                        crc >>= 1;                    // Shift right and XOR 0xA001
                        crc ^= 0xA001;
                    }
                    else                            // Else LSB is not set
                        crc >>= 1;                    // Just shift right
                }
            }
            byte[] reversed = new byte[2];
            reversed[0] = (byte)(crc & 0xff);
            reversed[1] = (byte)((crc >> 8) & 0xff);
            // Note, this number has low and high bytes swapped, so use it accordingly (or swap bytes)
            return reversed;
        }

        public static byte[] func3Response(byte[] data, byte device)
        {
            int len = data.Length * 2 + 5;
            byte[] response = new byte[len];
            response[0] = device;
            response[1] = 3;
            response[2] = (byte) data.Length;
            for (int i = 0; i < data.Length; i++)
            {               
                response[3 + i * 2] = 0;
                response[4 + i * 2] = data[i];

            }
            byte[] CRC = Modbus.CRC(response.Take(len - 2).ToArray());
            response[len - 2] = CRC[0];
            response[len - 1] = CRC[1];

            string ss = HexConverter.toString(response);
            return response;
        }
        public static byte[] func16Response(byte device)
        {
           byte[] response = new byte[8];

            response[0] = device;
            response[1] = 0x10;
            response[2] = 0x0;
            response[3] = 0x1;
            response[4] = 0x0;
            response[5] = 0xA;
            byte[] CRC = Modbus.CRC(response.Take(6).ToArray());
            response[6] = CRC[0];
            response[7] = CRC[1];          

            return response;
        }
    }
}
