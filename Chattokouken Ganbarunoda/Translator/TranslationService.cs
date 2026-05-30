using System;
using System.Text;
using System.Threading.Tasks;

namespace CKG.Translator
{
    public sealed class TranslationService : IDisposable
    {
        public string LastOriginalText { get; private set; }
        public string LastTranslatedText { get; private set; }

        private ITranslator _currentTranslator = null;
        private GlossaryInfo _loadedGlossary = null;
        private StringBuilder _translationBuffer = new StringBuilder(256);

        private bool _isDisposed = false;

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _currentTranslator?.Dispose();

            _isDisposed = true;
            GC.SuppressFinalize(this);
        }

        public async Task<STranslationResult> TranslateAsync(string text)
        {
            SLanguagePair languagePair = GetLanguagePair();
            string glossaryId = null;
            STranslationResult result = default;

            if (_loadedGlossary != null && _loadedGlossary.SupportedLanguagePairs.Contains(languagePair))
            {
                glossaryId = _loadedGlossary.Id;
            }

            if (_currentTranslator != null)
            {
                result = await _currentTranslator.TranslateAsync(text, languagePair, glossaryId);
                result.Text = GetTranslatedText(text, result.Text);
            }
            else
            {
                result = new STranslationResult("Invalid Translator", true);
            }

            LastOriginalText = text;
            LastTranslatedText = result.Text;
            return result;
        }

        public async Task<GlossaryInfo[]> LoadGlossariesAsync()
        {
            if (_currentTranslator == null)
            {
                return null;
            }

            return await _currentTranslator.GetGlossariesAsync();
        }

        public void InitializeTranslator()
        {
            ETranslatorModel model = (ETranslatorModel)UserProfile.Current.ModelIndex;
            string apiKey = UserProfile.Current.APIKey;
            bool hasApiKey = string.IsNullOrEmpty(apiKey) == false;
            int timeoutMs = UserProfile.Current.RequestTimeout * 1000;

            if (_currentTranslator != null)
            {
                (_currentTranslator as IDisposable)?.Dispose();
            }

            switch (model)
            {
                case ETranslatorModel.GoogleTranslate_Web:
                    _currentTranslator = new GoogleTranslateWebTranslator(timeoutMs);
                    break;

                case ETranslatorModel.Papago_Web:
                    _currentTranslator = new PapagoWebTranslator(timeoutMs);
                    break;

                case ETranslatorModel.DeepL_API:
                    _currentTranslator = hasApiKey ? new DeepLTranslator(apiKey, timeoutMs) : null;
                    break;
            }
        }

        public async Task<bool> LoadGlossary()
        {
            if (_currentTranslator == null || string.IsNullOrEmpty(UserProfile.Current.APIKey) ||
                string.IsNullOrEmpty(UserProfile.Current.GlossaryId))
            {
                return false;
            }

            _loadedGlossary = await _currentTranslator.GetGlossaryAsync(UserProfile.Current.GlossaryId);
            return _loadedGlossary != null;
        }

        public void SetGlossary(GlossaryInfo glossary)
        {
            _loadedGlossary = glossary;
        }

        public void AbortTranslation()
        {
            _currentTranslator?.AbortTranslation();
        }

        public void UpdateTimeout()
        {
            int timeout = UserProfile.Current.RequestTimeout;

            _currentTranslator?.SetTimeout(timeout * 1000);
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

        private SLanguagePair GetLanguagePair()
        {
            int sourceLanguageIndex = UserProfile.Current.SourceLanguageIndex;
            int destLanguageIndex = UserProfile.Current.DestinationLanguageIndex;
            string sourceLanguage = LanguageCodeInfo.SOURCE_LANGUAGES[sourceLanguageIndex].Code;
            string destLanguage = LanguageCodeInfo.TARGET_LANGUAGES[destLanguageIndex].Code;

            return new SLanguagePair(sourceLanguage, destLanguage);
        }
    }
}
