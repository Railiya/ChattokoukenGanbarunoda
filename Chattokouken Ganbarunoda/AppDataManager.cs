using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace CKG
{
    public readonly record struct SProfileInfo(string Name, int Number);

    public static class AppDataManager
    {
        private const string CONFIG_FILE_NAME = "config.json";

        private const string DIR_LOCALIZATION = "Localization";
        private const string DEFAULT_LOCALIZATION = "en-US";

        private const string DIR_PROFILES = "Profiles";
        private const string PROFILE_EXT = ".ckgprofile";
        private const int MAX_PROFILE_COUNT = 50;

        private static int _lastLoadedNumber = -1;

        #region Public Config Functions

        public static Config LoadConfig()
        {
            string path = GetConfigPath();
            Config config = null;

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };

            if (File.Exists(path) == false) //Create new
            {
                config = new Config();
                config.LanguageCode = CultureInfo.CurrentUICulture.Name;

                File.WriteAllText(path, JsonSerializer.Serialize(config, options));
                return config;
            }

            string content = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Config>(content, options);
        }

        #endregion

        #region Public Localization Functions

        public static JsonElement LoadLocalization(string code)
        {
            string path = GetLocalizationPath(code);

            if (File.Exists(path) == false)
            {
                //Load default language if system language is not supported
                path = GetLocalizationPath(DEFAULT_LOCALIZATION);
            }

            string content = File.ReadAllText(path);
            using JsonDocument document = JsonDocument.Parse(content);

            return document.RootElement.Clone();
        }

        #endregion

        #region Public Profile Functions

        public static UserProfile LoadDefaultProfile()
        {
            return LoadProfile(1);
        }

        public static UserProfile LoadProfile(int number)
        {
            if (_lastLoadedNumber == number)
            {
                return UserProfile.Current;
            }

            string path = GetProfilePath(number);

            if (File.Exists(path) == false) //Create new
            {
                UserProfile.Current = new UserProfile();
                UserProfile.Current.ProfileName = number == 1 ? "Default" : "New Profile";
                UserProfile.Current.Number = number;

                SaveCurrentProfile();
            }

            string content = File.ReadAllText(path);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };

            UserProfile profile = JsonSerializer.Deserialize<UserProfile>(content, options);
            UserProfile.Current = profile;
            UserProfile.Current.Number = number;
            _lastLoadedNumber = number;
            return profile;
        }

        public static void SaveCurrentProfile()
        {
            UserProfile profile = UserProfile.Current;
            string path = GetProfilePath(profile.Number);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };

            File.WriteAllText(path, JsonSerializer.Serialize(UserProfile.Current, options));
        }

        public static List<SProfileInfo> GetProfileList()
        {
            string dir = GetDirectoryPath(DIR_PROFILES);
            List<SProfileInfo> result = new List<SProfileInfo>();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };

            for (int i = 1; i <= MAX_PROFILE_COUNT; i++)
            {
                string path = Path.Combine(dir, GetProfileName(i));

                if (File.Exists(path) == false)
                {
                    break;
                }

                string content = File.ReadAllText(path);
                UserProfile profile = JsonSerializer.Deserialize<UserProfile>(content, options);
                result.Add(new SProfileInfo(profile.ProfileName, i));
            }

            return result;
        }

        #endregion

        #region Private Functions

        private static string GetDirectoryPath(string dirName)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string profileDir = Path.Combine(baseDir, dirName);

            Directory.CreateDirectory(profileDir);
            return profileDir;
        }

        private static string GetConfigPath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDir, CONFIG_FILE_NAME);
        }

        private static string GetLocalizationPath(string code)
        {
            return Path.Combine(GetDirectoryPath(DIR_LOCALIZATION), $"{code}.json");
        }

        private static string GetProfilePath(int number)
        {
            return Path.Combine(GetDirectoryPath(DIR_PROFILES), GetProfileName(number));
        }

        private static string GetProfileName(int number)
        {
            return $"profile{number}{PROFILE_EXT}";
        }

        #endregion
    }
}
