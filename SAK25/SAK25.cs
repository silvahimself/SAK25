namespace SAK25
{
    public static class SAK25
    {
        public static readonly string Letters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        public static readonly string Numbers = "1234567890";
        public static readonly string SpecialChars = "!@#$%^&*()_+=-][{};:/.>,<";

        public static SAKConfig Config { get; set; }

        public static Random Random { get; set; }

        public static void Init(int? seed = null)
        {
            Config = new SAKConfig
            {
                Seed = seed,
                DefaultStringSize = 32,
            };

            Random = Config.Seed.HasValue ? new Random(Config.Seed.Value) : System.Random.Shared;
        }
    }

    public class SAKConfig
    {
        public int? Seed { get; set; } = null;
        
        public int DefaultStringSize { get; set; }

        public SAKConfig(int? rndSeed = null)
        {
            Seed = rndSeed;
        }
    }
}
