using System.Text.RegularExpressions;

namespace NHibernateLab.UI {
    public static class ValidateHelper {
        //public (bool, string) IsAllowValueString(string value, int minLen, int maxLen) {
        //    if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
        //        return (false, Mes)
        //    }
        //}

        public static bool IsValidName(string name) {
            string pattern = @"^[a-zA-Z'-]+$";
            return Regex.IsMatch(name, pattern);
        }

        public static bool IsValidPhoneNumber(string phoneNumber) {
            string pattern = @"^[0-9\-\(\) ]+$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool IsValidEmail(string email) {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
