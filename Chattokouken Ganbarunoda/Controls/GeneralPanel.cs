using System;
using CKG.Forms;

namespace CKG.Controls
{
    public enum EGeneralSettingToggle
    {
        StartTranslateOnBuffered,
        AutoSendMessageOnTranslated,
        StartCapturingOnSendClipboard,
        SkipChatStartOnSendClipboard,
        SkipChatStartOnSendOriginalText
    }

    public partial class GeneralPanel : SettingPanel
    {
        public static event Action<EInputMethod> OnInputMethodChanged = null;

        public Action<EGeneralSettingToggle, bool> OnToggleChanged = null;

        protected override string LocalizationKey => "General";

        public GeneralPanel() : base()
        {
            InitializeComponent();
        }

        public override void UpdateProfile(UserProfile profile)
        {
            _startTranslateToggle.Checked = profile.StartTranslateOnBuffered;
            _autoSendClipboardToggle.Checked = profile.AutoSendClipboardOnTranslated;
            _inputMethodSelector.SelectedIndex = profile.InputMethodIndex;
            _outputMethodSelector.SelectedIndex = profile.OutputMethodIndex;
            _defaultInputCharacterSelector.SelectedIndex = profile.DefaultInputCharacterIndex;
        }

        private void _startTranslateToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            bool toggle = _startTranslateToggle.Checked;
            UserProfile.Current.StartTranslateOnBuffered = toggle;

            OnToggleChanged?.Invoke(EGeneralSettingToggle.StartTranslateOnBuffered, toggle);
            AppDataManager.SaveCurrentProfile();
        }

        private void _autoSendClipboardToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            bool toggle = _autoSendClipboardToggle.Checked;
            UserProfile.Current.AutoSendClipboardOnTranslated = toggle;

            OnToggleChanged?.Invoke(EGeneralSettingToggle.AutoSendMessageOnTranslated, toggle);
            AppDataManager.SaveCurrentProfile();
        }

        private void _startCapturingToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            bool toggle = _startCapturingToggle.Checked;
            UserProfile.Current.StartCapturingOnSendClipboard = toggle;

            OnToggleChanged?.Invoke(EGeneralSettingToggle.StartCapturingOnSendClipboard, toggle);
            AppDataManager.SaveCurrentProfile();
        }

        private void _outputSkipChatStartToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            bool toggle = _outputSkipChatStartToggle.Checked;
            UserProfile.Current.SkipChatStartOnSendClipboard = toggle;

            OnToggleChanged?.Invoke(EGeneralSettingToggle.SkipChatStartOnSendClipboard, toggle);
            AppDataManager.SaveCurrentProfile();
        }

        private void _overlayInputSkipChatStartToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            bool toggle = _overlayInputSkipChatStartToggle.Checked;
            UserProfile.Current.SkipChatStartOnSendOriginalText = toggle;

            OnToggleChanged?.Invoke(EGeneralSettingToggle.SkipChatStartOnSendOriginalText, toggle);
            AppDataManager.SaveCurrentProfile();
        }

        private void _inputMethodSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            int index = _inputMethodSelector.SelectedIndex;
            UserProfile.Current.InputMethodIndex = index;
            AppDataManager.SaveCurrentProfile();

            OnInputMethodChanged?.Invoke((EInputMethod)index);
        }

        private void _outputMethodSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.OutputMethodIndex = _outputMethodSelector.SelectedIndex;
            AppDataManager.SaveCurrentProfile();
        }

        private void _defaultInputModeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.DefaultInputCharacterIndex = _defaultInputCharacterSelector.SelectedIndex;
            AppDataManager.SaveCurrentProfile();
        }
    }
}
