using System;
using System.Collections.Generic;
using System.IO;

namespace CKG
{
    public static class Logger
    {
        private static readonly Dictionary<ECapturingState, string> STATE_TEXT_TABLE = new Dictionary<ECapturingState, string>()
        {
            { ECapturingState.Disabled, "DISABLED" },
            { ECapturingState.Idle, "IDLE" },
            { ECapturingState.Capturing, "CAPTURING" },
            { ECapturingState.Buffered, "BUFFERED" },
            { ECapturingState.Translating, "TRANSLATING" },
            { ECapturingState.Translated, "TRANSLATED" },
            { ECapturingState.Failed, "TIMEOUT" }
        };

        private static readonly string LOG_DIR = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private static readonly string LOG_FILE_PATH = Path.Combine(LOG_DIR, $"{DateTime.Now:yyyy-MM-dd}.log");

        public static void Write(ECapturingState state)
        {
            string line = $"[{DateTime.Now:HH:mm:ss}] [{STATE_TEXT_TABLE[state]}]\n";
            AppendText(line);
        }

        public static void Write(ECapturingState state, string message)
        {
            string line = $"[{DateTime.Now:HH:mm:ss}] [{STATE_TEXT_TABLE[state]}] {message}\n";
            AppendText(line);
        }

        public static void Write(string message)
        {
            string line = $"[{DateTime.Now:HH:mm:ss}] {message}\n";
            AppendText(line);
        }

        private static void AppendText(string text)
        {
            try
            {
                if (Directory.Exists(LOG_DIR) == false)
                {
                    Directory.CreateDirectory(LOG_DIR);
                }

                File.AppendAllText(LOG_FILE_PATH, text);
            }
            catch { }
        }
    }
}
