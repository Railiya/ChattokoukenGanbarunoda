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
            _inputTimeoutHintLabel = new System.Windows.Forms.Label();
            _inputTimeoutLabel = new System.Windows.Forms.Label();
            _inputTimeoutField = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)_iconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_inputTimeoutField).BeginInit();
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
            _debugEchoModeToggle.Location = new System.Drawing.Point(19, 87);
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
            _executeOnWindowStartToggle.Location = new System.Drawing.Point(19, 157);
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
            _writeLogFileToggle.Location = new System.Drawing.Point(19, 122);
            _writeLogFileToggle.Name = "_writeLogFileToggle";
            _writeLogFileToggle.Size = new System.Drawing.Size(262, 20);
            _writeLogFileToggle.TabIndex = 22;
            _writeLogFileToggle.Text = "Write Log File";
            _writeLogFileToggle.UseVisualStyleBackColor = true;
            _writeLogFileToggle.CheckedChanged += _writeLogFileToggle_CheckedChanged;
            // 
            // _inputTimeoutHintLabel
            // 
            _inputTimeoutHintLabel.Location = new System.Drawing.Point(200, 50);
            _inputTimeoutHintLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            _inputTimeoutHintLabel.Name = "_inputTimeoutHintLabel";
            _inputTimeoutHintLabel.Size = new System.Drawing.Size(84, 20);
            _inputTimeoutHintLabel.TabIndex = 23;
            _inputTimeoutHintLabel.Text = "(0: Disabled)";
            // 
            // _inputTimeoutLabel
            // 
            _inputTimeoutLabel.Location = new System.Drawing.Point(16, 50);
            _inputTimeoutLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _inputTimeoutLabel.Name = "_inputTimeoutLabel";
            _inputTimeoutLabel.Size = new System.Drawing.Size(115, 20);
            _inputTimeoutLabel.TabIndex = 24;
            _inputTimeoutLabel.Text = "Input Timeout (sec)";
            // 
            // _inputTimeoutField
            // 
            _inputTimeoutField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _inputTimeoutField.Enabled = false;
            _inputTimeoutField.Location = new System.Drawing.Point(137, 47);
            _inputTimeoutField.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            _inputTimeoutField.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _inputTimeoutField.Name = "_inputTimeoutField";
            _inputTimeoutField.Size = new System.Drawing.Size(60, 23);
            _inputTimeoutField.TabIndex = 25;
            _inputTimeoutField.Value = new decimal(new int[] { 3, 0, 0, 0 });
            _inputTimeoutField.ValueChanged += _inputTimeoutField_ValueChanged;
            // 
            // AdvancedPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(_debugEchoModeToggle);
            Controls.Add(_executeOnWindowStartToggle);
            Controls.Add(_writeLogFileToggle);
            Controls.Add(_inputTimeoutHintLabel);
            Controls.Add(_inputTimeoutLabel);
            Controls.Add(_inputTimeoutField);
            Icon = Properties.Resources.advanced_icon;
            Name = "AdvancedPanel";
            Padding = new System.Windows.Forms.Padding(16, 40, 16, 16);
            Size = new System.Drawing.Size(300, 230);
            Title = "Advanced";
            Controls.SetChildIndex(_titleLabel, 0);
            Controls.SetChildIndex(_iconBox, 0);
            Controls.SetChildIndex(_inputTimeoutField, 0);
            Controls.SetChildIndex(_inputTimeoutLabel, 0);
            Controls.SetChildIndex(_inputTimeoutHintLabel, 0);
            Controls.SetChildIndex(_writeLogFileToggle, 0);
            Controls.SetChildIndex(_executeOnWindowStartToggle, 0);
            Controls.SetChildIndex(_debugEchoModeToggle, 0);
            ((System.ComponentModel.ISupportInitialize)_iconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)_inputTimeoutField).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox _debugEchoModeToggle;
        private System.Windows.Forms.CheckBox _executeOnWindowStartToggle;
        private System.Windows.Forms.CheckBox _writeLogFileToggle;
        private System.Windows.Forms.Label _inputTimeoutHintLabel;
        private System.Windows.Forms.Label _inputTimeoutLabel;
        private System.Windows.Forms.NumericUpDown _inputTimeoutField;
    }
}