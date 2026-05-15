using System;
using System.Windows.Forms;

namespace CKG.Composer
{
    public interface IImeComposer
    {
        int Length { get; }
        void Input(Keys key, byte[] keyboardState);
        string Commit();
        void Backspace();
        void Reset();
        int CopyTo(Span<char> destination);
    }
}
