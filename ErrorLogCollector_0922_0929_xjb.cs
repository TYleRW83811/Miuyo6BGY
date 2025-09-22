// 代码生成时间: 2025-09-22 09:29:05
// ErrorLogCollector.cs
// 这是一个使用C#和MAUI框架的错误日志收集器程序。

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLogCollectionApp
{
    // 定义一个错误日志收集器类
    public class ErrorLogCollector
    {
        private const string LogDirectory = "./logs";
        private const string LogFileName = "error.log";

        // 构造函数
        public ErrorLogCollector()
        {
            // 确保日志目录存在
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        // 记录错误日志的方法
        public void LogError(Exception ex)
        {
            try
            {
                string logPath = Path.Combine(LogDirectory, LogFileName);
                // 使用StringBuilder构建错误信息
                StringBuilder logMessage = new StringBuilder();
                logMessage.AppendLine($"Error logged at: {DateTime.Now.ToString()}");
                logMessage.AppendLine($"Message: {ex.Message}");
                logMessage.AppendLine($"Stack Trace: {ex.StackTrace}");

                // 将错误信息追加到日志文件中
                File.AppendAllText(logPath, logMessage.ToString() + Environment.NewLine);
            }
            catch (Exception logEx)
            {
                // 如果记录日志时发生异常，输出到控制台
                Console.WriteLine($"Error writing to log: {logEx.Message}");
            }
        }
    }
}
