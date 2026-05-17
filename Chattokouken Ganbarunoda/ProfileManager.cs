using System;
using System.IO;
using System.Text.Json;

namespace CKG
{
    public static class ProfileManager
    {
        private const string PROFILE_EXT = ".ckgprofile";

        public static UserProfile LoadDefaultProfile()
        {
            return LoadProfile(1);
        }

        public static UserProfile LoadProfile(int number)
        {
            string path = GetProfilePath(number);

            if (File.Exists(path) == false)
            {
                UserProfile.Current = new UserProfile();
                UserProfile.Current.ProfileName = "Default";
                UserProfile.Current.Number = 1;

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

        private static string GetProfilePath(int number)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string profileDir = Path.Combine(baseDir, "Profiles");

            Directory.CreateDirectory(profileDir);
            return Path.Combine(profileDir, $"profile{number}{PROFILE_EXT}");
        }
    }
}
