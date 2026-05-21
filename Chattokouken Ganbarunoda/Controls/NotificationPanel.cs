using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CKG.Forms;

namespace CKG.Controls
{
    public partial class NotificationPanel : SettingPanel
    {
        protected override string LocalizationKey => "Notification";

        private List<Control> _notificationActiveGroup = null;

        public NotificationPanel()
        {
            InitializeComponent();

            _notificationActiveGroup =
            [
                _capturingStartNotifyToggle,
                _translationCompletedNotifyToggle,
                _notificationVolumeSlider,
            ];
        }

        public override void UpdateProfile(UserProfile profile)
        {
            _notificationEnabledToggle.Checked = profile.NotificationEnabled;
            _capturingStartNotifyToggle.Checked = profile.NotifyOnCapturingStart;
            _translationCompletedNotifyToggle.Checked = profile.NotifyOnTranslationCompleted;
            _translationFailedNotifyToggle.Checked = profile.NotifyOnTranslationFailed;
            _notificationVolumeSlider.Value = profile.NotificationVolume;
            _notificationVolumeField.Text = profile.NotificationVolume.ToString();

            _notificationActiveGroup.SetControlGroupActive(profile.NotificationEnabled);
        }

        private void _notificationEnabledToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            bool toggle = _notificationEnabledToggle.Checked;
            UserProfile.Current.NotificationEnabled = toggle;
            _notificationActiveGroup.SetControlGroupActive(toggle);

            AppDataManager.SaveCurrentProfile();
        }

        private void _capturingStartNotifyToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.NotifyOnCapturingStart = _capturingStartNotifyToggle.Checked;
            AppDataManager.SaveCurrentProfile();
        }

        private void _translationCompletedNotifyToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.NotifyOnTranslationCompleted = _translationCompletedNotifyToggle.Checked;
            AppDataManager.SaveCurrentProfile();
        }

        private void _translationFailedNotifyToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.NotifyOnTranslationFailed = _translationFailedNotifyToggle.Checked;
            AppDataManager.SaveCurrentProfile();
        }

        private void _notificationVolumeSlider_ValueChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            int value = _notificationVolumeSlider.Value;
            UserProfile.Current.NotificationVolume = value;
            _notificationVolumeField.Text = value.ToString();

            AppDataManager.SaveCurrentProfile();
        }
    }
}
