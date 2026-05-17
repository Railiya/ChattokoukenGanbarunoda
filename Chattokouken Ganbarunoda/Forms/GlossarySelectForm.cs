using System;
using System.Drawing;
using System.Windows.Forms;
using CKG.Controls;
using CKG.Translator;

namespace CKG.Forms
{
    public partial class GlossarySelectForm : Form
    {
        private const int ITEM_HEIGHT = 60;
        private const int ITEM_MARGIN = 6;

        private Label _stateLabel = null;
        private Action<GlossaryInfo> _onKeySelect = null;

        #region Constructor

        public GlossarySelectForm()
        {
            InitializeComponent();
            CreateComponents();
        }

        public GlossarySelectForm(TranslationService translationService, Action<GlossaryInfo> OnKeySelect)
        {
            InitializeComponent();
            CreateComponents();
            _onKeySelect = OnKeySelect;

            StartGlossaryLoad(translationService);
        }

        private void CreateComponents()
        {
            //set invisible layout panel
            _itemLayoutPanel.Visible = false;

            //_stateLabel
            _stateLabel = new Label();
            _stateLabel.Dock = DockStyle.Fill;
            _stateLabel.TextAlign = ContentAlignment.MiddleCenter;
            _stateLabel.Font = new Font(this.Font.FontFamily, 12f, FontStyle.Bold);
            _stateLabel.Text = "Loading DeepL glossary..";
            _stateLabel.BringToFront();
            Controls.Add(_stateLabel);

            //Set _itemLayoutPanel
            _itemLayoutPanel.Controls.Clear();
            _itemLayoutPanel.Padding = Padding.Empty;
            _itemLayoutPanel.FlowDirection = FlowDirection.TopDown;
            _itemLayoutPanel.WrapContents = false;
            _itemLayoutPanel.AutoScroll = true;
        }

        #endregion

        #region Private Glossary Load Functions

        private async void StartGlossaryLoad(TranslationService translationService)
        {
            GlossaryInfo[] glossaries = await translationService.LoadGlossariesAsync();

            SetGlossaryComponents(glossaries);
        }

        #endregion

        #region Private Functions

        private void SetGlossaryComponents(GlossaryInfo[] glossaries)
        {
            if (glossaries == null)
            {
                _stateLabel.Text = "Load Failed: Invalid API Key";
                return;
            }

            _stateLabel.Visible = false;
            _itemLayoutPanel.Visible = true;
            _itemLayoutPanel.SuspendLayout();

            try
            {
                int buttonWidth = _itemLayoutPanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;

                foreach (GlossaryInfo glossary in glossaries)
                {
                    AddHeaderButton(glossary, buttonWidth);
                }

                AddHeaderButton(null, buttonWidth); //Add empty glossary button
            }
            finally
            {
                _itemLayoutPanel.ResumeLayout();
            }
        }

        private void AddHeaderButton(GlossaryInfo glossary, int buttonWidth)
        {
            HeaderButton button = new HeaderButton();
            button.Header = glossary == null ? "None" : $"{glossary.Name} ({glossary.EntryCount})";
            button.Content = glossary == null ? "" : glossary.Id;
            button.Width = buttonWidth;
            button.Height = ITEM_HEIGHT;
            button.Margin = new Padding(0, 0, 0, ITEM_MARGIN);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Click += OnClick;

            _itemLayoutPanel.Controls.Add(button);

            void OnClick(object sender, EventArgs e)
            {
                _onKeySelect?.Invoke(glossary);
                Close();
            }
        }

        #endregion
    }
}
