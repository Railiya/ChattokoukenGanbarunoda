using System;
using System.Windows.Forms;
using CKG.Forms;

namespace CKG.Controls
{
    public partial class HotkeysPanel : SettingPanel
    {
        public event Action<EHotkey, SKeySetting> OnHotkeyChanged = null;

        protected override string LocalizationKey => "Hotkeys";

        private HotkeyControlGroup[] _hotkeyControlGroups = null;

        public HotkeysPanel()
        {
            InitializeComponent();

            _hotkeyControlGroups = new HotkeyControlGroup[] 
            {
                new HotkeyControlGroup(EHotkey.EnableCapturing, Keys.Scroll,
                    _enableCapturingKeyButton, _enableCapturingCtrlToggle, _enableCapturingAltToggle, _enableCapturingShiftToggle),
                new HotkeyControlGroup(EHotkey.CapturingToggle, Keys.Enter,
                    _capturingToggleKeyButton, _capturingToggleCtrlToggle, _capturingToggleAltToggle, _capturingToggleShiftToggle),
                new HotkeyControlGroup(EHotkey.Translate, Keys.F9,
                    _translateKeyButton, _translateCtrlToggle, _translateAltToggle, _translateShiftToggle),
                new HotkeyControlGroup(EHotkey.SendClipboard, Keys.OemPipe,
                    _sendClipboardKeyButton, _sendClipboardCtrlToggle, _sendClipboardAltToggle, _sendClipboardShiftToggle)
            };

            for (int i = 0; i < _hotkeyControlGroups.Length; i++)
            {
                _hotkeyControlGroups[i].HotkeyChanged += GroupHotkeyChanged;
            }
        }

        public override void UpdateProfile(UserProfile profile)
        {
            _hotkeyControlGroups[EHotkey.EnableCapturing.ToInt32()].KeySetting = profile.EnableCapturingKeySetting;
            _hotkeyControlGroups[EHotkey.CapturingToggle.ToInt32()].KeySetting = profile.CapturingToggleKeySetting;
            _hotkeyControlGroups[EHotkey.Translate.ToInt32()].KeySetting = profile.TranslateKeySetting;
            _hotkeyControlGroups[EHotkey.SendClipboard.ToInt32()].KeySetting = profile.SendClipboardKeySetting;
        }

        public void SetGroupActive(EHotkey hotkey, bool active)
        {
            _hotkeyControlGroups[hotkey.ToInt32()].SetActive(active);
        }

        private void GroupHotkeyChanged(EHotkey type, SKeySetting setting)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            switch (type)
            {
                case EHotkey.EnableCapturing:
                    UserProfile.Current.EnableCapturingKeySetting = setting;
                    break;

                case EHotkey.CapturingToggle:
                    UserProfile.Current.CapturingToggleKeySetting = setting;
                    break;

                case EHotkey.Translate:
                    UserProfile.Current.TranslateKeySetting = setting;
                    break;

                case EHotkey.SendClipboard:
                    UserProfile.Current.SendClipboardKeySetting = setting;
                    break;
            }

            AppDataManager.SaveCurrentProfile();
        }
    }
}
