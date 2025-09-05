// 代码生成时间: 2025-09-06 03:16:29
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MauiApp
{
    public class FormValidator
    {
        private readonly Dictionary<string, string> _errorMessages;

        public FormValidator()
        {
            _errorMessages = new Dictionary<string, string>();
        }

        // 验证表单数据
        public bool ValidateForm(IEnumerable<Entry> entries)
        {
            bool isValid = true;
            foreach (var entry in entries)
            {
                isValid &= ValidateEntry(entry);
                if (!isValid)
                {
                    break; // 如果发现错误则停止验证
                }
            }
            return isValid;
        }

        // 验证单个输入项
        private bool ValidateEntry(Entry entry)
        {
            bool isValid = !string.IsNullOrWhiteSpace(entry.Text);
            if (!isValid)
            {
                _errorMessages[entry.Name] = $"The field '{entry.Name}' cannot be empty.";
            }
            else
            {
                _errorMessages.Remove(entry.Name);
            }
            return isValid;
        }

        // 获取错误消息
        public string GetErrorMessage(string key)
        {
            return _errorMessages.TryGetValue(key, out var message) ? message : string.Empty;
        }
    }
}
