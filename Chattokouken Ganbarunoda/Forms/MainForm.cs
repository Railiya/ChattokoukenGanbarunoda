using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CKG.Controls;
using CKG.Translator;
using CKG.Input;

namespace CKG.Forms
{
    public partial class MainForm : Form
    {
        private const string PROJECT_NAME = "Chattokouken Ganbarunoda!!";

        public static event Action OnOverlaySettingChanged = null;

        #region Private Members

        private ContextMenuStrip _trayMenu = null;
        private NotifyIcon _trayIcon = null;

        private List<Control> _overlayActiveGroup = null;
        private List<Control> _notificationActiveGroup = null;
        private HotkeyControlGroup _enableCapturingKeyGroup = null;
        private HotkeyControlGroup _capturingToggleKeyGroup = null;
        private HotkeyControlGroup _translateKeyGroup = null;
        private HotkeyControlGroup _sendClipboardKeyGroup = null;

        private TranslationService _translationService = null;
        private OverlayForm _overlayForm = null;

        private bool _isControlEventNotifyLocked = false;
        private bool _hasShownTrayHint = false;
        private bool _isExitRequested;

        #endregion

        #region Constructor and Disposer

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(TranslationService translationService)
        {
            _translationService = translationService;

            InitializeComponent();
            InitializeControls();
        }

        private async void InitializeControls()
        {
            Text = $"{PROJECT_NAME} (v{Application.ProductVersion})";

            _isControlEventNotifyLocked = true;

            //Create system tray
            _trayMenu = new ContextMenuStrip();
            _trayMenu.Items.Add("Show", null, ShowProgram);
            _trayMenu.Items.Add("Exit", null, ExitProgram);

            _trayIcon = new NotifyIcon();
            _trayIcon.Icon = this.Icon;
            _trayIcon.Text = PROJECT_NAME;
            _trayIcon.Visible = true;
            _trayIcon.ContextMenuStrip = _trayMenu;
            _trayIcon.DoubleClick += ShowProgram;

            //Set group
            _overlayActiveGroup = new List<Control>();
            _notificationActiveGroup = new List<Control>();
            _enableCapturingKeyGroup = new HotkeyControlGroup(EHotkey.EnableCapturing, Keys.Scroll,
                _enableCapturingKeyButton, _enableCapturingCtrlToggle, _enableCapturingAltToggle, _enableCapturingShiftToggle);
            _capturingToggleKeyGroup = new HotkeyControlGroup(EHotkey.CapturingToggle, Keys.Enter,
                _capturingToggleKeyButton, _capturingToggleCtrlToggle, _capturingToggleAltToggle, _capturingToggleShiftToggle);
            _translateKeyGroup = new HotkeyControlGroup(EHotkey.Translate, Keys.F9,
                _translateKeyButton, _translateCtrlToggle, _translateAltToggle, _translateShiftToggle);
            _sendClipboardKeyGroup = new HotkeyControlGroup(EHotkey.SendClipboard, Keys.OemPipe,
                _sendClipboardKeyButton, _sendClipboardCtrlToggle, _sendClipboardAltToggle, _sendClipboardShiftToggle);

            _overlayActiveGroup.Add(_overlayAnchorSelector);
            _overlayActiveGroup.Add(_overlayOffsetXField);
            _overlayActiveGroup.Add(_overlayOffsetYField);
            _overlayActiveGroup.Add(_overlayFontSizeField);
            _overlayActiveGroup.Add(_overlayOpacitySlider);
            _notificationActiveGroup.Add(_capturingStartNotifyToggle);
            _notificationActiveGroup.Add(_translationCompletedNotifyToggle);
            _notificationActiveGroup.Add(_notificationVolumeSlider);

            SetLanguageSelectors();

            //Load first profile or create new
            LoadSettings(1);

            //Set control events
            _overlayAnchorSelector.OnAnchorChanged += _overlayAnchorSelector_AnchorChanged;
            _enableCapturingKeyGroup.HotkeyChanged += _enableCapturingKeyGroup_HotkeyChanged;
            _capturingToggleKeyGroup.HotkeyChanged += _capturingToggleKeyGroup_HotkeyChanged;
            _translateKeyGroup.HotkeyChanged += _translateKeyGroup_HotkeyChanged;
            _sendClipboardKeyGroup.HotkeyChanged += _sendClipboardKeyGroup_HotkeyChanged;

            _isControlEventNotifyLocked = false;

            //Set active overlay after profile loaded
            SetActiveOverlay(UserProfile.Current.OverlayEnabled);

            //Check new update release
            SUpdateCheckResult updateCheck = await GithubRepository.CheckForUpdatesAsync();

            if (updateCheck.isLatest == false && string.IsNullOrEmpty(updateCheck.latestVersion) == false)
            {
                DialogResult dialogResult = MessageBox.Show(
                    $"Current Version: {updateCheck.currentVersion}\n" +
                    $"Latest Version: {updateCheck.latestVersion}\n\n" +
                    $"Would you like to open the release page?",
                    "New Version Available",
                    MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    GithubRepository.OpenGithubPage();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isExitRequested == false)
            {
                e.Cancel = true;
                Hide();

                if (_hasShownTrayHint == false)
                {
                    _trayIcon.ShowBalloonTip(2000, "Chattokouken Ganbarunoda!!",
                        "The program is running on system tray", ToolTipIcon.Info);
                    _hasShownTrayHint = true;
                }

                return;
            }
        }

        #endregion

        #region Private Menu Strip Events

        private void _githubMenuItem_Click(object sender, EventArgs e)
        {
            GithubRepository.OpenGithubPage();
        }

        private void _exitMenuItem_Click(object sender, EventArgs e)
        {
            ExitProgram(sender, e);
        }

        #endregion

        #region Private System Tray Events

        private void ShowProgram(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void ExitProgram(object sender, EventArgs e)
        {
            _isExitRequested = true;
            _overlayForm?.Dispose();
            _trayIcon.Visible = false;
            _trayIcon.Dispose();

            Application.Exit();
        }

        #endregion

        #region Private Control Events (General)

        private void _startTranslateToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.StartTranslateOnBuffered = _startTranslateToggle.Checked;
            _translateKeyGroup.SetActive(!UserProfile.Current.StartTranslateOnBuffered);
            ProfileManager.SaveCurrentProfile();
        }

        private void _autoSendMessageToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.AutoSendMessageOnTranslated = _autoSendMessageToggle.Checked;
            _sendClipboardKeyGroup.SetActive(!UserProfile.Current.AutoSendMessageOnTranslated);
            ProfileManager.SaveCurrentProfile();
        }

