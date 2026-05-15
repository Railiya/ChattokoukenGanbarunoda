using System;
using System.Windows.Forms;

namespace CKG.Composer
{
    public sealed class AlphabetComposer : IImeComposer
    {
        public int Length => _length;

        private char[] _buffer = new char[128];
        private int _length = 0;

        public void Input(Keys key, byte[] keyboardState)
        {
            char c = KeyToChar(key, keyboardState);

            if (c == '\0')
            { 
                return; 
            }

            EnsureBuffer(_length + 1);
            _buffer[_length++] = c;
        }

        public string Commit()
        {
            string result = new string(_buffer, 0, _length);
            Reset();

            return result;
        }

        public void Backspace()
        {
            if (_length > 0)
            { 
                _length--; 
            }
        }

        public void Reset()
        {
            _length = 0;
        }

        public int CopyTo(Span<char> destination)
        {
            if (destination.Length < _length)
            { 
                return 0; 
            }

            _buffer.AsSpan(0, _length).CopyTo(destination);
            return _length;
        }

        private static char KeyToChar(Keys key, byte[] keyboardState)
        {
            bool shift = (keyboardState[(int)Keys.ShiftKey] & 0x80) != 0;
            bool capital = (keyboardState[(int)Keys.Capital] & 0x01) != 0;

            if (key >= Keys.A && key <= Keys.Z)
            {
                bool upper = shift ^ capital;
                return upper ? (char)('A' + (key - Keys.A)) : (char)('a' + (key - Keys.A));
            }

            return '\0';
        }

        private void EnsureBuffer(int required)
        {
            if (required <= _buffer.Length)
            { 
                return; 
            }

            char[] next = new char[_buffer.Length * 2];

            _buffer.AsSpan(0, _length).CopyTo(next);
            _buffer = next;
        }
    }
}
