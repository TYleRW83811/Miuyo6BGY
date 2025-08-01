// 代码生成时间: 2025-08-02 04:39:00
using System;
using System.Security.Cryptography;
using System.Text;
# 优化算法效率
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace HashCalculatorApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HashCalculatorPage : ContentPage
    {
        private const string ALGORITHMS = "MD5,SHA1,SHA256,SHA512";

        public HashCalculatorPage()
# 改进用户体验
        {
            InitializeComponent();
        }

        private async void CalculateHashButton_Clicked(object sender, EventArgs e)
        {
# NOTE: 重要实现细节
            string[] algorithms = ALGORITHMS.Split(',');
            string inputText = InputEntry.Text;
            if (string.IsNullOrWhiteSpace(inputText))
            {
                await DisplayAlert("Error", "Please enter text to calculate hash.", "OK");
                return;
            }

            foreach (string algorithm in algorithms)
            {
                using (var hashAlgorithm = HashAlgorithm.Create(algorithm))
                {
                    if (hashAlgorithm == null)
                    {
                        await DisplayAlert("Error", $"Algorithm {algorithm} not supported.", "OK");
                        continue;
                    }

                    byte[] bytes = Encoding.UTF8.GetBytes(inputText);
                    byte[] hashBytes = hashAlgorithm.ComputeHash(bytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
# TODO: 优化性能

                    await DisplayAlert(algorithm, $"Hash: {hash}", "OK");
                }
            }
# 优化算法效率
        }
    }
# 改进用户体验
}