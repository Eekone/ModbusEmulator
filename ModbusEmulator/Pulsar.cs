using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensionMethods;

namespace ModbusEmulator
{
    public static class Pulsar
    {
        private static byte[] U = { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
        private static byte[] pulsarCommand = { 0x55, 0x55, 0x55, 0x55, 0x55, 0x55, 0x55, 0x55, 0x55, 0x55, 0x55,
                                         0x7E, 0x01, 0x3F, 0x41, 0x27, 0x00, 0xDA, 0x27, 0x07, 0x30, 0x12,
                                         0x21, 0x48, 0xEF, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                         0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00,
                                         0x00, 0x00, 0x00, 0x00, 0x20, 0x9C,
                                         0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        private static byte[] mask={ 0xEF, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        public static byte[] OneTimeProgrammCommBufferFormer(byte KpCount)
        {
            byte[] CommBuffer = new byte[60];
            //byte KpNumber;
            byte[] Mask=new byte[16];
            byte[] UTR = new byte [12];
            byte Count;        
            byte[] CRC=new byte[2];
            byte[] kek;

            DateTime localDate = DateTime.Now;
            
            /*KpNumber = KpRequestFrame[33 * KpCount];
            for (Count = 0; Count < 16; Count++) Mask[Count] = KpRequestFrame[2 + 33 * KpCount + Count];
            for (Count = 0; Count < 12; Count++) UTR[Count] = KpRequestFrame[18 + 33 * KpCount + Count];*/

            for (Count = 0; Count < 11; Count++)
                CommBuffer[Count] = 0x55;

            CommBuffer[11] = 0x7E;
            CommBuffer[12] = 1;//LPU.Number;
            CommBuffer[13] = KpCount;
            CommBuffer[14] = 0x41; // Разовый пуск                    
            CommBuffer[15] = 39;   // длина сообщения               
            CommBuffer[16] = 0;    // длина сообщения               
            CommBuffer[17] = DKS(CommBuffer, 11, 16);

            CommBuffer[18] = HexToDecihex(localDate.Year - 1990);
            CommBuffer[19] = HexToDecihex(localDate.Month);
            CommBuffer[20] = HexToDecihex(localDate.Day);
            CommBuffer[21] = HexToDecihex(localDate.Hour);
            CommBuffer[22] = HexToDecihex(localDate.Minute);
            CommBuffer[23] = HexToDecihex(localDate.Second);

            for (Count = 0; Count < 16; Count++)
                CommBuffer[24 + Count] = mask[Count];

            for (Count = 0; Count < 8; Count++)
                CommBuffer[40 + Count] = U[Count];                 
           

            kek = BuildCRC(CommBuffer,11,47);
            CommBuffer[48] = kek[0];
            CommBuffer[49] = kek[1];

            for (Count = 50; Count < 60; Count++)
                CommBuffer[Count] = 0xFF;

            return CommBuffer;
        }

        private static byte HexToDecihex(int Hex)
        {
            byte Decihex;
            byte Dec = 0;
            if (Hex > 59) return 0xFF;          // be carefull here!
            while (Hex > 9) { Hex = Hex - 10; Dec++; }
            Decihex = (byte)(16 * Dec + Hex);
            return Decihex;
        }

        private static byte DecihexToHex(byte Decihex)
        {
            byte Hex;
            byte Dec = 0;
            if (Decihex > 0x59) return 0xFF;    // be carefull here!
            while (Decihex > 15) { Decihex = (byte) (Decihex - 16); Dec++; }
            if (Decihex > 9) return 0xFF;       // be carefull here!
            Hex = (byte)(10 * Dec + Decihex);
            return Hex;
        }

        private static byte DKS(byte[] buf, int begin, int end)
        {
            int i;
            byte dks = 0;
            for (i = begin; i <= end; i++) dks = (byte)(dks + buf[i]);
            return (byte)(256-dks);
        }



        public static byte[] NewProgrammCommBufferFormer(byte KpCount, byte[] data)
        {
            byte[] CommBuffer=new byte[62];            
            byte[] Mask = new byte[16];
            byte[] UTR = new byte[8];
            byte Count;
           
            DateTime CurrentTime = DateTime.Now;

            for (Count = 0; Count < 16; Count++)
                Mask[Count] = mask[Count];//KpRequestFrame[2 + 33 * KpCount + Count];
            
            Mask[15] &= 0x7F; //Turn off 127-th channel (this is exception)
            
            for (Count = 0; Count < 11; Count++)            
                CommBuffer[Count] = 0x55;            

            CommBuffer[11] = 0x7E;
            CommBuffer[12] = 01;
            CommBuffer[13] = KpCount;
            CommBuffer[14] = 0x32; // Выдача новой программы
            CommBuffer[15] = 41; // длина сообщения
            CommBuffer[16] = 0; // длина сообщения
            CommBuffer[17] = DKS(CommBuffer, 11, 16);

            CommBuffer[18] = HexToDecihex(CurrentTime.Year - 1990);
            CommBuffer[19] = HexToDecihex(CurrentTime.Month);
            CommBuffer[20] = HexToDecihex(CurrentTime.Day);
            CommBuffer[21] = HexToDecihex(CurrentTime.Hour);
            CommBuffer[22] = HexToDecihex(CurrentTime.Minute);
            CommBuffer[23] = HexToDecihex(CurrentTime.Second);

            for (Count = 0; Count < 16; Count++)            
                CommBuffer[24 + Count] = Mask[Count];            

            for (Count = 0; Count < 8; Count++)            
                CommBuffer[40 + Count] = data[Count*2+1]; //utr
            

            CommBuffer[48] = HexToDecihex(data[17]);
            CommBuffer[49] = HexToDecihex(data[19]);

            byte[] CRC = BuildCRC(CommBuffer, 11, 49);            
            CommBuffer[50] = CRC[0];
            CommBuffer[51] = CRC[1];

            for (Count = 52; Count < 62; Count++)            
                CommBuffer[Count] = 0xFF;           

            return CommBuffer;
        }
        public static byte[] BuildCRC(byte[] buf, int begin, int end)
        {
            int crc = 0;
            int flag;
            int shift;
            int c = begin;
            while (c <= end)
            {
                shift = 8;
                crc = crc ^ (buf[c] << 8);
                while (shift != 0)
                {
                    if ((crc & 0x8000) != 0)
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                    }
                    crc = crc << 1;
                    if (flag != 0)
                    {
                        crc = crc ^ 0x1021;
                    }
                    shift--;
                }
                c++;
            }
            byte[] b = BitConverter.GetBytes(crc);
            byte[] ret = { b[1], b[0] };
            return ret;
        }
    }
}
