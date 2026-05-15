using System;
using System.Windows.Forms;

namespace CKG.Controls
{
    public class HotkeyControlGroup
    {
        public event Action<EHotkey, SKeySetting> HotkeyChanged = null;

        public SKeySetting KeySetting
        {
            get => new SKeySetting(Key, Ctrl, Alt, Shift);
            set => UpdateControls(value);
        }

        public EHotkey Type { get; private set; }
        public Keys Key { get; private set; }

        public bool Ctrl
        {
            get => _ctrlToggle.Checked;
            set => _ctrlToggle.Checked = value;
        }

        public bool Alt
        {
            get => _altToggle.Checked;
            set => _altToggle.Checked = value;
        }

        public bool Shift
        {
            get => _shiftToggle.Checked;
            set => _shiftToggle.Checked = value;
        }

        private Button _keyButton = null;
        private CheckBox _ctrlToggle = null;
        private CheckBox _altToggle = null;
        private CheckBox _shiftToggle = null;
        private bool _capturing = false;

        public HotkeyControlGroup(EHotkey type, Keys defaultKey,
            Button keyButton, CheckBox ctrlToggle, CheckBox altToggle, CheckBox shiftToggle)
        {
            Type = type;
            Key = defaultKey;
            _keyButton = keyButton;
            _ctrlToggle = ctrlToggle;
            _altToggle = altToggle;
            _shiftToggle = shiftToggle;
            _keyButton.Text = defaultKey.ToString();

            keyButton.Click += OnKeyButtonClicked;
            keyButton.PreviewKeyDown += KeyButton_PreviewKeyDown;
            keyButton.KeyDown += OnKeyButtonKeyDown;
            ctrlToggle.CheckedChanged += OnModifierChanged;
            altToggle.CheckedChanged += OnModifierChanged;
            shiftToggle.CheckedChanged += OnModifierChanged;
        }

        public void SetActive(bool active)
        {
            _keyButton.Enabled = active;
            _ctrlToggle.Enabled = active;
            _altToggle.Enabled = active;
            _shiftToggle.Enabled = active;
        }

        private void OnKeyButtonClicked(object sender, EventArgs e)
        {
            _capturing = true;

            _keyButton.Text = "...";
            _keyButton.Focus();
        }

        private void KeyButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (_capturing)
            {
                e.IsInputKey = true;
            }
        }

        private void OnKeyButtonKeyDown(object sender, KeyEventArgs e)
        {
            if (_capturing == false)
            {
                return;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Escape)
            {
                Key = Keys.None;
                _keyButton.Text = "None";
            }
            else
            {
                Key = e.KeyCode;
                _keyButton.Text = KeyDisplayHelper.GetDisplayName(Key);
            }

            _capturing = false;

            InvokeHotkeyChanged();
        }

        private void OnModifierChanged(object sender, EventArgs e)
        {
            InvokeHotkeyChanged();
        }

        private void InvokeHotkeyChanged()
        {
            HotkeyChanged?.Invoke(Type, new SKeySetting(Key, Ctrl, Alt, Shift));
        }

        private void UpdateControls(SKeySetting setting)
        {
            Key = setting.Key;
            Ctrl = setting.Ctrl;
            Alt = setting.Alt;
            Shift = setting.Shift;
            _keyButton.Text = KeyDisplayHelper.GetDisplayName(Key);
        }
    }
}
