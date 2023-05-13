using System;

namespace Twileloop.Security.Encoding
{
    public static class HexEncoder
    {
        public static string Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return BitConverter.ToString(plainTextBytes).Replace("-", string.Empty);
        }

        public static string Decode(string hexText)
        {
            byte[] hexBytes = new byte[hexText.Length / 2];
            for (int i = 0; i < hexBytes.Length; i++)
            {
                hexBytes[i] = Convert.ToByte(hexText.Substring(i * 2, 2), 16);
            }
            return System.Text.Encoding.UTF8.GetString(hexBytes);
        }
    }
}
