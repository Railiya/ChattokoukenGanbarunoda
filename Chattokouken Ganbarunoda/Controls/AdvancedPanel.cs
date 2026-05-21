using System;
using System.Windows.Forms;
using CKG.Forms;

namespace CKG.Controls
{
    public partial class AdvancedPanel : SettingPanel
    {
        protected override string LocalizationKey => "Advanced";

        public AdvancedPanel()
        {
            InitializeComponent();
        }

        public override void UpdateProfile(UserProfile profile)
        {
            _inputTimeoutField.Value = profile.InputTimeout;
            _debugEchoModeToggle.Checked = profile.DebugEchoMode;
            _writeLogFileToggle.Checked = profile.WriteLogFile;
            _executeOnWindowStartToggle.Checked = profile.ExecuteOnWindowStart;
        }

        private void _inputTimeoutField_ValueChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.InputTimeout = (int)_inputTimeoutField.Value;
            AppDataManager.SaveCurrentProfile();
        }

        private void _debugEchoModeToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.DebugEchoMode = _debugEchoModeToggle.Checked;
            AppDataManager.SaveCurrentProfile();
        }

        private void _writeLogFileToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.WriteLogFile = _writeLogFileToggle.Checked;
            AppDataManager.SaveCurrentProfile();
        }

        private void _executeOnWindowStartToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.ExecuteOnWindowStart = _executeOnWindowStartToggle.Checked;
            AppDataManager.SaveCurrentProfile();
        }
    }
}
