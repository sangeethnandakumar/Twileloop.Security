using System;
using System.IO;
using System.Security.Cryptography;

namespace Twileloop.Security.Abstractions.Encryption
{
    public static class AESAlgorithm
    {
        public static string EncryptText(string plainText, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] keyBytes = DeriveKeyFromPassphrase(key, aes.KeySize / 8);
                byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(iv);

                aes.Key = keyBytes;
                aes.IV = ivBytes;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] encryptedBytes;
                using (var ms = new System.IO.MemoryStream())
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                    cs.Write(plaintextBytes, 0, plaintextBytes.Length);
                    cs.FlushFinalBlock();
                    encryptedBytes = ms.ToArray();
                }

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string DecryptText(string encryptedText, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] keyBytes = DeriveKeyFromPassphrase(key, aes.KeySize / 8);
                byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(iv);

                aes.Key = keyBytes;
                aes.IV = ivBytes;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                byte[] decryptedBytes;
                using (var ms = new System.IO.MemoryStream())
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                {
                    cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                    cs.FlushFinalBlock();
                    decryptedBytes = ms.ToArray();
                }

                return System.Text.Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        private static byte[] DeriveKeyFromPassphrase(string passphrase, int keySize)
        {
            byte[] salt = System.Text.Encoding.UTF8.GetBytes("SomeSaltValue"); // Provide a unique salt value

            using (var pbkdf2 = new Rfc2898DeriveBytes(passphrase, salt, 10000))
            {
                return pbkdf2.GetBytes(keySize);
            }
        }

        public static void EncryptFile(string inputFile, string outputFile, string key, string iv)
        {
            byte[] keyBytes = DeriveKeyFromPassphrase(key, 16);
            byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(iv);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (FileStream inputFileStream = File.OpenRead(inputFile))
                {
                    using (FileStream outputFileStream = File.OpenWrite(outputFile))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(outputFileStream, encryptor, CryptoStreamMode.Write))
                        {
                            inputFileStream.CopyTo(cryptoStream);
                        }
                    }
                }
            }
        }

        public static void DecryptFile(string inputFile, string outputFile, string key, string iv)
        {
            byte[] keyBytes = DeriveKeyFromPassphrase(key, 16);
            byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(iv);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (FileStream inputFileStream = File.OpenRead(inputFile))
                {
                    using (FileStream outputFileStream = File.OpenWrite(outputFile))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(inputFileStream, decryptor, CryptoStreamMode.Read))
                        {
                            cryptoStream.CopyTo(outputFileStream);
                        }
                    }
                }
            }
        }
    }
}
