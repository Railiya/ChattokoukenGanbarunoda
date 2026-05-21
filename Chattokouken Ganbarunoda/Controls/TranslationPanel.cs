using System;
using System.Windows.Forms;
using CKG.Forms;
using CKG.Translator;

namespace CKG.Controls
{
    public enum ETranslatorWorkRequest
    {
        InitializeTranslator,
        SelectGlossary,
        UpdateTimeout
    }

    public partial class TranslationPanel : SettingPanel
    {
        public Action<ETranslatorWorkRequest> OnRequestTranslatorWork = null;

        protected override string LocalizationKey => "Translation";

        public TranslationPanel() : base()
        {
            InitializeComponent();

            SetLanguageSelector(_sourceLanguageSelector, LanguageCodeInfo.SOURCE_LANGUAGES);
            SetLanguageSelector(_destinationLanguageSelector, LanguageCodeInfo.TARGET_LANGUAGES);
        }

        public override void UpdateProfile(UserProfile profile)
        {
            _modelSelector.SelectedIndex = profile.ModelIndex;
            _apiKeyField.Text = profile.APIKey;
            _glossaryIdField.Text = profile.GlossaryId;
            _sourceLanguageSelector.SelectedIndex = profile.SourceLanguageIndex;
            _destinationLanguageSelector.SelectedIndex = profile.DestinationLanguageIndex;
            _translationFormatField.Text = profile.TranslationFormat;
            _requestTimeoutField.Value = profile.RequestTimeout;
        }

        public void SetGlossaryId(string id)
        {
            _glossaryIdField.Text = id;
        }

        private void _modelSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.ModelIndex = _modelSelector.SelectedIndex;

            _apiKeyField.Text = "";
            _glossaryIdField.Text = "";
            AppDataManager.SaveCurrentProfile();
        }

        private void _apiKeyField_TextChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.APIKey = _apiKeyField.Text;
            AppDataManager.SaveCurrentProfile();

            OnRequestTranslatorWork?.Invoke(ETranslatorWorkRequest.InitializeTranslator);
        }

        private void _glossaryIdField_TextChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.GlossaryId = _glossaryIdField.Text;
            AppDataManager.SaveCurrentProfile();
        }

        private void _glossarySelectButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserProfile.Current.APIKey))
            {
                MessageBox.Show("You have to input api key first");
                return;
            }

            OnRequestTranslatorWork?.Invoke(ETranslatorWorkRequest.SelectGlossary);
        }

        private void _sourceLanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.SourceLanguageIndex = _sourceLanguageSelector.SelectedIndex;
            AppDataManager.SaveCurrentProfile();
        }

        private void _destinationLanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.DestinationLanguageIndex = _destinationLanguageSelector.SelectedIndex;
            AppDataManager.SaveCurrentProfile();
        }

        private void _translationFormatField_TextChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.TranslationFormat = _translationFormatField.Text;
            AppDataManager.SaveCurrentProfile();
        }

        private void _requestTimeoutField_ValueChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.RequestTimeout = (int)_requestTimeoutField.Value;
            AppDataManager.SaveCurrentProfile();

            OnRequestTranslatorWork?.Invoke(ETranslatorWorkRequest.UpdateTimeout);
        }

        private void SetLanguageSelector(ComboBox comboBox, LanguageCodeInfo[] infos)
        {
            comboBox.Items.Clear();

            foreach (var info in infos)
            {
                comboBox.Items.Add(info.Name);
            }
        }
    }
}
