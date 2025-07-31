// 代码生成时间: 2025-07-31 19:19:43
using CommunityToolkit.Maui;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using NPOI.HSSF.UserModel; // 导入NPOI的HSSF模型用于处理Excel文件
using NPOI.SS.UserModel; // 导入NPOI的Spreadsheet模型用于处理电子表格
using NPOI.XSSF.UserModel; // 导入NPOI的XSSF模型用于处理Excel文件

namespace ExcelGeneratorMauiApp
{
    public class ExcelGeneratorService
    {
        /// <summary>
        /// 生成Excel文件
        /// </summary>
        /// <param name="data">需要写入Excel的数据</param>
        /// <param name="fileName">生成的Excel文件名</param>
        /// <returns>生成Excel文件的完整路径</returns>
        public async Task<string> GenerateExcelAsync(string[,] data, string fileName)
        {
            try
            {
                // 使用临时文件名以避免文件名冲突
                var tempFileName = Path.GetTempFileName();

                IWorkbook workbook = new XSSFWorkbook(); // 创建新的Excel工作簿
                ISheet sheet = workbook.CreateSheet(); // 创建新的工作表

                // 遍历数据并填充到Excel中
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    IRow row = sheet.CreateRow(i); // 创建新的行
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        ICell cell = row.CreateCell(j); // 创建新的单元格
                        cell.SetCellValue(data[i, j]); // 设置单元格的值
                    }
                }

                // 将工作簿写入临时文件
                using (var fileStream = new FileStream(tempFileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fileStream);
                }

                // 将临时文件移动到指定的文件名
                File.Move(tempFileName, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName));

                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
            }
            catch (Exception ex)
            {
                // 异常处理
                Console.WriteLine($"An error occurred while generating Excel: {ex.Message}");
                throw;
            }
        }
    }

    public class MainPage : ContentPage
    {
        private readonly ExcelGeneratorService _excelGeneratorService = new ExcelGeneratorService();

        public MainPage()
        {
            // 按钮用于生成Excel
            Button generateExcelButton = new Button
            {
                Text = "Generate Excel",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            generateExcelButton.Clicked += async (sender, e) =>
            {
                string[,] data = new string[,]
                {
                    { "Header1", "Header2" },
                    { "Row1 Column1", "Row1 Column2" },
                    { "Row2 Column1", "Row2 Column2" }
                };
                string fileName = "example.xlsx";
                try
                {
                    string filePath = await _excelGeneratorService.GenerateExcelAsync(data, fileName);
                    DisplayAlert("Excel generated", $"Excel file generated at: {filePath}", "OK");
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", ex.Message, "OK");
                }
            };

            Content = generateExcelButton;
        }
    }
}