        private void _inputMethodSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.OutputMethodIndex = _outputMethodSelector.SelectedIndex;
            ProfileManager.SaveCurrentProfile();
        }

        private void _defaultInputModeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.DefaultInputModeIndex = _defaultInputModeSelector.SelectedIndex;
            ProfileManager.SaveCurrentProfile();
        }

        #endregion

        #region Private Control Events (Translation)

        private void _modelSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.ModelIndex = _modelSelector.SelectedIndex;

            _apiKeyField.Text = "";
            _glossaryIdField.Text = "";
            ProfileManager.SaveCurrentProfile();
        }

        private void _apiKeyField_TextChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.APIKey = _apiKeyField.Text;
            ProfileManager.SaveCurrentProfile();
            _translationService.InitializeTranslator();
        }

        private void _glossaryIdField_TextChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.GlossaryId = _glossaryIdField.Text;
            ProfileManager.SaveCurrentProfile();
        }

        private void _glossarySelectButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserProfile.Current.APIKey))
            {
                MessageBox.Show("You have to input api key first");
                return;
            }

            ETranslatorModel model = (ETranslatorModel)UserProfile.Current.ModelIndex;
            GlossarySelectForm glossarySelectForm = new GlossarySelectForm(_translationService, OnKeySelect);
            glossarySelectForm.ShowDialog(this);

            void OnKeySelect(GlossaryInfo glossary)
            {
                if (glossary != null)
                {
                    _translationService.SetGlossary(glossary);
                    _glossaryIdField.Text = glossary.Id;
                }
                else
                {
                    _translationService.SetGlossary(null);
                    _glossaryIdField.Text = "";
                }
            }
        }

        private void _sourceLanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.SourceLanguageIndex = _sourceLanguageSelector.SelectedIndex;
            ProfileManager.SaveCurrentProfile();
        }

        private void _destinationLanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.DestinationLanguageIndex = _destinationLanguageSelector.SelectedIndex;
            ProfileManager.SaveCurrentProfile();
        }

        private void _translationFormatField_TextChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.TranslationFormat = _translationFormatField.Text;
            ProfileManager.SaveCurrentProfile();
        }

        private void _requestTimeoutField_ValueChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.RequestTimeout = (int)_requestTimeoutField.Value;
            ProfileManager.SaveCurrentProfile();
            _translationService.UpdateTimeout();
        }

        #endregion

        #region Private Control Events (Overlay)

        private void _overlayEnabledToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.OverlayEnabled = _overlayEnabledToggle.Checked;
            _overlayActiveGroup.SetControlGroupActive(UserProfile.Current.OverlayEnabled);

            ProfileManager.SaveCurrentProfile();
            SetActiveOverlay(UserProfile.Current.OverlayEnabled);

            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayAnchorSelector_AnchorChanged(ContentAlignment alignment)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.OverlayAnchorIndex = (int)_overlayAnchorSelector.SelectedAnchor;
            ProfileManager.SaveCurrentProfile();

            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayOffsetXField_ValueChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.OverlayOffsetX = (int)_overlayOffsetXField.Value;
            ProfileManager.SaveCurrentProfile();

            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayOffsetYField_ValueChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.OverlayOffsetY = (int)_overlayOffsetYField.Value;
            ProfileManager.SaveCurrentProfile();

            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayFontSizeField_ValueChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.OverlayFontSize = (int)_overlayFontSizeField.Value;
            ProfileManager.SaveCurrentProfile();

            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayOpacitySlider_ValueChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.OverlayOpacity = (int)_overlayOpacitySlider.Value;
            _overlayOpacityField.Text = UserProfile.Current.OverlayOpacity.ToString();
            ProfileManager.SaveCurrentProfile();

            OnOverlaySettingChanged?.Invoke();
        }

        #endregion

        #region Private Control Events (Notification)

        private void _notificationEnabledToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.NotificationEnabled = _notificationEnabledToggle.Checked;
            _notificationActiveGroup.SetControlGroupActive(UserProfile.Current.NotificationEnabled);

            ProfileManager.SaveCurrentProfile();
        }

        private void _capturingStartNotifyToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.NotifyOnCapturingStart = _capturingStartNotifyToggle.Checked;
            ProfileManager.SaveCurrentProfile();
        }

        private void _translationCompletedNotifyToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.NotifyOnTranslationCompleted = _translationCompletedNotifyToggle.Checked;
            ProfileManager.SaveCurrentProfile();
        }

        private void _translationFailedNotifyToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.NotifyOnTranslationFailed = _translationFailedNotifyToggle.Checked;
            ProfileManager.SaveCurrentProfile();
        }

        private void _notificationVolumeSlider_ValueChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.NotificationVolume = (int)_notificationVolumeSlider.Value;
            _notificationVolumeField.Text = UserProfile.Current.NotificationVolume.ToString();
            ProfileManager.SaveCurrentProfile();
        }

        #endregion

        #region Private Control Events (Hotkeys)

        private void _enableCapturingKeyGroup_HotkeyChanged(EHotkey Type, SKeySetting setting)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.EnableCapturingKeySetting = _enableCapturingKeyGroup.KeySetting;
            ProfileManager.SaveCurrentProfile();
        }

        private void _capturingToggleKeyGroup_HotkeyChanged(EHotkey Type, SKeySetting setting)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.CapturingToggleKeySetting = _capturingToggleKeyGroup.KeySetting;
            ProfileManager.SaveCurrentProfile();
        }

        private void _translateKeyGroup_HotkeyChanged(EHotkey Type, SKeySetting setting)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.TranslateKeySetting = _translateKeyGroup.KeySetting;
            ProfileManager.SaveCurrentProfile();
        }

        private void _sendClipboardKeyGroup_HotkeyChanged(EHotkey Type, SKeySetting setting)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.SendClipboardKeySetting = _sendClipboardKeyGroup.KeySetting;
            ProfileManager.SaveCurrentProfile();
        }

        #endregion

        #region Private Control Events (Advanced)

        private void _inputTimeoutField_ValueChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.InputTimeout = (int)_inputTimeoutField.Value;
            ProfileManager.SaveCurrentProfile();
        }

        private void _debugEchoModeToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.DebugEchoMode = _debugEchoModeToggle.Checked;
            ProfileManager.SaveCurrentProfile();
        }

        private void _writeLogFileToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.WriteLogFile = _writeLogFileToggle.Checked;
            ProfileManager.SaveCurrentProfile();
        }

        private void _executeOnWindowStartToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.ExecuteOnWindowStart = _executeOnWindowStartToggle.Checked;
            ProfileManager.SaveCurrentProfile();
        }

        #endregion

        #region Private Functions

        private async void LoadSettings(int number)
        {
            UserProfile profile = UserProfile.Current;

            //Update controls
            _startTranslateToggle.Checked = profile.StartTranslateOnBuffered;
            _autoSendMessageToggle.Checked = profile.AutoSendMessageOnTranslated;
            _outputMethodSelector.SelectedIndex = profile.OutputMethodIndex;
            _defaultInputModeSelector.SelectedIndex = profile.DefaultInputModeIndex;

            _modelSelector.SelectedIndex = profile.ModelIndex;
            _apiKeyField.Text = profile.APIKey;
            _glossaryIdField.Text = profile.GlossaryId;
            _sourceLanguageSelector.SelectedIndex = profile.SourceLanguageIndex;
            _destinationLanguageSelector.SelectedIndex = profile.DestinationLanguageIndex;
            _translationFormatField.Text = profile.TranslationFormat;
            _requestTimeoutField.Value = profile.RequestTimeout;

            _overlayEnabledToggle.Checked = profile.OverlayEnabled;
            _overlayAnchorSelector.SelectedAnchor = (ContentAlignment)profile.OverlayAnchorIndex;
            _overlayOffsetXField.Value = profile.OverlayOffsetX;
            _overlayOffsetYField.Value = profile.OverlayOffsetY;
            _overlayFontSizeField.Value = profile.OverlayFontSize;
            _overlayOpacitySlider.Value = profile.OverlayOpacity;

            _notificationEnabledToggle.Checked = profile.NotificationEnabled;
            _capturingStartNotifyToggle.Checked = profile.NotifyOnCapturingStart;
            _translationCompletedNotifyToggle.Checked = profile.NotifyOnTranslationCompleted;
            _translationFailedNotifyToggle.Checked = profile.NotifyOnTranslationFailed;
            _notificationVolumeSlider.Value = profile.NotificationVolume;

            _enableCapturingKeyGroup.KeySetting = profile.EnableCapturingKeySetting;
            _capturingToggleKeyGroup.KeySetting = profile.CapturingToggleKeySetting;
            _translateKeyGroup.KeySetting = profile.TranslateKeySetting;
            _sendClipboardKeyGroup.KeySetting = profile.SendClipboardKeySetting;

            _inputTimeoutField.Value = profile.InputTimeout;
            _debugEchoModeToggle.Checked = profile.DebugEchoMode;
            _writeLogFileToggle.Checked = profile.WriteLogFile;
            _executeOnWindowStartToggle.Checked = profile.ExecuteOnWindowStart;

            //Update controls
            _overlayActiveGroup.SetControlGroupActive(profile.OverlayEnabled);
            _notificationActiveGroup.SetControlGroupActive(profile.NotificationEnabled);
            _translateKeyGroup.SetActive(!profile.StartTranslateOnBuffered);
            _sendClipboardKeyGroup.SetActive(!profile.AutoSendMessageOnTranslated);
            _overlayOpacityField.Text = profile.OverlayOpacity.ToString();
            _notificationVolumeField.Text = profile.NotificationVolume.ToString();

            SetActiveOverlay(profile.OverlayEnabled);

            _translationService.InitializeTranslator();
            bool glossaryLoaded = await _translationService.LoadGlossary();

            if (glossaryLoaded == false)
            {
                _glossaryIdField.Text = ""; //Failed to load glossary
            }
        }

        private void SetLanguageSelectors()
        {
            _sourceLanguageSelector.Items.Clear();
            _destinationLanguageSelector.Items.Clear();

            foreach (var info in LanguageCodeInfo.SOURCE_LANGUAGES)
            {
                _sourceLanguageSelector.Items.Add(info.Name);
            }

            foreach (var info in LanguageCodeInfo.TARGET_LANGUAGES)
            {
                _destinationLanguageSelector.Items.Add(info.Name);
            }
        }

        private void SetActiveOverlay(bool active)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            if (active)
            {
                if (_overlayForm == null) //Create new overlay form
                {
                    _overlayForm = new OverlayForm();
                }

                _overlayForm.Show();
            }
            else if (_overlayForm != null)
            {
                _overlayForm.Hide();
            }
        }

        #endregion
    }
}
