namespace SAK25.Extensions
{
    public static class StringExtensions
    {
        public static bool IsANumber(this char s) => "1234567890".Contains(s);

        public static string ToMixpanelCommentString(this Exception e, bool alerted = false, string[] alertedParties = default)
        {
            var alertString = alerted ? "[ALERTED]: (" + string.Join(',', alertedParties) + ")\n" : "";

            return $"{alertString}" +
                $"Exception: {e.Message}" +
                $"\nStack:{e.StackTrace}" +
                $"\nInner Exception:{e.InnerException?.Message}" +
                $"\nInner Stack: {e.InnerException?.StackTrace}";
        }

        // Input: 20^2=10^2+(2*1.25*s)(1)s=300/2.5(1)=30m(1)
        // Output: 20^{2}=10^{2}+(2*1.25*s)(1) s=\frac{300}{2.5}(1)=30m(1)
        // DS_TODO: Address Latex conversion issues
        // 1. The current replace for ^2 could break for exponents with more than 1 char
        public static string ToLatex(this string s)
        {
            int c = 0;
            string result = s;

            foreach (char ch in s)
            {
                if (ch == '^')
                {
                    int n = 1;
                    string exponent = "{";

                    while (c + n < s.Length - 1 && (s[c + n].IsANumber() || s[c + n] == '.'))
                    {
                        exponent += s[c + n];
                        n++;
                    }

                    exponent += "}";

                    result = result.Replace("^" + exponent.Replace("{", "").Replace("}", ""), "^" + exponent);
                }
                //else if (ch == '/'){
                //    string up = "";
                //    int n = 1;

                //    string original = "";

                //    while (c-n > 0 && s[c-n].IsANumber())
                //    {
                //        up+=s[c-n];
                //        original+= s[c-n];
                //        n++;
                //    }
                //    up += "{";
                //    up = up.Reverse().ToStringProper();
                //    up+= "}";

                //    original = original.Reverse().ToStringProper();
                //    original += "/";

                //    string down = "{";
                //    n = 1;

                //    while (c + n < s.Length - 1 && (s[c + n].IsANumber() || s[c + n] == '.')){
                //        down += s[c+n];

                //        original += s[c + n];
                //        n++;
                //    }

                //    down += "}";

                //    string frac = $"\\frac{up}{down}";
                //    result = result.Replace(original, frac);
                //}

                c++;
            }

            return result;
        }

        public static bool IsEmailAddress(this string s)
        {

            if (!s.Contains("@"))
                return false;

            // Contains only one @
            if (s.Split("@").Length != 2)
                return false;

            string domain = s.Split("@")[1];

            // Contains at least one .
            if (domain.Split(".").Length < 2)
                return false;

            // Domain exists
            // if (!NetworkHelpers.Ping(domain))
            //    return false;

            return true;
        }
    }
}
