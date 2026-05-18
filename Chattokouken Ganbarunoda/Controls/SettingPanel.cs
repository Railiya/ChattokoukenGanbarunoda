using System.Drawing;
using System.Windows.Forms;

namespace CKG.Controls
{
    public class SettingPanel : UserControl
    {
        protected Label _titleLabel = null;
        protected PictureBox _iconBox = null;

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
            _iconBox.Size = new Size(30, 30);
            _iconBox.Location = new Point(12, 10);
            _iconBox.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(_iconBox);

            // Title
            _titleLabel = new Label();
            _titleLabel.AutoSize = true;
            _titleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _titleLabel.Location = new Point(12, 10);
            _titleLabel.Text = "Panel";
            Controls.Add(_titleLabel);

            ResumeLayout(false);
        }

        public virtual void UpdateProfile(UserProfile profile)
        {
            
        }

        protected virtual void OnLayoutUpdate(object sender, LayoutEventArgs e)
        {
            int headerHeight = 40;
            int iconY = (headerHeight - _iconBox.Height) / 2;
            int titleY = (headerHeight - _titleLabel.Height) / 2;

            _iconBox.Location = new Point(12, iconY);
            _titleLabel.Location = new Point(_iconBox.Right + 6, titleY);
        }
    }
}
