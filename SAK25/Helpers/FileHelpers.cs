using SAK25.Types;

namespace SAK25.Helpers
{

    public static class FileHelpers
    {
        public static List<string> GetAllFilesRecursive(string path, FileSearchOptions? options = null)
        {
            var filesAndDirs = Directory.GetFileSystemEntries(path);

            List<string> result = new();

            foreach (var entry in filesAndDirs)
            {
                string item = entry.Replace('\\', '/');

                if (options?.IgnoreDirectories != null && options.IgnoreDirectories.Contains(item.Split('/').Last()))
                    continue;

                var type = Directory.Exists(item) ? 0 : File.Exists(item) ? 1 : -1;

                if (type == -1)
                {
                    throw Exceptions.DirOrFileUnknown(item);
                }

                else if (type == 1)
                {
                    if (options.Extension != null && !item.EndsWith($".{options.Extension}"))
                        continue;

                    result.Add(item);
                }

                else
                {
                    result.AddRange(GetAllFilesRecursive(item, options));
                }
            }

            return result;
        }
    }
}
