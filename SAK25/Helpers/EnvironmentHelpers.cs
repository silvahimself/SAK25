using SAK25.Types;
using System;
using System.IO;

namespace SAK25.Helpers;

public static class EnvironmentHelpers
{
    /// <summary>
    /// Retrieves an environment variable.
    /// Starts by looking for the variable in the current process, then in the user variables and finally in the machine variables.
    /// Throws an exception if the variable is not found.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string EnvVar(string name)
        => Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process)
            ?? Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User)
            ?? Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine)
            ?? throw Exceptions.EnvVarMissing(name);


    /// <summary>
    /// Retrieves the directory where the application is executing.
    /// i.e [PROJECT_PATH]/bin/debug/
    /// </summary>
    /// <returns></returns>
    public static string ExecutingDir() => Environment.CurrentDirectory;

    /// <summary>
    /// Retrieves the bin directory.
    /// i.e [PROJECT_PATH]/bin/
    /// </summary>
    /// <returns></returns>
    public static string BinDir() => Directory.GetParent(ExecutingDir()).Parent.FullName;

    /// <summary>
    /// Retrieves the directory where the project path.
    /// </summary>
    /// <returns></returns>
    public static string ProjectDir() => Directory.GetParent(ExecutingDir())
        // This line deserves to be in some hall of shame somewhere
        ?.Parent?.Parent?.Parent?.FullName 
        ?? throw new Exception("Unable to read project directory, something went terribly wrong." +
        "\n\n" +
        $"Executing Dir: {ExecutingDir()}");
}
