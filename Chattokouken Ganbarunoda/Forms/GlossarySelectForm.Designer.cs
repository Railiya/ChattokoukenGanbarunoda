namespace CKG.Forms
{
    partial class GlossarySelectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _itemLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            SuspendLayout();
            // 
            // _itemLayoutPanel
            // 
            _itemLayoutPanel.Location = new System.Drawing.Point(9, 9);
            _itemLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            _itemLayoutPanel.Name = "_itemLayoutPanel";
            _itemLayoutPanel.Size = new System.Drawing.Size(266, 323);
            _itemLayoutPanel.TabIndex = 0;
            // 
            // GlossarySelectForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(284, 341);
            Controls.Add(_itemLayoutPanel);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GlossarySelectForm";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Select Glossary";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _itemLayoutPanel;
    }
}