// 代码生成时间: 2025-09-19 13:59:08
 * It demonstrates error handling and follows C# best practices for maintainability and scalability.
 */
using System;
using System.IO;
using System.IO.Compression;

namespace CompressionTool
{
    public class FileCompressionTool
    {
        // Decompress a zip file from source to target directory
        public static void DecompressZipFile(string sourceFilePath, string targetDirectory)
        {
            // Check if the source file exists
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException("Source file not found.", sourceFilePath);
            }

            // Check if the target directory exists, if not create it
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            try
            {
                // Decompress the zip file
                ZipFile.ExtractToDirectory(sourceFilePath, targetDirectory);
                Console.WriteLine("Decompression successful.");
            }
            catch (InvalidDataException ex)
            {
                // Handle the case where the file is corrupted or not a valid zip file
                Console.WriteLine("Decompression failed: The file is not a valid zip file or is corrupted.");
                throw;
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that may occur
                Console.WriteLine($"Decompression failed: {ex.Message}");
                throw;
            }
        }

        // Main method to demonstrate the usage of the decompress functionality
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("Usage: FileCompressionTool <source zip file> <target directory>");
                    return;
                }

                string sourceFilePath = args[0];
                string targetDirectory = args[1];

                // Decompress the zip file using the provided arguments
                DecompressZipFile(sourceFilePath, targetDirectory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}