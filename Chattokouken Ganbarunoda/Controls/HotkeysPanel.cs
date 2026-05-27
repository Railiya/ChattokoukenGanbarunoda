using System;
using CKG.Forms;

namespace CKG.Controls
{
    public partial class HotkeysPanel : SettingPanel
    {
        public event Action<EHotkey, SKeySetting> OnHotkeyChanged = null;

        protected override string LocalizationKey => "Hotkeys";

        private HotkeyGroupRowItem[] _hotkeyGroups = null;

        public HotkeysPanel()
        {
            InitializeComponent();

            _hotkeyGroups = new HotkeyGroupRowItem[] 
            {
                _enableCapturingKeyGroup,
                _chatToggleKeyGroup,
                _requestTranslateKeyGroup,
                _sendClipboardKeyGroup
            };

            for (int i = 0; i < _hotkeyGroups.Length; i++)
            {
                _hotkeyGroups[i].HotkeyChanged += GroupHotkeyChanged;
            }
        }

        public override void UpdateProfile(UserProfile profile)
        {
            _hotkeyGroups[EHotkey.EnableCapturing.ToInt32()].KeySetting = profile.EnableCapturingKeySetting;
            _hotkeyGroups[EHotkey.ChatToggle.ToInt32()].KeySetting = profile.ChatToggleKeySetting;
            _hotkeyGroups[EHotkey.RequestTranslate.ToInt32()].KeySetting = profile.TranslateKeySetting;
            _hotkeyGroups[EHotkey.SendClipboard.ToInt32()].KeySetting = profile.SendClipboardKeySetting;
        }

        public void SetGroupActive(EHotkey hotkey, bool active)
        {
            _hotkeyGroups[hotkey.ToInt32()].SetActive(active);
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

                case EHotkey.ChatToggle:
                    UserProfile.Current.ChatToggleKeySetting = setting;
                    break;

                case EHotkey.RequestTranslate:
                    UserProfile.Current.TranslateKeySetting = setting;
                    break;

                case EHotkey.SendClipboard:
                    UserProfile.Current.SendClipboardKeySetting = setting;
                    break;
            }

            AppDataManager.SaveCurrentProfile();
            OnHotkeyChanged?.Invoke(type, setting);
        }
    }
}
