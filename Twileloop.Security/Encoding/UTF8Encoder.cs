namespace Twileloop.Security.Encoding
{
    public static class UTF8Encoder
    {
        public static string Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Text.Encoding.UTF8.GetString(plainTextBytes);
        }

        public static string Decode(string encodedText)
        {
            byte[] encodedBytes = System.Text.Encoding.UTF8.GetBytes(encodedText);
            return System.Text.Encoding.UTF8.GetString(encodedBytes);
        }
    }
}
