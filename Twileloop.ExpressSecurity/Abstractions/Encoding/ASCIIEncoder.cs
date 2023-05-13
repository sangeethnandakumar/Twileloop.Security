using Twileloop.Security.Abstractions.Encoding.Base;

namespace Twileloop.Security.Abstractions.Encoding
{
    public static class ASCIIEncoder 
    {
        public static string Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.ASCII.GetBytes(plainText);
            return System.Text.Encoding.ASCII.GetString(plainTextBytes);
        }

        public static string Decode(string encodedText)
        {
            byte[] encodedBytes = System.Text.Encoding.ASCII.GetBytes(encodedText);
            return System.Text.Encoding.ASCII.GetString(encodedBytes);
        }
    }
}
