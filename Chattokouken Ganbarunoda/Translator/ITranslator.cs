using System;
using System.Threading.Tasks;

namespace CKG.Translator
{
    public struct STranslationResult
    {
        public string Text;
        public bool HasException;

        public STranslationResult(string text, bool hasExeception)
        {
            Text = text;
            HasException = hasExeception;
        }
    }

    public interface ITranslator : IDisposable
    {
        Task<STranslationResult> TranslateAsync(string content, SLanguagePair languagePair, string glossaryId);
        Task<GlossaryInfo[]> GetGlossariesAsync();
        Task<GlossaryInfo> GetGlossaryAsync(string glossaryId);
        void AbortTranslation();
        void SetTimeout(int timeoutMilliseconds);
    }
}
