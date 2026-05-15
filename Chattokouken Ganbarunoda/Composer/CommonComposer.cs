using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CKG.Composer
{
    public sealed class CommonComposer
    {
        private static readonly char[] SHIFT_NUMNER_TABLE =
        {
            ')', '!', '@', '#', '$', '%', '^', '&', '*', '('
        };

        private static readonly Dictionary<Keys, (char normal, char shifted)> KEY_CHAR_TABLE = new()
        {
            { Keys.Space,            (' ',  ' ')  },
            { Keys.OemPeriod,        ('.',  '>') },
            { Keys.Oemcomma,         (',',  '<') },
            { Keys.OemQuestion,      ('/',  '?') },
            { Keys.OemSemicolon,     (';',  ':') },
            { Keys.OemQuotes,        ('\'', '"') },
            { Keys.OemOpenBrackets,  ('[',  '{') },
            { Keys.OemCloseBrackets, (']',  '}') },
            { Keys.OemMinus,         ('-',  '_') },
            { Keys.Oemplus,          ('=',  '+') },
            { Keys.Oemtilde,         ('`',  '~') },
            { Keys.OemBackslash,     ('\\', '|') },
            { Keys.NumPad0,          ('0',  '0') },
            { Keys.NumPad1,          ('1',  '1') },
            { Keys.NumPad2,          ('2',  '2') },
            { Keys.NumPad3,          ('3',  '3') },
            { Keys.NumPad4,          ('4',  '4') },
            { Keys.NumPad5,          ('5',  '5') },
            { Keys.NumPad6,          ('6',  '6') },
            { Keys.NumPad7,          ('7',  '7') },
            { Keys.NumPad8,          ('8',  '8') },
            { Keys.NumPad9,          ('9',  '9') },
            { Keys.Decimal,          ('.',  '.') },
            { Keys.Add,              ('+',  '+') },
            { Keys.Subtract,         ('-',  '-') },
            { Keys.Multiply,         ('*',  '*') },
            { Keys.Divide,           ('/',  '/') },
        };

        public bool TryGetChar(Keys key, byte[] keyboardState, out char result)
        {
            bool shift = (keyboardState[(int)Keys.ShiftKey] & 0x80) != 0;

            if (key >= Keys.D0 && key <= Keys.D9)
            {
                result = shift ? SHIFT_NUMNER_TABLE[key - Keys.D0] : (char)('0' + (key - Keys.D0));
                return true;
            }

            if (KEY_CHAR_TABLE.TryGetValue(key, out var pair))
            {
                result = shift ? pair.shifted : pair.normal;
                return true;
            }

            result = '\0';
            return false;
        }
    }
}
