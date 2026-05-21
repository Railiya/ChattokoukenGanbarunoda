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
            _menuStrip = new MenuStrip();
            _ckgMenuItem = new ToolStripMenuItem();
            _githubMenuItem = new ToolStripMenuItem();
            _ckgMenuSeparator = new ToolStripSeparator();
            _exitMenuItem = new ToolStripMenuItem();
            _profilesMenuItem = new ToolStripMenuItem();
            _generalPanel = new CKG.Controls.GeneralPanel();
            _translationPanel = new CKG.Controls.TranslationPanel();
            _overlayPanel = new CKG.Controls.OverlayPanel();
            _notificationPanel = new CKG.Controls.NotificationPanel();
            _hotkeysPanel = new CKG.Controls.HotkeysPanel();
            _advancedPanel = new CKG.Controls.AdvancedPanel();
            _menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // _menuStrip
            // 
            _menuStrip.BackColor = Color.LightGray;
            _menuStrip.Items.AddRange(new ToolStripItem[] { _ckgMenuItem, _profilesMenuItem });
            _menuStrip.Location = new Point(0, 0);
            _menuStrip.Name = "_menuStrip";
            _menuStrip.Size = new Size(734, 24);
            _menuStrip.TabIndex = 6;
            _menuStrip.Text = "menuStrip";
            // 
            // _ckgMenuItem
            // 
            _ckgMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _githubMenuItem, _ckgMenuSeparator, _exitMenuItem });
            _ckgMenuItem.Name = "_ckgMenuItem";
            _ckgMenuItem.Size = new Size(42, 20);
            _ckgMenuItem.Text = "CKG";
            // 
            // _githubMenuItem
            // 
            _githubMenuItem.Name = "_githubMenuItem";
            _githubMenuItem.Size = new Size(140, 22);
            _githubMenuItem.Text = "Github Page";
            _githubMenuItem.Click += _githubMenuItem_Click;
            // 
            // _ckgMenuSeparator
            // 
            _ckgMenuSeparator.Name = "_ckgMenuSeparator";
            _ckgMenuSeparator.Size = new Size(137, 6);
            // 
            // _exitMenuItem
            // 
            _exitMenuItem.Name = "_exitMenuItem";
            _exitMenuItem.Size = new Size(140, 22);
            _exitMenuItem.Text = "Exit";
            _exitMenuItem.Click += _exitMenuItem_Click;
            // 
            // _profilesMenuItem
            // 
            _profilesMenuItem.Name = "_profilesMenuItem";
            _profilesMenuItem.Size = new Size(58, 20);
            _profilesMenuItem.Text = "Profiles";
            // 
            // _generalPanel
            // 
            _generalPanel.BackColor = Color.White;
            _generalPanel.BorderStyle = BorderStyle.FixedSingle;
            _generalPanel.Icon = Properties.Resources.general_icon;
            _generalPanel.Location = new Point(12, 29);
            _generalPanel.Name = "_generalPanel";
            _generalPanel.Padding = new Padding(16, 40, 16, 16);
            _generalPanel.Size = new Size(300, 358);
            _generalPanel.TabIndex = 7;
            _generalPanel.Title = "General";
            // 
            // _translationPanel
            // 
            _translationPanel.BackColor = Color.White;
            _translationPanel.BorderStyle = BorderStyle.FixedSingle;
            _translationPanel.Icon = (Image)resources.GetObject("_translationPanel.Icon");
            _translationPanel.Location = new Point(322, 29);
            _translationPanel.Name = "_translationPanel";
            _translationPanel.Padding = new Padding(16, 40, 10, 16);
            _translationPanel.Size = new Size(400, 358);
            _translationPanel.TabIndex = 8;
            _translationPanel.Title = "Translation";
            // 
            // _overlayPanel
            // 
            _overlayPanel.BackColor = Color.White;
            _overlayPanel.BorderStyle = BorderStyle.FixedSingle;
            _overlayPanel.Icon = (Image)resources.GetObject("_overlayPanel.Icon");
            _overlayPanel.Location = new Point(12, 393);
            _overlayPanel.Name = "_overlayPanel";
            _overlayPanel.Padding = new Padding(16, 40, 10, 16);
            _overlayPanel.Size = new Size(300, 260);
            _overlayPanel.TabIndex = 9;
            _overlayPanel.Title = "Overlay";
            // 
            // _notificationPanel
            // 
            _notificationPanel.BackColor = Color.White;
            _notificationPanel.BorderStyle = BorderStyle.FixedSingle;
            _notificationPanel.Icon = (Image)resources.GetObject("_notificationPanel.Icon");
            _notificationPanel.Location = new Point(322, 393);
            _notificationPanel.Name = "_notificationPanel";
            _notificationPanel.Padding = new Padding(16, 40, 10, 16);
            _notificationPanel.Size = new Size(400, 260);
            _notificationPanel.TabIndex = 10;
            _notificationPanel.Title = "Notification";
            // 
            // _hotkeysPanel
            // 
            _hotkeysPanel.BackColor = Color.White;
            _hotkeysPanel.BorderStyle = BorderStyle.FixedSingle;
            _hotkeysPanel.Icon = (Image)resources.GetObject("_hotkeysPanel.Icon");
            _hotkeysPanel.Location = new Point(12, 659);
            _hotkeysPanel.Name = "_hotkeysPanel";
            _hotkeysPanel.Padding = new Padding(16, 40, 10, 16);
            _hotkeysPanel.Size = new Size(400, 230);
            _hotkeysPanel.TabIndex = 11;
            _hotkeysPanel.Title = "Hotkeys";
            // 
            // _advancedPanel
            // 
            _advancedPanel.BackColor = Color.White;
            _advancedPanel.BorderStyle = BorderStyle.FixedSingle;
            _advancedPanel.Icon = (Image)resources.GetObject("_advancedPanel.Icon");
            _advancedPanel.Location = new Point(422, 659);
            _advancedPanel.Name = "_advancedPanel";
            _advancedPanel.Padding = new Padding(16, 40, 10, 16);
            _advancedPanel.Size = new Size(300, 230);
            _advancedPanel.TabIndex = 12;
            _advancedPanel.Title = "Advanced";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(734, 901);
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
            _menuStrip.ResumeLayout(false);
            _menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip _menuStrip;
        private ToolStripMenuItem _ckgMenuItem;
        private ToolStripMenuItem _exitMenuItem;
        private ToolStripMenuItem _githubMenuItem;
        private ToolStripSeparator _ckgMenuSeparator;
        private Controls.GeneralPanel _generalPanel;
        private Controls.TranslationPanel _translationPanel;
        private Controls.OverlayPanel _overlayPanel;
        private Controls.NotificationPanel _notificationPanel;
        private Controls.HotkeysPanel _hotkeysPanel;
        private Controls.AdvancedPanel _advancedPanel;
        private ToolStripMenuItem _profilesMenuItem;
    }
}
