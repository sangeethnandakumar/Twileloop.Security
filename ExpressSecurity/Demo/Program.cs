using ExpressEncription;
using System;
using System.IO;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Express Security Modules");
            Console.WriteLine("1. SHA Hashing");
            Console.WriteLine("2. BCript Hashing");
            Console.WriteLine("3. AES File Encription (Symetric Key Encription)");
            Console.WriteLine("4. RSA Text Encription  (Asymetric Key Encription)");
            Console.WriteLine("Select A Catageory");
            Console.WriteLine("");
            var choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    PerformHashing();
                    break;
                case "2":
                    BCriptHashing();
                    break;
                case "3":
                    AESFileEncription();
                    break;
                case "4":
                    RSAKeyEncription();
                    break;
            }

            Console.Read();
        }

        //SHA Hashig
        private static void PerformHashing()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("SHA HASHING ---------------------------------------");
            Console.WriteLine("Enter a password?");
            var password = Console.ReadLine();
            Console.WriteLine("Hashing...");
            var hashText = Hashing.SHA256(password);
            Console.WriteLine("SHA256 value: " + hashText);

            hashText = Hashing.SHA512(password);
            Console.WriteLine("SHA512 value: " + hashText);
        }

        //BCriptHashing Hashig
        private static void BCriptHashing()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("BlowFish HASHING ---------------------------------------");
            Console.WriteLine("Enter a password?");
            var password = Console.ReadLine();
            Console.WriteLine("Enter a work factor? (Ideal around 10+-)");
            var workFactor = Console.ReadLine();
            Console.WriteLine("BCript Hashing...");
            var salt = BlowFishHashing.GenerateSalt(int.Parse(workFactor));
            var hashText = BlowFishHashing.HashString(password, salt);
            Console.WriteLine("BCript hash: " + hashText);
        }

        //AES Encription/Description
        private static void AESFileEncription()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("AES ENCRIPTION ---------------------------------------");
            Console.WriteLine("Enter file lock password?");
            var password = Console.ReadLine();
            Console.WriteLine(@"Enter input file location? (Eg: C:\sample.txt)");
            var input = Console.ReadLine();

            Console.WriteLine($"AES Encripting... (File {input})");
            AESEncription.AES_Encrypt(input, password);
            Console.WriteLine("File Encripted");

            Console.WriteLine($"AES Decripting... (File {input}.aes)");
            AESEncription.AES_Decrypt(input + ".aes", password);
            Console.WriteLine("File Decripted");
        }

        //RSA Encription/Description
        private static void RSAKeyEncription()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RSA ENCRIPTION ---------------------------------------");
            Console.WriteLine(@"Location to store public key?  (Eg: C:\publickey.rsa)");
            var publicKey = Console.ReadLine();
            Console.WriteLine(@"Location to store private key?  (Eg: C:\privatekey.rsa)");
            var privateKey = Console.ReadLine();
            Console.WriteLine("Generating public key and private key...");
            RSAEncription.MakeKey(publicKey, privateKey);

            Console.WriteLine("Enter text to be encripted");
            var input = Console.ReadLine();

            Console.WriteLine($"RSA Encripting... (With public key)");
            var ciphertext = RSAEncription.EncryptString(input, publicKey);
            Console.WriteLine("RSA Encripted - " + ciphertext);

            Console.WriteLine($"RSA Decripting... (With private key)");
            var text = RSAEncription.DecryptString(ciphertext, privateKey);
            Console.WriteLine("RSA Decripted - " + text);
        }


    }
}
