using System.Collections.Generic;
using System.Text.Json;
using System.Drawing;
using System.Windows.Forms;

namespace CKG.Controls
{
    public class SettingPanel : UserControl
    {
        protected virtual string LocalizationKey { get; }

        protected Label _titleLabel = null;
        protected PictureBox _iconBox = null;
        protected ToolTip _toolTip = null;

        public string Title
        {
            get => _titleLabel.Text;
            set => _titleLabel.Text = value;
        }

        public Image Icon
        {
            get => _iconBox.Image;
            set => _iconBox.Image = value;
        }

        public SettingPanel()
        {
            InitializeBaseComponent();
            Layout += OnLayoutUpdate;
        }

        private void InitializeBaseComponent()
        {
            SuspendLayout();

            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Padding = new Padding(16, 40, 10, 16);

            // Icon
            _iconBox = new PictureBox();
            _iconBox.Name = "_iconBox";
            _iconBox.Size = new Size(30, 30);
            _iconBox.Location = new Point(12, 10);
            _iconBox.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(_iconBox);

            // Title
            _titleLabel = new Label();
            _titleLabel.Name = "_titleLabel";
            _titleLabel.AutoSize = true;
            _titleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _titleLabel.Location = new Point(12, 10);
            _titleLabel.Text = "Panel";
            Controls.Add(_titleLabel);

            ResumeLayout(false);
        }

        public virtual void UpdateProfile(UserProfile profile) { }

        public void SetLocalization(in JsonElement root, in JsonElement tooltip)
        {
            JsonElement element = root.GetProperty(LocalizationKey);
            JsonElement property = default;

            foreach (Control control in GetControls())
            {
                string name = control.Name;

                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }

                //Set text of controls
                if (element.TryGetProperty(name, out property))
                {
                    if (control is ComboBox selector) //Set combo box
                    {
                        int selectedIndex = selector.SelectedIndex;
                        int length = property.GetArrayLength();

                        selector.Items.Clear();

                        for (int i = 0; i < length; i++)
                        {
                            selector.Items.Add(property[i].GetString());
                        }

                        selector.SelectedIndex = selectedIndex;
                    }
                    else if (control is HotkeyGroupRowItem keyGroup)
                    {
                        keyGroup.KeyText = property.GetString();
                    }
                    else //Set else (Label, Toggle etc..)
                    {
                        control.Text = property.GetString();
                    }
                }

                //Set tooltip of controls
                if (tooltip.TryGetProperty(name, out property))
                {
                    if (_toolTip == null)
                    {
                        _toolTip = new ToolTip();
                    }

                    if (control is HotkeyGroupRowItem keyGroup) //Set hotkey group label tooltip
                    {
                        _toolTip.SetToolTip(keyGroup.NameLabel, property.GetString());
                    }
                    else //Set else (Label, Toggle etc..)
                    {
                        _toolTip.SetToolTip(control, property.GetString());
                    }
                }
            }
        }

        protected virtual void OnLayoutUpdate(object sender, LayoutEventArgs e)
        {
            int headerHeight = 40;
            int iconY = (headerHeight - _iconBox.Height) / 2;
            int titleY = (headerHeight - _titleLabel.Height) / 2;

            _iconBox.Location = new Point(12, iconY);
            _titleLabel.Location = new Point(_iconBox.Right + 6, titleY);
        }

        private List<Control> GetControls()
        {
            List<Control> result = new List<Control>();

            foreach (Control control in Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control childControl in panel.Controls)
                    {
                        result.Add(childControl);
                    }
                }
                else
                {
                    result.Add(control);
                }
            }

            return result;
        }
    }
}
