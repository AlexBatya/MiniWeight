using System;
using System.IO;
using Newtonsoft.Json;
using MyApp.Models;

namespace MyApp.Services {
    public class ConfigManager {
      private static string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

      // Метод для проверки наличия файла и его создания с дефолтными данными
      public static ConfigData LoadConfig() {
        // Проверяем, существует ли файл конфигурации
        if (!File.Exists(configFilePath)) {
          // Если файл не существует, создаем его с дефолтными значениями
          var defaultConfig = new ConfigData();
          SaveConfig(defaultConfig); // Сохраняем дефолтные данные в файл
          return defaultConfig;
        }

        // Если файл существует, загружаем данные из JSON
        string json = File.ReadAllText(configFilePath);
        return JsonConvert.DeserializeObject<ConfigData>(json);
      }

      // Метод для сохранения данных в JSON файл
      public static void SaveConfig(ConfigData config) {
        string json = JsonConvert.SerializeObject(config, Formatting.Indented);
        File.WriteAllText(configFilePath, json);
      }

      // Метод для обновления данных в файле
      public static void UpdateConfig(Action<ConfigData> updateAction) {
        // Загружаем текущие данные из файла
        var config = LoadConfig();

        // Применяем изменения
        updateAction(config);

        // Сохраняем обновленные данные
        SaveConfig(config);
      }
  }
}
