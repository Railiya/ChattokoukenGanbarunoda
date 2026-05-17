using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CKG.Forms
{
    public partial class OverlayForm : Form
    {
        private class TextInfo
        {
            public string Text;
            public Color Color;

            public TextInfo(string text, Color color)
            {
                Text = text;
                Color = color;
            }
        }

        private static readonly Dictionary<ECapturingState, TextInfo> STATE_TEXT_TABLE = new Dictionary<ECapturingState, TextInfo>()
        {
            { ECapturingState.Disabled, new TextInfo("[CKG OFF]", Color.FromArgb(200, 200, 200)) },
            { ECapturingState.Idle, new TextInfo("[IDLE]", Color.FromArgb(255, 255, 255)) },
            { ECapturingState.Capturing, new TextInfo("[CAPTURING]", Color.FromArgb(0, 200, 255)) },
            { ECapturingState.Buffered, new TextInfo("[BUFFERED]", Color.FromArgb(255, 200, 0)) },
            { ECapturingState.Translating, new TextInfo(">> TRANSLATING", Color.FromArgb(255, 100, 0)) },
            { ECapturingState.Translated, new TextInfo("[READY]", Color.FromArgb(0, 255, 50)) },
            { ECapturingState.Failed, new TextInfo("[FAILED]", Color.FromArgb(255, 50, 50)) }
        };

        private static readonly Dictionary<EInputMode, string> INPUT_MODE_TEXT_TABLE = new Dictionary<EInputMode, string>()
        {
            { EInputMode.Alphabet, "A" },
            { EInputMode.Hangul, "가" }
        };

        protected override bool ShowWithoutActivation => true;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT (Prevent blocking click)
                cp.ExStyle |= 0x00000080; // WS_EX_TOOLWINDOW (Hide Alt+Tab)
                cp.ExStyle |= 0x00080000; // WS_EX_LAYERED
                cp.ExStyle |= 0x08000000; // WS_EX_NOACTIVATE
                return cp;
            }
        }

        private Label _statusLabel = null;
        private Label _inputModeLabel = null;
        private Panel _verticalLine = null;

        private ContentAlignment _anchor = ContentAlignment.TopLeft;
        private int _horizontalMargin = 2;
        private int _verticalLineWidth = 2;
        private int _offsetX = 0;
        private int _offsetY = 0;

        public OverlayForm()
        {
            InitializeComponent();

            Padding = new Padding(1);

            // Status Label
            _statusLabel = new Label();
            _statusLabel.AutoSize = true;
            _statusLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            _statusLabel.ForeColor = Color.White;
            _statusLabel.BackColor = Color.Transparent;
            _statusLabel.Location = new Point(12, 12);
            Controls.Add(_statusLabel);

            // Vertical Line
            _verticalLine = new Panel();
            _verticalLine.BackColor = Color.White;
            Controls.Add(_verticalLine);

            // Input Mode Label
            _inputModeLabel = new Label();
            _inputModeLabel.AutoSize = true;
            _inputModeLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            _inputModeLabel.ForeColor = Color.White;
            _inputModeLabel.BackColor = Color.Transparent;
            _inputModeLabel.Text = "A";
            Controls.Add(_inputModeLabel);

            OnOverlaySettingChanged();
            OnCapturingStateChanged(ECapturingState.Disabled);
            OnInputModeChanged((EInputMode)UserProfile.Current.DefaultInputModeIndex);

            MainForm.OnOverlaySettingChanged += OnOverlaySettingChanged;
            AppController.OnCapturingStateChanged += OnCapturingStateChanged;
            AppController.OnInputModeChanged += OnInputModeChanged;
        }

        private void Release()
        {
            MainForm.OnOverlaySettingChanged -= OnOverlaySettingChanged;
            AppController.OnCapturingStateChanged -= OnCapturingStateChanged;
            AppController.OnInputModeChanged -= OnInputModeChanged;
        }

        private void OverlayForm_Shown(object sender, EventArgs e)
        {
            TopMost = true;
        }

        #region Private Callbacks

        private void OnOverlaySettingChanged()
        {
            Font font = new Font("Segoe UI", UserProfile.Current.OverlayFontSize, FontStyle.Bold);

            _anchor = (ContentAlignment)UserProfile.Current.OverlayAnchorIndex;
            _offsetX = UserProfile.Current.OverlayOffsetX;
            _offsetY = UserProfile.Current.OverlayOffsetY;
            Opacity = UserProfile.Current.OverlayOpacity * 0.01d;

            _statusLabel.Font = font;
            _inputModeLabel.Font = font;
            UpdateRect();
        }

        private void OnCapturingStateChanged(ECapturingState state)
        {
            TextInfo info = STATE_TEXT_TABLE[state];
            _statusLabel.Text = info.Text;
            _statusLabel.ForeColor = info.Color;
            UpdateRect();
        }

        private void OnInputModeChanged(EInputMode mode)
        {
            _inputModeLabel.Text = INPUT_MODE_TEXT_TABLE[mode];
            UpdateRect();
        }

        #endregion

        #region Private Functions

        private void UpdateRect()
        {
            Size statusSize = TextRenderer.MeasureText(_statusLabel.Text, _statusLabel.Font);
            Size inputModeSize = TextRenderer.MeasureText(_inputModeLabel.Text, _inputModeLabel.Font);
            int contentHeight = Math.Max(statusSize.Height, inputModeSize.Height);
            int width = Padding.Left + statusSize.Width + _horizontalMargin +
                _verticalLineWidth + _horizontalMargin + inputModeSize.Width + Padding.Right;
            int height = Padding.Top + contentHeight + Padding.Bottom;

            ClientSize = new Size(width, height);

            int currentX = Padding.Left;

            // Status Label
            _statusLabel.Location = new Point(currentX, Padding.Top + (contentHeight - statusSize.Height) / 2);
            currentX += statusSize.Width + _horizontalMargin;

            // Vertical Line
            int lineHeight = (int)(contentHeight * 0.8f);

            _verticalLine.Location = new Point(currentX, Padding.Top + (contentHeight - lineHeight) / 2);
            _verticalLine.Size = new Size(_verticalLineWidth, lineHeight);
            currentX += _verticalLineWidth + _horizontalMargin;

            // Input Mode Label
            _inputModeLabel.Location = new Point(currentX, Padding.Top + (contentHeight - inputModeSize.Height) / 2);

            //Update form position
            Rectangle area = Screen.PrimaryScreen.WorkingArea;
            int x = 0;
            int y = 0;

            switch (_anchor)
            {
                case ContentAlignment.TopLeft:
                    x = _offsetX;
                    y = _offsetY;
                    break;

                case ContentAlignment.TopCenter:
                    x = (area.Width - Width) / 2 + _offsetX;
                    y = _offsetY;
                    break;

                case ContentAlignment.TopRight:
                    x = area.Width - Width - _offsetX;
                    y = _offsetY;
                    break;

                case ContentAlignment.MiddleLeft:
                    x = _offsetX;
                    y = (area.Height - Height) / 2 + _offsetY;
                    break;

                case ContentAlignment.MiddleRight:
                    x = area.Width - Width - _offsetX;
                    y = (area.Height - Height) / 2 + _offsetY;
                    break;

                case ContentAlignment.BottomLeft:
                    x = _offsetX;
                    y = area.Height - Height - _offsetY;
                    break;

                case ContentAlignment.BottomCenter:
                    x = (area.Width - Width) / 2 + _offsetX;
                    y = area.Height - Height - _offsetY;
                    break;

                case ContentAlignment.BottomRight:
                    x = area.Width - Width - _offsetX;
                    y = area.Height - Height - _offsetY;
                    break;
            }

            Location = new Point(x, y);
        }

        #endregion
    }
}
