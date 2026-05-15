using System.Collections.Generic;
using System.Windows.Forms;

namespace CKG
{
    public static class KeyDisplayHelper
    {
        private static readonly Dictionary<Keys, string> DisplayNames = null;

        static KeyDisplayHelper()
        {
            DisplayNames = new Dictionary<Keys, string>
            {
                { Keys.None,            "None"         },
                { Keys.Return,          "Enter"        },
                { Keys.Escape,          "ESC"          },
                { Keys.ControlKey,      "Ctrl"         },
                { Keys.Menu,            "Alt"          },
                { Keys.ShiftKey,        "Shift"        },
                { Keys.Prior,           "Page Up"      },
                { Keys.Next,            "Page Down"    },
                { Keys.OemPipe,         "\\"           },
                { Keys.OemQuestion,     "/"            },
                { Keys.Oemcomma,        ","            },
                { Keys.OemPeriod,       "."            },
                { Keys.OemOpenBrackets, "["            },
                { Keys.Oem6,            "]"            },
                { Keys.Oem1,            ";"            },
                { Keys.Oem7,            "'"            },
                { Keys.OemMinus,        "-"            },
                { Keys.Oemplus,         "="            },
                { Keys.Back,            "Backspace"    },
                { Keys.Capital,         "Caps Lock"    },
                { Keys.Snapshot,        "Print Screen" },
                { Keys.Scroll,          "Scroll Lock"  },
                { Keys.Pause,           "Pause Break"  },
            };
        }

        public static string GetDisplayName(Keys key)
        {
            if (DisplayNames.TryGetValue(key, out string name))
            {
                return name;
            }

            return key.ToString();
        }
    }
}
