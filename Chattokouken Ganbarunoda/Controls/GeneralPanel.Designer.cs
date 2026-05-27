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
            _directInputHint = new System.Windows.Forms.Label();
            _defaultInputCharacterSelector = new System.Windows.Forms.ComboBox();
            _defaultInputCharacterLabel = new System.Windows.Forms.Label();
            _outputMethodSelector = new System.Windows.Forms.ComboBox();
            _outputMethodLabel = new System.Windows.Forms.Label();
            _autoSendClipboardToggle = new System.Windows.Forms.CheckBox();
            _startTranslateToggle = new System.Windows.Forms.CheckBox();
            _inputMethodSelector = new System.Windows.Forms.ComboBox();
            _inputMethodLabel = new System.Windows.Forms.Label();
            _startCapturingToggle = new System.Windows.Forms.CheckBox();
            _outputSkipChatStartToggle = new System.Windows.Forms.CheckBox();
            _overlayInputSkipChatStartToggle = new System.Windows.Forms.CheckBox();
            _skipIdleToggle = new System.Windows.Forms.CheckBox();
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
            // _directInputHint
            // 
            _directInputHint.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 129);
            _directInputHint.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            _directInputHint.Location = new System.Drawing.Point(12, 290);
            _directInputHint.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _directInputHint.Name = "_directInputHint";
            _directInputHint.Size = new System.Drawing.Size(465, 44);
            _directInputHint.TabIndex = 14;
            _directInputHint.Text = "Direct Input Hint:\r\nPress the Han/Eng key to switch Input Mode. To change only the IME language, press it together with Ctrl (or Alt, Shift)";
            // 
            // _defaultInputCharacterSelector
            // 
            _defaultInputCharacterSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _defaultInputCharacterSelector.FormattingEnabled = true;
            _defaultInputCharacterSelector.ItemHeight = 15;
            _defaultInputCharacterSelector.Items.AddRange(new object[] { "Alphabet", "Hangul" });
            _defaultInputCharacterSelector.Location = new System.Drawing.Point(12, 265);
            _defaultInputCharacterSelector.Name = "_defaultInputCharacterSelector";
            _defaultInputCharacterSelector.Size = new System.Drawing.Size(225, 23);
            _defaultInputCharacterSelector.TabIndex = 13;
            _defaultInputCharacterSelector.SelectedIndexChanged += _defaultInputModeSelector_SelectedIndexChanged;
            // 
            // _defaultInputCharacterLabel
            // 
            _defaultInputCharacterLabel.Location = new System.Drawing.Point(12, 245);
            _defaultInputCharacterLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _defaultInputCharacterLabel.Name = "_defaultInputCharacterLabel";
            _defaultInputCharacterLabel.Size = new System.Drawing.Size(225, 20);
            _defaultInputCharacterLabel.TabIndex = 12;
            _defaultInputCharacterLabel.Text = "Default Input Character";
            // 
            // _outputMethodSelector
            // 
            _outputMethodSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _outputMethodSelector.FormattingEnabled = true;
            _outputMethodSelector.ItemHeight = 15;
            _outputMethodSelector.Items.AddRange(new object[] { "Clipboard Paste", "Input Simulation" });
            _outputMethodSelector.Location = new System.Drawing.Point(252, 205);
            _outputMethodSelector.Name = "_outputMethodSelector";
            _outputMethodSelector.Size = new System.Drawing.Size(225, 23);
            _outputMethodSelector.TabIndex = 11;
            _outputMethodSelector.SelectedIndexChanged += _outputMethodSelector_SelectedIndexChanged;
            // 
            // _outputMethodLabel
            // 
            _outputMethodLabel.Location = new System.Drawing.Point(252, 185);
            _outputMethodLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _outputMethodLabel.Name = "_outputMethodLabel";
            _outputMethodLabel.Size = new System.Drawing.Size(225, 20);
            _outputMethodLabel.TabIndex = 10;
            _outputMethodLabel.Text = "Output Method";
            // 
            // _autoSendClipboardToggle
            // 
            _autoSendClipboardToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _autoSendClipboardToggle.Location = new System.Drawing.Point(256, 50);
            _autoSendClipboardToggle.Name = "_autoSendClipboardToggle";
            _autoSendClipboardToggle.Size = new System.Drawing.Size(225, 35);
            _autoSendClipboardToggle.TabIndex = 9;
            _autoSendClipboardToggle.Text = "Auto Send Clipboard on Translated";
            _autoSendClipboardToggle.UseVisualStyleBackColor = true;
            _autoSendClipboardToggle.CheckedChanged += _autoSendClipboardToggle_CheckedChanged;
            // 
            // _startTranslateToggle
            // 
            _startTranslateToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _startTranslateToggle.Location = new System.Drawing.Point(16, 50);
            _startTranslateToggle.Name = "_startTranslateToggle";
            _startTranslateToggle.Size = new System.Drawing.Size(225, 35);
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
            _inputMethodSelector.Location = new System.Drawing.Point(12, 205);
            _inputMethodSelector.Name = "_inputMethodSelector";
            _inputMethodSelector.Size = new System.Drawing.Size(225, 23);
            _inputMethodSelector.TabIndex = 16;
            _inputMethodSelector.SelectedIndexChanged += _inputMethodSelector_SelectedIndexChanged;
            // 
            // _inputMethodLabel
            // 
            _inputMethodLabel.Location = new System.Drawing.Point(12, 185);
            _inputMethodLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _inputMethodLabel.Name = "_inputMethodLabel";
            _inputMethodLabel.Size = new System.Drawing.Size(225, 20);
            _inputMethodLabel.TabIndex = 15;
            _inputMethodLabel.Text = "Input Method";
            // 
            // _startCapturingToggle
            // 
            _startCapturingToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _startCapturingToggle.Location = new System.Drawing.Point(16, 90);
            _startCapturingToggle.Name = "_startCapturingToggle";
            _startCapturingToggle.Size = new System.Drawing.Size(225, 35);
            _startCapturingToggle.TabIndex = 19;
            _startCapturingToggle.Text = "Start Capturing on Send Clipboard";
            _startCapturingToggle.UseVisualStyleBackColor = true;
            _startCapturingToggle.CheckedChanged += _startCapturingToggle_CheckedChanged;
            // 
            // _outputSkipChatStartToggle
            // 
            _outputSkipChatStartToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _outputSkipChatStartToggle.Location = new System.Drawing.Point(16, 130);
            _outputSkipChatStartToggle.Name = "_outputSkipChatStartToggle";
            _outputSkipChatStartToggle.Size = new System.Drawing.Size(225, 35);
            _outputSkipChatStartToggle.TabIndex = 20;
            _outputSkipChatStartToggle.Text = "Skip Chat Start Input Step on Send Clipboard";
            _outputSkipChatStartToggle.UseVisualStyleBackColor = true;
            _outputSkipChatStartToggle.CheckedChanged += _outputSkipChatStartToggle_CheckedChanged;
            // 
            // _overlayInputSkipChatStartToggle
            // 
            _overlayInputSkipChatStartToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _overlayInputSkipChatStartToggle.Location = new System.Drawing.Point(256, 130);
            _overlayInputSkipChatStartToggle.Name = "_overlayInputSkipChatStartToggle";
            _overlayInputSkipChatStartToggle.Size = new System.Drawing.Size(225, 35);
            _overlayInputSkipChatStartToggle.TabIndex = 21;
            _overlayInputSkipChatStartToggle.Text = "(Overlay Input) Skip Chat Start Input Step on Send Original Text";
            _overlayInputSkipChatStartToggle.UseVisualStyleBackColor = true;
            _overlayInputSkipChatStartToggle.CheckedChanged += _overlayInputSkipChatStartToggle_CheckedChanged;
            // 
            // _skipIdleToggle
            // 
            _skipIdleToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _skipIdleToggle.Location = new System.Drawing.Point(256, 90);
            _skipIdleToggle.Name = "_skipIdleToggle";
            _skipIdleToggle.Size = new System.Drawing.Size(225, 35);
            _skipIdleToggle.TabIndex = 22;
            _skipIdleToggle.Text = "Skip Idle State";
            _skipIdleToggle.UseVisualStyleBackColor = true;
            _skipIdleToggle.CheckedChanged += _skipIdleToggle_CheckedChanged;
            // 
            // GeneralPanel
            // 
            Controls.Add(_skipIdleToggle);
            Controls.Add(_overlayInputSkipChatStartToggle);
            Controls.Add(_outputSkipChatStartToggle);
            Controls.Add(_startCapturingToggle);
            Controls.Add(_inputMethodSelector);
            Controls.Add(_inputMethodLabel);
            Controls.Add(_directInputHint);
            Controls.Add(_defaultInputCharacterSelector);
            Controls.Add(_defaultInputCharacterLabel);
            Controls.Add(_outputMethodSelector);
            Controls.Add(_outputMethodLabel);
            Controls.Add(_autoSendClipboardToggle);
            Controls.Add(_startTranslateToggle);
            Icon = Properties.Resources.general_icon;
            Name = "GeneralPanel";
            Padding = new System.Windows.Forms.Padding(16, 40, 16, 16);
            Size = new System.Drawing.Size(500, 350);
            Title = "General";
            Controls.SetChildIndex(_startTranslateToggle, 0);
            Controls.SetChildIndex(_autoSendClipboardToggle, 0);
            Controls.SetChildIndex(_outputMethodLabel, 0);
            Controls.SetChildIndex(_outputMethodSelector, 0);
            Controls.SetChildIndex(_defaultInputCharacterLabel, 0);
            Controls.SetChildIndex(_defaultInputCharacterSelector, 0);
            Controls.SetChildIndex(_directInputHint, 0);
            Controls.SetChildIndex(_inputMethodLabel, 0);
            Controls.SetChildIndex(_inputMethodSelector, 0);
            Controls.SetChildIndex(_titleLabel, 0);
            Controls.SetChildIndex(_iconBox, 0);
            Controls.SetChildIndex(_startCapturingToggle, 0);
            Controls.SetChildIndex(_outputSkipChatStartToggle, 0);
            Controls.SetChildIndex(_overlayInputSkipChatStartToggle, 0);
            Controls.SetChildIndex(_skipIdleToggle, 0);
            ((System.ComponentModel.ISupportInitialize)_iconBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label _directInputHint;
        private System.Windows.Forms.ComboBox _defaultInputCharacterSelector;
        private System.Windows.Forms.Label _defaultInputCharacterLabel;
        private System.Windows.Forms.ComboBox _outputMethodSelector;
        private System.Windows.Forms.Label _outputMethodLabel;
        private System.Windows.Forms.CheckBox _autoSendClipboardToggle;
        private System.Windows.Forms.CheckBox _startTranslateToggle;
        private System.Windows.Forms.ComboBox _inputMethodSelector;
        private System.Windows.Forms.Label _inputMethodLabel;
        private System.Windows.Forms.CheckBox _startCapturingToggle;
        private System.Windows.Forms.CheckBox _outputSkipChatStartToggle;
        private System.Windows.Forms.CheckBox _overlayInputSkipChatStartToggle;
        private System.Windows.Forms.CheckBox _skipIdleToggle;
    }
}