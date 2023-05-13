using System;
using System.Text;

namespace Twileloop.Security.Abstractions.Encoding
{
    public static class BinaryEncoder
    {
        public static string Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            StringBuilder binaryStringBuilder = new StringBuilder();
            foreach (byte b in plainTextBytes)
            {
                binaryStringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            return binaryStringBuilder.ToString();
        }

        public static string Decode(string binaryText)
        {
            byte[] binaryBytes = new byte[binaryText.Length / 8];
            for (int i = 0; i < binaryBytes.Length; i++)
            {
                binaryBytes[i] = Convert.ToByte(binaryText.Substring(i * 8, 8), 2);
            }
            return System.Text.Encoding.UTF8.GetString(binaryBytes);
        }
    }

}
