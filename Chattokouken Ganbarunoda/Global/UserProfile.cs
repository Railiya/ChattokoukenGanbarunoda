using System.Windows.Forms;

namespace CKG
{
    public class UserProfile
    {
        public static UserProfile Current { get; set; }

        //Profile
        public string ProfileName = "";
        public int Number = 0;

        //General
        public bool StartTranslateOnBuffered = false;
        public bool AutoSendMessageOnTranslated = false;
        public int OutputMethodIndex = 0;
        public int DefaultInputModeIndex = 0;

        //Translation
        public int ModelIndex = 0;
        public string APIKey = "";
        public string GlossaryId = "";
        public int SourceLanguageIndex = 0;
        public int DestinationLanguageIndex = 0;
        public string TranslationFormat = "({translated})";
        public int RequestTimeout = 3;

        //Overlay
        public bool OverlayEnabled = true;
        public int OverlayAnchorIndex = 0;
        public int OverlayOffsetX = 0;
        public int OverlayOffsetY = 0;
        public int OverlayFontSize = 12;
        public int OverlayOpacity = 80;

        //Notification
        public bool NotificationEnabled = true;
        public bool NotifyOnCapturingStart = true;
        public bool NotifyOnTranslationCompleted = true;
        public bool NotifyOnTranslationFailed = true;
        public int NotificationVolume = 80;

        //Hotkeys
        public SKeySetting EnableCapturingKeySetting = new SKeySetting(Keys.Scroll, false, false, false);
        public SKeySetting CapturingToggleKeySetting = new SKeySetting(Keys.Enter, false, false, false);
        public SKeySetting TranslateKeySetting = new SKeySetting(Keys.Enter, true, false, false);
        public SKeySetting SendClipboardKeySetting = new SKeySetting(Keys.OemPipe, false, false, false);

        //Advanced
        public int InputTimeout = 3;
        public bool DebugEchoMode = false;
        public bool WriteLogFile = false;
        public bool ExecuteOnWindowStart = false;
    }
}
