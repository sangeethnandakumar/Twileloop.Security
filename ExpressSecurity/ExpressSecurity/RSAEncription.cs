using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ExpressEncription
{
    public static class RSAEncription
    {
        readonly static int rsaKeyPair = 2048;
        public static void MakeKey(string publicKeyPath, string privateKeyPath)
        {
            //lets take a new CSP with a new 2048 bit rsa key pair
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(rsaKeyPair);

            //how to get the private key
            RSAParameters privKey = csp.ExportParameters(true);

            //and the public key ...
            RSAParameters pubKey = csp.ExportParameters(false);
            //converting the public key into a string representation
            string pubKeyString;
            {
                //we need some buffer
                var sw = new StringWriter();
                //we need a serializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //serialize the key into the stream
                xs.Serialize(sw, pubKey);
                //get the string from the stream
                pubKeyString = sw.ToString();
                File.WriteAllText(publicKeyPath, pubKeyString);
            }
            string privKeyString;
            {
                //we need some buffer
                var sw = new StringWriter();
                //we need a serializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //serialize the key into the stream
                xs.Serialize(sw, privKey);
                //get the string from the stream
                privKeyString = sw.ToString();
                File.WriteAllText(privateKeyPath, privKeyString);
            }
        }
        public static string EncryptString(string plaintext, string publicKeyPath)
        {
            try
            {
                string pubKeyString;
                {
                    using (StreamReader reader = new StreamReader(publicKeyPath)) { pubKeyString = reader.ReadToEnd(); }
                }
                var sr = new StringReader(pubKeyString);
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
                csp.ImportParameters((RSAParameters)xs.Deserialize(sr));
                byte[] bytesPlainTextData = Encoding.UTF8.GetBytes(plaintext);
                var bytesCipherText = csp.Encrypt(bytesPlainTextData, false);
                string encryptedText = Convert.ToBase64String(bytesCipherText);
                return encryptedText;
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }
        public static string DecryptString(string ciphertext, string privateKeyPath)
        {
            try
            {
                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
                string privKeyString;
                {
                    privKeyString = File.ReadAllText(privateKeyPath);
                    var sr = new StringReader(privKeyString);
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    RSAParameters privKey = (RSAParameters)xs.Deserialize(sr);
                    csp.ImportParameters(privKey);
                }
                byte[] bytesCipherText = Convert.FromBase64String(ciphertext);
                byte[] bytesPlainTextData = csp.Decrypt(bytesCipherText, false);
                return Encoding.UTF8.GetString(bytesPlainTextData);
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }
    }
}
