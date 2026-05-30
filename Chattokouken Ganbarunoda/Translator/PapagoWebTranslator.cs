using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CKG.Translator
{
    public sealed class PapagoWebTranslator : ITranslator
    {
        private const string URL_BASE = @"https://papago.naver.com";
        private const string URL_TRANSLATE = @"https://papago.naver.com/apis/n2mt/translate";
        private const string POST_ENCODE = @"application/x-www-form-urlencoded";
        private const int AUTH_KEY_FOUND_TIMEOUT = 5000;

        private HttpClient _client = null;
        private CancellationTokenSource _cancelTokenSource = null;
        private HMACMD5 _hmac = null;
        private string _authKey = null;
        private bool _authKeyFetched = false;

        private int _timeoutMilliseconds = 3000;
        private bool _isTranslating = false;
        private bool _isDisposed = false;

        public PapagoWebTranslator(int timeoutMilliseconds)
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
            languagePair = LanguageCodeInfo.ToLower(languagePair);

            if (languagePair.Source == null || languagePair.Destination == null)
            {
                return new STranslationResult("Not Supported Language", true);
            }

            if (_authKeyFetched == false)
            {
                //Find auth key on first translate request
                try
                {
                    _authKey = await FetchPapagoKey();
                    _hmac = new HMACMD5(Encoding.UTF8.GetBytes(_authKey));
                }
                catch
                {
                    _authKey = null;
                    _hmac = null;
                }
                
                _authKeyFetched = true;
            }

            if (_authKey == null)
            {
                return new STranslationResult("Auth Key Not Found", true);
            }

            _isTranslating = true;
            _cancelTokenSource = new CancellationTokenSource(_timeoutMilliseconds);

            string timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            string body = $"source={languagePair.Source}&target={languagePair.Destination}&text={Uri.EscapeDataString(content)}";
            string auth = GeneratePapagoAuth(timestamp, URL_TRANSLATE, body);
            StringContent bodyContent = new StringContent(body, Encoding.UTF8, POST_ENCODE);

            HttpResponseMessage response = null;
            JsonDocument doc = null;

            try
            {
                _client.DefaultRequestHeaders.Remove("Authorization");
                _client.DefaultRequestHeaders.Remove("Timestamp");
                _client.DefaultRequestHeaders.Add("Authorization", $"PPG {timestamp}:{auth}");
                _client.DefaultRequestHeaders.Add("Timestamp", timestamp);

                response = await _client.PostAsync(URL_TRANSLATE, bodyContent, _cancelTokenSource.Token);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                doc = JsonDocument.Parse(json);

                return new STranslationResult(doc.RootElement.GetProperty("translatedText").GetString(), false);
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

        private string GeneratePapagoAuth(string timestamp, string url, string body)
        {
            string message = $"{timestamp}\n{url}\n{body}";
            byte[] hash = _hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            return Convert.ToBase64String(hash);
        }

        private async Task<string> FetchPapagoKey()
        {
            CancellationTokenSource cancelToken = new CancellationTokenSource(AUTH_KEY_FOUND_TIMEOUT);

            string html = await _client.GetStringAsync(URL_BASE, cancelToken.Token);
            Match scriptMatch = Regex.Match(html, @"src=""(/main\.[a-f0-9]+\.chunk\.js)""");

            if (scriptMatch.Success == false)
            {
                cancelToken?.Dispose();
                return null;
            }

            string js = await _client.GetStringAsync(URL_BASE + scriptMatch.Groups[1].Value, cancelToken.Token);
            Match keyMatch = Regex.Match(js, @"HmacMD5\([^,]+,\s*""([^""]+)""");

            cancelToken?.Dispose();
            return keyMatch.Success ? keyMatch.Groups[1].Value : null;
        }
    }
}
