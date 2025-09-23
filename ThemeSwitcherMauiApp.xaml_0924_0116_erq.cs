// 代码生成时间: 2025-09-24 01:16:41
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

namespace ThemeSwitcherMauiApp
{
    public partial class ThemeSwitcherMauiApp : Application
    {
        // Define the dark and light themes
        public static readonly string LightTheme = "LightTheme";
        public static readonly string DarkTheme = "DarkTheme";

        // Constructor
        public ThemeSwitcherMauiApp()
        {
            InitializeComponent();

            // Set the initial theme
            MainPage = new MainPage();
            SetAppTheme();
        }

        // Method to switch the theme
        public void SwitchTheme(string theme)
        {
            // Set the theme for the application
            On<Microsoft.Maui.Controls.PlatformConfiguration.Windows>().SetRequestedTheme(theme);
            // Update the resource dictionary to apply the new theme
            Resources.MergedDictionaries.Clear();
            if (theme == DarkTheme)
            {
                Resources.MergedDictionaries.Add(new Styletune.Styles.DarkTheme());
            }
            else
            {
                Resources.MergedDictionaries.Add(new Styletune.Styles.LightTheme());
            }
        }

        // Method to toggle the theme
        public void ToggleTheme()
        {
            string currentTheme = Resources.MergedDictionaries.Count > 0 ? Resources.MergedDictionaries[0].ToString() : LightTheme;
            string newTheme = currentTheme == DarkTheme ? LightTheme : DarkTheme;
            SwitchTheme(newTheme);
        }

        // Method to set the initial theme
        private void SetAppTheme()
        {
            // Check if the user has set a preferred theme in settings
            if (Preferences.ContainsKey("PreferredTheme"))
            {
                string preferredTheme = Preferences.Get("PreferredTheme", LightTheme);
                SwitchTheme(preferredTheme);
            }
            else
            {
                // Default to light theme
                SwitchTheme(LightTheme);
            }
        }
    }
}
