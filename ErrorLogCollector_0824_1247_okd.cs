// 代码生成时间: 2025-08-24 12:47:46
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace ErrorLoggingApp
{
    public class ErrorLogCollector
    {
        private const string LogFileName = "error_log.txt";
        private const string LogFolderPath = "logs";

        // Method to get the full path for the log file
        private string GetLogFilePath()
        {
            var documentsPath = FileSystem.AppDataDirectory;
            var logPath = Path.Combine(documentsPath, LogFolderPath);
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            var filePath = Path.Combine(logPath, LogFileName);
            return filePath;
        }

        // Method to write an error log to a file
        public async Task WriteErrorLogAsync(Exception ex)
        {
            try
            {
                var filePath = GetLogFilePath();
                // Ensure the file is not locked by another process
                await File.WriteAllTextAsync(filePath, FormatExceptionForLog(ex));
            }
            catch (Exception writeEx)
            {
                // Handle exceptions that occur when attempting to write to the log file
                Console.WriteLine($"Error writing to log file: {writeEx.Message}");
            }
        }

        // Method to format an exception for logging
        private string FormatExceptionForLog(Exception ex)
        {
            return $"[{DateTime.UtcNow}] Error: {ex.Message}
StackTrace: {ex.StackTrace}
";
        }

        // Method to retrieve the last error log
        public async Task<string> GetLastErrorLogAsync()
        {
            try
            {
                var filePath = GetLogFilePath();
                return await File.ReadAllTextAsync(filePath);
            }
            catch (Exception readEx)
            {
                // Handle exceptions that occur when attempting to read from the log file
                Console.WriteLine($"Error reading log file: {readEx.Message}");
                return string.Empty;
            }
        }
    }
}