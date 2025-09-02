// 代码生成时间: 2025-09-02 17:10:48
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using System;

namespace MauiApp
{
    // 主题切换功能的MAUI应用
    public class ThemeSwitcherMauiApp : Application
    {
        public static string LightTheme = "LightTheme";
        public static string DarkTheme = "DarkTheme";
        private string currentTheme;

        public ThemeSwitcherMauiApp()
        {
            // 初始化应用主题
            InitializeTheme(LightTheme);
        }

        // 初始化应用主题
        private void InitializeTheme(string theme)
        {
            try
            {
                if (theme != LightTheme && theme != DarkTheme)
                {
                    throw new ArgumentException("Theme must be either 'LightTheme' or 'DarkTheme'.");
                }

                currentTheme = theme;
                if (DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    // iOS平台主题设置
                    On<Microsoft.Maui.Controls.PlatformConfiguration.iOS>().SetUserInterfaceStyle(new Xamarin.Forms.UserInterfaceStyle(theme));
                }
                else if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    // Android平台主题设置
                    On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"Error setting theme: {ex.Message}");
            }
        }

        // 切换主题
        public void SwitchTheme()
        {
            if (currentTheme == LightTheme)
            {
                InitializeTheme(DarkTheme);
            }
            else
            {
                InitializeTheme(LightTheme);
            }
        }
    }
}