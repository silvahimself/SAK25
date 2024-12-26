namespace SAK25.Types
{
    public static class Exceptions
    {
        public static Exception DirOrFileUnknown(string item)
            => new Exception($"Could not parse item type (directory or file?): {item}");

        public static Exception EnvVarMissing(string name)
            => new Exception($"Environemnt variable missing: {name}");
    }
}