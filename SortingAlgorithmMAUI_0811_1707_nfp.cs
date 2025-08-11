// 代码生成时间: 2025-08-11 17:07:43
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAUISortingApp
{
    public class SortingAlgorithmMAUI
    {
        // 冒泡排序算法（Bubble Sort）
        public static List<int> BubbleSort(List<int> list)
        {
            try
            {
                int n = list.Count;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (list[j] > list[j + 1])
                        {
                            // 交换元素
                            int temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"BubbleSort Error: {ex.Message}");
                return null;
            }
        }

        // 快速排序算法（Quick Sort）
        public static List<int> QuickSort(List<int> list, int low, int high)
        {
            try
            {
                int pi;
                if (list.Count == 0)
                    return list;

                if (low < high)
                {
                    // pi 是 partitioning index, arr[pi] 现在处于正确位置
                    pi = Partition(list, low, high);

                    // 分别对分区进行递归排序
                    QuickSort(list, low, pi - 1);
                    QuickSort(list, pi + 1, high);
                }
                return list;
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"QuickSort Error: {ex.Message}");
                return null;
            }
        }

        private static int Partition(List<int> list, int low, int high)
        {
            int pivot = list[high];    // pivot
            int i = (low - 1);  // 小于 pivot 的元素的索引

            for (int j = low; j < high; j++)
            {
                // 如果当前元素小于或等于 pivot
                if (list[j] <= pivot)
                {
                    i++;    // 增加小于 pivot 的元素索引
                    int temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }

            int temp = list[i + 1];
            list[i + 1] = list[high];
            list[high] = temp;

            return i + 1;
        }

        public static async Task DisplaySortingAsync(List<int> list)
        {
            try
            {
                // 显示排序前
                Console.WriteLine("Before sorting: ");
                foreach (int item in list)
                {
                    Console.WriteLine(item);
                }

                // 排序算法选择
                List<int> sortedList = BubbleSort(list); // 可以选择 BubbleSort 或 QuickSort
                // List<int> sortedList = QuickSort(list, 0, list.Count - 1);

                // 显示排序后
                Console.WriteLine("
After sorting: ");
                foreach (int item in sortedList)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"DisplaySortingAsync Error: {ex.Message}");
            }
        }
    }
}
