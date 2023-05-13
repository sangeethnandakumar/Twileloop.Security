using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using System.Security.Cryptography;
using System.Text;

namespace Twileloop.Security.Hashing
{
    public static class SHAAlgorithm
    {
        public static string HashUsingSHA1(string input)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha1.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public static string HashUsingSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public static string HashUsingSHA3(string input)
        {
            IDigest digest = new Sha3Digest(256);

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
