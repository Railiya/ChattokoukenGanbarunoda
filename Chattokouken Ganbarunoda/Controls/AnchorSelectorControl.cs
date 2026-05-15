using System;
using System.Drawing;
using System.Windows.Forms;

namespace CKG.Controls
{
    public partial class AnchorSelectorControl : UserControl
    {
        private struct SAnchorInfo
        {
            public ContentAlignment Alignment;
            public int Column;
            public int Row;

            public SAnchorInfo(ContentAlignment alignment, int column, int row)
            {
                Alignment = alignment;
                Column = column;
                Row = row;
            }
        }

        private static readonly SAnchorInfo[] ANCHOR_INFOS = new SAnchorInfo[]
        {
            new SAnchorInfo(ContentAlignment.TopLeft, 0, 0),
            new SAnchorInfo(ContentAlignment.TopCenter, 1, 0),
            new SAnchorInfo(ContentAlignment.TopRight, 2, 0),
            new SAnchorInfo(ContentAlignment.MiddleLeft, 0, 1),
            new SAnchorInfo(ContentAlignment.MiddleCenter, 1, 1),
            new SAnchorInfo(ContentAlignment.MiddleRight, 2, 1),
            new SAnchorInfo(ContentAlignment.BottomLeft, 0, 2),
            new SAnchorInfo(ContentAlignment.BottomCenter, 1, 2),
            new SAnchorInfo(ContentAlignment.BottomRight, 2, 2),
        };

        public event Action<ContentAlignment> OnAnchorChanged = null;

        private ContentAlignment _selectedAnchor = ContentAlignment.TopLeft;
        public ContentAlignment SelectedAnchor
        {
            get => _selectedAnchor;
            set => UpdateSelectedAnchorWithoutNotify(value);
        }

        private RadioButton[] _buttons = new RadioButton[9];
        private bool _lockEvent = false;

        public AnchorSelectorControl()
        {
            InitializeComponent();
            BuildLayout();
        }

        private void BuildLayout()
        {
            TableLayoutPanel layout = new TableLayoutPanel();

            layout.RowCount = 3;
            layout.ColumnCount = 3;
            layout.Dock = DockStyle.Fill;
            layout.Margin = Padding.Empty;
            layout.Padding = Padding.Empty;

            for (int i = 0; i < 3; i++)
            {
                layout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            }

            Controls.Add(layout);

            for (int i = 0; i < ANCHOR_INFOS.Length; i++)
            {
                SAnchorInfo info = ANCHOR_INFOS[i];

                if (info.Alignment == ContentAlignment.MiddleCenter)
                {
                    continue; //Skip middle-center button
                }

                RadioButton button = new RadioButton();

                button.Anchor = AnchorStyles.None;
                button.AutoSize = true;
                button.Tag = info.Alignment;
                button.Margin = Padding.Empty;
                button.CheckedChanged += OnRadioCheckedChanged;

                _buttons[i] = button;
                layout.Controls.Add(button, info.Column, info.Row);
            }

            _buttons[0].Checked = true;
        }

        private void OnRadioCheckedChanged(object sender, EventArgs e)
        {
            if (_lockEvent)
            {
                return;
            }

            RadioButton button = sender as RadioButton;

            if (button == null || button.Checked == false)
            {
                return;
            }

            SelectedAnchor = (ContentAlignment)button.Tag;

            OnAnchorChanged?.Invoke(SelectedAnchor);
        }

        private void UpdateSelectedAnchorWithoutNotify(ContentAlignment anchor)
        {
            int index = IndexOfAnchor(anchor);

            if (anchor == ContentAlignment.MiddleCenter || index == -1)
            {
                return;
            }

            _lockEvent = true;

            _selectedAnchor = anchor;
            _buttons[index].Checked = true;

            _lockEvent = false;
        }

        private int IndexOfAnchor(ContentAlignment anchor)
        {
            for (int i = 0; i < ANCHOR_INFOS.Length; i++)
            {
                if (ANCHOR_INFOS[i].Alignment == anchor)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}