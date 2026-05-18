using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CKG.Controls;
using CKG.Translator;

namespace CKG.Forms
{
    public partial class MainForm : Form
    {
        private const string PROJECT_NAME = "Chattokouken Ganbarunoda!!";

        public static bool LockControlEvents { get; private set; }

        private ContextMenuStrip _trayMenu = null;
        private NotifyIcon _trayIcon = null;

        private TranslationService _translationService = null;
        private OverlayForm _overlayForm = null;
        private bool _hasShownTrayHint = false;
        private bool _isExitRequested;

        #region Constructor and Disposer

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(TranslationService translationService)
        {
            _translationService = translationService;

            InitializeComponent();

            Text = $"{PROJECT_NAME} (v{Application.ProductVersion})";

            LockControlEvents = true;

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

            //Update controls by loaded profile
            UpdateProfile();

            //Create profile menu items
            RefreshProfilesMenu();

            //Set control events
            _generalPanel.OnToggleChanged += OnGeneralSettingToggleChanged;
            _translationPanel.OnRequestTranslatorWork += OnRequestTranslatorWork;
            _overlayPanel.OnOverlayToggleChanged += OnOverlayToggleChanged;

            LockControlEvents = false;

            //Set active overlay after profile loaded
            SetActiveOverlay(UserProfile.Current.OverlayEnabled);

            CheckForUpdatesAsync();
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

        #region Private Control Events

        private void OnGeneralSettingToggleChanged(EGeneralSettingToggle setting, bool toggle)
        {
            switch (setting)
            {
                case EGeneralSettingToggle.StartTranslateOnBuffered:
                    _hotkeysPanel.SetGroupActive(EHotkey.Translate, !toggle);
                    break;

                case EGeneralSettingToggle.AutoSendMessageOnTranslated:
                    _hotkeysPanel.SetGroupActive(EHotkey.SendClipboard, !toggle);
                    break;
            }
        }

        private void OnRequestTranslatorWork(ETranslatorWorkRequest request)
        {
            switch (request)
            {
                case ETranslatorWorkRequest.InitializeTranslator:
                    _translationService.InitializeTranslator();
                    break;

                case ETranslatorWorkRequest.SelectGlossary:
                    GlossarySelectForm glossarySelectForm = new GlossarySelectForm(_translationService, OnKeySelect);
                    glossarySelectForm.ShowDialog(this);
                    break;

                case ETranslatorWorkRequest.UpdateTimeout:
                    _translationService.UpdateTimeout();
                    break;
            }

            void OnKeySelect(GlossaryInfo glossary)
            {
                if (glossary != null)
                {
                    _translationService.SetGlossary(glossary);
                    _translationPanel.SetGlossaryId(glossary.Id);
                }
                else
                {
                    _translationService.SetGlossary(null);
                    _translationPanel.SetGlossaryId("");
                }
            }
        }

        private void OnOverlayToggleChanged(bool toggle)
        {
            SetActiveOverlay(toggle);
        }

        #endregion

        #region Private Functions

        private async void CheckForUpdatesAsync()
        {
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

        private async void UpdateProfile()
        {
            UserProfile profile = UserProfile.Current;

            //Update controls
            _generalPanel.UpdateProfile(profile);
            _translationPanel.UpdateProfile(profile);
            _overlayPanel.UpdateProfile(profile);
            _notificationPanel.UpdateProfile(profile);
            _hotkeysPanel.UpdateProfile(profile);
            _advancedPanel.UpdateProfile(profile);

            _hotkeysPanel.SetGroupActive(EHotkey.Translate, !profile.StartTranslateOnBuffered);
            _hotkeysPanel.SetGroupActive(EHotkey.SendClipboard, !profile.AutoSendMessageOnTranslated);
            SetActiveOverlay(profile.OverlayEnabled);

            _translationService.InitializeTranslator();
            bool glossaryLoaded = await _translationService.LoadGlossary();

            if (glossaryLoaded == false)
            {
                _translationPanel.SetGlossaryId(""); //Failed to load glossary
            }
        }

        private void RefreshProfilesMenu()
        {
            List<SProfileInfo> profiles = ProfileManager.GetProfileList();

            _profilesMenuItem.DropDownItems.Clear();

            for (int i = 0; i < profiles.Count; i++)
            {
                SProfileInfo profile = profiles[i];
                ToolStripMenuItem item = new ToolStripMenuItem(profile.Name);
                item.Click += OnItemClick;

                _profilesMenuItem.DropDownItems.Add(item);

                void OnItemClick(object sender, EventArgs e)
                {
                    int number = profile.Number;

                    ProfileManager.LoadProfile(number);
                    UpdateProfile();
                }
            }

            ToolStripSeparator separator = new ToolStripSeparator();
            _profilesMenuItem.DropDownItems.Add(separator);

            ToolStripMenuItem refreshItem = new ToolStripMenuItem("Refresh");
            refreshItem.Click += (sender, e) => RefreshProfilesMenu();

            _profilesMenuItem.DropDownItems.Add(refreshItem);
        }

        private void SetActiveOverlay(bool active)
        {
            if (LockControlEvents)
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
