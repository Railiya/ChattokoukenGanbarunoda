namespace CKG.Controls
{
    partial class NotificationPanel
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
            _translationFailedNotifyToggle = new System.Windows.Forms.CheckBox();
            _notificationVolumeField = new System.Windows.Forms.TextBox();
            _notificationVolumeHintLabel = new System.Windows.Forms.Label();
            _translationCompletedNotifyToggle = new System.Windows.Forms.CheckBox();
            _notificationVolumeLabel = new System.Windows.Forms.Label();
            _capturingStartNotifyToggle = new System.Windows.Forms.CheckBox();
            _notificationVolumeSlider = new System.Windows.Forms.TrackBar();
            _notificationEnabledToggle = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)_iconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_notificationVolumeSlider).BeginInit();
            SuspendLayout();
            // 
            // _titleLabel
            // 
            _titleLabel.Location = new System.Drawing.Point(48, 10);
            _titleLabel.Size = new System.Drawing.Size(93, 20);
            _titleLabel.Text = "Notification";
            // 
            // _iconBox
            // 
            _iconBox.Image = Properties.Resources.notification_icon;
            _iconBox.Location = new System.Drawing.Point(12, 5);
            // 
            // _translationFailedNotifyToggle
            // 
            _translationFailedNotifyToggle.Checked = true;
            _translationFailedNotifyToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            _translationFailedNotifyToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _translationFailedNotifyToggle.Location = new System.Drawing.Point(35, 155);
            _translationFailedNotifyToggle.Name = "_translationFailedNotifyToggle";
            _translationFailedNotifyToggle.Size = new System.Drawing.Size(246, 20);
            _translationFailedNotifyToggle.TabIndex = 42;
            _translationFailedNotifyToggle.Text = "On Translation Failed";
            _translationFailedNotifyToggle.UseVisualStyleBackColor = true;
            _translationFailedNotifyToggle.CheckedChanged += _translationFailedNotifyToggle_CheckedChanged;
            // 
            // _notificationVolumeField
            // 
            _notificationVolumeField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _notificationVolumeField.Location = new System.Drawing.Point(218, 194);
            _notificationVolumeField.Name = "_notificationVolumeField";
            _notificationVolumeField.ReadOnly = true;
            _notificationVolumeField.Size = new System.Drawing.Size(40, 23);
            _notificationVolumeField.TabIndex = 36;
            _notificationVolumeField.Text = "80";
            _notificationVolumeField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _notificationVolumeHintLabel
            // 
            _notificationVolumeHintLabel.Location = new System.Drawing.Point(261, 197);
            _notificationVolumeHintLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            _notificationVolumeHintLabel.Name = "_notificationVolumeHintLabel";
            _notificationVolumeHintLabel.Size = new System.Drawing.Size(20, 20);
            _notificationVolumeHintLabel.TabIndex = 41;
            _notificationVolumeHintLabel.Text = "%";
            // 
            // _translationCompletedNotifyToggle
            // 
            _translationCompletedNotifyToggle.Checked = true;
            _translationCompletedNotifyToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            _translationCompletedNotifyToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _translationCompletedNotifyToggle.Location = new System.Drawing.Point(35, 120);
            _translationCompletedNotifyToggle.Name = "_translationCompletedNotifyToggle";
            _translationCompletedNotifyToggle.Size = new System.Drawing.Size(246, 20);
            _translationCompletedNotifyToggle.TabIndex = 38;
            _translationCompletedNotifyToggle.Text = "On Translation Completed";
            _translationCompletedNotifyToggle.UseVisualStyleBackColor = true;
            _translationCompletedNotifyToggle.CheckedChanged += _translationCompletedNotifyToggle_CheckedChanged;
            // 
            // _notificationVolumeLabel
            // 
            _notificationVolumeLabel.Location = new System.Drawing.Point(21, 197);
            _notificationVolumeLabel.Margin = new System.Windows.Forms.Padding(0);
            _notificationVolumeLabel.Name = "_notificationVolumeLabel";
            _notificationVolumeLabel.Size = new System.Drawing.Size(50, 20);
            _notificationVolumeLabel.TabIndex = 40;
            _notificationVolumeLabel.Text = "Volume";
            // 
            // _capturingStartNotifyToggle
            // 
            _capturingStartNotifyToggle.Checked = true;
            _capturingStartNotifyToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            _capturingStartNotifyToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _capturingStartNotifyToggle.Location = new System.Drawing.Point(35, 85);
            _capturingStartNotifyToggle.Name = "_capturingStartNotifyToggle";
            _capturingStartNotifyToggle.Size = new System.Drawing.Size(246, 20);
            _capturingStartNotifyToggle.TabIndex = 35;
            _capturingStartNotifyToggle.Text = "On Capturing Start";
            _capturingStartNotifyToggle.UseVisualStyleBackColor = true;
            _capturingStartNotifyToggle.CheckedChanged += _capturingStartNotifyToggle_CheckedChanged;
            // 
            // _notificationVolumeSlider
            // 
            _notificationVolumeSlider.AutoSize = false;
            _notificationVolumeSlider.Location = new System.Drawing.Point(71, 195);
            _notificationVolumeSlider.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            _notificationVolumeSlider.Maximum = 100;
            _notificationVolumeSlider.Name = "_notificationVolumeSlider";
            _notificationVolumeSlider.Size = new System.Drawing.Size(141, 23);
            _notificationVolumeSlider.TabIndex = 39;
            _notificationVolumeSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            _notificationVolumeSlider.Value = 80;
            _notificationVolumeSlider.ValueChanged += _notificationVolumeSlider_ValueChanged;
            // 
            // _notificationEnabledToggle
            // 
            _notificationEnabledToggle.Checked = true;
            _notificationEnabledToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            _notificationEnabledToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _notificationEnabledToggle.Location = new System.Drawing.Point(19, 50);
            _notificationEnabledToggle.Name = "_notificationEnabledToggle";
            _notificationEnabledToggle.Size = new System.Drawing.Size(262, 20);
            _notificationEnabledToggle.TabIndex = 37;
            _notificationEnabledToggle.Text = "Enabled";
            _notificationEnabledToggle.UseVisualStyleBackColor = true;
            _notificationEnabledToggle.CheckedChanged += _notificationEnabledToggle_CheckedChanged;
            // 
            // NotificationPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(_translationFailedNotifyToggle);
            Controls.Add(_notificationVolumeField);
            Controls.Add(_notificationVolumeHintLabel);
            Controls.Add(_translationCompletedNotifyToggle);
            Controls.Add(_notificationVolumeLabel);
            Controls.Add(_capturingStartNotifyToggle);
            Controls.Add(_notificationVolumeSlider);
            Controls.Add(_notificationEnabledToggle);
            Icon = Properties.Resources.notification_icon;
            Name = "NotificationPanel";
            Padding = new System.Windows.Forms.Padding(16, 40, 16, 16);
            Size = new System.Drawing.Size(300, 240);
            Title = "Notification";
            Controls.SetChildIndex(_titleLabel, 0);
            Controls.SetChildIndex(_iconBox, 0);
            Controls.SetChildIndex(_notificationEnabledToggle, 0);
            Controls.SetChildIndex(_notificationVolumeSlider, 0);
            Controls.SetChildIndex(_capturingStartNotifyToggle, 0);
            Controls.SetChildIndex(_notificationVolumeLabel, 0);
            Controls.SetChildIndex(_translationCompletedNotifyToggle, 0);
            Controls.SetChildIndex(_notificationVolumeHintLabel, 0);
            Controls.SetChildIndex(_notificationVolumeField, 0);
            Controls.SetChildIndex(_translationFailedNotifyToggle, 0);
            ((System.ComponentModel.ISupportInitialize)_iconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)_notificationVolumeSlider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox _translationFailedNotifyToggle;
        private System.Windows.Forms.TextBox _notificationVolumeField;
        private System.Windows.Forms.Label _notificationVolumeHintLabel;
        private System.Windows.Forms.CheckBox _translationCompletedNotifyToggle;
        private System.Windows.Forms.Label _notificationVolumeLabel;
        private System.Windows.Forms.CheckBox _capturingStartNotifyToggle;
        private System.Windows.Forms.TrackBar _notificationVolumeSlider;
        private System.Windows.Forms.CheckBox _notificationEnabledToggle;
    }
}