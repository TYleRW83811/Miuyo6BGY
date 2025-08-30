// 代码生成时间: 2025-08-30 12:55:51
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Collections.Generic;

namespace MyApp.Configuration
{
    /// <summary>
    /// Provides functionality to manage application configuration files.
    /// </summary>
    public class ConfigurationManager
    {
        private readonly IConfigurationRoot _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationManager"/> class.
        /// </summary>
        /// <param name="configFilePath">The path to the configuration file.</param>
        public ConfigurationManager(string configFilePath)
        {
            if (string.IsNullOrEmpty(configFilePath))
            {
                throw new ArgumentException("Configuration file path cannot be null or empty.", nameof(configFilePath));
            }

            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException("Configuration file not found.", configFilePath);
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFilePath, optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        /// <summary>
        /// Gets the value of a setting from the configuration file.
        /// </summary>
        /// <param name="key">The key of the setting to retrieve.</param>
        /// <returns>The value of the setting if found; otherwise, null.</returns>
        public string GetSetting(string key)
        {
            return _configuration[key];
        }

        /// <summary>
        /// Updates the configuration file with new settings.
        /// </summary>
        /// <param name="settings">A dictionary of settings to update in the configuration file.</param>
        public void UpdateSettings(Dictionary<string, string> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            foreach (var setting in settings)
            {
                _configuration[setting.Key] = setting.Value;
            }

            // Persist changes to the configuration file.
            // This requires additional implementation depending on how the configuration file should be updated.
            // For example, you could use a provider-specific method to save the changes.
        }

        /// <summary>
        /// Reloads the configuration file, picking up any changes made to the file.
        /// </summary>
        public void ReloadConfiguration()
        {
            _configuration.Reload();
        }
    }
}