using System;
using System.Collections.Generic;

// Клас, який використовує патерн Singleton для збереження конфігураційних налаштувань
public class ConfigurationManager
{
    private static ConfigurationManager instance;
    private Dictionary<string, string> settings;

    private ConfigurationManager()
    {
        // Ініціалізація конфігураційних налаштувань
        settings = new Dictionary<string, string>();
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    // Метод для отримання значення конфігураційного параметру
    public string GetSetting(string key)
    {
        if (settings.ContainsKey(key))
        {
            return settings[key];
        }
        return null;
    }

    // Метод для встановлення або оновлення конфігураційного параметру
    public void SetSetting(string key, string value)
    {
        if (settings.ContainsKey(key))
        {
            settings[key] = value;
        }
        else
        {
            settings.Add(key, value);
        }
    }

    // Метод для відображення всіх конфігураційних налаштувань
    public void DisplaySettings()
    {
        foreach (var setting in settings)
        {
            Console.WriteLine($"{setting.Key}: {setting.Value}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Використання Singleton патерну через ConfigurationManager.Instance
        ConfigurationManager configManager = ConfigurationManager.Instance;

        // Зміна та відображення конфігураційних налаштувань через консольний інтерфейс
        while (true)
        {
            Console.WriteLine("1. Переглянути налаштування");
            Console.WriteLine("2. Змінити налаштування");
            Console.WriteLine("3. Вийти");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        configManager.DisplaySettings();
                        break;

                    case 2:
                        Console.Write("Введіть ім'я параметра: ");
                        string key = Console.ReadLine();
                        Console.Write("Введіть значення параметра: ");
                        string value = Console.ReadLine();
                        configManager.SetSetting(key, value);
                        Console.WriteLine($"Параметр {key} успішно змінено.");
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Невірний вибір. Будь ласка, введіть вірне число.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Невірний вибір. Будь ласка, введіть число.");
            }
        }
    }
}
