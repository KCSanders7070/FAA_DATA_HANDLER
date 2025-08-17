using System;
using System.IO;

namespace FAA_DATA_HANDLER.Helpers
{
    public static class DirectoryHandler
    {
        /// <summary>
        /// Creates an output directory at the specified path.  
        /// If the directory already exists, it will either 
        /// Delete and recreate it automatically when <paramref name="forceDelete"/> is true  
        /// or Prompt the user for confirmation when <paramref name="forceDelete"/> is false.  
        /// </summary>
        /// <param name="basePath">The base path where the directory will be created.</param>
        /// <param name="directoryName">The name of the directory to create.</param>
        /// <param name="forceDelete">
        ///     If true, the existing directory is deleted without prompting.  
        ///     If false, the user is prompted before deletion.
        /// </param>
        /// <returns>The full path of the created directory.</returns>
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
