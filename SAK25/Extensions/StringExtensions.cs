namespace SAK25.Extensions
{
    public static class StringExtensions
    {

        public static bool IsANumber(this char s) => "1234567890".Contains(s);

        public static bool IsEmailAddress(this string s)
        {

            if (!s.Contains("@"))
                return false;

            if (s.Split("@").Length != 2)
                return false;

            string domain = s.Split("@")[1];

            if (domain.Split(".").Length < 2)
                return false;

            if (domain.Last().IsSpecialCharacter())
                return false;

            return true;
        }

        public static string Fill(this string s, int size, string chars)
        {
            while (s.Length < size)
            {
                s += chars;
            }

            return s[..size];
        }

        public static string FillRandom(this string s, RandomStringParams? stringParams = null)
        {
            string result = "";
            string charset = SAK25.Letters;

            if (stringParams != null)
            {
                charset += stringParams.IncludeNumbers ? SAK25.Numbers : "";
                charset += stringParams.IncludeSpecialChars ? SAK25.SpecialChars : "";
            }

            for (int i = 0; i < (stringParams != null ? stringParams.Size : SAK25.Config.DefaultStringSize); i++)
                result += charset[SAK25.Random.Next(charset.Length)];
            

            return result;
        }
    }
}
