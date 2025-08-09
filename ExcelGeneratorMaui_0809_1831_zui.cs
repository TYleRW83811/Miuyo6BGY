// 代码生成时间: 2025-08-09 18:31:59
 * Follows C# best practices for maintainability and scalability.
 */

using System;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExcelGeneratorMaui
{
    public class ExcelGenerator
    {
        // Method to create an Excel file with the specified number of rows and columns
        public void CreateExcelFile(string filePath, int rows, int columns)
        {
            try
            {
                // Ensure the file path is valid
                if (string.IsNullOrEmpty(filePath) || rows < 0 || columns < 0)
                {
                    throw new ArgumentException("Invalid file path, rows, or columns.");
                }

                // Create an Excel document
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
                {
                    // Add a workbook and a worksheet to the document
                    WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();
                    SheetData sheetData = new SheetData();
                    Sheets sheets = workbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                    Sheet sheet = new Sheet()
                    {
                        Id = workbookPart.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>(), "rId"),
                        SheetId = 1,
                        Name = "Sheet1"
                    };
                    sheets.Append(sheet);

                    // Create header row
                    Row headerRow = new Row();
                    for (int i = 1; i <= columns; i++)
                    {
                        // Cells for header row
                        headerRow.Append(new Cell() { CellValue = new CellValue($"Column {i}"), DataType = CellValues.String });
                    }
                    sheetData.Append(headerRow);

                    // Create data rows
                    for (int row = 1; row <= rows; row++)
                    {
                        Row dataRow = new Row();
                        for (int col = 1; col <= columns; col++)
                        {
                            // Cells for data rows
                            dataRow.Append(new Cell() { CellValue = new CellValue($"Data {row}-{col}"), DataType = CellValues.String });
                        }
                        sheetData.Append(dataRow);
                    }

                    // Add sheet data to the worksheet
                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    worksheetPart.Worksheet = new Worksheet(sheetData);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the creation of the Excel file
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    // Example usage of the ExcelGenerator class
    class Program
    {
        static void Main(string[] args)
        {
            ExcelGenerator excelGenerator = new ExcelGenerator();
            string filePath = "example.xlsx";
            int rows = 10;
            int columns = 5;

            excelGenerator.CreateExcelFile(filePath, rows, columns);
            Console.WriteLine($"Excel file created successfully at: {filePath}");
        }
    }
}