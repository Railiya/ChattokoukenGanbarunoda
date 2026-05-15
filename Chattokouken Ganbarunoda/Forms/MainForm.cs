using System;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using CKG.Controls;
using CKG.Translator;
using CKG.Input;

namespace CKG.Forms
{
    public partial class MainForm : Form
    {
        private const string PROJECT_NAME = "Chattokouken Ganbarunoda!!";
        private const string PROFILE_EXT = ".ckgprofile";

        public static event Action OnOverlaySettingChanged = null;
        public static event Action<ECapturingState> OnCapturingStateChanged = null;
        public static event Action<EInputMode> OnInputModeChanged = null;

        #region Private Members

        private ContextMenuStrip _trayMenu = null;
        private NotifyIcon _trayIcon = null;

        private List<Control> _overlayActiveGroup = null;
        private List<Control> _notificationActiveGroup = null;
        private HotkeyControlGroup _enableCapturingKeyGroup = null;
        private HotkeyControlGroup _capturingToggleKeyGroup = null;
        private HotkeyControlGroup _translateKeyGroup = null;
        private HotkeyControlGroup _sendClipboardKeyGroup = null;

        private OverlayForm _overlayForm = null;
        private CapturingHandler _capturingHandler = null;
        private SoundPlayer _soundPlayer = null;
        private ITranslator _currentTranslator = null;
        private GlossaryInfo _loadedGlossary = null;
        private StringBuilder _translationBuffer = new StringBuilder(256);

        private bool _isControlEventNotifyLocked = false;
        private string _lastTranslatedText = "";
        private bool _hasShownTrayHint = false;
        private bool _isExitRequested;

        #endregion

        #region Constructor & Disposer

        public MainForm()
        {
            InitializeComponent();
            Text = $"{PROJECT_NAME} (v{Application.ProductVersion})";

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

            InitializeControls();
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

            DisposeComponents();
        }

        private void InitializeControls()
        {
            _isControlEventNotifyLocked = true;

            SetLanguageSelectors();

            //Load first profile or create new
            LoadSettings(1);

            //Set control events
            _overlayAnchorSelector.OnAnchorChanged += _overlayAnchorSelector_AnchorChanged;
            _enableCapturingKeyGroup.HotkeyChanged += _enableCapturingKeyGroup_HotkeyChanged;
            _capturingToggleKeyGroup.HotkeyChanged += _capturingToggleKeyGroup_HotkeyChanged;
            _translateKeyGroup.HotkeyChanged += _translateKeyGroup_HotkeyChanged;
            _sendClipboardKeyGroup.HotkeyChanged += _sendClipboardKeyGroup_HotkeyChanged;

            //Create handlers
            _capturingHandler = new CapturingHandler();
            _capturingHandler.OnStateChanged += OnHandlerCapturingStateChanged;
            _capturingHandler.OnInputModeChanged += OnHandlerInputModeChanged;
            _soundPlayer = new SoundPlayer();

            _isControlEventNotifyLocked = false;

            //Set active overlay after profile loaded
            SetActiveOverlay(UserProfile.Current.OverlayEnabled);
        }

        private void DisposeComponents()
        {
            _overlayForm?.Dispose();
            _capturingHandler?.Dispose();
            _soundPlayer?.Dispose();
            _currentTranslator?.Dispose();
        }

        #endregion

        #region Private Menu Strip Events

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
            _trayIcon.Visible = false;
            _trayIcon.Dispose();

            DisposeComponents();
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
            SaveCurrentProfile();
        }

