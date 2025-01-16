namespace SAK25.Extensions
{
    /// <summary>
    /// Extension methods for characters.
    /// </summary>
    public static class CharExtensions
    {
        /// <summary>
        /// Checks if a character is a special character.
        /// Any character that is not a letter or a number is considered a special character.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsSpecialCharacter (this char c) => !SAK25.Letters.Contains(c) && !SAK25.Numbers.Contains(c);
    }
}
