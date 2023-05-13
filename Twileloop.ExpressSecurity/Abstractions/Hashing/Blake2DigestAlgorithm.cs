using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using System.Text;
using Twileloop.Security.Abstractions.Hashing.Base;

namespace Twileloop.Security.Abstractions.Hashing
{
    public static class Blake2DigestAlgorithm
    {
        public static string Hash(string input)
        {
            IDigest digest = new Blake2bDigest(); // Blake2b

            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = new byte[digest.GetDigestSize()];

            digest.BlockUpdate(inputBytes, 0, inputBytes.Length);
            digest.DoFinal(hashBytes, 0);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
