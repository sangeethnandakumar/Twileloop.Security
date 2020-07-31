using DevOne.Security.Cryptography.BCrypt;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressEncription
{
    public class BlowFishHashing
    {
        public static string HashString(string text, string salt)
        {
            return BCryptHelper.HashPassword(text, salt);
        }

        public static bool Validate(string text, string hashed)
        {
            return BCryptHelper.CheckPassword(text, hashed);
        }

        public static string GenerateSalt(int workFactor)
        {
            return BCryptHelper.GenerateSalt(workFactor);
        }
    }
}
