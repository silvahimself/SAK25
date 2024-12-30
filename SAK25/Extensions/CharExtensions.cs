namespace SAK25.Extensions
{
    public static class CharExtensions
    {
        public static bool IsSpecialCharacter (this char c) => !SAK25.Letters.Contains(c) && !SAK25.Numbers.Contains(c);
    }
}
