using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CKG.Controls
{
    public sealed class LabelGroupRowItem : TableGroupRowItem
    {
        [Browsable(true)]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;

                foreach (Label label in _labels)
                {
                    label.ForeColor = value;
                }

                UpdateLabelTexts();
            }
        }

        [Browsable(true)]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;

                foreach (Label label in _labels)
                {
                    label.Font = value;
                }

                UpdateLabelTexts();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance")]
        public string[] Texts
        {
            get => _texts;
            set
            {
                _texts = value != null ? value : Array.Empty<string>();
                UpdateLabelTexts();
            }
        }

        private Label[] _labels = Array.Empty<Label>();
        private string[] _texts = Array.Empty<string>();

        protected override void OnCellRebuild(int length)
        {
            UpdateLabelTexts();
        }

        private void UpdateLabelTexts()
        {
            if (_labels.Length != _texts.Length)
            {
                foreach (Label label in _labels)
                {
                    label?.Dispose();
                }

                _labels = new Label[_texts.Length];
            }

            for (int i = 0; i < _labels.Length; i++)
            {
                Panel panel = base.GetCell(i);
                Label label = new Label()
                {
                    Dock = DockStyle.Fill,
                    Margin = Padding.Empty,
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    ForeColor = ForeColor,
                    Font = Font,
                    Text = _texts[i]
                };

                _labels[i] = label;
                panel.Controls.Clear();
                panel.Controls.Add(label);
            }
        }
    }
}