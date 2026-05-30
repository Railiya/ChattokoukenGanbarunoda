namespace CKG.Controls
{
    partial class HotkeysPanel
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
            _hotkeysHintLabel = new System.Windows.Forms.Label();
            _labelGroup = new LabelGroupRowItem();
            _enableCapturingKeyGroup = new HotkeyGroupRowItem();
            _chatToggleKeyGroup = new HotkeyGroupRowItem();
            _requestTranslateKeyGroup = new HotkeyGroupRowItem();
            _sendClipboardKeyGroup = new HotkeyGroupRowItem();
            ((System.ComponentModel.ISupportInitialize)_iconBox).BeginInit();
            SuspendLayout();
            // 
            // _titleLabel
            // 
            _titleLabel.Location = new System.Drawing.Point(48, 10);
            _titleLabel.Size = new System.Drawing.Size(66, 20);
            _titleLabel.Text = "Hotkeys";
            // 
            // _iconBox
            // 
            _iconBox.Image = Properties.Resources.hotkeys_icon;
            _iconBox.Location = new System.Drawing.Point(12, 5);
            // 
            // _hotkeysHintLabel
            // 
            _hotkeysHintLabel.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 129);
            _hotkeysHintLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            _hotkeysHintLabel.Location = new System.Drawing.Point(16, 198);
            _hotkeysHintLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _hotkeysHintLabel.Name = "_hotkeysHintLabel";
            _hotkeysHintLabel.Size = new System.Drawing.Size(466, 16);
            _hotkeysHintLabel.TabIndex = 65;
            _hotkeysHintLabel.Text = "Click the key button and press any key to set hotkey";
            _hotkeysHintLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _labelGroup
            // 
            _labelGroup.CellColor = System.Drawing.Color.WhiteSmoke;
            _labelGroup.CellHeight = 30;
            _labelGroup.CellWidths = new int[]
    {
    200,
    120,
    50,
    50,
    50
    };
            _labelGroup.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            _labelGroup.Location = new System.Drawing.Point(16, 50);
            _labelGroup.Margin = new System.Windows.Forms.Padding(0);
            _labelGroup.Name = "_labelGroup";
            _labelGroup.Size = new System.Drawing.Size(466, 30);
            _labelGroup.TabIndex = 85;
            _labelGroup.Texts = new string[]
    {
    "Action",
    "Key",
    "Ctrl",
    "Alt",
    "Shift"
    };
            // 
            // _enableCapturingKeyGroup
            // 
            _enableCapturingKeyGroup.Alt = false;
            _enableCapturingKeyGroup.CellHeight = 30;
            _enableCapturingKeyGroup.CellWidths = new int[]
    {
    200,
    120,
    50,
    50,
    50
    };
            _enableCapturingKeyGroup.Ctrl = false;
            _enableCapturingKeyGroup.Key = System.Windows.Forms.Keys.None;
            _enableCapturingKeyGroup.KeyText = "Enable Capturing";
            _enableCapturingKeyGroup.Location = new System.Drawing.Point(16, 79);
            _enableCapturingKeyGroup.Margin = new System.Windows.Forms.Padding(0);
            _enableCapturingKeyGroup.Name = "_enableCapturingKeyGroup";
            _enableCapturingKeyGroup.Shift = false;
            _enableCapturingKeyGroup.Size = new System.Drawing.Size(466, 30);
            _enableCapturingKeyGroup.TabIndex = 86;
            _enableCapturingKeyGroup.Type = EHotkey.EnableCapturing;
            // 
            // _chatToggleKeyGroup
            // 
            _chatToggleKeyGroup.Alt = false;
            _chatToggleKeyGroup.CellHeight = 30;
            _chatToggleKeyGroup.CellWidths = new int[]
    {
    200,
    120,
    50,
    50,
    50
    };
            _chatToggleKeyGroup.Ctrl = false;
            _chatToggleKeyGroup.Key = System.Windows.Forms.Keys.None;
            _chatToggleKeyGroup.KeyText = "Chat Toggle";
            _chatToggleKeyGroup.Location = new System.Drawing.Point(16, 108);
            _chatToggleKeyGroup.Margin = new System.Windows.Forms.Padding(0);
            _chatToggleKeyGroup.Name = "_chatToggleKeyGroup";
            _chatToggleKeyGroup.Shift = false;
            _chatToggleKeyGroup.Size = new System.Drawing.Size(466, 30);
            _chatToggleKeyGroup.TabIndex = 87;
            _chatToggleKeyGroup.Type = EHotkey.ChatToggle;
            // 
            // _requestTranslateKeyGroup
            // 
            _requestTranslateKeyGroup.Alt = false;
            _requestTranslateKeyGroup.CellHeight = 30;
            _requestTranslateKeyGroup.CellWidths = new int[]
    {
    200,
    120,
    50,
    50,
    50
    };
            _requestTranslateKeyGroup.Ctrl = false;
            _requestTranslateKeyGroup.Key = System.Windows.Forms.Keys.None;
            _requestTranslateKeyGroup.KeyText = "Request Translate";
            _requestTranslateKeyGroup.Location = new System.Drawing.Point(16, 137);
            _requestTranslateKeyGroup.Margin = new System.Windows.Forms.Padding(0);
            _requestTranslateKeyGroup.Name = "_requestTranslateKeyGroup";
            _requestTranslateKeyGroup.Shift = false;
            _requestTranslateKeyGroup.Size = new System.Drawing.Size(466, 30);
            _requestTranslateKeyGroup.TabIndex = 88;
            _requestTranslateKeyGroup.Type = EHotkey.RequestTranslate;
            // 
            // _sendClipboardKeyGroup
            // 
            _sendClipboardKeyGroup.Alt = false;
            _sendClipboardKeyGroup.CellHeight = 30;
            _sendClipboardKeyGroup.CellWidths = new int[]
    {
    200,
    120,
    50,
    50,
    50
    };
            _sendClipboardKeyGroup.Ctrl = false;
            _sendClipboardKeyGroup.Key = System.Windows.Forms.Keys.None;
            _sendClipboardKeyGroup.KeyText = "Send Clipboard";
            _sendClipboardKeyGroup.Location = new System.Drawing.Point(16, 166);
            _sendClipboardKeyGroup.Margin = new System.Windows.Forms.Padding(0);
            _sendClipboardKeyGroup.Name = "_sendClipboardKeyGroup";
            _sendClipboardKeyGroup.Shift = false;
            _sendClipboardKeyGroup.Size = new System.Drawing.Size(466, 30);
            _sendClipboardKeyGroup.TabIndex = 89;
            _sendClipboardKeyGroup.Type = EHotkey.SendClipboard;
            // 
            // HotkeysPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(_sendClipboardKeyGroup);
            Controls.Add(_requestTranslateKeyGroup);
            Controls.Add(_chatToggleKeyGroup);
            Controls.Add(_enableCapturingKeyGroup);
            Controls.Add(_labelGroup);
            Controls.Add(_hotkeysHintLabel);
            Icon = Properties.Resources.hotkeys_icon;
            Name = "HotkeysPanel";
            Padding = new System.Windows.Forms.Padding(16, 40, 16, 16);
            Size = new System.Drawing.Size(500, 230);
            Title = "Hotkeys";
            Controls.SetChildIndex(_hotkeysHintLabel, 0);
            Controls.SetChildIndex(_titleLabel, 0);
            Controls.SetChildIndex(_iconBox, 0);
            Controls.SetChildIndex(_labelGroup, 0);
            Controls.SetChildIndex(_enableCapturingKeyGroup, 0);
            Controls.SetChildIndex(_chatToggleKeyGroup, 0);
            Controls.SetChildIndex(_requestTranslateKeyGroup, 0);
            Controls.SetChildIndex(_sendClipboardKeyGroup, 0);
            ((System.ComponentModel.ISupportInitialize)_iconBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label _hotkeysHintLabel;
        private LabelGroupRowItem _labelGroup;
        private HotkeyGroupRowItem _enableCapturingKeyGroup;
        private HotkeyGroupRowItem _chatToggleKeyGroup;
        private HotkeyGroupRowItem _requestTranslateKeyGroup;
        private HotkeyGroupRowItem _sendClipboardKeyGroup;
    }
}