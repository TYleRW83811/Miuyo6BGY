// 代码生成时间: 2025-08-11 05:14:32
using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

namespace LogParserApp
{
    public class LogParserApp : ContentPage
    {
        private Entry logFilePathEntry;
        private Button parseButton;
        private Label resultLabel;
        private ListView parsedLogListView;

        public LogParserApp()
        {
            // Initialize UI components
            InitComponents();
        }

        private void InitializeComponents()
        {
            // Set the content of the page
            Content = new StackLayout
            {
                Spacing = 10,
                Children =
                {
                    new Label { Text = "Enter the path to the log file:" },

                    logFilePathEntry = new Entry
                    {
                        Placeholder = "/path/to/log/file.log",
                        HeightRequest = 40
                    },

                    parseButton = new Button { Text = "Parse Log" },

                    resultLabel = new Label
                    {
                        Text = "Results will be displayed here",
                        Wrap = true
                    },

                    parsedLogListView = new ListView
                    {
                        HasUnevenRows = true
                    }
                }
            };

            // Add event handlers
            parseButton.Clicked += OnParseButtonClicked;
        }

        private async void OnParseButtonClicked(object sender, EventArgs e)
        {
            string logFilePath = logFilePathEntry.Text;

            // Check if the log file path is provided
            if (string.IsNullOrWhiteSpace(logFilePath))
            {
                resultLabel.Text = "Please enter a valid log file path.";
                return;
            }

            try
            {
                // Read the log file content
                string logContent = await File.ReadAllTextAsync(logFilePath);

                // Parse the log content
                var parsedLogs = ParseLogContent(logContent);

                // Bind the parsed logs to the ListView
                parsedLogListView.ItemsSource = parsedLogs;
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display the error message
                resultLabel.Text = $"Error reading file: {ex.Message}";
            }
        }

        private List<string> ParseLogContent(string logContent)
        {
            // Define a regex pattern to match log entries
            string pattern = @"(?:[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{2}:[0-9]{2}:[0-9]{2},[0-9]{3}) (.*)";

            // Compile the regex pattern
            Regex regex = new Regex(pattern);

            // Use regex to extract log entries from the content
            List<string> parsedLogs = new List<string>();
            foreach (Match match in regex.Matches(logContent))
            {
                if (match.Success)
                {
                    parsedLogs.Add(match.Value);
                }
            }

            return parsedLogs;
        }
    }
}
