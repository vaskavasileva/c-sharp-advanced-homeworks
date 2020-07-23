using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTracker.Services.Helpers
{
    public static class ValidationHelpers
    {
        public static string UsernameValidation(string username)
        {
            if (username.Length < 5)
            {
                return null;
            }
            return username;
        }

        public static string PasswordValidation(string password)
        {
            
            int capitalLetters = 0;
            int numbers = 0;
            if (password.Length < 6)
            {
                return null;
            }
            foreach (var character in password.ToCharArray())
            {
                if (Char.IsUpper(character))
                {
                    capitalLetters++;
                }
                if (Char.IsDigit(character))
                {

                }
            }
            if(capitalLetters == 0)
            {
                return null;
            }
            if (numbers == 0)
            {
                return null;
            }
            return password;
        }

        public static string NameValidation(string name)
        {
            foreach (var character in name.ToCharArray())
            {
                if (Char.IsDigit(character))
                {
                    return null;
                }
            }
            if (name.Length < 2)
            {
                return null;
            }
            return name;
        }

        public static int AgeValidation(int age)
        {
            if (age < 18 || age > 120)
            {
                return -1;
            }
            return age;
        }

        public static int NumberValidation(string number, int range)
        {
            bool isNumber = int.TryParse(number, out int num);
            if (!isNumber) return -1;
            if (num <= 0 || num > range) return -1;
            return num;
        }
    }
}
