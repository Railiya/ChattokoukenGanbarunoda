namespace CKG.Controls
{
    partial class AdvancedPanel
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
            _debugEchoModeToggle = new System.Windows.Forms.CheckBox();
            _executeOnWindowStartToggle = new System.Windows.Forms.CheckBox();
            _writeLogFileToggle = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)_iconBox).BeginInit();
            SuspendLayout();
            // 
            // _titleLabel
            // 
            _titleLabel.Location = new System.Drawing.Point(48, 10);
            _titleLabel.Size = new System.Drawing.Size(78, 20);
            _titleLabel.Text = "Advanced";
            // 
            // _iconBox
            // 
            _iconBox.Image = Properties.Resources.advanced_icon;
            _iconBox.Location = new System.Drawing.Point(12, 5);
            // 
            // _debugEchoModeToggle
            // 
            _debugEchoModeToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _debugEchoModeToggle.Location = new System.Drawing.Point(19, 50);
            _debugEchoModeToggle.Name = "_debugEchoModeToggle";
            _debugEchoModeToggle.Size = new System.Drawing.Size(262, 20);
            _debugEchoModeToggle.TabIndex = 27;
            _debugEchoModeToggle.Text = "Debug Echo Mode";
            _debugEchoModeToggle.UseVisualStyleBackColor = true;
            _debugEchoModeToggle.CheckedChanged += _debugEchoModeToggle_CheckedChanged;
            // 
            // _executeOnWindowStartToggle
            // 
            _executeOnWindowStartToggle.Enabled = false;
            _executeOnWindowStartToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _executeOnWindowStartToggle.Location = new System.Drawing.Point(19, 120);
            _executeOnWindowStartToggle.Name = "_executeOnWindowStartToggle";
            _executeOnWindowStartToggle.Size = new System.Drawing.Size(262, 20);
            _executeOnWindowStartToggle.TabIndex = 26;
            _executeOnWindowStartToggle.Text = "Execute on Window Start";
            _executeOnWindowStartToggle.UseVisualStyleBackColor = true;
            _executeOnWindowStartToggle.CheckedChanged += _executeOnWindowStartToggle_CheckedChanged;
            // 
            // _writeLogFileToggle
            // 
            _writeLogFileToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _writeLogFileToggle.Location = new System.Drawing.Point(19, 85);
            _writeLogFileToggle.Name = "_writeLogFileToggle";
            _writeLogFileToggle.Size = new System.Drawing.Size(262, 20);
            _writeLogFileToggle.TabIndex = 22;
            _writeLogFileToggle.Text = "Write Log File";
            _writeLogFileToggle.UseVisualStyleBackColor = true;
            _writeLogFileToggle.CheckedChanged += _writeLogFileToggle_CheckedChanged;
            // 
            // AdvancedPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(_debugEchoModeToggle);
            Controls.Add(_executeOnWindowStartToggle);
            Controls.Add(_writeLogFileToggle);
            Icon = Properties.Resources.advanced_icon;
            Name = "AdvancedPanel";
            Padding = new System.Windows.Forms.Padding(16, 40, 16, 16);
            Size = new System.Drawing.Size(300, 160);
            Title = "Advanced";
            Controls.SetChildIndex(_titleLabel, 0);
            Controls.SetChildIndex(_iconBox, 0);
            Controls.SetChildIndex(_writeLogFileToggle, 0);
            Controls.SetChildIndex(_executeOnWindowStartToggle, 0);
            Controls.SetChildIndex(_debugEchoModeToggle, 0);
            ((System.ComponentModel.ISupportInitialize)_iconBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox _debugEchoModeToggle;
        private System.Windows.Forms.CheckBox _executeOnWindowStartToggle;
        private System.Windows.Forms.CheckBox _writeLogFileToggle;
    }
}