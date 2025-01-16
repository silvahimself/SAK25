namespace SAK25.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if a string is a number
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsANumber(this char s) => "1234567890".Contains(s);

        /// <summary>
        /// Checks if a string is a valid email address
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Minifies a string, removing all spaces, tabs, new lines and carriage returns.
        /// </summary>
        /// <param name="s">The string to be minified. Original value is not changed.</param>
        /// <returns></returns>
        public static string Minified(this string s)
            => s.Replace("\n", "").Replace("\t", "").Replace(" ", "").Replace("\r", "");

        /// <summary>
        /// Fills a string with a character until it reaches a desired size, trimming the string if it exceeds the size.
        /// The original string is changed.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="size"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string Fill(this string s, int size, string chars)
        {
            while (s.Length < size)
            {
                s += chars;
            }

            return s[..size];
        }

        /// <summary>
        /// Creates a MemoryStream from a string.
        /// </summary>
        /// <param name="s">The source for the stream.</param>
        /// <returns></returns>
        public static Stream AsStream(this string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Fiills a string with random characters, for a desired size.
        /// Default size is defined in <seealso cref="SAKConfig"/>, default being 32.
        /// 
        /// Usage: "Hello".FillRandom(10) -> "Hello" + 5 random characters.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="stringParams"></param>
        /// <returns></returns>
        public static string FillRandom(this string s, RandomStringParams? stringParams = null)
        {
            string result = s;
            string charset = SAK25.Letters;

            if (stringParams != null)
            {
                charset += stringParams.IncludeNumbers ? SAK25.Numbers : "";
                charset += stringParams.IncludeSpecialChars ? SAK25.SpecialChars : "";
            }

            for (int i = 0; i < (stringParams != null ? stringParams.Size : SAK25.Config.DefaultStringSize) - result.Length; i++)
                result += charset[SAK25.Random.Next(charset.Length)];
            

            return result;
        }
    }
}