        private void _autoSendMessageToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.AutoSendMessageOnTranslated = _autoSendMessageToggle.Checked;
            _sendClipboardKeyGroup.SetActive(!UserProfile.Current.AutoSendMessageOnTranslated);
            SaveCurrentProfile();
        }

        private void _inputMethodSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.OutputMethodIndex = _outputMethodSelector.SelectedIndex;
            SaveCurrentProfile();
        }

        private void _defaultInputModeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.DefaultInputModeIndex = _defaultInputModeSelector.SelectedIndex;
            SaveCurrentProfile();
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
            SaveCurrentProfile();
        }

        private void _apiKeyField_TextChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.APIKey = _apiKeyField.Text;
            SaveCurrentProfile();
            InitializeTranslator((ETranslatorModel)UserProfile.Current.ModelIndex, 
                UserProfile.Current.APIKey, UserProfile.Current.RequestTimeout);
        }

        private void _glossaryIdField_TextChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.GlossaryId = _glossaryIdField.Text;
            SaveCurrentProfile();
        }

        private void _glossarySelectButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserProfile.Current.APIKey))
            {
                MessageBox.Show("You have to input api key first");
                return;
            }

            ETranslatorModel model = (ETranslatorModel)UserProfile.Current.ModelIndex;
            GlossarySelectForm glossarySelectForm = new GlossarySelectForm(_currentTranslator, OnKeySelect);
            glossarySelectForm.ShowDialog(this);

            void OnKeySelect(GlossaryInfo glossary)
            {
                _loadedGlossary = glossary;
                _glossaryIdField.Text = _loadedGlossary == null ? "" : glossary.Id;
            }
        }

        private void _sourceLanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.SourceLanguageIndex = _sourceLanguageSelector.SelectedIndex;
            SaveCurrentProfile();
        }

        private void _destinationLanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.DestinationLanguageIndex = _destinationLanguageSelector.SelectedIndex;
            SaveCurrentProfile();
        }

        private void _translationFormatField_TextChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.TranslationFormat = _translationFormatField.Text;
            SaveCurrentProfile();
        }

        private void _requestTimeoutField_ValueChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.RequestTimeout = (int)_requestTimeoutField.Value;
            SaveCurrentProfile();

            if (_currentTranslator != null)
            {
                _currentTranslator.SetTimeout(UserProfile.Current.RequestTimeout * 1000);
            }
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
            SetControlGroupActive(_overlayActiveGroup, _overlayEnabledToggle.Checked);
            SaveCurrentProfile();
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
            SaveCurrentProfile();

            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayOffsetXField_ValueChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.OverlayOffsetX = (int)_overlayOffsetXField.Value;
            SaveCurrentProfile();

            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayOffsetYField_ValueChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.OverlayOffsetY = (int)_overlayOffsetYField.Value;
            SaveCurrentProfile();

            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayFontSizeField_ValueChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.OverlayFontSize = (int)_overlayFontSizeField.Value;
            SaveCurrentProfile();

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
            SaveCurrentProfile();

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
            SetControlGroupActive(_notificationActiveGroup, _notificationEnabledToggle.Checked);
            SaveCurrentProfile();
        }

        private void _capturingStartNotifyToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.NotifyOnCapturingStart = _capturingStartNotifyToggle.Checked;
            SaveCurrentProfile();
        }

        private void _translationCompletedNotifyToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.NotifyOnTranslationCompleted = _translationCompletedNotifyToggle.Checked;
            SaveCurrentProfile();
        }

        private void _translationFailedNotifyToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.NotifyOnTranslationFailed = _translationFailedNotifyToggle.Checked;
            SaveCurrentProfile();
        }

        private void _notificationVolumeSlider_ValueChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.NotificationVolume = (int)_notificationVolumeSlider.Value;
            _notificationVolumeField.Text = UserProfile.Current.NotificationVolume.ToString();
            SaveCurrentProfile();
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
            SaveCurrentProfile();
        }

        private void _capturingToggleKeyGroup_HotkeyChanged(EHotkey Type, SKeySetting setting)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.CapturingToggleKeySetting = _capturingToggleKeyGroup.KeySetting;
            SaveCurrentProfile();
        }

        private void _translateKeyGroup_HotkeyChanged(EHotkey Type, SKeySetting setting)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.TranslateKeySetting = _translateKeyGroup.KeySetting;
            SaveCurrentProfile();
        }

        private void _sendClipboardKeyGroup_HotkeyChanged(EHotkey Type, SKeySetting setting)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.SendClipboardKeySetting = _sendClipboardKeyGroup.KeySetting;
            SaveCurrentProfile();
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
            SaveCurrentProfile();
        }

        private void _debugEchoModeToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.DebugEchoMode = _debugEchoModeToggle.Checked;
            SaveCurrentProfile();
        }

        private void _writeLogFileToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.WriteLogFile = _writeLogFileToggle.Checked;
            SaveCurrentProfile();
        }

        private void _executeOnWindowStartToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (_isControlEventNotifyLocked)
            {
                return;
            }

            UserProfile.Current.ExecuteOnWindowStart = _executeOnWindowStartToggle.Checked;
            SaveCurrentProfile();
        }

        #endregion

        #region Private Callbacks

        private async void OnHandlerCapturingStateChanged(ECapturingState state)
        {
            OnCapturingStateChanged?.Invoke(state);

            //Handle state
            switch (state)
            {
                case ECapturingState.Disabled:
                {
                    Logger.Write(state);

                    _currentTranslator?.AbortTranslation();
                    break;
                }
                case ECapturingState.Capturing:
                {
                    Logger.Write(state);

                    PlaySound(ESound.CapturingStart, UserProfile.Current.NotifyOnCapturingStart);
                    break;
                }
                case ECapturingState.Buffered:
                {
                    string text = _capturingHandler.BufferedText;

                    Logger.Write(state, text);

                    if (UserProfile.Current.StartTranslateOnBuffered)
                    {
                        _capturingHandler.SetTranslating();
                    }
                    break;
                }
                case ECapturingState.Translating:
                {
                    Logger.Write(state);

                    string text = _capturingHandler.BufferedText;

                    if (UserProfile.Current.DebugEchoMode)
                    {
                        _lastTranslatedText = text;

                        Clipboard.SetText(_lastTranslatedText);
                        _capturingHandler.SetTranslated();
                    }
                    else
                    {
                        SLanguagePair languagePair = GetLanguagePair();
                        string glossaryId = null;

                        if (_loadedGlossary != null && _loadedGlossary.SupportedLanguagePairs.Contains(languagePair))
                        {
                            glossaryId = _loadedGlossary.Id;
                        }

                        STranslationResult result = await _currentTranslator.TranslateAsync(text, languagePair, glossaryId);

                        _lastTranslatedText = result.Text;

                        if (result.HasException)
                        {
                            _capturingHandler.SetFailed();
                        }
                        else
                        {
                            Clipboard.SetText(GetTranslatedText(text, _lastTranslatedText));
                            _capturingHandler.SetTranslated();
                        }
                    }

                    break;
                }
                case ECapturingState.Translated:
                {
                    Logger.Write(state, Clipboard.GetText());

                    if (UserProfile.Current.AutoSendMessageOnTranslated)
                    {
                        _capturingHandler.SendMacroMessage();
                    }

                    PlaySound(ESound.TranslationCompleted, UserProfile.Current.NotifyOnTranslationCompleted);
                    break;
                }
                case ECapturingState.Failed:
                {
                    Logger.Write(state, _lastTranslatedText);

                    PlaySound(ESound.TranslationFailed, UserProfile.Current.NotifyOnTranslationFailed);
                    break;
                }
                default:
                {
                    Logger.Write(state);
                    break;
                }
            }
        }

        private void OnHandlerInputModeChanged(EInputMode mode)
        {
            OnInputModeChanged?.Invoke(mode);
        }

        #endregion

        #region File Management

        private async void LoadSettings(int number)
        {
            string path = GetProfilePath(number);

            if (File.Exists(path) == false)
            {
                UserProfile.Current = new UserProfile();
                UserProfile.Current.ProfileName = "Default";
                UserProfile.Current.Number = 1;

                SaveCurrentProfile();
            }

            string content = File.ReadAllText(path);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };

            UserProfile profile = JsonSerializer.Deserialize<UserProfile>(content, options);
            UserProfile.Current = profile;

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
            SetControlGroupActive(_overlayActiveGroup, _overlayEnabledToggle.Checked);
            SetControlGroupActive(_notificationActiveGroup, _notificationEnabledToggle.Checked);
            _translateKeyGroup.SetActive(!profile.StartTranslateOnBuffered);
            _sendClipboardKeyGroup.SetActive(!profile.AutoSendMessageOnTranslated);
            _overlayOpacityField.Text = profile.OverlayOpacity.ToString();
            _notificationVolumeField.Text = profile.NotificationVolume.ToString();

            SetActiveOverlay(profile.OverlayEnabled);
            InitializeTranslator((ETranslatorModel)profile.ModelIndex, profile.APIKey, profile.RequestTimeout);

            if (string.IsNullOrEmpty(profile.GlossaryId) == false)
            {
                _loadedGlossary = await LoadGlossaryInfo();

                if (_loadedGlossary == null)
                {
                    _glossaryIdField.Text = ""; //Failed to load glossary
                }
            }
        }

        private void SaveCurrentProfile()
        {
            UserProfile profile = UserProfile.Current;
            string path = GetProfilePath(profile.Number);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };

            File.WriteAllText(path, JsonSerializer.Serialize(UserProfile.Current, options));
        }

        private string GetProfilePath(int number)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string profileDir = Path.Combine(baseDir, "Profiles");

            Directory.CreateDirectory(profileDir);
            return Path.Combine(profileDir, $"profile{number}{PROFILE_EXT}");
        }

        private void PlaySound(ESound sound, bool enabled)
        {
            if (UserProfile.Current.NotificationEnabled == false || enabled == false)
            {
                return;
            }

            float volume = UserProfile.Current.NotificationVolume * 0.01f;

            _soundPlayer.Play(sound, volume);
        }

        #endregion

        #region Private Functions

        private void SetControlGroupActive(List<Control> controls, bool active)
        {
            foreach (var control in controls)
            {
                control.Enabled = active;
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

        private void InitializeTranslator(ETranslatorModel model, string apiKey, int timeout)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                (_currentTranslator as IDisposable)?.Dispose();
                return;
            }

            switch (model)
            {
                case ETranslatorModel.DeepL:
                    _currentTranslator = new DeepLTranslator(apiKey, timeout * 1000);
                    break;

                case ETranslatorModel.Papago:
                    break;

                case ETranslatorModel.GoogleTranslate:
                    break;
            }
        }

        private string GetTranslatedText(string source, string translated)
        {
            _translationBuffer.Append(UserProfile.Current.TranslationFormat);
            _translationBuffer.Replace("{source}", source);
            _translationBuffer.Replace("{translated}", translated);

            string output = _translationBuffer.ToString();
            _translationBuffer.Clear();

            return output;
        }

        private async Task<GlossaryInfo> LoadGlossaryInfo()
        {
            if (_currentTranslator == null || string.IsNullOrEmpty(UserProfile.Current.APIKey) || 
                string.IsNullOrEmpty(UserProfile.Current.GlossaryId))
            {
                return null;
            }

            return await _currentTranslator.GetGlossaryAsync(UserProfile.Current.GlossaryId);
        }

        private SLanguagePair GetLanguagePair()
        {
            string sourceLanguage = LanguageCodeInfo.SOURCE_LANGUAGES[UserProfile.Current.SourceLanguageIndex].Code;
            string destLanguage = LanguageCodeInfo.TARGET_LANGUAGES[UserProfile.Current.DestinationLanguageIndex].Code;

            return new SLanguagePair(sourceLanguage, destLanguage);
        }

        #endregion
    }
}
