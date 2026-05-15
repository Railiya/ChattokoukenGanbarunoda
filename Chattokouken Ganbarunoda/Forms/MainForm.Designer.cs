using System;
using System.Drawing;
using System.Windows.Forms;

namespace CKG.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            _generalPanel = new CKG.Controls.SettingPanel();
            _inputModeHintLabel = new Label();
            _defaultInputModeSelector = new ComboBox();
            _defaultInputModeLabel = new Label();
            _outputMethodSelector = new ComboBox();
            _outputMethodLabel = new Label();
            _autoSendMessageToggle = new CheckBox();
            _startTranslateToggle = new CheckBox();
            _translationPanel = new CKG.Controls.SettingPanel();
            _glossarySelectButton = new Button();
            _glossaryIdField = new TextBox();
            _requestTimeoutDefaultLabel = new Label();
            _requestTimeoutLabel = new Label();
            _requestTimeoutField = new NumericUpDown();
            _translationFormatHintLabel = new Label();
            _translationFormatField = new TextBox();
            _translationFormatLabel = new Label();
            _destinationLanguage = new Label();
            _destinationLanguageSelector = new ComboBox();
            _sourceLanguageSelector = new ComboBox();
            _sourceLanguageLabel = new Label();
            _apiKeyField = new TextBox();
            _apiKeyLabel = new Label();
            _modelSelector = new ComboBox();
            _modelLabel = new Label();
            _overlayPanel = new CKG.Controls.SettingPanel();
            _overlayOpacityField = new TextBox();
            _overlayOpacityHintLabel = new Label();
            _overlayOpacityLabel = new Label();
            _overlayOpacitySlider = new TrackBar();
            _overlayFontSizeHintLabel = new Label();
            _overlayFontSizeLabel = new Label();
            _overlayFontSizeField = new NumericUpDown();
            _overlayOffsetYLabel = new Label();
            _overlayOffsetYField = new NumericUpDown();
            _overlayOffsetXLabel = new Label();
            _overlayOffsetXField = new NumericUpDown();
            _overlayAnchorSelector = new CKG.Controls.AnchorSelectorControl();
            _anchorLabel = new Label();
            _overlayEnabledToggle = new CheckBox();
            _notificationPanel = new CKG.Controls.SettingPanel();
            _translationFailedNotifyToggle = new CheckBox();
            _notificationVolumeField = new TextBox();
            _notificationVolumeHintLabel = new Label();
            _translationCompletedNotifyToggle = new CheckBox();
            _notificationVolumeLabel = new Label();
            _capturingStartNotifyToggle = new CheckBox();
            _notificationVolumeSlider = new TrackBar();
            _notificationEnabledToggle = new CheckBox();
            _hotkeysPanel = new CKG.Controls.SettingPanel();
            _hotkeysHintLabel = new Label();
            _hoykeyGridViewPanel44 = new Panel();
            _sendClipboardShiftToggle = new CheckBox();
            _hoykeyGridViewPanel34 = new Panel();
            _sendClipboardAltToggle = new CheckBox();
            _hoykeyGridViewPanel43 = new Panel();
            _translateShiftToggle = new CheckBox();
            _hoykeyGridViewPanel24 = new Panel();
            _sendClipboardCtrlToggle = new CheckBox();
            _hoykeyGridViewPanel33 = new Panel();
            _translateAltToggle = new CheckBox();
            _hoykeyGridViewPanel14 = new Panel();
            _sendClipboardKeyButton = new Button();
            _hoykeyGridViewPanel04 = new Panel();
            _sendClipboardLabel = new Label();
            _hoykeyGridViewPanel23 = new Panel();
            _translateCtrlToggle = new CheckBox();
            _hoykeyGridViewPanel13 = new Panel();
            _translateKeyButton = new Button();
            _hoykeyGridViewPanel03 = new Panel();
            _translateLabel = new Label();
            _hoykeyGridViewPanel42 = new Panel();
            _capturingToggleShiftToggle = new CheckBox();
            _hoykeyGridViewPanel32 = new Panel();
            _capturingToggleAltToggle = new CheckBox();
            _hoykeyGridViewPanel22 = new Panel();
            _capturingToggleCtrlToggle = new CheckBox();
            _hoykeyGridViewPanel12 = new Panel();
            _capturingToggleKeyButton = new Button();
            _hoykeyGridViewPanel02 = new Panel();
            _capturingToggleLabel = new Label();
            _hoykeyGridViewPanel41 = new Panel();
            _enableCapturingShiftToggle = new CheckBox();
            _hoykeyGridViewPanel31 = new Panel();
            _enableCapturingAltToggle = new CheckBox();
            _hoykeyGridViewPanel40 = new Panel();
            _shiftLabel = new Label();
            _hoykeyGridViewPanel21 = new Panel();
            _enableCapturingCtrlToggle = new CheckBox();
            _hoykeyGridViewPanel30 = new Panel();
            _altLabel = new Label();
            _hoykeyGridViewPanel11 = new Panel();
            _enableCapturingKeyButton = new Button();
            _hoykeyGridViewPanel01 = new Panel();
            _enableCapturingLabel = new Label();
            _hoykeyGridViewPanel20 = new Panel();
            _ctrlLabel = new Label();
            _hoykeyGridViewPanel10 = new Panel();
            _keyLabel = new Label();
            _hoykeyGridViewPanel00 = new Panel();
            _actionLabel = new Label();
            _advancedPanel = new CKG.Controls.SettingPanel();
            _debugEchoModeToggle = new CheckBox();
            _executeOnWindowStartToggle = new CheckBox();
            _writeLogFileToggle = new CheckBox();
            _inputTimeoutHintLabel = new Label();
            _inputTimeoutLabel = new Label();
            _inputTimeoutField = new NumericUpDown();
            _menuStrip = new MenuStrip();
            _ckgMenuItem = new ToolStripMenuItem();
            _exitMenuItem = new ToolStripMenuItem();
            _generalPanel.SuspendLayout();
            _translationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_requestTimeoutField).BeginInit();
            _overlayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_overlayOpacitySlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_overlayFontSizeField).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_overlayOffsetYField).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_overlayOffsetXField).BeginInit();
            _notificationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_notificationVolumeSlider).BeginInit();
            _hotkeysPanel.SuspendLayout();
            _hoykeyGridViewPanel44.SuspendLayout();
            _hoykeyGridViewPanel34.SuspendLayout();
            _hoykeyGridViewPanel43.SuspendLayout();
            _hoykeyGridViewPanel24.SuspendLayout();
            _hoykeyGridViewPanel33.SuspendLayout();
            _hoykeyGridViewPanel14.SuspendLayout();
            _hoykeyGridViewPanel04.SuspendLayout();
            _hoykeyGridViewPanel23.SuspendLayout();
            _hoykeyGridViewPanel13.SuspendLayout();
            _hoykeyGridViewPanel03.SuspendLayout();
            _hoykeyGridViewPanel42.SuspendLayout();
            _hoykeyGridViewPanel32.SuspendLayout();
            _hoykeyGridViewPanel22.SuspendLayout();
            _hoykeyGridViewPanel12.SuspendLayout();
            _hoykeyGridViewPanel02.SuspendLayout();
            _hoykeyGridViewPanel41.SuspendLayout();
            _hoykeyGridViewPanel31.SuspendLayout();
            _hoykeyGridViewPanel40.SuspendLayout();
            _hoykeyGridViewPanel21.SuspendLayout();
            _hoykeyGridViewPanel30.SuspendLayout();
            _hoykeyGridViewPanel11.SuspendLayout();
            _hoykeyGridViewPanel01.SuspendLayout();
            _hoykeyGridViewPanel20.SuspendLayout();
            _hoykeyGridViewPanel10.SuspendLayout();
            _hoykeyGridViewPanel00.SuspendLayout();
            _advancedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_inputTimeoutField).BeginInit();
            _menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // _generalPanel
            // 
            _generalPanel.BackColor = Color.White;
            _generalPanel.BorderStyle = BorderStyle.FixedSingle;
            _generalPanel.Controls.Add(_inputModeHintLabel);
            _generalPanel.Controls.Add(_defaultInputModeSelector);
            _generalPanel.Controls.Add(_defaultInputModeLabel);
            _generalPanel.Controls.Add(_outputMethodSelector);
            _generalPanel.Controls.Add(_outputMethodLabel);
            _generalPanel.Controls.Add(_autoSendMessageToggle);
            _generalPanel.Controls.Add(_startTranslateToggle);
            _generalPanel.Icon = Properties.Resources.general_icon;
            _generalPanel.Location = new Point(12, 29);
            _generalPanel.Margin = new Padding(3, 3, 10, 10);
            _generalPanel.Name = "_generalPanel";
            _generalPanel.Padding = new Padding(16, 40, 10, 16);
            _generalPanel.Size = new Size(300, 320);
            _generalPanel.TabIndex = 0;
            _generalPanel.Title = "General";
            // 
            // _inputModeHintLabel
            // 
            _inputModeHintLabel.Font = new Font("맑은 고딕", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 129);
            _inputModeHintLabel.ForeColor = SystemColors.ControlDarkDark;
            _inputModeHintLabel.Location = new Point(19, 230);
            _inputModeHintLabel.Margin = new Padding(0, 0, 3, 0);
            _inputModeHintLabel.Name = "_inputModeHintLabel";
            _inputModeHintLabel.Size = new Size(257, 69);
            _inputModeHintLabel.TabIndex = 7;
            _inputModeHintLabel.Text = "Press the Han/Eng key to switch Input Mode.\r\nTo change only the IME language, press it together with Ctrl (or Alt, Shift)";
            _inputModeHintLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // _defaultInputModeSelector
            // 
            _defaultInputModeSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            _defaultInputModeSelector.FormattingEnabled = true;
            _defaultInputModeSelector.ItemHeight = 15;
            _defaultInputModeSelector.Items.AddRange(new object[] { "Alphabet", "Hangul" });
            _defaultInputModeSelector.Location = new Point(19, 205);
            _defaultInputModeSelector.Name = "_defaultInputModeSelector";
            _defaultInputModeSelector.Size = new Size(260, 23);
            _defaultInputModeSelector.TabIndex = 6;
            _defaultInputModeSelector.SelectedIndexChanged += _defaultInputModeSelector_SelectedIndexChanged;
            // 
            // _defaultInputModeLabel
            // 
            _defaultInputModeLabel.Location = new Point(19, 185);
            _defaultInputModeLabel.Margin = new Padding(0, 0, 3, 0);
            _defaultInputModeLabel.Name = "_defaultInputModeLabel";
            _defaultInputModeLabel.Size = new Size(260, 20);
            _defaultInputModeLabel.TabIndex = 5;
            _defaultInputModeLabel.Text = "Default Input Mode";
            // 
            // _outputMethodSelector
            // 
            _outputMethodSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            _outputMethodSelector.FormattingEnabled = true;
            _outputMethodSelector.ItemHeight = 15;
            _outputMethodSelector.Items.AddRange(new object[] { "Clipboard Paste", "Input Simulation" });
            _outputMethodSelector.Location = new Point(19, 145);
            _outputMethodSelector.Name = "_outputMethodSelector";
            _outputMethodSelector.Size = new Size(260, 23);
            _outputMethodSelector.TabIndex = 4;
            _outputMethodSelector.SelectedIndexChanged += _inputMethodSelector_SelectedIndexChanged;
            // 
            // _outputMethodLabel
            // 
            _outputMethodLabel.Location = new Point(19, 125);
            _outputMethodLabel.Margin = new Padding(0, 0, 3, 0);
            _outputMethodLabel.Name = "_outputMethodLabel";
            _outputMethodLabel.Size = new Size(260, 20);
            _outputMethodLabel.TabIndex = 3;
            _outputMethodLabel.Text = "Output Method";
            // 
            // _autoSendMessageToggle
            // 
            _autoSendMessageToggle.FlatStyle = FlatStyle.Flat;
            _autoSendMessageToggle.Location = new Point(19, 85);
            _autoSendMessageToggle.Name = "_autoSendMessageToggle";
            _autoSendMessageToggle.Size = new Size(260, 20);
            _autoSendMessageToggle.TabIndex = 2;
            _autoSendMessageToggle.Text = "Auto Send Message on Translated";
            _autoSendMessageToggle.UseVisualStyleBackColor = true;
            _autoSendMessageToggle.CheckedChanged += _autoSendMessageToggle_CheckedChanged;
            // 
            // _startTranslateToggle
            // 
            _startTranslateToggle.FlatStyle = FlatStyle.Flat;
            _startTranslateToggle.Location = new Point(19, 50);
            _startTranslateToggle.Name = "_startTranslateToggle";
            _startTranslateToggle.Size = new Size(260, 20);
            _startTranslateToggle.TabIndex = 1;
            _startTranslateToggle.Text = "Start Translate on Buffered";
            _startTranslateToggle.UseVisualStyleBackColor = true;
            _startTranslateToggle.CheckedChanged += _startTranslateToggle_CheckedChanged;
            // 
            // _translationPanel
            // 
            _translationPanel.BackColor = Color.White;
            _translationPanel.BorderStyle = BorderStyle.FixedSingle;
            _translationPanel.Controls.Add(_glossarySelectButton);
            _translationPanel.Controls.Add(_glossaryIdField);
            _translationPanel.Controls.Add(_requestTimeoutDefaultLabel);
            _translationPanel.Controls.Add(_requestTimeoutLabel);
            _translationPanel.Controls.Add(_requestTimeoutField);
            _translationPanel.Controls.Add(_translationFormatHintLabel);
            _translationPanel.Controls.Add(_translationFormatField);
            _translationPanel.Controls.Add(_translationFormatLabel);
            _translationPanel.Controls.Add(_destinationLanguage);
            _translationPanel.Controls.Add(_destinationLanguageSelector);
            _translationPanel.Controls.Add(_sourceLanguageSelector);
            _translationPanel.Controls.Add(_sourceLanguageLabel);
            _translationPanel.Controls.Add(_apiKeyField);
            _translationPanel.Controls.Add(_apiKeyLabel);
            _translationPanel.Controls.Add(_modelSelector);
            _translationPanel.Controls.Add(_modelLabel);
            _translationPanel.Icon = Properties.Resources.translation_icon;
            _translationPanel.Location = new Point(322, 29);
            _translationPanel.Margin = new Padding(0, 3, 3, 10);
            _translationPanel.Name = "_translationPanel";
            _translationPanel.Padding = new Padding(16, 40, 16, 16);
            _translationPanel.Size = new Size(400, 320);
            _translationPanel.TabIndex = 1;
            _translationPanel.Title = "Translation";
            // 
            // _glossarySelectButton
            // 
            _glossarySelectButton.BackgroundImage = Properties.Resources.select_icon;
            _glossarySelectButton.BackgroundImageLayout = ImageLayout.Zoom;
            _glossarySelectButton.FlatStyle = FlatStyle.Flat;
            _glossarySelectButton.Location = new Point(345, 100);
            _glossarySelectButton.Name = "_glossarySelectButton";
            _glossarySelectButton.Size = new Size(34, 23);
            _glossarySelectButton.TabIndex = 20;
            _glossarySelectButton.UseVisualStyleBackColor = true;
            _glossarySelectButton.Click += _glossarySelectButton_Click;
            // 
            // _glossaryIdField
            // 
            _glossaryIdField.BorderStyle = BorderStyle.FixedSingle;
            _glossaryIdField.Location = new Point(169, 100);
            _glossaryIdField.Name = "_glossaryIdField";
            _glossaryIdField.PlaceholderText = "Glossary ID";
            _glossaryIdField.ReadOnly = true;
            _glossaryIdField.Size = new Size(170, 23);
            _glossaryIdField.TabIndex = 19;
            _glossaryIdField.TextChanged += _glossaryIdField_TextChanged;
            // 
            // _requestTimeoutDefaultLabel
            // 
            _requestTimeoutDefaultLabel.Location = new Point(215, 279);
            _requestTimeoutDefaultLabel.Margin = new Padding(0, 0, 0, 10);
            _requestTimeoutDefaultLabel.Name = "_requestTimeoutDefaultLabel";
            _requestTimeoutDefaultLabel.Size = new Size(164, 20);
            _requestTimeoutDefaultLabel.TabIndex = 18;
            _requestTimeoutDefaultLabel.Text = "(Default: 3)";
            // 
            // _requestTimeoutLabel
            // 
            _requestTimeoutLabel.Location = new Point(16, 279);
            _requestTimeoutLabel.Margin = new Padding(0, 0, 3, 0);
            _requestTimeoutLabel.Name = "_requestTimeoutLabel";
            _requestTimeoutLabel.Size = new Size(130, 20);
            _requestTimeoutLabel.TabIndex = 17;
            _requestTimeoutLabel.Text = "Request Timeout (sec)";
            // 
            // _requestTimeoutField
            // 
            _requestTimeoutField.BorderStyle = BorderStyle.FixedSingle;
            _requestTimeoutField.Location = new Point(152, 276);
            _requestTimeoutField.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            _requestTimeoutField.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _requestTimeoutField.Name = "_requestTimeoutField";
            _requestTimeoutField.Size = new Size(60, 23);
            _requestTimeoutField.TabIndex = 16;
            _requestTimeoutField.Value = new decimal(new int[] { 3, 0, 0, 0 });
            _requestTimeoutField.ValueChanged += _requestTimeoutField_ValueChanged;
            // 
            // _translationFormatHintLabel
            // 
            _translationFormatHintLabel.Font = new Font("맑은 고딕", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 129);
            _translationFormatHintLabel.ForeColor = SystemColors.ControlDarkDark;
            _translationFormatHintLabel.Location = new Point(16, 245);
            _translationFormatHintLabel.Margin = new Padding(0, 0, 3, 0);
            _translationFormatHintLabel.Name = "_translationFormatHintLabel";
            _translationFormatHintLabel.Size = new Size(363, 20);
            _translationFormatHintLabel.TabIndex = 15;
            _translationFormatHintLabel.Text = "Availiable Keywords: {source}, {translated}";
            _translationFormatHintLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // _translationFormatField
            // 
            _translationFormatField.BorderStyle = BorderStyle.FixedSingle;
            _translationFormatField.Location = new Point(16, 220);
            _translationFormatField.Name = "_translationFormatField";
            _translationFormatField.Size = new Size(363, 23);
            _translationFormatField.TabIndex = 14;
            _translationFormatField.Text = "({translated})";
            _translationFormatField.TextChanged += _translationFormatField_TextChanged;
            // 
            // _translationFormatLabel
            // 
            _translationFormatLabel.Location = new Point(16, 200);
            _translationFormatLabel.Margin = new Padding(0, 0, 3, 0);
            _translationFormatLabel.Name = "_translationFormatLabel";
            _translationFormatLabel.Size = new Size(363, 20);
            _translationFormatLabel.TabIndex = 13;
            _translationFormatLabel.Text = "Translation Format";
            // 
            // _destinationLanguage
            // 
            _destinationLanguage.Location = new Point(204, 140);
            _destinationLanguage.Margin = new Padding(0, 0, 3, 0);
            _destinationLanguage.Name = "_destinationLanguage";
            _destinationLanguage.Size = new Size(175, 20);
            _destinationLanguage.TabIndex = 12;
            _destinationLanguage.Text = "Destination Language";
            // 
            // _destinationLanguageSelector
            // 
            _destinationLanguageSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            _destinationLanguageSelector.FormattingEnabled = true;
            _destinationLanguageSelector.IntegralHeight = false;
            _destinationLanguageSelector.ItemHeight = 15;
            _destinationLanguageSelector.Location = new Point(204, 160);
            _destinationLanguageSelector.Margin = new Padding(3, 3, 10, 3);
            _destinationLanguageSelector.Name = "_destinationLanguageSelector";
            _destinationLanguageSelector.Size = new Size(175, 23);
            _destinationLanguageSelector.TabIndex = 11;
            _destinationLanguageSelector.SelectedIndexChanged += _destinationLanguageSelector_SelectedIndexChanged;
            // 
            // _sourceLanguageSelector
            // 
            _sourceLanguageSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            _sourceLanguageSelector.FormattingEnabled = true;
            _sourceLanguageSelector.IntegralHeight = false;
            _sourceLanguageSelector.ItemHeight = 15;
            _sourceLanguageSelector.Location = new Point(16, 160);
            _sourceLanguageSelector.Margin = new Padding(3, 3, 10, 3);
            _sourceLanguageSelector.Name = "_sourceLanguageSelector";
            _sourceLanguageSelector.Size = new Size(175, 23);
            _sourceLanguageSelector.TabIndex = 10;
            _sourceLanguageSelector.SelectedIndexChanged += _sourceLanguageSelector_SelectedIndexChanged;
            // 
            // _sourceLanguageLabel
            // 
            _sourceLanguageLabel.Location = new Point(16, 140);
            _sourceLanguageLabel.Margin = new Padding(0, 0, 3, 0);
            _sourceLanguageLabel.Name = "_sourceLanguageLabel";
            _sourceLanguageLabel.Size = new Size(175, 20);
            _sourceLanguageLabel.TabIndex = 9;
            _sourceLanguageLabel.Text = "Source Language";
            // 
            // _apiKeyField
            // 
            _apiKeyField.BorderStyle = BorderStyle.FixedSingle;
            _apiKeyField.Location = new Point(169, 70);
            _apiKeyField.Name = "_apiKeyField";
            _apiKeyField.PlaceholderText = "API Key";
            _apiKeyField.Size = new Size(210, 23);
            _apiKeyField.TabIndex = 8;
            _apiKeyField.TextChanged += _apiKeyField_TextChanged;
            // 
            // _apiKeyLabel
            // 
            _apiKeyLabel.Location = new Point(169, 50);
            _apiKeyLabel.Margin = new Padding(0, 0, 3, 0);
            _apiKeyLabel.Name = "_apiKeyLabel";
            _apiKeyLabel.Size = new Size(210, 20);
            _apiKeyLabel.TabIndex = 7;
            _apiKeyLabel.Text = "API Key and Glossary ID";
            // 
            // _modelSelector
            // 
            _modelSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            _modelSelector.Enabled = false;
            _modelSelector.FormattingEnabled = true;
            _modelSelector.IntegralHeight = false;
            _modelSelector.ItemHeight = 15;
            _modelSelector.Items.AddRange(new object[] { "DeepL", "Papago", "Google Translate" });
            _modelSelector.Location = new Point(16, 70);
            _modelSelector.Margin = new Padding(3, 3, 10, 3);
            _modelSelector.Name = "_modelSelector";
            _modelSelector.Size = new Size(140, 23);
            _modelSelector.TabIndex = 5;
            _modelSelector.SelectedIndexChanged += _modelSelector_SelectedIndexChanged;
            // 
            // _modelLabel
            // 
            _modelLabel.Location = new Point(16, 50);
            _modelLabel.Margin = new Padding(0, 0, 3, 0);
            _modelLabel.Name = "_modelLabel";
            _modelLabel.Size = new Size(140, 20);
            _modelLabel.TabIndex = 4;
            _modelLabel.Text = "Model";
            // 
            // _overlayPanel
            // 
            _overlayPanel.BackColor = Color.White;
            _overlayPanel.BorderStyle = BorderStyle.FixedSingle;
            _overlayPanel.Controls.Add(_overlayOpacityField);
            _overlayPanel.Controls.Add(_overlayOpacityHintLabel);
            _overlayPanel.Controls.Add(_overlayOpacityLabel);
            _overlayPanel.Controls.Add(_overlayOpacitySlider);
            _overlayPanel.Controls.Add(_overlayFontSizeHintLabel);
            _overlayPanel.Controls.Add(_overlayFontSizeLabel);
            _overlayPanel.Controls.Add(_overlayFontSizeField);
            _overlayPanel.Controls.Add(_overlayOffsetYLabel);
            _overlayPanel.Controls.Add(_overlayOffsetYField);
            _overlayPanel.Controls.Add(_overlayOffsetXLabel);
            _overlayPanel.Controls.Add(_overlayOffsetXField);
            _overlayPanel.Controls.Add(_overlayAnchorSelector);
            _overlayPanel.Controls.Add(_anchorLabel);
            _overlayPanel.Controls.Add(_overlayEnabledToggle);
            _overlayPanel.Icon = Properties.Resources.overlay_icon;
            _overlayPanel.Location = new Point(12, 359);
            _overlayPanel.Margin = new Padding(3, 0, 10, 10);
            _overlayPanel.Name = "_overlayPanel";
            _overlayPanel.Padding = new Padding(16, 40, 16, 16);
            _overlayPanel.Size = new Size(300, 260);
            _overlayPanel.TabIndex = 2;
            _overlayPanel.Title = "Overlay";
            // 
            // _overlayOpacityField
            // 
            _overlayOpacityField.BorderStyle = BorderStyle.FixedSingle;
            _overlayOpacityField.Location = new Point(216, 214);
            _overlayOpacityField.Name = "_overlayOpacityField";
            _overlayOpacityField.ReadOnly = true;
            _overlayOpacityField.Size = new Size(40, 23);
            _overlayOpacityField.TabIndex = 19;
            _overlayOpacityField.Text = "80";
            _overlayOpacityField.TextAlign = HorizontalAlignment.Center;
            // 
            // _overlayOpacityHintLabel
            // 
            _overlayOpacityHintLabel.Location = new Point(259, 217);
            _overlayOpacityHintLabel.Margin = new Padding(0, 0, 3, 0);
            _overlayOpacityHintLabel.Name = "_overlayOpacityHintLabel";
            _overlayOpacityHintLabel.Size = new Size(20, 20);
            _overlayOpacityHintLabel.TabIndex = 29;
            _overlayOpacityHintLabel.Text = "%";
            // 
            // _overlayOpacityLabel
            // 
            _overlayOpacityLabel.Location = new Point(19, 217);
            _overlayOpacityLabel.Margin = new Padding(0);
            _overlayOpacityLabel.Name = "_overlayOpacityLabel";
            _overlayOpacityLabel.Size = new Size(50, 20);
            _overlayOpacityLabel.TabIndex = 27;
            _overlayOpacityLabel.Text = "Opacity";
            // 
            // _overlayOpacitySlider
            // 
            _overlayOpacitySlider.AutoSize = false;
            _overlayOpacitySlider.Location = new Point(69, 215);
            _overlayOpacitySlider.Margin = new Padding(0, 3, 3, 3);
            _overlayOpacitySlider.Maximum = 100;
            _overlayOpacitySlider.Name = "_overlayOpacitySlider";
            _overlayOpacitySlider.Size = new Size(141, 23);
            _overlayOpacitySlider.TabIndex = 26;
            _overlayOpacitySlider.TickStyle = TickStyle.None;
            _overlayOpacitySlider.Value = 80;
            _overlayOpacitySlider.ValueChanged += _overlayOpacitySlider_ValueChanged;
            // 
            // _overlayFontSizeHintLabel
            // 
            _overlayFontSizeHintLabel.Location = new Point(259, 175);
            _overlayFontSizeHintLabel.Margin = new Padding(0, 0, 3, 0);
            _overlayFontSizeHintLabel.Name = "_overlayFontSizeHintLabel";
            _overlayFontSizeHintLabel.Size = new Size(20, 20);
            _overlayFontSizeHintLabel.TabIndex = 25;
            _overlayFontSizeHintLabel.Text = "pt";
            // 
            // _overlayFontSizeLabel
            // 
            _overlayFontSizeLabel.Location = new Point(116, 175);
            _overlayFontSizeLabel.Margin = new Padding(0, 0, 3, 0);
            _overlayFontSizeLabel.Name = "_overlayFontSizeLabel";
            _overlayFontSizeLabel.Size = new Size(74, 20);
            _overlayFontSizeLabel.TabIndex = 24;
            _overlayFontSizeLabel.Text = "Font Size:";
            _overlayFontSizeLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // _overlayFontSizeField
            // 
            _overlayFontSizeField.BorderStyle = BorderStyle.FixedSingle;
            _overlayFontSizeField.Location = new Point(196, 172);
            _overlayFontSizeField.Name = "_overlayFontSizeField";
            _overlayFontSizeField.Size = new Size(60, 23);
            _overlayFontSizeField.TabIndex = 23;
            _overlayFontSizeField.Value = new decimal(new int[] { 10, 0, 0, 0 });
            _overlayFontSizeField.ValueChanged += _overlayFontSizeField_ValueChanged;
            // 
            // _overlayOffsetYLabel
            // 
            _overlayOffsetYLabel.Location = new Point(116, 142);
            _overlayOffsetYLabel.Margin = new Padding(0, 0, 3, 0);
            _overlayOffsetYLabel.Name = "_overlayOffsetYLabel";
            _overlayOffsetYLabel.Size = new Size(74, 20);
            _overlayOffsetYLabel.TabIndex = 22;
            _overlayOffsetYLabel.Text = "Offset Y:";
            _overlayOffsetYLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // _overlayOffsetYField
            // 
            _overlayOffsetYField.BorderStyle = BorderStyle.FixedSingle;
            _overlayOffsetYField.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            _overlayOffsetYField.Location = new Point(196, 139);
            _overlayOffsetYField.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            _overlayOffsetYField.Name = "_overlayOffsetYField";
            _overlayOffsetYField.Size = new Size(60, 23);
            _overlayOffsetYField.TabIndex = 21;
            _overlayOffsetYField.ValueChanged += _overlayOffsetYField_ValueChanged;
            // 
            // _overlayOffsetXLabel
            // 
            _overlayOffsetXLabel.Location = new Point(116, 108);
            _overlayOffsetXLabel.Margin = new Padding(0, 0, 3, 0);
            _overlayOffsetXLabel.Name = "_overlayOffsetXLabel";
            _overlayOffsetXLabel.Size = new Size(74, 20);
            _overlayOffsetXLabel.TabIndex = 20;
            _overlayOffsetXLabel.Text = "Offset X:";
            _overlayOffsetXLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // _overlayOffsetXField
            // 
            _overlayOffsetXField.BorderStyle = BorderStyle.FixedSingle;
            _overlayOffsetXField.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            _overlayOffsetXField.Location = new Point(196, 105);
            _overlayOffsetXField.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            _overlayOffsetXField.Name = "_overlayOffsetXField";
            _overlayOffsetXField.Size = new Size(60, 23);
            _overlayOffsetXField.TabIndex = 19;
            _overlayOffsetXField.ValueChanged += _overlayOffsetXField_ValueChanged;
            // 
            // _overlayAnchorSelector
            // 
            _overlayAnchorSelector.BorderStyle = BorderStyle.FixedSingle;
            _overlayAnchorSelector.Location = new Point(19, 105);
            _overlayAnchorSelector.Margin = new Padding(3, 3, 10, 3);
            _overlayAnchorSelector.Name = "_overlayAnchorSelector";
            _overlayAnchorSelector.SelectedAnchor = ContentAlignment.TopLeft;
            _overlayAnchorSelector.Size = new Size(90, 90);
            _overlayAnchorSelector.TabIndex = 6;
            // 
            // _anchorLabel
            // 
            _anchorLabel.Location = new Point(19, 85);
            _anchorLabel.Margin = new Padding(0, 0, 3, 0);
            _anchorLabel.Name = "_anchorLabel";
            _anchorLabel.Size = new Size(90, 20);
            _anchorLabel.TabIndex = 5;
            _anchorLabel.Text = "Anchor";
            // 
            // _overlayEnabledToggle
            // 
            _overlayEnabledToggle.Checked = true;
            _overlayEnabledToggle.CheckState = CheckState.Checked;
            _overlayEnabledToggle.FlatStyle = FlatStyle.Flat;
            _overlayEnabledToggle.Location = new Point(19, 50);
            _overlayEnabledToggle.Name = "_overlayEnabledToggle";
            _overlayEnabledToggle.Size = new Size(260, 20);
            _overlayEnabledToggle.TabIndex = 5;
            _overlayEnabledToggle.Text = "Enabled";
            _overlayEnabledToggle.UseVisualStyleBackColor = true;
            _overlayEnabledToggle.CheckedChanged += _overlayEnabledToggle_CheckedChanged;
            // 
            // _notificationPanel
            // 
            _notificationPanel.BackColor = Color.White;
            _notificationPanel.BorderStyle = BorderStyle.FixedSingle;
            _notificationPanel.Controls.Add(_translationFailedNotifyToggle);
            _notificationPanel.Controls.Add(_notificationVolumeField);
            _notificationPanel.Controls.Add(_notificationVolumeHintLabel);
            _notificationPanel.Controls.Add(_translationCompletedNotifyToggle);
            _notificationPanel.Controls.Add(_notificationVolumeLabel);
            _notificationPanel.Controls.Add(_capturingStartNotifyToggle);
            _notificationPanel.Controls.Add(_notificationVolumeSlider);
            _notificationPanel.Controls.Add(_notificationEnabledToggle);
            _notificationPanel.Icon = Properties.Resources.notification_icon;
            _notificationPanel.Location = new Point(322, 359);
            _notificationPanel.Margin = new Padding(0, 0, 3, 10);
            _notificationPanel.Name = "_notificationPanel";
            _notificationPanel.Padding = new Padding(16, 40, 16, 16);
            _notificationPanel.Size = new Size(400, 260);
            _notificationPanel.TabIndex = 3;
            _notificationPanel.Title = "Notification";
            // 
            // _translationFailedNotifyToggle
            // 
            _translationFailedNotifyToggle.Checked = true;
            _translationFailedNotifyToggle.CheckState = CheckState.Checked;
            _translationFailedNotifyToggle.FlatStyle = FlatStyle.Flat;
            _translationFailedNotifyToggle.Location = new Point(32, 155);
            _translationFailedNotifyToggle.Name = "_translationFailedNotifyToggle";
            _translationFailedNotifyToggle.Size = new Size(347, 20);
            _translationFailedNotifyToggle.TabIndex = 34;
            _translationFailedNotifyToggle.Text = "On Translation Failed";
            _translationFailedNotifyToggle.UseVisualStyleBackColor = true;
            _translationFailedNotifyToggle.CheckedChanged += _translationFailedNotifyToggle_CheckedChanged;
            // 
            // _notificationVolumeField
            // 
            _notificationVolumeField.BorderStyle = BorderStyle.FixedSingle;
            _notificationVolumeField.Location = new Point(316, 194);
            _notificationVolumeField.Name = "_notificationVolumeField";
            _notificationVolumeField.ReadOnly = true;
            _notificationVolumeField.Size = new Size(40, 23);
            _notificationVolumeField.TabIndex = 30;
            _notificationVolumeField.Text = "80";
            _notificationVolumeField.TextAlign = HorizontalAlignment.Center;
            // 
            // _notificationVolumeHintLabel
            // 
            _notificationVolumeHintLabel.Location = new Point(359, 197);
            _notificationVolumeHintLabel.Margin = new Padding(0, 0, 3, 0);
            _notificationVolumeHintLabel.Name = "_notificationVolumeHintLabel";
            _notificationVolumeHintLabel.Size = new Size(20, 20);
            _notificationVolumeHintLabel.TabIndex = 33;
            _notificationVolumeHintLabel.Text = "%";
            // 
            // _translationCompletedNotifyToggle
            // 
            _translationCompletedNotifyToggle.Checked = true;
            _translationCompletedNotifyToggle.CheckState = CheckState.Checked;
            _translationCompletedNotifyToggle.FlatStyle = FlatStyle.Flat;
            _translationCompletedNotifyToggle.Location = new Point(32, 120);
            _translationCompletedNotifyToggle.Name = "_translationCompletedNotifyToggle";
            _translationCompletedNotifyToggle.Size = new Size(347, 20);
            _translationCompletedNotifyToggle.TabIndex = 31;
            _translationCompletedNotifyToggle.Text = "On Translation Completed";
            _translationCompletedNotifyToggle.UseVisualStyleBackColor = true;
            _translationCompletedNotifyToggle.CheckedChanged += _translationCompletedNotifyToggle_CheckedChanged;
            // 
            // _notificationVolumeLabel
            // 
            _notificationVolumeLabel.Location = new Point(18, 197);
            _notificationVolumeLabel.Margin = new Padding(0);
            _notificationVolumeLabel.Name = "_notificationVolumeLabel";
            _notificationVolumeLabel.Size = new Size(50, 20);
            _notificationVolumeLabel.TabIndex = 32;
            _notificationVolumeLabel.Text = "Volume";
            // 
            // _capturingStartNotifyToggle
            // 
            _capturingStartNotifyToggle.Checked = true;
            _capturingStartNotifyToggle.CheckState = CheckState.Checked;
            _capturingStartNotifyToggle.FlatStyle = FlatStyle.Flat;
            _capturingStartNotifyToggle.Location = new Point(32, 85);
            _capturingStartNotifyToggle.Name = "_capturingStartNotifyToggle";
            _capturingStartNotifyToggle.Size = new Size(347, 20);
            _capturingStartNotifyToggle.TabIndex = 5;
            _capturingStartNotifyToggle.Text = "On Capturing Start";
            _capturingStartNotifyToggle.UseVisualStyleBackColor = true;
            _capturingStartNotifyToggle.CheckedChanged += _capturingStartNotifyToggle_CheckedChanged;
            // 
            // _notificationVolumeSlider
            // 
            _notificationVolumeSlider.AutoSize = false;
            _notificationVolumeSlider.Location = new Point(68, 195);
            _notificationVolumeSlider.Margin = new Padding(0, 3, 3, 3);
            _notificationVolumeSlider.Maximum = 100;
            _notificationVolumeSlider.Name = "_notificationVolumeSlider";
            _notificationVolumeSlider.Size = new Size(242, 23);
            _notificationVolumeSlider.TabIndex = 31;
            _notificationVolumeSlider.TickStyle = TickStyle.None;
            _notificationVolumeSlider.Value = 80;
            _notificationVolumeSlider.ValueChanged += _notificationVolumeSlider_ValueChanged;
            // 
            // _notificationEnabledToggle
            // 
            _notificationEnabledToggle.Checked = true;
            _notificationEnabledToggle.CheckState = CheckState.Checked;
            _notificationEnabledToggle.FlatStyle = FlatStyle.Flat;
            _notificationEnabledToggle.Location = new Point(16, 50);
            _notificationEnabledToggle.Name = "_notificationEnabledToggle";
            _notificationEnabledToggle.Size = new Size(260, 20);
            _notificationEnabledToggle.TabIndex = 30;
            _notificationEnabledToggle.Text = "Enabled";
            _notificationEnabledToggle.UseVisualStyleBackColor = true;
            _notificationEnabledToggle.CheckedChanged += _notificationEnabledToggle_CheckedChanged;
            // 
            // _hotkeysPanel
            // 
            _hotkeysPanel.BackColor = Color.White;
            _hotkeysPanel.BorderStyle = BorderStyle.FixedSingle;
            _hotkeysPanel.Controls.Add(_hotkeysHintLabel);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel44);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel34);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel43);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel24);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel33);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel14);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel04);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel23);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel13);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel03);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel42);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel32);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel22);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel12);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel02);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel41);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel31);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel40);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel21);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel30);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel11);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel01);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel20);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel10);
            _hotkeysPanel.Controls.Add(_hoykeyGridViewPanel00);
            _hotkeysPanel.Icon = Properties.Resources.hotkeys_icon;
            _hotkeysPanel.Location = new Point(12, 629);
            _hotkeysPanel.Margin = new Padding(3, 0, 10, 3);
            _hotkeysPanel.Name = "_hotkeysPanel";
            _hotkeysPanel.Padding = new Padding(16, 40, 16, 16);
            _hotkeysPanel.Size = new Size(400, 230);
            _hotkeysPanel.TabIndex = 4;
            _hotkeysPanel.Title = "Hotkeys";
            // 
            // _hotkeysHintLabel
            // 
            _hotkeysHintLabel.Font = new Font("맑은 고딕", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 129);
            _hotkeysHintLabel.ForeColor = SystemColors.ControlDarkDark;
            _hotkeysHintLabel.Location = new Point(16, 198);
            _hotkeysHintLabel.Margin = new Padding(0, 0, 3, 0);
            _hotkeysHintLabel.Name = "_hotkeysHintLabel";
            _hotkeysHintLabel.Size = new Size(366, 20);
            _hotkeysHintLabel.TabIndex = 5;
            _hotkeysHintLabel.Text = "Click the key button and press any key to set hotkey";
            _hotkeysHintLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // _hoykeyGridViewPanel44
            // 
            _hoykeyGridViewPanel44.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel44.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel44.Controls.Add(_sendClipboardShiftToggle);
            _hoykeyGridViewPanel44.Location = new Point(332, 166);
            _hoykeyGridViewPanel44.Margin = new Padding(0);
            _hoykeyGridViewPanel44.Name = "_hoykeyGridViewPanel44";
            _hoykeyGridViewPanel44.Size = new Size(50, 30);
            _hoykeyGridViewPanel44.TabIndex = 23;
            // 
            // _sendClipboardShiftToggle
            // 
            _sendClipboardShiftToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _sendClipboardShiftToggle.FlatStyle = FlatStyle.Flat;
            _sendClipboardShiftToggle.Location = new Point(-1, 1);
            _sendClipboardShiftToggle.Name = "_sendClipboardShiftToggle";
            _sendClipboardShiftToggle.Size = new Size(50, 26);
            _sendClipboardShiftToggle.TabIndex = 31;
            _sendClipboardShiftToggle.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel34
            // 
            _hoykeyGridViewPanel34.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel34.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel34.Controls.Add(_sendClipboardAltToggle);
            _hoykeyGridViewPanel34.Location = new Point(283, 166);
            _hoykeyGridViewPanel34.Margin = new Padding(0);
            _hoykeyGridViewPanel34.Name = "_hoykeyGridViewPanel34";
            _hoykeyGridViewPanel34.Size = new Size(50, 30);
            _hoykeyGridViewPanel34.TabIndex = 24;
            // 
            // _sendClipboardAltToggle
            // 
            _sendClipboardAltToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _sendClipboardAltToggle.FlatStyle = FlatStyle.Flat;
            _sendClipboardAltToggle.Location = new Point(-1, 1);
            _sendClipboardAltToggle.Name = "_sendClipboardAltToggle";
            _sendClipboardAltToggle.Size = new Size(50, 26);
            _sendClipboardAltToggle.TabIndex = 30;
            _sendClipboardAltToggle.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel43
            // 
            _hoykeyGridViewPanel43.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel43.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel43.Controls.Add(_translateShiftToggle);
            _hoykeyGridViewPanel43.Location = new Point(332, 137);
            _hoykeyGridViewPanel43.Margin = new Padding(0);
            _hoykeyGridViewPanel43.Name = "_hoykeyGridViewPanel43";
            _hoykeyGridViewPanel43.Size = new Size(50, 30);
            _hoykeyGridViewPanel43.TabIndex = 18;
            // 
            // _translateShiftToggle
            // 
            _translateShiftToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _translateShiftToggle.FlatStyle = FlatStyle.Flat;
            _translateShiftToggle.Location = new Point(-1, 1);
            _translateShiftToggle.Name = "_translateShiftToggle";
            _translateShiftToggle.Size = new Size(50, 26);
            _translateShiftToggle.TabIndex = 33;
            _translateShiftToggle.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel24
            // 
            _hoykeyGridViewPanel24.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel24.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel24.Controls.Add(_sendClipboardCtrlToggle);
            _hoykeyGridViewPanel24.Location = new Point(234, 166);
            _hoykeyGridViewPanel24.Margin = new Padding(0);
            _hoykeyGridViewPanel24.Name = "_hoykeyGridViewPanel24";
            _hoykeyGridViewPanel24.Size = new Size(50, 30);
            _hoykeyGridViewPanel24.TabIndex = 22;
            // 
            // _sendClipboardCtrlToggle
            // 
            _sendClipboardCtrlToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _sendClipboardCtrlToggle.FlatStyle = FlatStyle.Flat;
            _sendClipboardCtrlToggle.Location = new Point(-1, 1);
            _sendClipboardCtrlToggle.Name = "_sendClipboardCtrlToggle";
            _sendClipboardCtrlToggle.Size = new Size(50, 26);
            _sendClipboardCtrlToggle.TabIndex = 29;
            _sendClipboardCtrlToggle.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel33
            // 
            _hoykeyGridViewPanel33.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel33.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel33.Controls.Add(_translateAltToggle);
            _hoykeyGridViewPanel33.Location = new Point(283, 137);
            _hoykeyGridViewPanel33.Margin = new Padding(0);
            _hoykeyGridViewPanel33.Name = "_hoykeyGridViewPanel33";
            _hoykeyGridViewPanel33.Size = new Size(50, 30);
            _hoykeyGridViewPanel33.TabIndex = 19;
            // 
            // _translateAltToggle
            // 
            _translateAltToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _translateAltToggle.FlatStyle = FlatStyle.Flat;
            _translateAltToggle.Location = new Point(-1, 1);
            _translateAltToggle.Name = "_translateAltToggle";
            _translateAltToggle.Size = new Size(50, 26);
            _translateAltToggle.TabIndex = 29;
            _translateAltToggle.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel14
            // 
            _hoykeyGridViewPanel14.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel14.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel14.Controls.Add(_sendClipboardKeyButton);
            _hoykeyGridViewPanel14.Location = new Point(125, 166);
            _hoykeyGridViewPanel14.Margin = new Padding(0);
            _hoykeyGridViewPanel14.Name = "_hoykeyGridViewPanel14";
            _hoykeyGridViewPanel14.Size = new Size(110, 30);
            _hoykeyGridViewPanel14.TabIndex = 21;
            // 
            // _sendClipboardKeyButton
            // 
            _sendClipboardKeyButton.Location = new Point(3, 1);
            _sendClipboardKeyButton.Name = "_sendClipboardKeyButton";
            _sendClipboardKeyButton.Size = new Size(102, 26);
            _sendClipboardKeyButton.TabIndex = 4;
            _sendClipboardKeyButton.Text = "\\";
            _sendClipboardKeyButton.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel04
            // 
            _hoykeyGridViewPanel04.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel04.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel04.Controls.Add(_sendClipboardLabel);
            _hoykeyGridViewPanel04.Location = new Point(16, 166);
            _hoykeyGridViewPanel04.Margin = new Padding(0);
            _hoykeyGridViewPanel04.Name = "_hoykeyGridViewPanel04";
            _hoykeyGridViewPanel04.Size = new Size(110, 30);
            _hoykeyGridViewPanel04.TabIndex = 20;
            // 
            // _sendClipboardLabel
            // 
            _sendClipboardLabel.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            _sendClipboardLabel.Location = new Point(0, -1);
            _sendClipboardLabel.Margin = new Padding(0);
            _sendClipboardLabel.Name = "_sendClipboardLabel";
            _sendClipboardLabel.Size = new Size(110, 30);
            _sendClipboardLabel.TabIndex = 35;
            _sendClipboardLabel.Text = "Send Clipboard";
            _sendClipboardLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _hoykeyGridViewPanel23
            // 
            _hoykeyGridViewPanel23.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel23.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel23.Controls.Add(_translateCtrlToggle);
            _hoykeyGridViewPanel23.Location = new Point(234, 137);
            _hoykeyGridViewPanel23.Margin = new Padding(0);
            _hoykeyGridViewPanel23.Name = "_hoykeyGridViewPanel23";
            _hoykeyGridViewPanel23.Size = new Size(50, 30);
            _hoykeyGridViewPanel23.TabIndex = 17;
            // 
            // _translateCtrlToggle
            // 
            _translateCtrlToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _translateCtrlToggle.Checked = true;
            _translateCtrlToggle.CheckState = CheckState.Checked;
            _translateCtrlToggle.FlatStyle = FlatStyle.Flat;
            _translateCtrlToggle.Location = new Point(-1, 1);
            _translateCtrlToggle.Name = "_translateCtrlToggle";
            _translateCtrlToggle.Size = new Size(50, 26);
            _translateCtrlToggle.TabIndex = 28;
            _translateCtrlToggle.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel13
            // 
            _hoykeyGridViewPanel13.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel13.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel13.Controls.Add(_translateKeyButton);
            _hoykeyGridViewPanel13.Location = new Point(125, 137);
            _hoykeyGridViewPanel13.Margin = new Padding(0);
            _hoykeyGridViewPanel13.Name = "_hoykeyGridViewPanel13";
            _hoykeyGridViewPanel13.Size = new Size(110, 30);
            _hoykeyGridViewPanel13.TabIndex = 16;
            // 
            // _translateKeyButton
            // 
            _translateKeyButton.Location = new Point(4, 1);
            _translateKeyButton.Name = "_translateKeyButton";
            _translateKeyButton.Size = new Size(102, 26);
            _translateKeyButton.TabIndex = 3;
            _translateKeyButton.Text = "Enter";
            _translateKeyButton.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel03
            // 
            _hoykeyGridViewPanel03.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel03.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel03.Controls.Add(_translateLabel);
            _hoykeyGridViewPanel03.Location = new Point(16, 137);
            _hoykeyGridViewPanel03.Margin = new Padding(0);
            _hoykeyGridViewPanel03.Name = "_hoykeyGridViewPanel03";
            _hoykeyGridViewPanel03.Size = new Size(110, 30);
            _hoykeyGridViewPanel03.TabIndex = 15;
            // 
            // _translateLabel
            // 
            _translateLabel.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            _translateLabel.Location = new Point(0, -1);
            _translateLabel.Margin = new Padding(0);
            _translateLabel.Name = "_translateLabel";
            _translateLabel.Size = new Size(110, 30);
            _translateLabel.TabIndex = 34;
            _translateLabel.Text = "Translate";
            _translateLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _hoykeyGridViewPanel42
            // 
            _hoykeyGridViewPanel42.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel42.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel42.Controls.Add(_capturingToggleShiftToggle);
            _hoykeyGridViewPanel42.Location = new Point(332, 108);
            _hoykeyGridViewPanel42.Margin = new Padding(0);
            _hoykeyGridViewPanel42.Name = "_hoykeyGridViewPanel42";
            _hoykeyGridViewPanel42.Size = new Size(50, 30);
            _hoykeyGridViewPanel42.TabIndex = 13;
            // 
            // _capturingToggleShiftToggle
            // 
            _capturingToggleShiftToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _capturingToggleShiftToggle.FlatStyle = FlatStyle.Flat;
            _capturingToggleShiftToggle.Location = new Point(-1, 1);
            _capturingToggleShiftToggle.Name = "_capturingToggleShiftToggle";
            _capturingToggleShiftToggle.Size = new Size(50, 26);
            _capturingToggleShiftToggle.TabIndex = 31;
            _capturingToggleShiftToggle.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel32
            // 
            _hoykeyGridViewPanel32.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel32.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel32.Controls.Add(_capturingToggleAltToggle);
            _hoykeyGridViewPanel32.Location = new Point(283, 108);
            _hoykeyGridViewPanel32.Margin = new Padding(0);
            _hoykeyGridViewPanel32.Name = "_hoykeyGridViewPanel32";
            _hoykeyGridViewPanel32.Size = new Size(50, 30);
            _hoykeyGridViewPanel32.TabIndex = 14;
            // 
            // _capturingToggleAltToggle
            // 
            _capturingToggleAltToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _capturingToggleAltToggle.FlatStyle = FlatStyle.Flat;
            _capturingToggleAltToggle.Location = new Point(-1, 1);
            _capturingToggleAltToggle.Name = "_capturingToggleAltToggle";
            _capturingToggleAltToggle.Size = new Size(50, 26);
            _capturingToggleAltToggle.TabIndex = 27;
            _capturingToggleAltToggle.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel22
            // 
            _hoykeyGridViewPanel22.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel22.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel22.Controls.Add(_capturingToggleCtrlToggle);
            _hoykeyGridViewPanel22.Location = new Point(234, 108);
            _hoykeyGridViewPanel22.Margin = new Padding(0);
            _hoykeyGridViewPanel22.Name = "_hoykeyGridViewPanel22";
            _hoykeyGridViewPanel22.Size = new Size(50, 30);
            _hoykeyGridViewPanel22.TabIndex = 12;
            // 
            // _capturingToggleCtrlToggle
            // 
            _capturingToggleCtrlToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _capturingToggleCtrlToggle.FlatStyle = FlatStyle.Flat;
            _capturingToggleCtrlToggle.Location = new Point(-1, 1);
            _capturingToggleCtrlToggle.Name = "_capturingToggleCtrlToggle";
            _capturingToggleCtrlToggle.Size = new Size(50, 26);
            _capturingToggleCtrlToggle.TabIndex = 26;
            _capturingToggleCtrlToggle.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel12
            // 
            _hoykeyGridViewPanel12.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel12.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel12.Controls.Add(_capturingToggleKeyButton);
            _hoykeyGridViewPanel12.Location = new Point(125, 108);
            _hoykeyGridViewPanel12.Margin = new Padding(0);
            _hoykeyGridViewPanel12.Name = "_hoykeyGridViewPanel12";
            _hoykeyGridViewPanel12.Size = new Size(110, 30);
            _hoykeyGridViewPanel12.TabIndex = 11;
            // 
            // _capturingToggleKeyButton
            // 
            _capturingToggleKeyButton.Location = new Point(3, 1);
            _capturingToggleKeyButton.Name = "_capturingToggleKeyButton";
            _capturingToggleKeyButton.Size = new Size(102, 26);
            _capturingToggleKeyButton.TabIndex = 1;
            _capturingToggleKeyButton.Text = "Enter";
            _capturingToggleKeyButton.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel02
            // 
            _hoykeyGridViewPanel02.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel02.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel02.Controls.Add(_capturingToggleLabel);
            _hoykeyGridViewPanel02.Location = new Point(16, 108);
            _hoykeyGridViewPanel02.Margin = new Padding(0);
            _hoykeyGridViewPanel02.Name = "_hoykeyGridViewPanel02";
            _hoykeyGridViewPanel02.Size = new Size(110, 30);
            _hoykeyGridViewPanel02.TabIndex = 10;
            // 
            // _capturingToggleLabel
            // 
            _capturingToggleLabel.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            _capturingToggleLabel.Location = new Point(-1, -1);
            _capturingToggleLabel.Margin = new Padding(0);
            _capturingToggleLabel.Name = "_capturingToggleLabel";
            _capturingToggleLabel.Size = new Size(110, 30);
            _capturingToggleLabel.TabIndex = 32;
            _capturingToggleLabel.Text = "Capturing Toggle";
            _capturingToggleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _hoykeyGridViewPanel41
            // 
            _hoykeyGridViewPanel41.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel41.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel41.Controls.Add(_enableCapturingShiftToggle);
            _hoykeyGridViewPanel41.Location = new Point(332, 79);
            _hoykeyGridViewPanel41.Margin = new Padding(0);
            _hoykeyGridViewPanel41.Name = "_hoykeyGridViewPanel41";
            _hoykeyGridViewPanel41.Size = new Size(50, 30);
            _hoykeyGridViewPanel41.TabIndex = 8;
            // 
            // _enableCapturingShiftToggle
            // 
            _enableCapturingShiftToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _enableCapturingShiftToggle.FlatStyle = FlatStyle.Flat;
            _enableCapturingShiftToggle.Location = new Point(-1, 1);
            _enableCapturingShiftToggle.Name = "_enableCapturingShiftToggle";
            _enableCapturingShiftToggle.Size = new Size(50, 26);
            _enableCapturingShiftToggle.TabIndex = 30;
            _enableCapturingShiftToggle.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel31
            // 
            _hoykeyGridViewPanel31.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel31.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel31.Controls.Add(_enableCapturingAltToggle);
            _hoykeyGridViewPanel31.Location = new Point(283, 79);
            _hoykeyGridViewPanel31.Margin = new Padding(0);
            _hoykeyGridViewPanel31.Name = "_hoykeyGridViewPanel31";
            _hoykeyGridViewPanel31.Size = new Size(50, 30);
            _hoykeyGridViewPanel31.TabIndex = 9;
            // 
            // _enableCapturingAltToggle
            // 
            _enableCapturingAltToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _enableCapturingAltToggle.FlatStyle = FlatStyle.Flat;
            _enableCapturingAltToggle.Location = new Point(-1, 1);
            _enableCapturingAltToggle.Name = "_enableCapturingAltToggle";
            _enableCapturingAltToggle.Size = new Size(50, 26);
            _enableCapturingAltToggle.TabIndex = 26;
            _enableCapturingAltToggle.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel40
            // 
            _hoykeyGridViewPanel40.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel40.BackColor = Color.WhiteSmoke;
            _hoykeyGridViewPanel40.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel40.Controls.Add(_shiftLabel);
            _hoykeyGridViewPanel40.Location = new Point(332, 50);
            _hoykeyGridViewPanel40.Margin = new Padding(0);
            _hoykeyGridViewPanel40.Name = "_hoykeyGridViewPanel40";
            _hoykeyGridViewPanel40.Size = new Size(50, 30);
            _hoykeyGridViewPanel40.TabIndex = 4;
            // 
            // _shiftLabel
            // 
            _shiftLabel.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            _shiftLabel.Location = new Point(-1, -1);
            _shiftLabel.Margin = new Padding(0);
            _shiftLabel.Name = "_shiftLabel";
            _shiftLabel.Size = new Size(50, 30);
            _shiftLabel.TabIndex = 33;
            _shiftLabel.Text = "Shift";
            _shiftLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _hoykeyGridViewPanel21
            // 
            _hoykeyGridViewPanel21.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel21.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel21.Controls.Add(_enableCapturingCtrlToggle);
            _hoykeyGridViewPanel21.Location = new Point(234, 79);
            _hoykeyGridViewPanel21.Margin = new Padding(0);
            _hoykeyGridViewPanel21.Name = "_hoykeyGridViewPanel21";
            _hoykeyGridViewPanel21.Size = new Size(50, 30);
            _hoykeyGridViewPanel21.TabIndex = 7;
            // 
            // _enableCapturingCtrlToggle
            // 
            _enableCapturingCtrlToggle.CheckAlign = ContentAlignment.MiddleCenter;
            _enableCapturingCtrlToggle.FlatStyle = FlatStyle.Flat;
            _enableCapturingCtrlToggle.Location = new Point(-1, 1);
            _enableCapturingCtrlToggle.Name = "_enableCapturingCtrlToggle";
            _enableCapturingCtrlToggle.Size = new Size(50, 26);
            _enableCapturingCtrlToggle.TabIndex = 25;
            _enableCapturingCtrlToggle.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel30
            // 
            _hoykeyGridViewPanel30.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel30.BackColor = Color.WhiteSmoke;
            _hoykeyGridViewPanel30.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel30.Controls.Add(_altLabel);
            _hoykeyGridViewPanel30.Location = new Point(283, 50);
            _hoykeyGridViewPanel30.Margin = new Padding(0);
            _hoykeyGridViewPanel30.Name = "_hoykeyGridViewPanel30";
            _hoykeyGridViewPanel30.Size = new Size(50, 30);
            _hoykeyGridViewPanel30.TabIndex = 4;
            // 
            // _altLabel
            // 
            _altLabel.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            _altLabel.Location = new Point(-1, -1);
            _altLabel.Margin = new Padding(0);
            _altLabel.Name = "_altLabel";
            _altLabel.Size = new Size(50, 30);
            _altLabel.TabIndex = 32;
            _altLabel.Text = "Alt";
            _altLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _hoykeyGridViewPanel11
            // 
            _hoykeyGridViewPanel11.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel11.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel11.Controls.Add(_enableCapturingKeyButton);
            _hoykeyGridViewPanel11.Location = new Point(125, 79);
            _hoykeyGridViewPanel11.Margin = new Padding(0);
            _hoykeyGridViewPanel11.Name = "_hoykeyGridViewPanel11";
            _hoykeyGridViewPanel11.Size = new Size(110, 30);
            _hoykeyGridViewPanel11.TabIndex = 6;
            // 
            // _enableCapturingKeyButton
            // 
            _enableCapturingKeyButton.Location = new Point(3, 1);
            _enableCapturingKeyButton.Name = "_enableCapturingKeyButton";
            _enableCapturingKeyButton.Size = new Size(102, 26);
            _enableCapturingKeyButton.TabIndex = 0;
            _enableCapturingKeyButton.Text = "Scroll Lock";
            _enableCapturingKeyButton.UseVisualStyleBackColor = true;
            // 
            // _hoykeyGridViewPanel01
            // 
            _hoykeyGridViewPanel01.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel01.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel01.Controls.Add(_enableCapturingLabel);
            _hoykeyGridViewPanel01.Location = new Point(16, 79);
            _hoykeyGridViewPanel01.Margin = new Padding(0);
            _hoykeyGridViewPanel01.Name = "_hoykeyGridViewPanel01";
            _hoykeyGridViewPanel01.Size = new Size(110, 30);
            _hoykeyGridViewPanel01.TabIndex = 5;
            // 
            // _enableCapturingLabel
            // 
            _enableCapturingLabel.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            _enableCapturingLabel.Location = new Point(-1, -1);
            _enableCapturingLabel.Margin = new Padding(0);
            _enableCapturingLabel.Name = "_enableCapturingLabel";
            _enableCapturingLabel.Size = new Size(110, 30);
            _enableCapturingLabel.TabIndex = 31;
            _enableCapturingLabel.Text = "Enable Capturing";
            _enableCapturingLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _hoykeyGridViewPanel20
            // 
            _hoykeyGridViewPanel20.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel20.BackColor = Color.WhiteSmoke;
            _hoykeyGridViewPanel20.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel20.Controls.Add(_ctrlLabel);
            _hoykeyGridViewPanel20.Location = new Point(234, 50);
            _hoykeyGridViewPanel20.Margin = new Padding(0);
            _hoykeyGridViewPanel20.Name = "_hoykeyGridViewPanel20";
            _hoykeyGridViewPanel20.Size = new Size(50, 30);
            _hoykeyGridViewPanel20.TabIndex = 3;
            // 
            // _ctrlLabel
            // 
            _ctrlLabel.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            _ctrlLabel.Location = new Point(-1, -1);
            _ctrlLabel.Margin = new Padding(0);
            _ctrlLabel.Name = "_ctrlLabel";
            _ctrlLabel.Size = new Size(50, 30);
            _ctrlLabel.TabIndex = 31;
            _ctrlLabel.Text = "Ctrl";
            _ctrlLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _hoykeyGridViewPanel10
            // 
            _hoykeyGridViewPanel10.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel10.BackColor = Color.WhiteSmoke;
            _hoykeyGridViewPanel10.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel10.Controls.Add(_keyLabel);
            _hoykeyGridViewPanel10.Location = new Point(125, 50);
            _hoykeyGridViewPanel10.Margin = new Padding(0);
            _hoykeyGridViewPanel10.Name = "_hoykeyGridViewPanel10";
            _hoykeyGridViewPanel10.Size = new Size(110, 30);
            _hoykeyGridViewPanel10.TabIndex = 2;
            // 
            // _keyLabel
            // 
            _keyLabel.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            _keyLabel.Location = new Point(-1, -1);
            _keyLabel.Margin = new Padding(0);
            _keyLabel.Name = "_keyLabel";
            _keyLabel.Size = new Size(110, 30);
            _keyLabel.TabIndex = 31;
            _keyLabel.Text = "Key";
            _keyLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _hoykeyGridViewPanel00
            // 
            _hoykeyGridViewPanel00.AccessibleRole = AccessibleRole.None;
            _hoykeyGridViewPanel00.BackColor = Color.WhiteSmoke;
            _hoykeyGridViewPanel00.BorderStyle = BorderStyle.FixedSingle;
            _hoykeyGridViewPanel00.Controls.Add(_actionLabel);
            _hoykeyGridViewPanel00.Location = new Point(16, 50);
            _hoykeyGridViewPanel00.Margin = new Padding(0);
            _hoykeyGridViewPanel00.Name = "_hoykeyGridViewPanel00";
            _hoykeyGridViewPanel00.Size = new Size(110, 30);
            _hoykeyGridViewPanel00.TabIndex = 1;
            // 
            // _actionLabel
            // 
            _actionLabel.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            _actionLabel.Location = new Point(-1, -1);
            _actionLabel.Margin = new Padding(0);
            _actionLabel.Name = "_actionLabel";
            _actionLabel.Size = new Size(110, 30);
            _actionLabel.TabIndex = 30;
            _actionLabel.Text = "Action";
            _actionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _advancedPanel
            // 
            _advancedPanel.BackColor = Color.White;
            _advancedPanel.BorderStyle = BorderStyle.FixedSingle;
            _advancedPanel.Controls.Add(_debugEchoModeToggle);
            _advancedPanel.Controls.Add(_executeOnWindowStartToggle);
            _advancedPanel.Controls.Add(_writeLogFileToggle);
            _advancedPanel.Controls.Add(_inputTimeoutHintLabel);
            _advancedPanel.Controls.Add(_inputTimeoutLabel);
            _advancedPanel.Controls.Add(_inputTimeoutField);
            _advancedPanel.Icon = Properties.Resources.advanced_icon;
            _advancedPanel.Location = new Point(422, 629);
            _advancedPanel.Margin = new Padding(0, 0, 0, 3);
            _advancedPanel.Name = "_advancedPanel";
            _advancedPanel.Padding = new Padding(16, 40, 16, 16);
            _advancedPanel.Size = new Size(300, 230);
            _advancedPanel.TabIndex = 5;
            _advancedPanel.Title = "Advanced";
            // 
            // _debugEchoModeToggle
            // 
            _debugEchoModeToggle.FlatStyle = FlatStyle.Flat;
            _debugEchoModeToggle.Location = new Point(19, 90);
            _debugEchoModeToggle.Name = "_debugEchoModeToggle";
            _debugEchoModeToggle.Size = new Size(260, 20);
            _debugEchoModeToggle.TabIndex = 21;
            _debugEchoModeToggle.Text = "Debug Echo Mode";
            _debugEchoModeToggle.UseVisualStyleBackColor = true;
            _debugEchoModeToggle.CheckedChanged += _debugEchoModeToggle_CheckedChanged;
            // 
            // _executeOnWindowStartToggle
            // 
            _executeOnWindowStartToggle.Enabled = false;
            _executeOnWindowStartToggle.FlatStyle = FlatStyle.Flat;
            _executeOnWindowStartToggle.Location = new Point(19, 160);
            _executeOnWindowStartToggle.Name = "_executeOnWindowStartToggle";
            _executeOnWindowStartToggle.Size = new Size(260, 20);
            _executeOnWindowStartToggle.TabIndex = 20;
            _executeOnWindowStartToggle.Text = "Execute on Window Start";
            _executeOnWindowStartToggle.UseVisualStyleBackColor = true;
            _executeOnWindowStartToggle.CheckedChanged += _executeOnWindowStartToggle_CheckedChanged;
            // 
            // _writeLogFileToggle
            // 
            _writeLogFileToggle.FlatStyle = FlatStyle.Flat;
            _writeLogFileToggle.Location = new Point(19, 125);
            _writeLogFileToggle.Name = "_writeLogFileToggle";
            _writeLogFileToggle.Size = new Size(260, 20);
            _writeLogFileToggle.TabIndex = 5;
            _writeLogFileToggle.Text = "Write Log File";
            _writeLogFileToggle.UseVisualStyleBackColor = true;
            _writeLogFileToggle.CheckedChanged += _writeLogFileToggle_CheckedChanged;
            // 
            // _inputTimeoutHintLabel
            // 
            _inputTimeoutHintLabel.Location = new Point(200, 53);
            _inputTimeoutHintLabel.Margin = new Padding(0, 0, 0, 10);
            _inputTimeoutHintLabel.Name = "_inputTimeoutHintLabel";
            _inputTimeoutHintLabel.Size = new Size(79, 20);
            _inputTimeoutHintLabel.TabIndex = 19;
            _inputTimeoutHintLabel.Text = "(0: Disabled)";
            // 
            // _inputTimeoutLabel
            // 
            _inputTimeoutLabel.Location = new Point(16, 53);
            _inputTimeoutLabel.Margin = new Padding(0, 0, 3, 0);
            _inputTimeoutLabel.Name = "_inputTimeoutLabel";
            _inputTimeoutLabel.Size = new Size(115, 20);
            _inputTimeoutLabel.TabIndex = 19;
            _inputTimeoutLabel.Text = "Input Timeout (sec)";
            // 
            // _inputTimeoutField
            // 
            _inputTimeoutField.BorderStyle = BorderStyle.FixedSingle;
            _inputTimeoutField.Enabled = false;
            _inputTimeoutField.Location = new Point(137, 50);
            _inputTimeoutField.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            _inputTimeoutField.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _inputTimeoutField.Name = "_inputTimeoutField";
            _inputTimeoutField.Size = new Size(60, 23);
            _inputTimeoutField.TabIndex = 19;
            _inputTimeoutField.Value = new decimal(new int[] { 3, 0, 0, 0 });
            _inputTimeoutField.ValueChanged += _inputTimeoutField_ValueChanged;
            // 
            // _menuStrip
            // 
            _menuStrip.BackColor = Color.LightGray;
            _menuStrip.Items.AddRange(new ToolStripItem[] { _ckgMenuItem });
            _menuStrip.Location = new Point(0, 0);
            _menuStrip.Name = "_menuStrip";
            _menuStrip.Size = new Size(734, 24);
            _menuStrip.TabIndex = 6;
            _menuStrip.Text = "menuStrip";
            // 
            // _ckgMenuItem
            // 
            _ckgMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _exitMenuItem });
            _ckgMenuItem.Name = "_ckgMenuItem";
            _ckgMenuItem.Size = new Size(42, 20);
            _ckgMenuItem.Text = "CKG";
            // 
            // _exitMenuItem
            // 
            _exitMenuItem.Name = "_exitMenuItem";
            _exitMenuItem.Size = new Size(93, 22);
            _exitMenuItem.Text = "Exit";
            _exitMenuItem.Click += _exitMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(734, 871);
            Controls.Add(_advancedPanel);
            Controls.Add(_hotkeysPanel);
            Controls.Add(_notificationPanel);
            Controls.Add(_overlayPanel);
            Controls.Add(_translationPanel);
            Controls.Add(_generalPanel);
            Controls.Add(_menuStrip);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = _menuStrip;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "Chattokouken Ganbarunoda!!";
            FormClosing += MainForm_FormClosing;
            _generalPanel.ResumeLayout(false);
            _generalPanel.PerformLayout();
            _translationPanel.ResumeLayout(false);
            _translationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_requestTimeoutField).EndInit();
            _overlayPanel.ResumeLayout(false);
            _overlayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_overlayOpacitySlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)_overlayFontSizeField).EndInit();
            ((System.ComponentModel.ISupportInitialize)_overlayOffsetYField).EndInit();
            ((System.ComponentModel.ISupportInitialize)_overlayOffsetXField).EndInit();
            _notificationPanel.ResumeLayout(false);
            _notificationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_notificationVolumeSlider).EndInit();
            _hotkeysPanel.ResumeLayout(false);
            _hotkeysPanel.PerformLayout();
            _hoykeyGridViewPanel44.ResumeLayout(false);
            _hoykeyGridViewPanel34.ResumeLayout(false);
            _hoykeyGridViewPanel43.ResumeLayout(false);
            _hoykeyGridViewPanel24.ResumeLayout(false);
            _hoykeyGridViewPanel33.ResumeLayout(false);
            _hoykeyGridViewPanel14.ResumeLayout(false);
            _hoykeyGridViewPanel04.ResumeLayout(false);
            _hoykeyGridViewPanel23.ResumeLayout(false);
            _hoykeyGridViewPanel13.ResumeLayout(false);
            _hoykeyGridViewPanel03.ResumeLayout(false);
            _hoykeyGridViewPanel42.ResumeLayout(false);
            _hoykeyGridViewPanel32.ResumeLayout(false);
            _hoykeyGridViewPanel22.ResumeLayout(false);
            _hoykeyGridViewPanel12.ResumeLayout(false);
            _hoykeyGridViewPanel02.ResumeLayout(false);
            _hoykeyGridViewPanel41.ResumeLayout(false);
            _hoykeyGridViewPanel31.ResumeLayout(false);
            _hoykeyGridViewPanel40.ResumeLayout(false);
            _hoykeyGridViewPanel21.ResumeLayout(false);
            _hoykeyGridViewPanel30.ResumeLayout(false);
            _hoykeyGridViewPanel11.ResumeLayout(false);
            _hoykeyGridViewPanel01.ResumeLayout(false);
            _hoykeyGridViewPanel20.ResumeLayout(false);
            _hoykeyGridViewPanel10.ResumeLayout(false);
            _hoykeyGridViewPanel00.ResumeLayout(false);
            _advancedPanel.ResumeLayout(false);
            _advancedPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_inputTimeoutField).EndInit();
            _menuStrip.ResumeLayout(false);
            _menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.SettingPanel _generalPanel;
        private CheckBox _autoSendMessageToggle;
        private CheckBox _startTranslateToggle;
        private ComboBox _outputMethodSelector;
        private Label _outputMethodLabel;
        private Controls.SettingPanel _translationPanel;
        private ComboBox _modelSelector;
        private Label _modelLabel;
        private Label _apiKeyLabel;
        private TextBox _apiKeyField;
        private ComboBox _destinationLanguageSelector;
        private ComboBox _sourceLanguageSelector;
        private Label _sourceLanguageLabel;
        private Label _destinationLanguage;
        private TextBox _translationFormatField;
        private Label _translationFormatLabel;
        private NumericUpDown _requestTimeoutField;
        private Label _translationFormatHintLabel;
        private Label _requestTimeoutDefaultLabel;
        private Label _requestTimeoutLabel;
        private Controls.SettingPanel _overlayPanel;
        private Controls.AnchorSelectorControl _overlayAnchorSelector;
        private Label _anchorLabel;
        private CheckBox _overlayEnabledToggle;
        private Label _overlayOffsetYLabel;
        private NumericUpDown _overlayOffsetYField;
        private Label _overlayOffsetXLabel;
        private NumericUpDown _overlayOffsetXField;
        private Label _overlayFontSizeHintLabel;
        private Label _overlayFontSizeLabel;
        private NumericUpDown _overlayFontSizeField;
        private Label _overlayOpacityLabel;
        private TrackBar _overlayOpacitySlider;
        private TextBox _overlayOpacityField;
        private Label _overlayOpacityHintLabel;
        private Controls.SettingPanel _notificationPanel;
        private CheckBox _translationCompletedNotifyToggle;
        private CheckBox _capturingStartNotifyToggle;
        private CheckBox _notificationEnabledToggle;
        private TextBox _notificationVolumeField;
        private Label _notificationVolumeHintLabel;
        private Label _notificationVolumeLabel;
        private TrackBar _notificationVolumeSlider;
        private Controls.SettingPanel _hotkeysPanel;
        private Panel _hoykeyGridViewPanel10;
        private Panel _hoykeyGridViewPanel00;
        private Panel _hoykeyGridViewPanel43;
        private Panel _hoykeyGridViewPanel33;
        private Panel _hoykeyGridViewPanel23;
        private Panel _hoykeyGridViewPanel13;
        private Panel _hoykeyGridViewPanel03;
        private Panel _hoykeyGridViewPanel42;
        private Panel _hoykeyGridViewPanel32;
        private Panel _hoykeyGridViewPanel22;
        private Panel _hoykeyGridViewPanel12;
        private Panel _hoykeyGridViewPanel02;
        private Panel _hoykeyGridViewPanel41;
        private Panel _hoykeyGridViewPanel31;
        private Panel _hoykeyGridViewPanel40;
        private Panel _hoykeyGridViewPanel21;
        private Panel _hoykeyGridViewPanel30;
        private Panel _hoykeyGridViewPanel11;
        private Panel _hoykeyGridViewPanel01;
        private Panel _hoykeyGridViewPanel20;
        private Label _actionLabel;
        private Label _shiftLabel;
        private Label _altLabel;
        private Label _ctrlLabel;
        private Label _keyLabel;
        private Panel _hoykeyGridViewPanel44;
        private Panel _hoykeyGridViewPanel34;
        private Panel _hoykeyGridViewPanel24;
        private Panel _hoykeyGridViewPanel14;
        private Panel _hoykeyGridViewPanel04;
        private Label _translateLabel;
        private Label _capturingToggleLabel;
        private Label _enableCapturingLabel;
        private Button _translateKeyButton;
        private Button _capturingToggleKeyButton;
        private Button _enableCapturingKeyButton;
        private CheckBox _enableCapturingCtrlToggle;
        private CheckBox _translateShiftToggle;
        private CheckBox _translateAltToggle;
        private CheckBox _translateCtrlToggle;
        private CheckBox _capturingToggleShiftToggle;
        private CheckBox _capturingToggleAltToggle;
        private CheckBox _capturingToggleCtrlToggle;
        private CheckBox _enableCapturingShiftToggle;
        private CheckBox _enableCapturingAltToggle;
        private Label _hotkeysHintLabel;
        private Controls.SettingPanel _advancedPanel;
        private Label _inputTimeoutHintLabel;
        private Label _inputTimeoutLabel;
        private NumericUpDown _inputTimeoutField;
        private CheckBox _executeOnWindowStartToggle;
        private CheckBox _writeLogFileToggle;
        private Button _sendClipboardKeyButton;
        private Label _sendClipboardLabel;
        private CheckBox _sendClipboardShiftToggle;
        private CheckBox _sendClipboardAltToggle;
        private CheckBox _sendClipboardCtrlToggle;
        private ComboBox _defaultInputModeSelector;
        private Label _defaultInputModeLabel;
        private Label _inputModeHintLabel;
        private MenuStrip _menuStrip;
        private TextBox _glossaryIdField;
        private CheckBox _debugEchoModeToggle;
        private CheckBox _translationFailedNotifyToggle;
        private Button _glossarySelectButton;
        private ToolStripMenuItem _ckgMenuItem;
        private ToolStripMenuItem _exitMenuItem;
    }
}
