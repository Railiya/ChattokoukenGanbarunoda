using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CKG.Controls;
using CKG.Input;

namespace CKG.Forms
{
    public partial class OverlayForm : Form
    {
        #region Private Definitions

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

        private record SAnchor2D(EAnchorH Horizontal, EAnchorV Vertical);

        private enum EAnchorH
        {
            Left,
            Center,
            Right
        }

        private enum EAnchorV
        {
            Top,
            Middle,
            Bottom
        }

        #endregion

        #region Private Const Members

        private static readonly Dictionary<ContentAlignment, SAnchor2D> ANCHOR_TABLE = new Dictionary<ContentAlignment, SAnchor2D>()
        {
            { ContentAlignment.TopLeft,      new SAnchor2D(EAnchorH.Left,   EAnchorV.Top)    },
            { ContentAlignment.TopCenter,    new SAnchor2D(EAnchorH.Center, EAnchorV.Top)    },
            { ContentAlignment.TopRight,     new SAnchor2D(EAnchorH.Right,  EAnchorV.Top)    },
            { ContentAlignment.MiddleLeft,   new SAnchor2D(EAnchorH.Left,   EAnchorV.Middle) },
            { ContentAlignment.MiddleCenter, new SAnchor2D(EAnchorH.Center, EAnchorV.Middle) },
            { ContentAlignment.MiddleRight,  new SAnchor2D(EAnchorH.Right,  EAnchorV.Middle) },
            { ContentAlignment.BottomLeft,   new SAnchor2D(EAnchorH.Left,   EAnchorV.Bottom) },
            { ContentAlignment.BottomCenter, new SAnchor2D(EAnchorH.Center, EAnchorV.Bottom) },
            { ContentAlignment.BottomRight,  new SAnchor2D(EAnchorH.Right,  EAnchorV.Bottom) },
        };

        private static readonly Dictionary<ECapturingState, TextInfo> STATE_TEXT_TABLE = new Dictionary<ECapturingState, TextInfo>()
        {
            { ECapturingState.Disabled,     new TextInfo("[CKG OFF]", Color.FromArgb(200, 200, 200)) },
            { ECapturingState.Idle,         new TextInfo("[IDLE]", Color.FromArgb(255, 255, 255)) },
            { ECapturingState.Capturing,    new TextInfo("[CAPTURING]", Color.FromArgb(0, 200, 255)) },
            { ECapturingState.Buffered,     new TextInfo("[BUFFERED]", Color.FromArgb(255, 200, 0)) },
            { ECapturingState.Translating,  new TextInfo(">> TRANSLATING", Color.FromArgb(255, 100, 0)) },
            { ECapturingState.Translated,   new TextInfo("[READY]", Color.FromArgb(0, 255, 50)) },
            { ECapturingState.Failed,       new TextInfo("[FAILED]", Color.FromArgb(255, 50, 50)) }
        };

        private static readonly Dictionary<EInputCharacter, string> INPUT_MODE_TEXT_TABLE = new Dictionary<EInputCharacter, string>()
        {
            { EInputCharacter.Alphabet,  "A" },
            { EInputCharacter.Hangul,    "가" }
        };

        #endregion

        public static IntPtr HandlePtr { get; private set; }

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
        private Label _inputCharacterLabel = null;
        private Panel _verticalLine = null;
        private TextBox _inputField = null;
        private Control[] _components = null;

        private ContentAlignment _anchor = ContentAlignment.TopLeft;
        private int _horizontalMargin = 2;
        private int _verticalLineWidth = 2;
        private int _verticalLinePadding = 3;
        private int _offsetX = 0;
        private int _offsetY = 0;
        private int _lastFontSize = 0;
        private bool _lockRectUpdate = false;

        private ECapturingState _currentState = ECapturingState.Idle;
        private bool _showInput = false;

        #region Contructor and Disposer

