using System;

namespace Twileloop.Security.Abstractions.Encoding
{
    public static class Base64Encoder
    {
        public static string Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Decode(string encodedText)
        {
            byte[] encodedBytes = Convert.FromBase64String(encodedText);
            return System.Text.Encoding.UTF8.GetString(encodedBytes);
        }
    }

}
