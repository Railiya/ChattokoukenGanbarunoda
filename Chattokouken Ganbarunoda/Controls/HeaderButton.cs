using System;
using System.Drawing;
using System.Windows.Forms;

namespace CKG.Controls
{
    public class HeaderButton : Button
    {
        public string Header { get; set; }
        public string Content { get; set; }

        private Font _headerFont = null;
        private Font _contentFont = null;
        private Brush _headerBrush = null;
        private Brush _contentBrush = null;

        public HeaderButton()
        {
            SetStyle(ControlStyles.UserPaint, true);

            _headerFont = new Font(this.Font, FontStyle.Bold);
            _contentFont = new Font(this.Font.FontFamily, this.Font.Size - 2);
            _headerBrush = new SolidBrush(this.ForeColor);
            _contentBrush = new SolidBrush(Color.Gray);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            RecreateFonts();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            RecreateBrushes();
        }

        private void RecreateFonts()
        {
            _headerFont?.Dispose();
            _contentFont?.Dispose();
            _headerFont = new Font(this.Font, FontStyle.Bold);
            _contentFont = new Font(this.Font.FontFamily, this.Font.Size - 2);
        }

        private void RecreateBrushes()
        {
            _headerBrush?.Dispose();
            _contentBrush?.Dispose();
            _headerBrush = new SolidBrush(this.ForeColor);
            _contentBrush = new SolidBrush(Color.Gray);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.DrawString(Header ?? "", _headerFont, _headerBrush, 8, 6);
            g.DrawString(Content ?? "", _contentFont, _contentBrush, 8, 26);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _headerFont?.Dispose();
                _contentFont?.Dispose();
                _headerBrush?.Dispose();
                _contentBrush?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