        public OverlayForm()
        {
            InitializeComponent();

            HandlePtr = this.Handle;
            Padding = new Padding(1);

            Font font = new Font("Segoe UI", 16F, FontStyle.Bold);

            // Status Label
            _statusLabel = new Label();
            _statusLabel.AutoSize = true;
            _statusLabel.Font = font;
            _statusLabel.ForeColor = Color.White;
            _statusLabel.BackColor = Color.Transparent;
            _statusLabel.Location = new Point(12, 12);
            Controls.Add(_statusLabel);

            // Vertical Line
            _verticalLine = new Panel();
            _verticalLine.BackColor = Color.White;
            _verticalLine.Size = new Size(_verticalLineWidth, 10);
            Controls.Add(_verticalLine);

            // Input Mode Label
            _inputCharacterLabel = new Label();
            _inputCharacterLabel.AutoSize = true;
            _inputCharacterLabel.Font = font;
            _inputCharacterLabel.ForeColor = Color.White;
            _inputCharacterLabel.BackColor = Color.Transparent;
            _inputCharacterLabel.Text = "A";
            Controls.Add(_inputCharacterLabel);

            // Input field
            _inputField = new TextBox();
            _inputField.Font = font;
            _inputField.BorderStyle = BorderStyle.None;
            _inputField.ForeColor = Color.White;
            _inputField.BackColor = Color.Black;
            _inputField.Text = "";
            _inputField.TextAlign = HorizontalAlignment.Center;
            Controls.Add(_inputField);

            _components = new Control[]
            {
                _statusLabel,
                _verticalLine,
                _inputCharacterLabel,
                _inputField
            };

            OverlayPanel.OnOverlaySettingChanged += OnOverlaySettingChanged;
            AppController.OnCapturingStateChanged += OnCapturingStateChanged;
            AppController.OnInputCharacterChanged += OnInputCharacterChanged;
            GeneralPanel.OnInputMethodChanged += OnInputMethodChanged;
            CapturingHandler.OnInputToggleBefore += OnInputToggleBefore;
            CapturingHandler.OnInputToggle += OnInputToggle;
            _inputField.TextChanged += _inputField_TextChanged;
        }

        private void Release()
        {
            HandlePtr = IntPtr.Zero;

            OverlayPanel.OnOverlaySettingChanged -= OnOverlaySettingChanged;
            AppController.OnCapturingStateChanged -= OnCapturingStateChanged;
            AppController.OnInputCharacterChanged -= OnInputCharacterChanged;
            GeneralPanel.OnInputMethodChanged -= OnInputMethodChanged;
            CapturingHandler.OnInputToggleBefore -= OnInputToggleBefore;
            CapturingHandler.OnInputToggle -= OnInputToggle;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            _lockRectUpdate = true;
            OnOverlaySettingChanged();
            OnCapturingStateChanged(ECapturingState.Disabled);
            OnInputCharacterChanged((EInputCharacter)UserProfile.Current.DefaultInputCharacterIndex);
            OnInputMethodChanged((EInputMethod)UserProfile.Current.InputMethodIndex);
            _lockRectUpdate = false;

            UpdateRect();
        }

        private void OverlayForm_Shown(object sender, EventArgs e)
        {
            TopMost = true;
        }

        #endregion

        #region Private Callbacks

        private void OnOverlaySettingChanged()
        {
            UserProfile profile = UserProfile.Current;

            _anchor = (ContentAlignment)profile.OverlayAnchorIndex;
            _offsetX = profile.OverlayOffsetX;
            _offsetY = profile.OverlayOffsetY;
            UpdateOpacity(_currentState == ECapturingState.Capturing && _showInput);

            if (profile.OverlayFontSize != _lastFontSize)
            {
                Font font = new Font("Segoe UI", profile.OverlayFontSize, FontStyle.Bold);

                _statusLabel.Font = font;
                _inputCharacterLabel.Font = font;
                _inputField.Font = font;
            }

            UpdateRect();
        }

        private void OnCapturingStateChanged(ECapturingState state)
        {
            _currentState = state;

            TextInfo info = STATE_TEXT_TABLE[state];
            _statusLabel.Text = info.Text;
            _statusLabel.ForeColor = info.Color;

            bool activeInput = state == ECapturingState.Capturing && _showInput;
            _verticalLine.Visible = _showInput == false || activeInput;

            if (state == ECapturingState.Disabled)
            {
                _inputField.Text = "";
                _inputField.Visible = false;
            }

            UpdateOpacity(activeInput);
            UpdateRect();
        }

        private void OnInputCharacterChanged(EInputCharacter character)
        {
            _inputCharacterLabel.Text = INPUT_MODE_TEXT_TABLE[character];
            UpdateRect();
        }

        private void OnInputMethodChanged(EInputMethod method)
        {
            //The state will be IDLE on this time
            _showInput = method == EInputMethod.OverlayInput;

            _inputField.Text = "";
            _inputField.Enabled = _showInput;
            _inputField.Visible = false;
            _verticalLine.Visible = !_showInput;
            _inputCharacterLabel.Visible = !_showInput;
            UpdateRect();
        }

