using System;
using System.Collections.Generic;
using System.Text;

namespace CLientServerUtil
{
    class MyUtil
    {
        public static string cleanMessage(byte[] bytes)
        {
            string message = System.Text.Encoding.Unicode.GetString(bytes);

            string messageToPrint = null;
            foreach (var nullChar in message)
            {
                if (nullChar != '\0')
                {
                    messageToPrint += nullChar;
                }
            }
            return messageToPrint;
        }

    }
}
