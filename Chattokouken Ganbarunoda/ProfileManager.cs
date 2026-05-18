using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CKG
{
    public readonly record struct SProfileInfo(string Name, int Number);

    public static class ProfileManager
    {
        private const string PROFILE_EXT = ".ckgprofile";
        private const int MAX_PROFILE_COUNT = 50;

        private static int _lastLoadedNumber = -1;

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

            if (File.Exists(path) == false)
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
            string dir = GetDirectoryPath();
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

        private static string GetProfilePath(int number)
        {
            return Path.Combine(GetDirectoryPath(), GetProfileName(number));
        }

        private static string GetDirectoryPath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string profileDir = Path.Combine(baseDir, "Profiles");

            Directory.CreateDirectory(profileDir);
            return profileDir;
        }

        private static string GetProfileName(int number)
        {
            return $"profile{number}{PROFILE_EXT}";
        }
    }
}
