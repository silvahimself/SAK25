using SAK25.Helpers;

namespace SAK25_console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var options = new FileSearchOptions
            {
                Extension = "cs",
                IgnoreDirectories = ["node_modules", "Library", "Package", ".git", ".vs", ".vscode", "bin", "obj", "src"]
            };

            var files = FileHelpers.GetAllFilesRecursive("C:/TMP_D/code", options);

            string extensions = "";


            foreach (var file in files)
            {
                if (file.ToLowerInvariant().Contains("extension"))
                {
                    var text = await File.ReadAllTextAsync(file);
                    extensions += $"--------------------\r\n{text}\r\n--------------------\r\n\r\n";
                }
            }

            Console.WriteLine(extensions);
        }
    }
}
