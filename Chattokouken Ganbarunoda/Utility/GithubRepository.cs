using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKG
{
    public readonly record struct SUpdateCheckResult(bool isLatest, string currentVersion, string latestVersion);

    public static class GithubRepository
    {
        private const string REPOSITORY_URL = "https://github.com/Railiya/ChattokoukenGanbarunoda";
        private const string LATEST_RELEASE_API = "https://api.github.com/repos/Railiya/ChattokoukenGanbarunoda/releases/latest";

        public static async Task<SUpdateCheckResult> CheckForUpdatesAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "CKG");

                string json = await client.GetStringAsync(LATEST_RELEASE_API);
                using JsonDocument doc = JsonDocument.Parse(json);

                string latestTag = doc.RootElement.GetProperty("tag_name").GetString();
                string currentVersion = $"v{Application.ProductVersion}";
                bool isLatest = IsLatest(latestTag, currentVersion);

                //Return true if it's latest version
                return new SUpdateCheckResult(isLatest, currentVersion, latestTag);
            }
            catch
            {
                return default;
            }
        }

        public static void OpenGithubPage()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = REPOSITORY_URL,
                UseShellExecute = true
            };

            Process.Start(processStartInfo);
        }

        private static bool IsLatest(string latest, string current)
        {
            Version latestVer = Version.Parse(latest.Substring(1));
            Version currentVer = Version.Parse(current.Substring(1));

            return currentVer >= latestVer;
        }
    }
}
