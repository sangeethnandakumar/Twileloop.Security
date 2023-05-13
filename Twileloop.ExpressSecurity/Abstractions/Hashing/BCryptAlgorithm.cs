using Twileloop.Security.Abstractions.Hashing.Base;

namespace Twileloop.Security.Abstractions.Hashing
{
    public static class BCryptAlgorithm
    {
        public static string Hash(string input, int workFactor = 11)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(input, workFactor);
            return hashedPassword;
        }
    }
}
