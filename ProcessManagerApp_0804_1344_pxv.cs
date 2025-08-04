// 代码生成时间: 2025-08-04 13:44:31
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace MAUIApp
{
    // ProcessManagerApp.xaml.cs
    public partial class ProcessManagerApp : ContentPage
    {
        private ListView ProcessListView;

        public ProcessManagerApp()
        {
            InitializeComponent();
            SetupProcessListView();
        }

        private void SetupProcessListView()
        {
            ProcessListView = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var label = new Label();
                    label.SetBinding(Label.TextProperty, "ProcessName");
                    return label;
                }),
                RowHeight = 50
            };

            Content = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "Process Manager",
                        FontSize = FontSize.Medium,
                        FontAttributes = FontAttributes.Bold
                    },
                    ProcessListView
                }
            };

            RefreshProcesses();
        }

        private async Task RefreshProcesses()
        {
            try
            {
                Process[] processes = Process.GetProcesses();
                List<ProcessInfo> processList = processes.Select(p => new ProcessInfo
                {
                    ProcessName = p.ProcessName,
                    ProcessId = p.Id,
                    CpuUsage = p.TotalProcessorTime.TotalMilliseconds,
                    WorkingSet = p.WorkingSet64
                }).ToList();

                ProcessListView.ItemsSource = processList;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        // Supporting class to hold process information
        private class ProcessInfo
        {
            public string ProcessName { get; set; }
            public int ProcessId { get; set; }
            public long CpuUsage { get; set; }
            public long WorkingSet { get; set; }
        }

        // You can add more functionality to handle process operations here.
    }
}
