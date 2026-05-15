using System.Windows.Forms;

namespace CKG
{
    public struct SKeySetting
    {
        public Keys Key;
        public bool Ctrl;
        public bool Alt;
        public bool Shift;

        public SKeySetting(Keys key, bool ctrl, bool alt, bool shift)
        {
            Key = key;
            Ctrl = ctrl;
            Alt = alt;
            Shift = shift;
        }
    }
}
