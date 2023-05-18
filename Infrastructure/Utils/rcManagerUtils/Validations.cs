using System;
using System.Text.RegularExpressions;

namespace rcUtils
{
    public static class Validations
    {
        public static bool ValidateChars_Generic(string text)
        {
            try {
                Regex regex = new Regex(@"^[A-Z0-9_?!@#$%&*.=+-]+$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(200));
                return regex.IsMatch(text);
            } catch (RegexMatchTimeoutException) {
                return false;
            }
        }

        public static bool ValidateChars_Login(string text)
        {
            try {
                Regex regex = new Regex(@"^[A-Z0-9_-]+$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(200));
                return regex.IsMatch(text);
            } catch (RegexMatchTimeoutException) {
                return false;
            }
        }

        public static bool ValidateChars_Name(string text)
        {
            try {
                Regex regex = new Regex(@"^[A-Z0-9À-Ü_\s-]+$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(200));
                return regex.IsMatch(text);
            } catch (RegexMatchTimeoutException) {
                return false;
            }
        }

        public static bool ValidateChars_Password(string text)
        {
            try {
                Regex regex = new Regex(@"^[A-Z0-9_?!@#$%&*.=+-]+$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(200));
                return regex.IsMatch(text);
            } catch (RegexMatchTimeoutException) {
                return false;
            }
        }

        public static bool ValidateChars_Email(string text)
        {
            try {
                Regex regex = new Regex(@"^[A-Z0-9_@.-]+$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(200));
                return regex.IsMatch(text);
            } catch (RegexMatchTimeoutException) {
                return false;
            }
        }
    }
}
