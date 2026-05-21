using System;
using System.Text.Json;
using System.Windows.Forms;
using CKG.Forms;
using CKG.Translator;

namespace CKG
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Config config = AppDataManager.LoadConfig();
            JsonElement localization = AppDataManager.LoadLocalization(config.LanguageCode);
            AppDataManager.LoadDefaultProfile();

            using TranslationService translationService = new TranslationService();
            using AppController appController = new AppController(translationService);

            Application.Run(new MainForm(translationService, in localization));
        }
    }
}