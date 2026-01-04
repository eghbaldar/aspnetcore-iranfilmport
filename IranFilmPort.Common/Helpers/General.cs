using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IranFilmPort.Common.Helpers
{
    public class General
    {
        /// <summary>
        /// true => correct
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            string emailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            Regex regex = new Regex(emailRegex);
            return regex.IsMatch(email);
        }
        /// <summary>
        /// true => correct
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool IsValidIranianCellPhone(string phoneNumber)
        {
            string iranianCellPhoneRegex = @"^((\+98)|0)?9\d{9}$";
            Regex regex = new Regex(iranianCellPhoneRegex);
            return regex.IsMatch(phoneNumber);
        }
        public static string Generate6DigitString()
        {
            Random random = new Random();
            return random.Next(100000, 1000000).ToString();
        }
        public static string GenerateStrenghtPassword()
        {
            string passMadeUp = "";
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                         "a%b!cd_e+fg(hi/%jklm*n[%op]qrs/tu|vwxyz%01%23$456@@78%9@@#$";
            Random rnd = new Random();

            for (int i = 1; i <= 25; i++)
            {
                int char_index = rnd.Next(0, str.Length);
                passMadeUp += str[char_index];
            }
            return passMadeUp;
        }
        public static bool CheckStrengthPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUppercase = true;
                else if (char.IsLower(c))
                    hasLowercase = true;
                else if (char.IsDigit(c))
                    hasDigit = true;
                else if (!char.IsLetterOrDigit(c))
                    hasSpecialChar = true;
            }

            return password.Length > 6 && hasUppercase && hasLowercase && hasDigit && hasSpecialChar;
        }
    }
}
