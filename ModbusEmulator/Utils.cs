using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModbusEmulator
{
    public static class Utils
    {
        public static int SearchBytes(byte[] haystack, byte[] needle, int length)
        {
            var len = needle.Length;
            var limit = length - len;
            for (var i = 0; i <= limit; i++)
            {
                var k = 0;
                for (; k < len; k++)
                {
                    if (needle[k] != haystack[i + k]) break;
                }
                if (k == len) return i;
            }
            return -1;
        }
    }
}
