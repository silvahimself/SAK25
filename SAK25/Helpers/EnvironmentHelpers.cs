using SAK25.Types;
using System;
using System.IO;

namespace SAK25.Helpers;

public static class EnvironmentHelpers
{
    public static string EnvVar(string name)
        => Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process)
            ?? Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User)
            ?? Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine)
            ?? throw Exceptions.EnvVarMissing(name);

    // [PROJECT_PATH]/bin/debug/
    public static string ExecutingDir() => Environment.CurrentDirectory;


    // [PROJECT_PATH]/bin/
    public static string BinDir() => Directory.GetParent(ExecutingDir()).Parent.FullName;

    // [PROJECT_PATH]
    public static string ProjectDir() => Directory.GetParent(ExecutingDir())?.Parent?.Parent?.Parent?.FullName ?? throw new Exception("Unable to read project directory, something went terribly wrong." +
        "\n\n" +
        $"Executing Dir: {ExecutingDir()}");
}
