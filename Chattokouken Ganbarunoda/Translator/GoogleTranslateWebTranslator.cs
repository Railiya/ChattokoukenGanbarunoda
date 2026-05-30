using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CKG.Translator
{
    public sealed class GoogleTranslateWebTranslator : ITranslator
    {
        private const string URL_BASE = @"https://translate.googleapis.com/translate_a/single?client=gtx";
        private const string POST_ENCODE = @"application/x-www-form-urlencoded";

        private HttpClient _client = null;
        private CancellationTokenSource _cancelTokenSource = null;

        private int _timeoutMilliseconds = 3000;
        private bool _isTranslating = false;
        private bool _isDisposed = false;

        public GoogleTranslateWebTranslator(int timeoutMilliseconds)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36");
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

            string url = $"{URL_BASE}&sl={languagePair.Source}&tl={languagePair.Destination}&dt=t";
            string body = "q=" + Uri.EscapeDataString(content);
            StringContent bodyContent = new StringContent(body, Encoding.UTF8, POST_ENCODE);

            HttpResponseMessage response = null;
            JsonDocument doc = null;

            try
            {
                response = await _client.PostAsync(url, bodyContent, _cancelTokenSource.Token);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                doc = JsonDocument.Parse(json);

                JsonElement first = doc.RootElement[0][0];

                if (first[0].ValueKind == JsonValueKind.String)
                {
                    return new STranslationResult(first[0].GetString(), false);
                }
                else
                {
                    return new STranslationResult("", false);
                } 
            }
            catch (Exception e)
            {
                return new STranslationResult(e.Message, true);
            }
            finally
            {
                _cancelTokenSource.Dispose();
                _cancelTokenSource = null;

                response?.Dispose();
                doc?.Dispose();

                _isTranslating = false;
            }
        }

        public Task<GlossaryInfo[]> GetGlossariesAsync()
        {
            return Task.FromResult<GlossaryInfo[]>(null);
        }

        public Task<GlossaryInfo> GetGlossaryAsync(string glossaryId)
        {
            return Task.FromResult<GlossaryInfo>(null);
            ;
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