        private void OnInputToggleBefore(bool toggle)
        {
            int exStyle = GetWindowLong(Handle, -20); // GWL_EXSTYLE

            if (toggle)
            {
                exStyle &= ~0x08000000; // Remove WS_EX_NOACTIVATE
                SetWindowLong(Handle, -20, exStyle);
            }
            else
            {
                exStyle |= 0x08000000; // Restore WS_EX_NOACTIVATE
                SetWindowLong(Handle, -20, exStyle);
            }
        }

        private string OnInputToggle(bool toggle, bool invokeFlush)
        {
            string result = null;

            _inputField.Visible = toggle;
            _inputField.Text = "";

            UpdateRect();

            if (toggle)
            {
                Activate();
                _inputField.Select();
            }
            else if (invokeFlush)
            {
                result = _inputField.Text;
                _inputField.Text = "";
            }

            return result;
        }

        private void _inputField_TextChanged(object sender, EventArgs e)
        {
            Logger.Write(_inputField.Text);
            UpdateRect();
        }

        #endregion

        #region Private Functions

        private void UpdateOpacity(bool activeInput)
        {
            if (activeInput)
            {
                Opacity = 1;
            }
            else
            {
                Opacity = UserProfile.Current.OverlayOpacity * 0.01d;
            }
        }

        private void UpdateRect()
        {
            if (_lockRectUpdate)
            {
                return;
            }

            SuspendLayout();

            SAnchor2D anchor = ANCHOR_TABLE[_anchor];
            int height = UpdateComponentSize();
            int width = UpdateComponentPosition(height);

            UpdateFormRect(width, height, anchor);

            ResumeLayout(true);
            Opacity = Opacity; //Force update layout. Do not remvoe it.
        }

        private int UpdateComponentSize()
        {
            Size statusSize = TextRenderer.MeasureText(_statusLabel.Text, _statusLabel.Font);
            int height = 0;

            if (_showInput) //Set input field size
            {
                Size inputFieldSize = TextRenderer.MeasureText(_inputField.Text, _inputField.Font);
                height = Math.Max(statusSize.Height, inputFieldSize.Height);

                _inputField.Size = new Size(inputFieldSize.Width, height);
            }
            else //Set input character label size
            {
                Size inputCharacterSize = TextRenderer.MeasureText(_inputCharacterLabel.Text, _inputCharacterLabel.Font);
                height = Math.Max(statusSize.Height, inputCharacterSize.Height);

                _inputCharacterLabel.Size = new Size(inputCharacterSize.Width, height);
            }

            //Set status label size
            //Vertical line does not updated in this time, it updated on UpdateComponentPosition()
            _statusLabel.Size = new Size(statusSize.Width, height);

            return height + Padding.Top + Padding.Bottom;
        }

        private int UpdateComponentPosition(int height)
        {
            int currentX = Padding.Left;

            //Update controls
            foreach (Control control in _components)
            {
                if (control.Visible == false)
                {
                    continue;
                }

                control.Location = new Point(currentX, Padding.Top);
                currentX += control.Width + _horizontalMargin;
            }

            //Update vertical line
            int lineHeight = height - _verticalLinePadding * 2;

            _verticalLine.Size = new Size(_verticalLineWidth, lineHeight);
            _verticalLine.Location = new Point(_verticalLine.Location.X, _verticalLinePadding);

            return currentX - _horizontalMargin + Padding.Right;
        }

        private void UpdateFormRect(int width, int height, SAnchor2D anchor)
        {
            ClientSize = new Size(width, height);
            Rectangle area = Screen.PrimaryScreen.WorkingArea;

            int x = anchor.Horizontal switch
            {
                EAnchorH.Center => (area.Width - Width) / 2 + _offsetX,
                EAnchorH.Right => area.Width - Width - _offsetX,
                _ => _offsetX
            };

            int y = anchor.Vertical switch
            {
                EAnchorV.Middle => (area.Height - Height) / 2 + _offsetY,
                EAnchorV.Bottom => area.Height - Height - _offsetY,
                _ => _offsetY
            };

            Location = new Point(x, y);
        }

        #endregion

        #region Win32

        /* Used For Overlay Input */

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        #endregion
    }
}
