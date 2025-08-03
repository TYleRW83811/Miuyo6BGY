// 代码生成时间: 2025-08-03 09:58:02
using System;
using System.IO;
using System.IO.Compression;

namespace MauiCompressorApp
{
    /// <summary>
    /// A utility class for decompressing files in a MAUI application.
    /// </summary>
    public class FileDecompressor
    {
        /// <summary>
        /// Decompresses a zip file to a specified directory.
        /// </summary>
        /// <param name="zipFilePath">The path to the zip file to decompress.</param>
        /// <param name="outputDirectory">The directory where the files will be extracted.</param>
        /// <returns>True if decompression was successful, false otherwise.</returns>
        public bool DecompressZipFile(string zipFilePath, string outputDirectory)
        {
            try
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Decompress the zip file
                ZipFile.ExtractToDirectory(zipFilePath, outputDirectory);

                // Return true if decompression was successful
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during decompression
                Console.WriteLine($"An error occurred during decompression: {ex.Message}");
                return false;
            }
        }
    }
}