// 代码生成时间: 2025-08-18 06:08:16
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

namespace WebContentGrabberApp
{
    /// <summary>
    /// A class that provides functionality to grab web content.
    /// </summary>
    public class WebContentGrabber
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebContentGrabber"/> class.
        /// </summary>
        public WebContentGrabber()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Fetches the content of the webpage from the specified URL.
        /// </summary>
        /// <param name="url">The URL of the webpage to fetch.</param>
        /// <returns>A <see cref="string"/> containing the HTML content of the webpage.</returns>
        public async Task<string> FetchWebContentAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("URL cannot be null or empty.", nameof(url));
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (HttpRequestException ex)
            {
                // Log and handle the error appropriately.
                Console.WriteLine($"Error fetching web content: {ex.Message}");
                throw;
            }
        }
    }

    public class WebContentGrabberPage : ContentPage
    {
        private readonly WebContentGrabber _grabber;
        private Entry _urlEntry;
        private Button _fetchButton;
        private Label _resultLabel;

        public WebContentGrabberPage()
        {
            _grabber = new WebContentGrabber();

            // Setup the UI elements.
            _urlEntry = new Entry { Placeholder = "Enter URL" };
            _fetchButton = new Button { Text = "Fetch Web Content" };
            _resultLabel = new Label();

            // Layout setup.
            VerticalStackLayout layout = new VerticalStackLayout()
            {
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    _urlEntry,
                    _fetchButton,
                    _resultLabel
                }
            };

            Content = layout;

            // Set up the fetch button click event handler.
            _fetchButton.Clicked += async (sender, e) =>
            {
                try
                {
                    string url = _urlEntry.Text;
                    string content = await _grabber.FetchWebContentAsync(url);
                    _resultLabel.Text = content; // Display the web content in the label.
                }
                catch (Exception ex)
                {
                    _resultLabel.Text = $"Error: {ex.Message}";
                }
            };
        }
    }
}
