using SAK25.Types;

namespace SAK25.Helpers;

public static class EnvironmentHelpers
{
    public static string EnvVar(string name)
        => Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process)
            ?? Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User)
            ?? Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine)
            ?? throw Exceptions.EnvVarMissing(name);
}
