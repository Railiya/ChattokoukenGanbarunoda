using System;
using CKG.Forms;

namespace CKG.Controls
{
    public enum EGeneralSettingToggle
    {
        StartTranslateOnBuffered,
        AutoSendMessageOnTranslated
    }

    public partial class GeneralPanel : SettingPanel
    {
        public Action<EGeneralSettingToggle, bool> OnToggleChanged = null;

        public GeneralPanel() : base()
        {
            InitializeComponent();
        }

        public override void UpdateProfile(UserProfile profile)
        {
            _startTranslateToggle.Checked = profile.StartTranslateOnBuffered;
            _autoSendMessageToggle.Checked = profile.AutoSendMessageOnTranslated;
            _outputMethodSelector.SelectedIndex = profile.OutputMethodIndex;
            _defaultInputModeSelector.SelectedIndex = profile.DefaultInputModeIndex;
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
            ProfileManager.SaveCurrentProfile();
        }

        private void _autoSendMessageToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            bool toggle = _autoSendMessageToggle.Checked;
            UserProfile.Current.AutoSendMessageOnTranslated = toggle;

            OnToggleChanged?.Invoke(EGeneralSettingToggle.AutoSendMessageOnTranslated, toggle);
            ProfileManager.SaveCurrentProfile();
        }

        private void _outputMethodSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.OutputMethodIndex = _outputMethodSelector.SelectedIndex;
            ProfileManager.SaveCurrentProfile();
        }

        private void _defaultInputModeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.DefaultInputModeIndex = _defaultInputModeSelector.SelectedIndex;
            ProfileManager.SaveCurrentProfile();
        }
    }
}
