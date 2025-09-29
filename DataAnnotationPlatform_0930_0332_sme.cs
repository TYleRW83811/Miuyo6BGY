// 代码生成时间: 2025-09-30 03:32:20
// DataAnnotationPlatform.cs
// This is a simple C# MAUI application for a data annotation platform.

using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Devices;

namespace DataAnnotationApp
{
    public class DataAnnotationPlatform : Application
    {
        private MainPage mainPage;

        public DataAnnotationPlatform()
        {
            // Initialize the main page of the application
            mainPage = new MainPage();

            // Set the main page as the root page
            MainPage = mainPage;
        }

        // Override this method to handle any initialization logic after the
        // application has been initialized
        protected override void OnStart()
        {
            // Handle when your app starts
            base.OnStart();
        }

        // Override this method to handle any logic when the application is closing
        protected override void OnSleep()
        {
            // Handle when your app sleeps
            base.OnSleep();
        }

        // Override this method to handle any logic when the application resumes
        protected override void OnResume()
        {
            // Handle when your app resumes
            base.OnResume();
        }
    }

    public class MainPage : ContentPage
    {
        public MainPage()
        {
            // Initialization code for the main page
            Title = "Data Annotation Platform";
            Content = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "Welcome to the Data Annotation Platform"
                    }
                }
            };
        }
    }
}
