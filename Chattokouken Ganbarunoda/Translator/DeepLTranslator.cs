using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DeepL;
using DeepL.Model;

namespace CKG.Translator
{
    public sealed class DeepLTranslator : ITranslator
    {
        private const int GLOSSARY_LOAD_TIMEOUT = 5000;

        private DeepLClient _client = null;
        private TextTranslateOptions _options = null;
        private CancellationTokenSource _cancelTokenSource = null;

        private int _timeoutMilliseconds = 3000;
        private bool _isTranslating = false;
        private bool _isDisposed = false;

        public DeepLTranslator(string authKey, int timeoutMilliseconds)
        {
            _client = new DeepLClient(authKey);
            _options = new TextTranslateOptions()
            {
                SentenceSplittingMode = SentenceSplittingMode.Off,
                PreserveFormatting = true,
                Formality = Formality.Default
            };

            SetTimeout(timeoutMilliseconds);
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _cancelTokenSource?.Dispose();
            _client?.Dispose();

            _isDisposed = true;
            GC.SuppressFinalize(this);
        }

        public async Task<STranslationResult> TranslateAsync(string content, SLanguagePair languagePair, string glossaryId)
        {
            _isTranslating = true;

            _cancelTokenSource = new CancellationTokenSource(_timeoutMilliseconds);
            _options.GlossaryId = string.IsNullOrEmpty(glossaryId) ? null : glossaryId;

            try
            {
                TextResult result = await _client.TranslateTextAsync
                    (content, languagePair.Source, languagePair.Destination, _options, _cancelTokenSource.Token);

                return new STranslationResult(result.Text, false);
            }
            catch (Exception e)
            {
                return new STranslationResult(e.Message, true);
            }
            finally
            {
                _cancelTokenSource.Dispose();
                _cancelTokenSource = null;

                _isTranslating = false;
            }
        }

        public async Task<GlossaryInfo[]> GetGlossariesAsync()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource(GLOSSARY_LOAD_TIMEOUT);

            try
            {
                MultilingualGlossaryInfo[] glossaries = await _client.ListMultilingualGlossariesAsync(cancelTokenSource.Token);
                GlossaryInfo[] result = new GlossaryInfo[glossaries.Length];

                for (int i = 0; i < glossaries.Length; i++)
                {
                    result[i] = ConvertGlossary(glossaries[i]);
                }

                return result;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cancelTokenSource.Dispose();
                cancelTokenSource = null;
            }
        }

        public async Task<GlossaryInfo> GetGlossaryAsync(string glossaryId)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource(GLOSSARY_LOAD_TIMEOUT);

            try
            {
                MultilingualGlossaryInfo glossary = await _client.GetMultilingualGlossaryAsync(glossaryId);
                return ConvertGlossary(glossary);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cancelTokenSource.Dispose();
                cancelTokenSource = null;
            }
        }

        private static GlossaryInfo ConvertGlossary(MultilingualGlossaryInfo glossary)
        {
            HashSet<SLanguagePair> supportedLanguagePairs = new HashSet<SLanguagePair>();
            int entryCount = 0;

            foreach (MultilingualGlossaryDictionaryInfo dictionary in glossary.Dictionaries)
            {
                string sourceLanguage = dictionary.SourceLanguageCode.ToUpper();
                string destLanguage = dictionary.TargetLanguageCode.ToUpper();

                supportedLanguagePairs.Add(new SLanguagePair(sourceLanguage, destLanguage));
                entryCount += dictionary.EntryCount;
            }

            return new GlossaryInfo(glossary.Name, glossary.GlossaryId, entryCount, supportedLanguagePairs);
        }

        public void AbortTranslation()
        {
            if (_isTranslating)
            {
                _cancelTokenSource?.Cancel(false);
                _isTranslating = false;
            }
        }

        public void SetTimeout(int timeoutMilliseconds)
        {
            _timeoutMilliseconds = timeoutMilliseconds;
        }
    }
}
