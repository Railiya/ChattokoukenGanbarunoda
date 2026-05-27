using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CKG.Controls
{
    public class HotkeyGroupRowItem : TableGroupRowItem
    {
        public event Action<EHotkey, SKeySetting> HotkeyChanged = null;

        private const int COMPONENT_COUNT = 5;

        #region Public Properties

        public SKeySetting KeySetting
        {
            get => new SKeySetting(Key, Ctrl, Alt, Shift);
            set => UpdateControls(value);
        }

        [Browsable(true)]
        public EHotkey Type { get; set; }

        [Browsable(true)]
        public Keys Key
        {
            get => _key;
            set
            {
                _key = value;
                _keyButton.Text = KeyDisplayHelper.GetDisplayName(Key);
            }
        }

        [Browsable(true)]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                _nameLabel.ForeColor = value;
                _keyButton.ForeColor = value;
            }
        }

        [Browsable(true)]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                _nameLabel.Font = value;
                _keyButton.Font = value;
            }
        }

        [Browsable(true)]
        public string KeyText
        {
            get => _nameLabel.Text;
            set => _nameLabel.Text = value;
        }

        [Browsable(true)]
        public bool Ctrl
        {
            get => _ctrlToggle.Checked;
            set => _ctrlToggle.Checked = value;
        }

        [Browsable(true)]
        public bool Alt
        {
            get => _altToggle.Checked;
            set => _altToggle.Checked = value;
        }

        [Browsable(true)]
        public bool Shift
        {
            get => _shiftToggle.Checked;
            set => _shiftToggle.Checked = value;
        }

        public Label NameLabel => _nameLabel;

        #endregion

        private Label _nameLabel = null;
        private Button _keyButton = null;
        private CheckBox _ctrlToggle = null;
        private CheckBox _altToggle = null;
        private CheckBox _shiftToggle = null;

        private string _cachedKeyText = "";
        private SKeySetting _cachedKeySetting = default;
        private Keys _key = Keys.None;
        private bool _capturing = false;

        public HotkeyGroupRowItem()
        {
            //Set cell count
            base.CellWidths = new int[] { 100, 100, 50, 50, 50 };
        }

        public void SetActive(bool active)
        {
            _keyButton.Enabled = active;
            _ctrlToggle.Enabled = active;
            _altToggle.Enabled = active;
            _shiftToggle.Enabled = active;
        }

        protected override void OnBeforeCellRebuild()
        {
            _cachedKeyText = _nameLabel != null ? KeyText : "";
            _cachedKeySetting = new SKeySetting()
            {
                Key = _keyButton != null ? Key : Keys.None,
                Ctrl = _ctrlToggle != null ? Ctrl : false,
                Alt = _altToggle != null ? Alt : false,
                Shift = _shiftToggle != null ? Shift : false,
            };
        }

        protected override void OnCellRebuild(int length)
        {
            if (length != COMPONENT_COUNT)
            {
                return;
            }

            //Dispose previous controls
            _nameLabel?.Dispose();
            _keyButton?.Dispose();
            _ctrlToggle?.Dispose();
            _altToggle?.Dispose();
            _shiftToggle?.Dispose();

            //Create name label
            _nameLabel = new Label();
            _nameLabel.Dock = DockStyle.Fill;
            _nameLabel.Margin = Padding.Empty;
            _nameLabel.TextAlign = ContentAlignment.MiddleLeft;
            _nameLabel.AutoSize = false;
            base.GetCell(0).Controls.Add(_nameLabel);

            //Create key button
            _keyButton = new Button();
            _keyButton.Dock = DockStyle.Fill;
            _keyButton.Margin = Padding.Empty;
            _keyButton.TextAlign = ContentAlignment.MiddleCenter;
            _keyButton.AutoSize = false;
            base.GetCell(1).Padding = new Padding(2, 1, 2, 1);
            base.GetCell(1).Controls.Add(_keyButton);

            //Create ctrl toggle
            _ctrlToggle = new CheckBox();
            _ctrlToggle.Dock = DockStyle.Fill;
            _ctrlToggle.Margin = Padding.Empty;
            _ctrlToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _ctrlToggle.AutoSize = false;
            _ctrlToggle.FlatStyle = FlatStyle.Flat;
            base.GetCell(2).Controls.Add(_ctrlToggle);

            //Create alt toggle
            _altToggle = new CheckBox();
            _altToggle.Dock = DockStyle.Fill;
            _altToggle.Margin = Padding.Empty;
            _altToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _altToggle.AutoSize = false;
            _altToggle.FlatStyle = FlatStyle.Flat;
            base.GetCell(3).Controls.Add(_altToggle);

            //Create shift toggle
            _shiftToggle = new CheckBox();
            _shiftToggle.Dock = DockStyle.Fill;
            _shiftToggle.Margin = Padding.Empty;
            _shiftToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _shiftToggle.AutoSize = false;
            _shiftToggle.FlatStyle = FlatStyle.Flat;
            base.GetCell(4).Controls.Add(_shiftToggle);

            //Set previous setting
            _nameLabel.Text = _cachedKeyText;
            UpdateControls(_cachedKeySetting);

            //Create events
            _keyButton.Click += OnKeyButtonClicked;
            _keyButton.PreviewKeyDown += KeyButton_PreviewKeyDown;
            _keyButton.KeyDown += OnKeyButtonKeyDown;
            _ctrlToggle.CheckedChanged += OnModifierChanged;
            _altToggle.CheckedChanged += OnModifierChanged;
            _shiftToggle.CheckedChanged += OnModifierChanged;
        }

        #region Private Control Events

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

        #endregion

        private void UpdateControls(SKeySetting setting)
        {
            Key = setting.Key;
            Ctrl = setting.Ctrl;
            Alt = setting.Alt;
            Shift = setting.Shift;
            _keyButton.Text = KeyDisplayHelper.GetDisplayName(Key);
        }

        private void InvokeHotkeyChanged()
        {
            HotkeyChanged?.Invoke(Type, KeySetting);
        }
    }
}
