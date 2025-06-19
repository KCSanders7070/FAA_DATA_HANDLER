using System;
using System.IO;

namespace FAA_DATA_HANDLER.Helpers
{
    public static class DirectoryHandler
    {
        public static string CreateOutputDirectory(string basePath, string directoryName, bool forceDelete = false)
        {
            string fullPath = Path.Combine(basePath, directoryName);

            if (Directory.Exists(fullPath))
            {
                if (forceDelete)
                {
                    Directory.Delete(fullPath, true);
                    Console.WriteLine($"Directory '{fullPath}' deleted (forceDelete enabled).");
                }
                else
                {
                    Console.WriteLine($"Directory '{fullPath}' already exists.");
                    Console.Write("Delete and recreate it? (y/n): ");
                    string? input = Console.ReadLine();

                    if (!string.Equals(input, "y", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new Exception("Operation cancelled by user.");
                    }

                    Directory.Delete(fullPath, true);
                    Console.WriteLine($"Directory '{fullPath}' deleted.");
                }
            }

            Directory.CreateDirectory(fullPath);
            Console.WriteLine($"Directory '{fullPath}' created.");

            return fullPath;
        }
    }
}
