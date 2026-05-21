namespace CKG.Controls
{
    partial class TranslationPanel
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
            _glossarySelectButton = new System.Windows.Forms.Button();
            _glossaryIdField = new System.Windows.Forms.TextBox();
            _requestTimeoutDefaultLabel = new System.Windows.Forms.Label();
            _requestTimeoutLabel = new System.Windows.Forms.Label();
            _requestTimeoutField = new System.Windows.Forms.NumericUpDown();
            _translationFormatHintLabel = new System.Windows.Forms.Label();
            _translationFormatField = new System.Windows.Forms.TextBox();
            _translationFormatLabel = new System.Windows.Forms.Label();
            _destinationLanguage = new System.Windows.Forms.Label();
            _destinationLanguageSelector = new System.Windows.Forms.ComboBox();
            _sourceLanguageSelector = new System.Windows.Forms.ComboBox();
            _sourceLanguageLabel = new System.Windows.Forms.Label();
            _apiKeyField = new System.Windows.Forms.TextBox();
            _apiKeyLabel = new System.Windows.Forms.Label();
            _modelSelector = new System.Windows.Forms.ComboBox();
            _modelLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)_iconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_requestTimeoutField).BeginInit();
            SuspendLayout();
            // 
            // _titleLabel
            // 
            _titleLabel.Location = new System.Drawing.Point(48, 10);
            _titleLabel.Size = new System.Drawing.Size(87, 20);
            _titleLabel.Text = "Translation";
            // 
            // _iconBox
            // 
            _iconBox.Image = Properties.Resources.translation_icon;
            _iconBox.Location = new System.Drawing.Point(12, 5);
            // 
            // _glossarySelectButton
            // 
            _glossarySelectButton.BackgroundImage = Properties.Resources.select_icon;
            _glossarySelectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            _glossarySelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _glossarySelectButton.Location = new System.Drawing.Point(345, 100);
            _glossarySelectButton.Name = "_glossarySelectButton";
            _glossarySelectButton.Size = new System.Drawing.Size(34, 23);
            _glossarySelectButton.TabIndex = 36;
            _glossarySelectButton.UseVisualStyleBackColor = true;
            _glossarySelectButton.Click += _glossarySelectButton_Click;
            // 
            // _glossaryIdField
            // 
            _glossaryIdField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _glossaryIdField.Location = new System.Drawing.Point(169, 100);
            _glossaryIdField.Name = "_glossaryIdField";
            _glossaryIdField.PlaceholderText = "Glossary ID";
            _glossaryIdField.ReadOnly = true;
            _glossaryIdField.Size = new System.Drawing.Size(170, 23);
            _glossaryIdField.TabIndex = 35;
            _glossaryIdField.TextChanged += _glossaryIdField_TextChanged;
            // 
            // _requestTimeoutDefaultLabel
            // 
            _requestTimeoutDefaultLabel.Location = new System.Drawing.Point(215, 279);
            _requestTimeoutDefaultLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            _requestTimeoutDefaultLabel.Name = "_requestTimeoutDefaultLabel";
            _requestTimeoutDefaultLabel.Size = new System.Drawing.Size(164, 20);
            _requestTimeoutDefaultLabel.TabIndex = 34;
            _requestTimeoutDefaultLabel.Text = "(Default: 3)";
            // 
            // _requestTimeoutLabel
            // 
            _requestTimeoutLabel.Location = new System.Drawing.Point(16, 279);
            _requestTimeoutLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _requestTimeoutLabel.Name = "_requestTimeoutLabel";
            _requestTimeoutLabel.Size = new System.Drawing.Size(130, 20);
            _requestTimeoutLabel.TabIndex = 33;
            _requestTimeoutLabel.Text = "Request Timeout (sec)";
            // 
            // _requestTimeoutField
            // 
            _requestTimeoutField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _requestTimeoutField.Location = new System.Drawing.Point(152, 276);
            _requestTimeoutField.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            _requestTimeoutField.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _requestTimeoutField.Name = "_requestTimeoutField";
            _requestTimeoutField.Size = new System.Drawing.Size(60, 23);
            _requestTimeoutField.TabIndex = 32;
            _requestTimeoutField.Value = new decimal(new int[] { 3, 0, 0, 0 });
            _requestTimeoutField.ValueChanged += _requestTimeoutField_ValueChanged;
            // 
            // _translationFormatHintLabel
            // 
            _translationFormatHintLabel.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 129);
            _translationFormatHintLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            _translationFormatHintLabel.Location = new System.Drawing.Point(16, 245);
            _translationFormatHintLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _translationFormatHintLabel.Name = "_translationFormatHintLabel";
            _translationFormatHintLabel.Size = new System.Drawing.Size(363, 20);
            _translationFormatHintLabel.TabIndex = 31;
            _translationFormatHintLabel.Text = "Availiable Keywords: {source}, {translated}";
            _translationFormatHintLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _translationFormatField
            // 
            _translationFormatField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _translationFormatField.Location = new System.Drawing.Point(16, 220);
            _translationFormatField.Name = "_translationFormatField";
            _translationFormatField.Size = new System.Drawing.Size(363, 23);
            _translationFormatField.TabIndex = 30;
            _translationFormatField.Text = "({translated})";
            _translationFormatField.TextChanged += _translationFormatField_TextChanged;
            // 
            // _translationFormatLabel
            // 
            _translationFormatLabel.Location = new System.Drawing.Point(16, 200);
            _translationFormatLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _translationFormatLabel.Name = "_translationFormatLabel";
            _translationFormatLabel.Size = new System.Drawing.Size(363, 20);
            _translationFormatLabel.TabIndex = 29;
            _translationFormatLabel.Text = "Translation Format";
            // 
            // _destinationLanguage
            // 
            _destinationLanguage.Location = new System.Drawing.Point(204, 140);
            _destinationLanguage.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _destinationLanguage.Name = "_destinationLanguage";
            _destinationLanguage.Size = new System.Drawing.Size(175, 20);
            _destinationLanguage.TabIndex = 28;
            _destinationLanguage.Text = "Destination Language";
            // 
            // _destinationLanguageSelector
            // 
            _destinationLanguageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _destinationLanguageSelector.FormattingEnabled = true;
            _destinationLanguageSelector.IntegralHeight = false;
            _destinationLanguageSelector.ItemHeight = 15;
            _destinationLanguageSelector.Location = new System.Drawing.Point(204, 160);
            _destinationLanguageSelector.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            _destinationLanguageSelector.Name = "_destinationLanguageSelector";
            _destinationLanguageSelector.Size = new System.Drawing.Size(175, 23);
            _destinationLanguageSelector.TabIndex = 27;
            _destinationLanguageSelector.SelectedIndexChanged += _destinationLanguageSelector_SelectedIndexChanged;
            // 
            // _sourceLanguageSelector
            // 
            _sourceLanguageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _sourceLanguageSelector.FormattingEnabled = true;
            _sourceLanguageSelector.IntegralHeight = false;
            _sourceLanguageSelector.ItemHeight = 15;
            _sourceLanguageSelector.Location = new System.Drawing.Point(16, 160);
            _sourceLanguageSelector.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            _sourceLanguageSelector.Name = "_sourceLanguageSelector";
            _sourceLanguageSelector.Size = new System.Drawing.Size(175, 23);
            _sourceLanguageSelector.TabIndex = 26;
            _sourceLanguageSelector.SelectedIndexChanged += _sourceLanguageSelector_SelectedIndexChanged;
            // 
            // _sourceLanguageLabel
            // 
            _sourceLanguageLabel.Location = new System.Drawing.Point(16, 140);
            _sourceLanguageLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _sourceLanguageLabel.Name = "_sourceLanguageLabel";
            _sourceLanguageLabel.Size = new System.Drawing.Size(175, 20);
            _sourceLanguageLabel.TabIndex = 25;
            _sourceLanguageLabel.Text = "Source Language";
            // 
            // _apiKeyField
            // 
            _apiKeyField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _apiKeyField.Location = new System.Drawing.Point(169, 70);
            _apiKeyField.Name = "_apiKeyField";
            _apiKeyField.PlaceholderText = "API Key";
            _apiKeyField.Size = new System.Drawing.Size(210, 23);
            _apiKeyField.TabIndex = 24;
            _apiKeyField.TextChanged += _apiKeyField_TextChanged;
            // 
            // _apiKeyLabel
            // 
            _apiKeyLabel.Location = new System.Drawing.Point(169, 50);
            _apiKeyLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _apiKeyLabel.Name = "_apiKeyLabel";
            _apiKeyLabel.Size = new System.Drawing.Size(210, 20);
            _apiKeyLabel.TabIndex = 23;
            _apiKeyLabel.Text = "API Key and Glossary ID";
            // 
            // _modelSelector
            // 
            _modelSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _modelSelector.Enabled = false;
            _modelSelector.FormattingEnabled = true;
            _modelSelector.IntegralHeight = false;
            _modelSelector.ItemHeight = 15;
            _modelSelector.Items.AddRange(new object[] { "DeepL", "Papago", "Google Translate" });
            _modelSelector.Location = new System.Drawing.Point(16, 70);
            _modelSelector.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            _modelSelector.Name = "_modelSelector";
            _modelSelector.Size = new System.Drawing.Size(140, 23);
            _modelSelector.TabIndex = 22;
            _modelSelector.SelectedIndexChanged += _modelSelector_SelectedIndexChanged;
            // 
            // _modelLabel
            // 
            _modelLabel.Location = new System.Drawing.Point(16, 50);
            _modelLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _modelLabel.Name = "_modelLabel";
            _modelLabel.Size = new System.Drawing.Size(140, 20);
            _modelLabel.TabIndex = 21;
            _modelLabel.Text = "Model";
            // 
            // TranslationPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(_glossarySelectButton);
            Controls.Add(_glossaryIdField);
            Controls.Add(_requestTimeoutDefaultLabel);
            Controls.Add(_requestTimeoutLabel);
            Controls.Add(_requestTimeoutField);
            Controls.Add(_translationFormatHintLabel);
            Controls.Add(_translationFormatField);
            Controls.Add(_translationFormatLabel);
            Controls.Add(_destinationLanguage);
            Controls.Add(_destinationLanguageSelector);
            Controls.Add(_sourceLanguageSelector);
            Controls.Add(_sourceLanguageLabel);
            Controls.Add(_apiKeyField);
            Controls.Add(_apiKeyLabel);
            Controls.Add(_modelSelector);
            Controls.Add(_modelLabel);
            Icon = Properties.Resources.translation_icon;
            Name = "TranslationPanel";
            Size = new System.Drawing.Size(400, 350);
            Title = "Translation";
            Controls.SetChildIndex(_titleLabel, 0);
            Controls.SetChildIndex(_iconBox, 0);
            Controls.SetChildIndex(_modelLabel, 0);
            Controls.SetChildIndex(_modelSelector, 0);
            Controls.SetChildIndex(_apiKeyLabel, 0);
            Controls.SetChildIndex(_apiKeyField, 0);
            Controls.SetChildIndex(_sourceLanguageLabel, 0);
            Controls.SetChildIndex(_sourceLanguageSelector, 0);
            Controls.SetChildIndex(_destinationLanguageSelector, 0);
            Controls.SetChildIndex(_destinationLanguage, 0);
            Controls.SetChildIndex(_translationFormatLabel, 0);
            Controls.SetChildIndex(_translationFormatField, 0);
            Controls.SetChildIndex(_translationFormatHintLabel, 0);
            Controls.SetChildIndex(_requestTimeoutField, 0);
            Controls.SetChildIndex(_requestTimeoutLabel, 0);
            Controls.SetChildIndex(_requestTimeoutDefaultLabel, 0);
            Controls.SetChildIndex(_glossaryIdField, 0);
            Controls.SetChildIndex(_glossarySelectButton, 0);
            ((System.ComponentModel.ISupportInitialize)_iconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)_requestTimeoutField).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button _glossarySelectButton;
        private System.Windows.Forms.TextBox _glossaryIdField;
        private System.Windows.Forms.Label _requestTimeoutDefaultLabel;
        private System.Windows.Forms.Label _requestTimeoutLabel;
        private System.Windows.Forms.NumericUpDown _requestTimeoutField;
        private System.Windows.Forms.Label _translationFormatHintLabel;
        private System.Windows.Forms.TextBox _translationFormatField;
        private System.Windows.Forms.Label _translationFormatLabel;
        private System.Windows.Forms.Label _destinationLanguage;
        private System.Windows.Forms.ComboBox _destinationLanguageSelector;
        private System.Windows.Forms.ComboBox _sourceLanguageSelector;
        private System.Windows.Forms.Label _sourceLanguageLabel;
        private System.Windows.Forms.TextBox _apiKeyField;
        private System.Windows.Forms.Label _apiKeyLabel;
        private System.Windows.Forms.ComboBox _modelSelector;
        private System.Windows.Forms.Label _modelLabel;
    }
}