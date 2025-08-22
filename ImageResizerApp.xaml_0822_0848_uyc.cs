// 代码生成时间: 2025-08-22 08:48:44
 * Features:
 * - Browse for a folder containing images.
 * - Select a target size and quality.
 * - Batch resize images in the folder.
 * - Error handling for file access and resize operations.
 */

using System;
using System.IO;
using System.Threading.Tasks;
using SkiaSharp;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.SkiaSharp;

namespace ImageResizerApp
{
    public partial class MainPage : ContentPage
    {
        // Folder path where images are located
        private string sourceFolderPath;
        // Target size for resizing
        private SKSize targetSize;
        // Target quality for resizing
        private float targetQuality;

        public MainPage()
        {
            InitializeComponent();
        }

        // Browse for folder containing images
        private async Task BrowseForFolder()
        {
            var folderPicker = new FolderPicker();
            string folderPath = await folderPicker.PickFolderAsync();
            if (!string.IsNullOrWhiteSpace(folderPath))
            {
                sourceFolderPath = folderPath;
                // TODO: Display folder path to the user
            }
        }

        // Resize images in the selected folder
        private async Task ResizeImages()
        {
            if (string.IsNullOrWhiteSpace(sourceFolderPath))
            {
                await DisplayAlert("Error", "Please select a folder first.", "OK");
                return;
            }

            try
            {
                var files = Directory.GetFiles(sourceFolderPath);
                foreach (var file in files)
                {
                    using (var image = SKBitmap.Decode(file))
                    {
                        await ResizeImageAsync(image, file);
                    }
                }
                await DisplayAlert("Success", "Images resized successfully.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        // Resize a single image
        private async Task ResizeImageAsync(SKBitmap originalImage, string filePath)
        {
            // Create an image canvas with the target size
            using (var resizedImage = new SKImage((int)targetSize.Width, (int)targetSize.Height))
            {
                using (var canvas = new SKCanvas(resizedImage))
                {
                    canvas.Clear(SKColors.Transparent);
                    canvas.DrawBitmap(originalImage, new SKRectI(0, 0, originalImage.Width, originalImage.Height),
                        new SKRectI(0, 0, (int)targetSize.Width, (int)targetSize.Height),
                        SKFilterQuality.High);
                }
                // Save the resized image
                string outputPath = Path.Combine(sourceFolderPath, Path.GetFileName(filePath) + "_resized");
                await resizedImage.Encode(SKEncodedImageFormat.Jpeg, (int)(targetQuality * 100)).SaveToAsync(outputPath);
            }
        }
    }
}
