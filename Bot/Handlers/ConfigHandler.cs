﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Bot.Handlers
{
    internal class ConfigHandler
    {
        private const string _dataDirectory = "Data";
        private const string _configFile = "config.json";
        private const string _configLocation = _dataDirectory + "/" + _configFile;

        /// <summary>
        /// Get information from config.json file for use with bot.
        /// </summary>
        /// <returns></returns>
        public Config GetConfig()
            => GetConfigData();

        /// <summary>
        /// Private function to hide implementation of this method.
        /// </summary>
        /// <returns></returns>
        private Config GetConfigData()
        {
            CheckConfigExists();
            var data = File.ReadAllText(_configLocation);
            return JsonConvert.DeserializeObject<Config>(data);
        }

        /// <summary>
        /// Check if config.json exists and generate one if it doesn't.
        /// </summary>
        private void CheckConfigExists()
        {
            if (!Directory.Exists(_dataDirectory))
                Directory.CreateDirectory(_dataDirectory);

            if (File.Exists(_configLocation))
                return;

            Console.WriteLine("No config file found.\n" +
                              $"A new one has been generated at {_configLocation}\n" +
                              "Fill in required values and restart the bot.");
            var json = JsonConvert.SerializeObject(GenerateDefaultConfig(), Formatting.Indented);
            File.WriteAllText(_configLocation, json, Encoding.UTF8);
            Console.ReadKey();
            Environment.Exit(0);
        }

        /// <summary>
        /// Generate config.json file with default values.
        /// </summary>
        /// <returns></returns>
        private Config GenerateDefaultConfig()
            => new Config
            {
                Token = "",
                Prefix = ".",
                Status = "It's alive!"
            };
    }

}