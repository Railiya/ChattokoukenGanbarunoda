namespace CKG.Controls
{
    partial class OverlayPanel
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
            _overlayOpacityField = new System.Windows.Forms.TextBox();
            _overlayOpacityHintLabel = new System.Windows.Forms.Label();
            _overlayOpacityLabel = new System.Windows.Forms.Label();
            _overlayOpacitySlider = new System.Windows.Forms.TrackBar();
            _overlayFontSizeHintLabel = new System.Windows.Forms.Label();
            _overlayFontSizeLabel = new System.Windows.Forms.Label();
            _overlayFontSizeField = new System.Windows.Forms.NumericUpDown();
            _overlayOffsetYLabel = new System.Windows.Forms.Label();
            _overlayOffsetYField = new System.Windows.Forms.NumericUpDown();
            _overlayOffsetXLabel = new System.Windows.Forms.Label();
            _overlayOffsetXField = new System.Windows.Forms.NumericUpDown();
            _overlayAnchorSelector = new AnchorSelectorControl();
            _anchorLabel = new System.Windows.Forms.Label();
            _overlayEnabledToggle = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)_iconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_overlayOpacitySlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_overlayFontSizeField).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_overlayOffsetYField).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_overlayOffsetXField).BeginInit();
            SuspendLayout();
            // 
            // _titleLabel
            // 
            _titleLabel.Location = new System.Drawing.Point(48, 10);
            _titleLabel.Size = new System.Drawing.Size(62, 20);
            _titleLabel.Text = "Overlay";
            // 
            // _iconBox
            // 
            _iconBox.Image = Properties.Resources.overlay_icon;
            _iconBox.Location = new System.Drawing.Point(12, 5);
            // 
            // _overlayOpacityField
            // 
            _overlayOpacityField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _overlayOpacityField.Location = new System.Drawing.Point(216, 214);
            _overlayOpacityField.Name = "_overlayOpacityField";
            _overlayOpacityField.ReadOnly = true;
            _overlayOpacityField.Size = new System.Drawing.Size(40, 23);
            _overlayOpacityField.TabIndex = 33;
            _overlayOpacityField.Text = "80";
            _overlayOpacityField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _overlayOpacityHintLabel
            // 
            _overlayOpacityHintLabel.Location = new System.Drawing.Point(259, 217);
            _overlayOpacityHintLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _overlayOpacityHintLabel.Name = "_overlayOpacityHintLabel";
            _overlayOpacityHintLabel.Size = new System.Drawing.Size(20, 20);
            _overlayOpacityHintLabel.TabIndex = 43;
            _overlayOpacityHintLabel.Text = "%";
            // 
            // _overlayOpacityLabel
            // 
            _overlayOpacityLabel.Location = new System.Drawing.Point(19, 217);
            _overlayOpacityLabel.Margin = new System.Windows.Forms.Padding(0);
            _overlayOpacityLabel.Name = "_overlayOpacityLabel";
            _overlayOpacityLabel.Size = new System.Drawing.Size(50, 20);
            _overlayOpacityLabel.TabIndex = 42;
            _overlayOpacityLabel.Text = "Opacity";
            // 
            // _overlayOpacitySlider
            // 
            _overlayOpacitySlider.AutoSize = false;
            _overlayOpacitySlider.Location = new System.Drawing.Point(69, 215);
            _overlayOpacitySlider.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            _overlayOpacitySlider.Maximum = 100;
            _overlayOpacitySlider.Name = "_overlayOpacitySlider";
            _overlayOpacitySlider.Size = new System.Drawing.Size(141, 23);
            _overlayOpacitySlider.TabIndex = 41;
            _overlayOpacitySlider.TickStyle = System.Windows.Forms.TickStyle.None;
            _overlayOpacitySlider.Value = 80;
            _overlayOpacitySlider.ValueChanged += _overlayOpacitySlider_ValueChanged;
            // 
            // _overlayFontSizeHintLabel
            // 
            _overlayFontSizeHintLabel.Location = new System.Drawing.Point(259, 175);
            _overlayFontSizeHintLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _overlayFontSizeHintLabel.Name = "_overlayFontSizeHintLabel";
            _overlayFontSizeHintLabel.Size = new System.Drawing.Size(20, 20);
            _overlayFontSizeHintLabel.TabIndex = 40;
            _overlayFontSizeHintLabel.Text = "pt";
            // 
            // _overlayFontSizeLabel
            // 
            _overlayFontSizeLabel.Location = new System.Drawing.Point(116, 175);
            _overlayFontSizeLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _overlayFontSizeLabel.Name = "_overlayFontSizeLabel";
            _overlayFontSizeLabel.Size = new System.Drawing.Size(74, 20);
            _overlayFontSizeLabel.TabIndex = 39;
            _overlayFontSizeLabel.Text = "Font Size:";
            _overlayFontSizeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _overlayFontSizeField
            // 
            _overlayFontSizeField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _overlayFontSizeField.Location = new System.Drawing.Point(196, 172);
            _overlayFontSizeField.Name = "_overlayFontSizeField";
            _overlayFontSizeField.Size = new System.Drawing.Size(60, 23);
            _overlayFontSizeField.TabIndex = 38;
            _overlayFontSizeField.Value = new decimal(new int[] { 10, 0, 0, 0 });
            _overlayFontSizeField.ValueChanged += _overlayFontSizeField_ValueChanged;
            // 
            // _overlayOffsetYLabel
            // 
            _overlayOffsetYLabel.Location = new System.Drawing.Point(116, 142);
            _overlayOffsetYLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _overlayOffsetYLabel.Name = "_overlayOffsetYLabel";
            _overlayOffsetYLabel.Size = new System.Drawing.Size(74, 20);
            _overlayOffsetYLabel.TabIndex = 37;
            _overlayOffsetYLabel.Text = "Offset Y:";
            _overlayOffsetYLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _overlayOffsetYField
            // 
            _overlayOffsetYField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _overlayOffsetYField.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            _overlayOffsetYField.Location = new System.Drawing.Point(196, 139);
            _overlayOffsetYField.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            _overlayOffsetYField.Name = "_overlayOffsetYField";
            _overlayOffsetYField.Size = new System.Drawing.Size(60, 23);
            _overlayOffsetYField.TabIndex = 36;
            _overlayOffsetYField.ValueChanged += _overlayOffsetYField_ValueChanged;
            // 
            // _overlayOffsetXLabel
            // 
            _overlayOffsetXLabel.Location = new System.Drawing.Point(116, 108);
            _overlayOffsetXLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _overlayOffsetXLabel.Name = "_overlayOffsetXLabel";
            _overlayOffsetXLabel.Size = new System.Drawing.Size(74, 20);
            _overlayOffsetXLabel.TabIndex = 35;
            _overlayOffsetXLabel.Text = "Offset X:";
            _overlayOffsetXLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _overlayOffsetXField
            // 
            _overlayOffsetXField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _overlayOffsetXField.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            _overlayOffsetXField.Location = new System.Drawing.Point(196, 105);
            _overlayOffsetXField.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            _overlayOffsetXField.Name = "_overlayOffsetXField";
            _overlayOffsetXField.Size = new System.Drawing.Size(60, 23);
            _overlayOffsetXField.TabIndex = 34;
            _overlayOffsetXField.ValueChanged += _overlayOffsetXField_ValueChanged;
            // 
            // _overlayAnchorSelector
            // 
            _overlayAnchorSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _overlayAnchorSelector.Location = new System.Drawing.Point(19, 105);
            _overlayAnchorSelector.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            _overlayAnchorSelector.Name = "_overlayAnchorSelector";
            _overlayAnchorSelector.SelectedAnchor = System.Drawing.ContentAlignment.TopLeft;
            _overlayAnchorSelector.Size = new System.Drawing.Size(90, 90);
            _overlayAnchorSelector.TabIndex = 32;
            // 
            // _anchorLabel
            // 
            _anchorLabel.Location = new System.Drawing.Point(19, 85);
            _anchorLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _anchorLabel.Name = "_anchorLabel";
            _anchorLabel.Size = new System.Drawing.Size(90, 20);
            _anchorLabel.TabIndex = 30;
            _anchorLabel.Text = "Anchor";
            // 
            // _overlayEnabledToggle
            // 
            _overlayEnabledToggle.Checked = true;
            _overlayEnabledToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            _overlayEnabledToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _overlayEnabledToggle.Location = new System.Drawing.Point(19, 50);
            _overlayEnabledToggle.Name = "_overlayEnabledToggle";
            _overlayEnabledToggle.Size = new System.Drawing.Size(260, 20);
            _overlayEnabledToggle.TabIndex = 31;
            _overlayEnabledToggle.Text = "Enabled";
            _overlayEnabledToggle.UseVisualStyleBackColor = true;
            _overlayEnabledToggle.CheckedChanged += _overlayEnabledToggle_CheckedChanged;
            // 
            // OverlayPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(_overlayOpacityField);
            Controls.Add(_overlayOpacityHintLabel);
            Controls.Add(_overlayOpacityLabel);
            Controls.Add(_overlayOpacitySlider);
            Controls.Add(_overlayFontSizeHintLabel);
            Controls.Add(_overlayFontSizeLabel);
            Controls.Add(_overlayFontSizeField);
            Controls.Add(_overlayOffsetYLabel);
            Controls.Add(_overlayOffsetYField);
            Controls.Add(_overlayOffsetXLabel);
            Controls.Add(_overlayOffsetXField);
            Controls.Add(_overlayAnchorSelector);
            Controls.Add(_anchorLabel);
            Controls.Add(_overlayEnabledToggle);
            Icon = Properties.Resources.overlay_icon;
            Name = "OverlayPanel";
            Size = new System.Drawing.Size(300, 260);
            Title = "Overlay";
            Controls.SetChildIndex(_titleLabel, 0);
            Controls.SetChildIndex(_iconBox, 0);
            Controls.SetChildIndex(_overlayEnabledToggle, 0);
            Controls.SetChildIndex(_anchorLabel, 0);
            Controls.SetChildIndex(_overlayAnchorSelector, 0);
            Controls.SetChildIndex(_overlayOffsetXField, 0);
            Controls.SetChildIndex(_overlayOffsetXLabel, 0);
            Controls.SetChildIndex(_overlayOffsetYField, 0);
            Controls.SetChildIndex(_overlayOffsetYLabel, 0);
            Controls.SetChildIndex(_overlayFontSizeField, 0);
            Controls.SetChildIndex(_overlayFontSizeLabel, 0);
            Controls.SetChildIndex(_overlayFontSizeHintLabel, 0);
            Controls.SetChildIndex(_overlayOpacitySlider, 0);
            Controls.SetChildIndex(_overlayOpacityLabel, 0);
            Controls.SetChildIndex(_overlayOpacityHintLabel, 0);
            Controls.SetChildIndex(_overlayOpacityField, 0);
            ((System.ComponentModel.ISupportInitialize)_iconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)_overlayOpacitySlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)_overlayFontSizeField).EndInit();
            ((System.ComponentModel.ISupportInitialize)_overlayOffsetYField).EndInit();
            ((System.ComponentModel.ISupportInitialize)_overlayOffsetXField).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox _overlayOpacityField;
        private System.Windows.Forms.Label _overlayOpacityHintLabel;
        private System.Windows.Forms.Label _overlayOpacityLabel;
        private System.Windows.Forms.TrackBar _overlayOpacitySlider;
        private System.Windows.Forms.Label _overlayFontSizeHintLabel;
        private System.Windows.Forms.Label _overlayFontSizeLabel;
        private System.Windows.Forms.NumericUpDown _overlayFontSizeField;
        private System.Windows.Forms.Label _overlayOffsetYLabel;
        private System.Windows.Forms.NumericUpDown _overlayOffsetYField;
        private System.Windows.Forms.Label _overlayOffsetXLabel;
        private System.Windows.Forms.NumericUpDown _overlayOffsetXField;
        private AnchorSelectorControl _overlayAnchorSelector;
        private System.Windows.Forms.Label _anchorLabel;
        private System.Windows.Forms.CheckBox _overlayEnabledToggle;
    }
}