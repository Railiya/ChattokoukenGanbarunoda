using System;
using System.IO;
using NAudio.Wave;

namespace CKG
{
    public enum ESound
    {
        CapturingStart,
        TranslationCompleted,
        TranslationFailed
    }

    public sealed class SoundPlayer : IDisposable
    {
        private static readonly string[] FILE_NAMES = new string[]
        {
            "capturing_start.wav",
            "translation_completed.wav",
            "translation_failed.wav"
        };

        public static int AUDIO_COUNT = FILE_NAMES.Length;

        private AudioFileReader[] _readers;
        private WaveOutEvent _output;

        private AudioFileReader _currentReader = null;
        private bool _isDisposed = false;

        public SoundPlayer()
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");

            _readers = new AudioFileReader[AUDIO_COUNT];

            for (int i = 0; i < AUDIO_COUNT; i++)
            {
                string path = Path.Combine(dir, FILE_NAMES[i]);

                if (File.Exists(path) == false)
                {
                    continue;
                }

                try
                {
                    _readers[i] = new AudioFileReader(path);
                }
                catch { }
            }

            _output = new WaveOutEvent();
        }

        public void Play(ESound sound, float volume)
        {
            AudioFileReader reader = _readers[sound.ToInt32()];

            if (reader == null)
            {
                return;
            }

            reader.Volume = volume;
            _output.Stop();

            if (_currentReader != reader)
            {
                _output.Init(reader);
                _currentReader = reader;
            }

            reader.Position = 0;
            _output.Play();
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _output.Dispose();

            foreach (AudioFileReader reader in _readers)
            {
                reader?.Dispose();
            }

            _isDisposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
