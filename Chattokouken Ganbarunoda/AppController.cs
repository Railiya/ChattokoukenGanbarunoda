using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CKG.Forms;
using CKG.Input;
using CKG.Translator;

namespace CKG
{
    public class AppController : IDisposable
    {
        public static event Action<ECapturingState> OnCapturingStateChanged = null;
        public static event Action<EInputMode> OnInputModeChanged = null;

        private CapturingHandler _capturingHandler = null;
        private TranslationService _translationService = null;
        private SoundPlayer _soundPlayer = null;

        private bool _isDisposed = false;

        public AppController(TranslationService translationService)
        {
            _translationService = translationService;

            _capturingHandler = new CapturingHandler();
            _capturingHandler.OnStateChanged += OnHandlerCapturingStateChanged;
            _capturingHandler.OnInputModeChanged += OnHandlerInputModeChanged;
            _soundPlayer = new SoundPlayer();
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _capturingHandler?.Dispose();
            _soundPlayer?.Dispose();
            _translationService?.Dispose();

            _isDisposed = true;
            GC.SuppressFinalize(this);
        }

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

                    _translationService.AbortTranslation();
                    break;
                }
                case ECapturingState.Capturing:
                {
                    Logger.Write(state);

                    _soundPlayer.Play(ESound.CapturingStart, UserProfile.Current.NotifyOnCapturingStart);
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
                        Clipboard.SetText(_translationService.LastOriginalText);
                        _capturingHandler.SetTranslated();
                    }
                    else
                    {
                        STranslationResult result = await _translationService.TranslateAsync(text);

                        if (result.HasException)
                        {
                            _capturingHandler.SetFailed();
                        }
                        else
                        {
                            Clipboard.SetText(result.Text);
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

                    _soundPlayer.Play(ESound.TranslationCompleted, UserProfile.Current.NotifyOnTranslationCompleted);
                    break;
                }
                case ECapturingState.Failed:
                {
                    Logger.Write(state, _translationService.LastTranslatedText);

                    _soundPlayer.Play(ESound.TranslationFailed, UserProfile.Current.NotifyOnTranslationFailed);
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
    }
}
