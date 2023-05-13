using System.Security.Cryptography;
using Twileloop.Security.Encoding;
using Twileloop.Security.Encryption;
using Twileloop.Security.Hashing;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //A. Encodings
            //-------------------------------
            //1. ASCII
            var data1 = ASCIIEncoder.Encode("English");
            var data2 = ASCIIEncoder.Decode(data1);

            //2. UTF-8
            var data3 = UTF8Encoder.Encode("മലയാളം");
            var data4 = UTF8Encoder.Decode(data3);

            //3. Base64
            var data5 = Base64Encoder.Encode("मैं तुमसे प्यार करता हूँ");
            var data6 = Base64Encoder.Decode(data5);

            //4. Hex
            var data7 = HexEncoder.Encode("أنا ذاهب");
            var data8 = HexEncoder.Decode(data7);

            //5. Binary
            var data9 = BinaryEncoder.Encode("நான் உன்னை அன்புக்குரியேன்");
            var data10 = BinaryEncoder.Decode(data9);




            //A. Encryptions
            //-------------------------------
            //1 - AES (Advanced Encryption Standard)
            var aesEncryptedData = AESAlgorithm.EncryptText("Twileloop", key: "1234", iv: "1234567890123456");
            var aesDecryptedData = AESAlgorithm.DecryptText(aesEncryptedData, key: "1234", iv: "1234567890123456");
            AESAlgorithm.EncryptFile(@"D:\data.txt", @"D:\data_aes_encrypted.aes", key: "1234", iv: "1234567890123456");
            AESAlgorithm.DecryptFile(@"D:\data_aes_encrypted.aes", @"D:\data_aes_decrypted.txt", key: "1234", iv: "1234567890123456");

            //2 - RSA
            RSAAlgorithm.MakeRSAKeyPairs(out RSAParameters publicKey, out RSAParameters privateKey);
            var rsaEncryptedData = RSAAlgorithm.EncryptText("Twileloop", publicKey);
            var rsaDecryptedData = RSAAlgorithm.DecryptText(rsaEncryptedData, privateKey);
            RSAAlgorithm.EncryptFile(@"D:\data.txt", @"D:\data_rsa_encrypted.rsa", publicKey);
            RSAAlgorithm.DecryptFile(@"D:\data_rsa_encrypted.rsa", @"D:\data_rsa_decrypted.txt", privateKey);


            //A. Hashing
            //-------------------------------
            //1 - MD5
            var hash1 = MD5Algorithm.Hash("Sangeeth Nandakumar");
            //2 - SHA1
            var hash2 = SHAAlgorithm.HashUsingSHA1("Sangeeth Nandakumar");
            //3 - SHA256 
            var hash3 = SHAAlgorithm.HashUsingSHA256("Sangeeth Nandakumar");
            //4 - SHA3 
            var hash4 = SHAAlgorithm.HashUsingSHA3("Sangeeth Nandakumar");
            //5 - Blake2 
            var hash5 = Blake2DigestAlgorithm.Hash("Sangeeth Nandakumar");
            //6 - BCrypt 
            var hash7 = BCryptAlgorithm.Hash("Sangeeth Nandakumar", workFactor: 11);
            //7 - Argon2
            var hash8 = Argon2Algorithm.Hash("Sangeeth Nandakumar", byteSize: 32, iterations: 1, memorySizeKB: 4096, degreeOfParallelism: 1);
        }
    }
}
