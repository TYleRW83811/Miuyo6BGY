// 代码生成时间: 2025-08-30 17:15:14
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Maui.Controls;

namespace ConfigurationManagerApp
{
    /// <summary>
    /// A class responsible for managing application configuration.
    /// </summary>
    public class ConfigurationManager
    {
        private readonly string _configFilePath;
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationManager" /> class.
        /// </summary>
        /// <param name="configFilePath">The file path of the configuration file.</param>
        public ConfigurationManager(string configFilePath)
        {
            _configFilePath = configFilePath;
        }

        /// <summary>
        /// Loads the configuration data from the specified file path.
        /// </summary>
        /// <typeparam name="T">The type of the configuration object.</typeparam>
        /// <returns>The deserialized configuration object.</returns>
        public T LoadConfiguration<T>() where T : class
        {
            if (!File.Exists(_configFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found at {_configFilePath}");
            }

            var json = File.ReadAllText(_configFilePath);
            return JsonSerializer.Deserialize<T>(json, _options);
        }

        /// <summary>
        /// Saves the configuration data to the specified file path.
        /// </summary>
        /// <param name="config">The configuration object to serialize and save.</param>
        public void SaveConfiguration<T>(T config) where T : class
        {
            var json = JsonSerializer.Serialize(config, _options);
            File.WriteAllText(_configFilePath, json);
        }

        /// <summary>
        /// Checks if the configuration file exists.
        /// </summary>
        /// <returns>True if the configuration file exists, otherwise false.</returns>
        public bool ConfigurationExists()
        {
            return File.Exists(_configFilePath);
        }
    }
}
