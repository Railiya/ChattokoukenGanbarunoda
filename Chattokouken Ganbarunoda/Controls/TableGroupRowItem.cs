using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CKG.Controls
{
    public class TableGroupRowItem : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Layout")]
        public int[] CellWidths
        {
            get => _cellWidths;
            set
            {
                _cellWidths = value != null ? value : Array.Empty<int>();
                RebuildCells();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "White")]
        [Browsable(true)]
        public Color CellColor
        {
            get => _cellColor;
            set
            {
                _cellColor = value;

                foreach (Panel panel in _cellPanels)
                {
                    panel.BackColor = value;
                }
            }
        }

        public int CellCount => _cellPanels.Length;

        private Panel[] _cellPanels = Array.Empty<Panel>();
        private int[] _cellWidths = new int[] { 50, 50, 50 };
        private Color _cellColor = Color.White;

        public TableGroupRowItem()
        {
            DoubleBuffered = true;
            Margin = Padding.Empty;
            Padding = Padding.Empty;

            RebuildCells();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateCellLayouts();
        }

        protected Panel GetCell(int index)
        {
            if (index < 0 || index >= _cellPanels.Length)
            {
                return null;
            }

            return _cellPanels[index];
        }

        protected virtual void OnBeforeCellRebuild() { }
        protected virtual void OnCellRebuild(int length) { }

        private void RebuildCells()
        {
            if (_cellWidths == null)
            {
                return;
            }

            SuspendLayout();
            OnBeforeCellRebuild();

            foreach (Panel panel in _cellPanels)
            {
                panel?.Dispose();
            }

            int length = _cellWidths.Length;

            _cellPanels = new Panel[length];
            Controls.Clear();

            for (int i = 0; i < length; i++)
            {
                Panel panel = new Panel()
                {
                    Margin = Padding.Empty,
                    Padding = Padding.Empty,
                    BorderStyle = BorderStyle.FixedSingle
                };

                _cellPanels[i] = panel;
                Controls.Add(panel);
            }

            UpdateCellLayouts();
            OnCellRebuild(length);

            ResumeLayout();
        }

        private void UpdateCellLayouts()
        {
            int currentX = 0;

            for (int i = 0; i < _cellPanels.Length; i++)
            {
                Panel panel = _cellPanels[i];

                panel.Location = new Point(currentX, 0);
                panel.Size = new Size(_cellWidths[i], Height);
                panel.BackColor = CellColor;

                currentX += _cellWidths[i] - 1;
            }
        }
    }
}
