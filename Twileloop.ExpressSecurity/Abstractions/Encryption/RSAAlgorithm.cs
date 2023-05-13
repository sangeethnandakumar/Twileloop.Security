using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Twileloop.Security.Abstractions.Encryption
{
    public class RSAAlgorithm
    {
        public static string EncryptText(string plaintext, RSAParameters publicKey)
        {
            byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);

            using (System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create())
            {
                rsa.ImportParameters(publicKey);
                byte[] encryptedBytes = rsa.Encrypt(plaintextBytes, RSAEncryptionPadding.OaepSHA256);

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string DecryptText(string encryptedText, RSAParameters privateKey)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create())
            {
                rsa.ImportParameters(privateKey);
                byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.OaepSHA256);

                return System.Text.Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        public static void EncryptFile(string inputFile, string outputFile, RSAParameters publicKey)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportParameters(publicKey);

                int keySizeInBytes = rsa.KeySize / 8;
                int bufferSize = keySizeInBytes - 42; // Limit to the key size

                if (bufferSize <= 0)
                {
                    throw new ArgumentException("RSA key size is too small for encryption.");
                }

                byte[] buffer = new byte[bufferSize];
                int bytesRead;

                using (FileStream inputFileStream = File.OpenRead(inputFile))
                using (FileStream outputFileStream = File.OpenWrite(outputFile))
                {
                    while ((bytesRead = inputFileStream.Read(buffer, 0, bufferSize)) > 0)
                    {
                        byte[] dataToEncrypt = bytesRead == bufferSize ? buffer : buffer.Take(bytesRead).ToArray();
                        byte[] encryptedBytes = rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.OaepSHA256);
                        outputFileStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }
                }
            }
        }

        public static void DecryptFile(string inputFile, string outputFile, RSAParameters privateKey)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportParameters(privateKey);

                using (FileStream inputFileStream = File.OpenRead(inputFile))
                {
                    using (FileStream outputFileStream = File.OpenWrite(outputFile))
                    {
                        int bufferSize = rsa.KeySize / 8; // Limit to the key size
                        byte[] buffer = new byte[bufferSize];
                        int bytesRead;

                        while ((bytesRead = inputFileStream.Read(buffer, 0, bufferSize)) > 0)
                        {
                            byte[] decryptedBytes = rsa.Decrypt(buffer, RSAEncryptionPadding.OaepSHA256);
                            outputFileStream.Write(decryptedBytes, 0, decryptedBytes.Length);
                        }
                    }
                }
            }
        }


        public static void MakeRSAKeyPairs(out RSAParameters publicKey, out RSAParameters privateKey)
        {
            using (System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create())
            {
                publicKey = rsa.ExportParameters(false); // Export public key parameters
                privateKey = rsa.ExportParameters(true); // Export private key parameters
            }
        }

        public static string ExportRSAParametersToJson(RSAParameters rsaParameters)
        {
            string json = JsonSerializer.Serialize(rsaParameters);
            return json;
        }

        public static RSAParameters ImportRSAParametersFromJson(string json)
        {
            RSAParameters rsaParameters = JsonSerializer.Deserialize<RSAParameters>(json);
            return rsaParameters;
        }
    }
}
