namespace CKG.Controls
{
    partial class GeneralPanel
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
            components = new System.ComponentModel.Container();
            _inputModeHintLabel = new System.Windows.Forms.Label();
            _defaultInputCharacterSelector = new System.Windows.Forms.ComboBox();
            _defaultInputCharacterLabel = new System.Windows.Forms.Label();
            _outputMethodSelector = new System.Windows.Forms.ComboBox();
            _outputMethodLabel = new System.Windows.Forms.Label();
            _autoSendMessageToggle = new System.Windows.Forms.CheckBox();
            _startTranslateToggle = new System.Windows.Forms.CheckBox();
            _inputMethodSelector = new System.Windows.Forms.ComboBox();
            _inputMethodLabel = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)_iconBox).BeginInit();
            SuspendLayout();
            // 
            // _titleLabel
            // 
            _titleLabel.Location = new System.Drawing.Point(48, 10);
            _titleLabel.Size = new System.Drawing.Size(63, 20);
            _titleLabel.Text = "General";
            // 
            // _iconBox
            // 
            _iconBox.Image = Properties.Resources.general_icon;
            _iconBox.Location = new System.Drawing.Point(12, 5);
            // 
            // _inputModeHintLabel
            // 
            _inputModeHintLabel.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 129);
            _inputModeHintLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            _inputModeHintLabel.Location = new System.Drawing.Point(16, 290);
            _inputModeHintLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _inputModeHintLabel.Name = "_inputModeHintLabel";
            _inputModeHintLabel.Size = new System.Drawing.Size(265, 44);
            _inputModeHintLabel.TabIndex = 14;
            _inputModeHintLabel.Text = "Press the Han/Eng key to switch Input Mode.\r\nTo change only the IME language, press it together with Ctrl (or Alt, Shift)";
            _inputModeHintLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _defaultInputCharacterSelector
            // 
            _defaultInputCharacterSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _defaultInputCharacterSelector.FormattingEnabled = true;
            _defaultInputCharacterSelector.ItemHeight = 15;
            _defaultInputCharacterSelector.Items.AddRange(new object[] { "Alphabet", "Hangul" });
            _defaultInputCharacterSelector.Location = new System.Drawing.Point(16, 265);
            _defaultInputCharacterSelector.Name = "_defaultInputCharacterSelector";
            _defaultInputCharacterSelector.Size = new System.Drawing.Size(265, 23);
            _defaultInputCharacterSelector.TabIndex = 13;
            _defaultInputCharacterSelector.SelectedIndexChanged += _defaultInputModeSelector_SelectedIndexChanged;
            // 
            // _defaultInputCharacterLabel
            // 
            _defaultInputCharacterLabel.Location = new System.Drawing.Point(16, 245);
            _defaultInputCharacterLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _defaultInputCharacterLabel.Name = "_defaultInputCharacterLabel";
            _defaultInputCharacterLabel.Size = new System.Drawing.Size(265, 20);
            _defaultInputCharacterLabel.TabIndex = 12;
            _defaultInputCharacterLabel.Text = "Default Input Character";
            // 
            // _outputMethodSelector
            // 
            _outputMethodSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _outputMethodSelector.FormattingEnabled = true;
            _outputMethodSelector.ItemHeight = 15;
            _outputMethodSelector.Items.AddRange(new object[] { "Clipboard Paste", "Input Simulation" });
            _outputMethodSelector.Location = new System.Drawing.Point(16, 205);
            _outputMethodSelector.Name = "_outputMethodSelector";
            _outputMethodSelector.Size = new System.Drawing.Size(265, 23);
            _outputMethodSelector.TabIndex = 11;
            _outputMethodSelector.SelectedIndexChanged += _outputMethodSelector_SelectedIndexChanged;
            // 
            // _outputMethodLabel
            // 
            _outputMethodLabel.Location = new System.Drawing.Point(16, 185);
            _outputMethodLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _outputMethodLabel.Name = "_outputMethodLabel";
            _outputMethodLabel.Size = new System.Drawing.Size(271, 20);
            _outputMethodLabel.TabIndex = 10;
            _outputMethodLabel.Text = "Output Method";
            // 
            // _autoSendMessageToggle
            // 
            _autoSendMessageToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _autoSendMessageToggle.Location = new System.Drawing.Point(16, 85);
            _autoSendMessageToggle.Name = "_autoSendMessageToggle";
            _autoSendMessageToggle.Size = new System.Drawing.Size(265, 20);
            _autoSendMessageToggle.TabIndex = 9;
            _autoSendMessageToggle.Text = "Auto Send Message on Translated";
            _autoSendMessageToggle.UseVisualStyleBackColor = true;
            _autoSendMessageToggle.CheckedChanged += _autoSendMessageToggle_CheckedChanged;
            // 
            // _startTranslateToggle
            // 
            _startTranslateToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _startTranslateToggle.Location = new System.Drawing.Point(16, 50);
            _startTranslateToggle.Name = "_startTranslateToggle";
            _startTranslateToggle.Size = new System.Drawing.Size(265, 20);
            _startTranslateToggle.TabIndex = 8;
            _startTranslateToggle.Text = "Start Translate on Buffered";
            _startTranslateToggle.UseVisualStyleBackColor = true;
            _startTranslateToggle.CheckedChanged += _startTranslateToggle_CheckedChanged;
            // 
            // _inputMethodSelector
            // 
            _inputMethodSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _inputMethodSelector.FormattingEnabled = true;
            _inputMethodSelector.ItemHeight = 15;
            _inputMethodSelector.Items.AddRange(new object[] { "Direct Input", "Overlay Input" });
            _inputMethodSelector.Location = new System.Drawing.Point(16, 145);
            _inputMethodSelector.Name = "_inputMethodSelector";
            _inputMethodSelector.Size = new System.Drawing.Size(265, 23);
            _inputMethodSelector.TabIndex = 16;
            _inputMethodSelector.SelectedIndexChanged += _inputMethodSelector_SelectedIndexChanged;
            // 
            // _inputMethodLabel
            // 
            _inputMethodLabel.Location = new System.Drawing.Point(16, 125);
            _inputMethodLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _inputMethodLabel.Name = "_inputMethodLabel";
            _inputMethodLabel.Size = new System.Drawing.Size(265, 20);
            _inputMethodLabel.TabIndex = 15;
            _inputMethodLabel.Text = "Input Method";
            // 
            // GeneralPanel
            // 
            Controls.Add(_inputMethodSelector);
            Controls.Add(_inputMethodLabel);
            Controls.Add(_inputModeHintLabel);
            Controls.Add(_defaultInputCharacterSelector);
            Controls.Add(_defaultInputCharacterLabel);
            Controls.Add(_outputMethodSelector);
            Controls.Add(_outputMethodLabel);
            Controls.Add(_autoSendMessageToggle);
            Controls.Add(_startTranslateToggle);
            Icon = Properties.Resources.general_icon;
            Name = "GeneralPanel";
            Size = new System.Drawing.Size(300, 350);
            Title = "General";
            Controls.SetChildIndex(_startTranslateToggle, 0);
            Controls.SetChildIndex(_autoSendMessageToggle, 0);
            Controls.SetChildIndex(_outputMethodLabel, 0);
            Controls.SetChildIndex(_outputMethodSelector, 0);
            Controls.SetChildIndex(_defaultInputCharacterLabel, 0);
            Controls.SetChildIndex(_defaultInputCharacterSelector, 0);
            Controls.SetChildIndex(_inputModeHintLabel, 0);
            Controls.SetChildIndex(_titleLabel, 0);
            Controls.SetChildIndex(_iconBox, 0);
            Controls.SetChildIndex(_inputMethodLabel, 0);
            Controls.SetChildIndex(_inputMethodSelector, 0);
            ((System.ComponentModel.ISupportInitialize)_iconBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label _inputModeHintLabel;
        private System.Windows.Forms.ComboBox _defaultInputCharacterSelector;
        private System.Windows.Forms.Label _defaultInputCharacterLabel;
        private System.Windows.Forms.ComboBox _outputMethodSelector;
        private System.Windows.Forms.Label _outputMethodLabel;
        private System.Windows.Forms.CheckBox _autoSendMessageToggle;
        private System.Windows.Forms.CheckBox _startTranslateToggle;
        private System.Windows.Forms.ComboBox _inputMethodSelector;
        private System.Windows.Forms.Label _inputMethodLabel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}