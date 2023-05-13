using Konscious.Security.Cryptography;
using System.Text;
using Twileloop.Security.Abstractions.Hashing.Base;

namespace Twileloop.Security.Abstractions.Hashing
{
    public static class Argon2Algorithm
    {
        public static string Hash(string input, int byteSize = 32, int iterations = 1, int memorySizeKB = 4096, int degreeOfParallelism = 1)
        {
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);

            using (var argon2 = new Argon2id(inputBytes))
            {
                argon2.Iterations = iterations;
                argon2.MemorySize = memorySizeKB; // Set the memory size in kilobytes
                argon2.DegreeOfParallelism = degreeOfParallelism;

                byte[] hashBytes = argon2.GetBytes(byteSize);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
