using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CKG.Composer
{
    public sealed class HangulComposer : IImeComposer
    {
        // 두벌식 자음 키 → 초성 인덱스 (0~18)
        private static readonly Dictionary<char, int> CONSONANT_TO_CHO = new Dictionary<char, int>()
        {
            { 'r',  0 }, // ㄱ
            { 'R',  1 }, // ㄲ
            { 's',  2 }, // ㄴ
            { 'e',  3 }, // ㄷ
            { 'E',  4 }, // ㄸ
            { 'f',  5 }, // ㄹ
            { 'a',  6 }, // ㅁ
            { 'q',  7 }, // ㅂ
            { 'Q',  8 }, // ㅃ
            { 't',  9 }, // ㅅ
            { 'T', 10 }, // ㅆ
            { 'd', 11 }, // ㅇ
            { 'w', 12 }, // ㅈ
            { 'W', 13 }, // ㅉ
            { 'c', 14 }, // ㅊ
            { 'z', 15 }, // ㅋ
            { 'x', 16 }, // ㅌ
            { 'v', 17 }, // ㅍ
            { 'g', 18 }, // ㅎ
        };

        // 두벌식 모음 키 → 중성 인덱스 (0~20)
        private static readonly Dictionary<char, int> VOWEL_TO_JUNG = new Dictionary<char, int>()
        {
            { 'k',  0 }, // ㅏ
            { 'o',  1 }, // ㅐ
            { 'i',  2 }, // ㅑ
            { 'O',  3 }, // ㅒ
            { 'j',  4 }, // ㅓ
            { 'p',  5 }, // ㅔ
            { 'u',  6 }, // ㅕ
            { 'P',  7 }, // ㅖ
            { 'h',  8 }, // ㅗ
            { 'y', 12 }, // ㅛ
            { 'n', 13 }, // ㅜ
            { 'b', 17 }, // ㅠ
            { 'm', 18 }, // ㅡ
            { 'l', 20 }, // ㅣ
        };

        // 초성 인덱스 → 종성 인덱스
        // -1 은 종성 불가 (ㄸ,ㅃ,ㅉ)
        private static readonly int[] CHO_TO_JONG =
        {
             1,  2,  4,  7, -1,  8, 16, 17, -1, 19,
            20, 21, 22, -1, 23, 24, 25, 26, 27
        };

        // 종성 인덱스 → 초성 인덱스 (분리 시)
        private static readonly int[] JONG_TO_CHO =
        {
            -1,  0,  1,  0,  2,  2,  2,  3,  5,  5,
             5,  5,  5,  5,  5,  5,  6,  7,  7,  9,
             9, 11, 12, 14, 15, 16, 17, 18
        };

        // 복합 종성: (현재 종성, 추가 초성) → 복합 종성
        private static readonly Dictionary<(int jong, int cho), int> COMPOUND_JONG = new Dictionary<(int jong, int cho), int>()
        {
            { (1,  9), 3  }, // ㄱ+ㅅ=ㄳ
            { (4,  12), 5 }, // ㄴ+ㅈ=ㄵ
            { (4,  18), 6 }, // ㄴ+ㅎ=ㄶ
            { (8,  0),  9 }, // ㄹ+ㄱ=ㄺ
            { (8,  6),  10}, // ㄹ+ㅁ=ㄻ
            { (8,  7),  11}, // ㄹ+ㅂ=ㄼ
            { (8,  9),  12}, // ㄹ+ㅅ=ㄽ
            { (8,  16), 13}, // ㄹ+ㅌ=ㄾ
            { (8,  17), 14}, // ㄹ+ㅍ=ㄿ
            { (8,  18), 15}, // ㄹ+ㅎ=ㅀ
            { (17, 9),  18}, // ㅂ+ㅅ=ㅄ
        };

        // 복합 종성 분리: 종성 → (앞 종성, 뒤 초성)
        private static readonly Dictionary<int, (int frontJong, int backCho)> SPLIT_JONG = new Dictionary<int, (int frontJong, int backCho)>()
        {
            {  3, (1,  9)  }, // ㄳ→ㄱ+ㅅ
            {  5, (4,  12) }, // ㄵ→ㄴ+ㅈ
            {  6, (4,  18) }, // ㄶ→ㄴ+ㅎ
            {  9, (8,  0)  }, // ㄺ→ㄹ+ㄱ
            { 10, (8,  6)  }, // ㄻ→ㄹ+ㅁ
            { 11, (8,  7)  }, // ㄼ→ㄹ+ㅂ
            { 12, (8,  9)  }, // ㄽ→ㄹ+ㅅ
            { 13, (8,  16) }, // ㄾ→ㄹ+ㅌ
            { 14, (8,  17) }, // ㄿ→ㄹ+ㅍ
            { 15, (8,  18) }, // ㅀ→ㄹ+ㅎ
            { 18, (17, 9)  }, // ㅄ→ㅂ+ㅅ
        };

        // 복합 중성: (앞 중성, 뒤 중성) → 복합 중성
        private static readonly Dictionary<(int, int), int> COMPOUND_JUNG = new Dictionary<(int, int), int>()
        {
            { (8,  0),  9  }, // ㅗ+ㅏ=ㅘ
            { (8,  1),  10 }, // ㅗ+ㅐ=ㅙ
            { (8,  20), 11 }, // ㅗ+ㅣ=ㅚ
            { (13, 4),  14 }, // ㅜ+ㅓ=ㅝ
            { (13, 5),  15 }, // ㅜ+ㅔ=ㅞ
            { (13, 20), 16 }, // ㅜ+ㅣ=ㅟ
            { (18, 20), 19 }, // ㅡ+ㅣ=ㅢ
        };

        // 초성 인덱스 → 유니코드 호환 자모
        private static readonly char[] CHO_TO_JAMO =
        {
            'ㄱ','ㄲ','ㄴ','ㄷ','ㄸ','ㄹ','ㅁ','ㅂ','ㅃ','ㅅ',
            'ㅆ','ㅇ','ㅈ','ㅉ','ㅊ','ㅋ','ㅌ','ㅍ','ㅎ'
        };

        // 중성 인덱스 → 유니코드 호환 자모
        private static readonly char[] JUNG_TO_JAMO =
        {
            'ㅏ','ㅐ','ㅑ','ㅒ','ㅓ','ㅔ','ㅕ','ㅖ','ㅗ','ㅘ',
            'ㅙ','ㅚ','ㅛ','ㅜ','ㅝ','ㅞ','ㅟ','ㅠ','ㅡ','ㅢ','ㅣ'
        };

        private const int HANGUL_BASE = 0xAC00;
        private const int CHO_STRIDE = 21 * 28;
        private const int JUNG_STRIDE = 28;

        private char[] _buffer = new char[256];
        private int _length = 0;
        private int _cho = -1;
        private int _jung = -1;
        private int _jong = -1;

        public int Length => _length + ((_cho >= 0 || _jung >= 0) ? 1 : 0);

        public void Input(Keys key, byte[] keyboardState)
        {
            bool shift = (keyboardState[(int)Keys.ShiftKey] & 0x80) != 0;
            bool capital = (keyboardState[(int)Keys.Capital] & 0x01) != 0;
            char c = KeyToChar(key, shift, capital);

            if (c == '\0')
            { 
                return; 
            }

            Input(c);
        }

        public string Commit()
        {
            FlushCurrent();
            string result = new string(_buffer, 0, _length);

            Reset();
            return result;
        }

        public void Backspace()
        {
            if (_jong > 0)
            {
                if (SPLIT_JONG.TryGetValue(_jong, out var split))
                {
                    _jong = split.frontJong;
                }
                else
                {
                    _jong = -1;
                }
            }
            else if (_jung >= 0)
            {
                _jung = -1;
            }
            else if (_cho >= 0)
            {
                _cho = -1;
            }
            else if (_length > 0)
            {
                _length--;
            }
        }

        public void Reset()
        {
            _cho = -1;
            _jung = -1;
            _jong = -1;
            _length = 0;
        }

        public int CopyTo(Span<char> destination)
        {
            int total = Length;

            if (destination.Length < total)
            { 
                return 0; 
            }

            _buffer.AsSpan(0, _length).CopyTo(destination);

            int offset = _length;

            if (_cho >= 0 && _jung >= 0)
            {
                destination[offset++] = Compose(_cho, _jung, _jong > 0 ? _jong : 0);
            }
            else if (_cho >= 0)
            {
                destination[offset++] = CHO_TO_JAMO[_cho];
            }
            else if (_jung >= 0)
            {
                destination[offset++] = JUNG_TO_JAMO[_jung];
            }

            return total;
        }

        private void Input(char c)
        {
            if (CONSONANT_TO_CHO.TryGetValue(c, out int choIndex))
            {
                InputConsonant(choIndex);
            }
            else if (VOWEL_TO_JUNG.TryGetValue(c, out int jungIndex))
            {
                InputVowel(jungIndex);
            }
            else
            {
                FlushCurrent();
                EnsureBuffer(_length + 1);
                _buffer[_length++] = c;
            }
        }

        private void InputConsonant(int choIndex)
        {
            if (_cho < 0 && _jung < 0)
            {
                // 빈 상태 → 초성 시작
                _cho = choIndex;
                return;
            }

            if (_cho >= 0 && _jung < 0)
            {
                // 초성만 → 이전 초성 확정, 새 초성 시작
                FlushCurrent();
                _cho = choIndex;
                return;
            }

            if (_cho >= 0 && _jung >= 0 && _jong < 0)
            {
                // 초+중 → 종성 시도
                int jongIndex = CHO_TO_JONG[choIndex];

                if (jongIndex > 0)
                {
                    _jong = jongIndex;
                }
                else
                {
                    FlushCurrent();
                    _cho = choIndex;
                }

                return;
            }

            if (_cho >= 0 && _jung >= 0 && _jong > 0)
            {
                // 초+중+종 → 복합 종성 시도
                if (COMPOUND_JONG.TryGetValue((_jong, choIndex), out int compound))
                {
                    _jong = compound;
                }
                else
                {
                    // 현재 글자 종성 그대로 확정, 새 초성 시작
                    FlushCurrent();
                    _cho = choIndex;
                }
            }
        }

        private void InputVowel(int jungIndex)
        {
            if (_cho < 0 && _jung < 0)
            {
                // 빈 상태 → 중성만
                _jung = jungIndex;
                return;
            }

            if (_cho >= 0 && _jung < 0)
            {
                // 초성만 → 초+중 결합
                _jung = jungIndex;
                return;
            }

            if (_cho >= 0 && _jung >= 0 && _jong < 0)
            {
                // 초+중 → 복합 중성 시도
                if (COMPOUND_JUNG.TryGetValue((_jung, jungIndex), out int compound))
                {
                    _jung = compound;
                }
                else
                {
                    FlushCurrent();
                    _jung = jungIndex;
                }

                return;
            }

            if (_cho >= 0 && _jung >= 0 && _jong > 0)
            {
                // 초+중+종 → 종성 분리, 다음 글자 초성+중성으로
                CommitWithSplitJong(-1, jungIndex);
            }
        }

        private void CommitWithSplitJong(int newCho, int newJung)
        {
            int frontJong;
            int backCho;

            if (SPLIT_JONG.TryGetValue(_jong, out var split))
            {
                frontJong = split.frontJong;
                backCho = split.backCho;
            }
            else
            {
                // 모음이 들어온 경우: 종성을 다음 초성으로 이동
                // 자음이 들어온 경우: 종성 유지하고 새 자음이 초성
                frontJong = newCho >= 0 ? _jong : 0;
                backCho = JONG_TO_CHO[_jong];
            }

            EnsureBuffer(_length + 1);
            _buffer[_length++] = Compose(_cho, _jung, frontJong);

            _cho = newCho >= 0 ? newCho : backCho;
            _jung = newJung;
            _jong = -1;
        }

        private void FlushCurrent()
        {
            if (_cho < 0 && _jung < 0)
            {
                return;
            }

            EnsureBuffer(_length + 1);

            if (_cho >= 0 && _jung >= 0)
            {
                _buffer[_length++] = Compose(_cho, _jung, _jong > 0 ? _jong : 0);
            }
            else if (_cho >= 0)
            {
                _buffer[_length++] = CHO_TO_JAMO[_cho];
            }
            else
            {
                _buffer[_length++] = JUNG_TO_JAMO[_jung];
            }

            _cho = -1;
            _jung = -1;
            _jong = -1;
        }

        private static char Compose(int cho, int jung, int jong)
        {
            return (char)(HANGUL_BASE + cho * CHO_STRIDE + jung * JUNG_STRIDE + jong);
        }

        private static char KeyToChar(Keys key, bool shift, bool capital)
        {
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

            //버퍼 용량이 요구량 보다 작을 경우 확장
            char[] next = new char[_buffer.Length * 2];
            _buffer.AsSpan(0, _length).CopyTo(next);
            _buffer = next;
        }
    }
}
