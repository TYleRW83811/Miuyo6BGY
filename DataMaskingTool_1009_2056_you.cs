// 代码生成时间: 2025-10-09 20:56:52
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataMaskingTool
{
    public static class DataMasking
    {
        // 定义一个方法用于脱敏字符串
        public static string MaskData(string data)
        {
            // 检查输入是否为空
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("输入数据不能为空。");
            }

            // 使用正则表达式匹配敏感信息，并替换为星号
            // 假设敏感信息为手机号码或者电子邮件地址
            return Regex.Replace(data, @"(\d{3}-?\d{4}-?\d{4})|([A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,})", "***");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 示例数据
                string sensitiveData = "John Doe, email: john.doe@example.com, phone: 123-456-7890";

                // 调用脱敏方法
                string maskedData = DataMasking.MaskData(sensitiveData);

                // 输出脱敏后的数据
                Console.WriteLine($"Original Data: {sensitiveData}
Masked Data: {maskedData}");
            }
            catch (Exception ex)
            {
                // 输出错误信息
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}