using System;
using System.Drawing;
using System.Windows.Forms;

namespace CKG.Forms
{
    partial class OverlayForm
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

            this.Release();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // OverlayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(200, 50);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "OverlayForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "OverlayForm";
            TopMost = true;
            Shown += OverlayForm_Shown;
            ResumeLayout(false);
        }

        #endregion
    }
}