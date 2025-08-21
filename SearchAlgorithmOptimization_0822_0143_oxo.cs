// 代码生成时间: 2025-08-22 01:43:12
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace MauiApp
{
    // 搜索算法优化类
    public class SearchAlgorithmOptimization
    {
        private readonly List<string> _searchItems;

        public SearchAlgorithmOptimization(IEnumerable<string> searchItems)
        {
            _searchItems = new List<string>(searchItems);
        }

        // 搜索函数，使用二分查找算法优化
        public string? BinarySearch(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                throw new ArgumentException("Search term cannot be null or empty.", nameof(searchTerm));

            int left = 0;
            int right = _searchItems.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                // 使用OrdinalIgnoreCase进行不区分大小写的比较
                int comparison = StringComparison.OrdinalIgnoreCase.Compare(_searchItems[mid], searchTerm);

                if (comparison == 0)
                {
                    // 找到匹配项
                    return _searchItems[mid];
                }
                else if (comparison < 0)
                {
                    // 搜索项小于中间项，搜索右半部分
                    left = mid + 1;
                }
                else
                {
                    // 搜索项大于中间项，搜索左半部分
                    right = mid - 1;
                }
            }

            // 未找到匹配项
            return null;
        }

        // 添加搜索项
        public void AddSearchItem(string item)
        {
            if (string.IsNullOrEmpty(item))
                throw new ArgumentException("Item cannot be null or empty.", nameof(item));

            _searchItems.Add(item);
        }

        // 移除搜索项
        public bool RemoveSearchItem(string item)
        {
            if (string.IsNullOrEmpty(item))
                throw new ArgumentException("Item cannot be null or empty.", nameof(item));

            return _searchItems.Remove(item);
        }
    }
}
