using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NSI.Classes.Postgresql
{
    public static class ConfigManager
    {
        private static DatabaseConfig _dbConfig;
        public static readonly string ConfigFilePath = "dbconfig.json";

        public static void SetDatabaseConfig(string host, string username, string password, string database, string port)
        {
            _dbConfig = new DatabaseConfig(host, username, password, database, port);
            SaveConfigToFile();
        }

        public static DatabaseConfig GetDatabaseConfig()
        {
            if (_dbConfig == null)
            {
                LoadConfigFromFile();
            }
            return _dbConfig;
        }

        private static void SaveConfigToFile()
        {
            string json = JsonConvert.SerializeObject(_dbConfig, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);
        }

        private static void LoadConfigFromFile()
        {
            if (File.Exists(ConfigFilePath))
            {
                string json = File.ReadAllText(ConfigFilePath);
                _dbConfig = JsonConvert.DeserializeObject<DatabaseConfig>(json);
            }
            else
            {
                _dbConfig = new DatabaseConfig();
            }
        }
    }
}
