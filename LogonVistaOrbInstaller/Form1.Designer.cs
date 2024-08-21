/*
 * Copyright (C) 2024 Marshall Lalonde (AKA xxxman360)
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace LogonVistaOrbInstaller
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.installerLabel = new System.Windows.Forms.Label();
            this.installButton = new System.Windows.Forms.Button();
            this.uninstallButton = new System.Windows.Forms.Button();
            this.installProgress = new System.Windows.Forms.ProgressBar();
            this.installIndicator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::LogonVistaOrbInstaller.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(625, 85);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // installerLabel
            // 
            this.installerLabel.BackColor = System.Drawing.Color.Transparent;
            this.installerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installerLabel.ForeColor = System.Drawing.Color.Black;
            this.installerLabel.Location = new System.Drawing.Point(12, 88);
            this.installerLabel.Name = "installerLabel";
            this.installerLabel.Size = new System.Drawing.Size(600, 58);
            this.installerLabel.TabIndex = 1;
            this.installerLabel.Text = "Click the \"Install Animation\" button to add the startup orb to your login screen." +
    " Click \"Uninstall Animation\" to remove it from your computer.";
            // 
            // installButton
            // 
            this.installButton.BackColor = System.Drawing.Color.Transparent;
            this.installButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.installButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installButton.ForeColor = System.Drawing.Color.Black;
            this.installButton.Location = new System.Drawing.Point(80, 149);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(180, 50);
            this.installButton.TabIndex = 2;
            this.installButton.Text = "Install Animation";
            this.installButton.UseVisualStyleBackColor = false;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // uninstallButton
            // 
            this.uninstallButton.BackColor = System.Drawing.Color.Transparent;
            this.uninstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uninstallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uninstallButton.ForeColor = System.Drawing.Color.Black;
            this.uninstallButton.Location = new System.Drawing.Point(360, 149);
            this.uninstallButton.Name = "uninstallButton";
            this.uninstallButton.Size = new System.Drawing.Size(180, 50);
            this.uninstallButton.TabIndex = 3;
            this.uninstallButton.Text = "Uninstall Animation";
            this.uninstallButton.UseVisualStyleBackColor = false;
            this.uninstallButton.Click += new System.EventHandler(this.uninstallButton_Click);
            // 
            // installProgress
            // 
            this.installProgress.Location = new System.Drawing.Point(80, 203);
            this.installProgress.MarqueeAnimationSpeed = 10;
            this.installProgress.Name = "installProgress";
            this.installProgress.Size = new System.Drawing.Size(460, 30);
            this.installProgress.Step = 1;
            this.installProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.installProgress.TabIndex = 4;
            this.installProgress.Visible = false;
            // 
            // installIndicator
            // 
            this.installIndicator.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.installIndicator.BackColor = System.Drawing.Color.Transparent;
            this.installIndicator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.installIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installIndicator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.installIndicator.Location = new System.Drawing.Point(80, 236);
            this.installIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.installIndicator.Name = "installIndicator";
            this.installIndicator.Size = new System.Drawing.Size(460, 24);
            this.installIndicator.TabIndex = 5;
            this.installIndicator.Text = "Status: <<Insert Status About Installation Here>>";
            this.installIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.installIndicator.Click += new System.EventHandler(this.installIndicator_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.BackgroundImage = global::LogonVistaOrbInstaller.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(624, 261);
            this.Controls.Add(this.installIndicator);
            this.Controls.Add(this.installProgress);
            this.Controls.Add(this.uninstallButton);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.installerLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Vista Animation Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShutdownSound);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label installerLabel;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button uninstallButton;
        private System.Windows.Forms.ProgressBar installProgress;
        private System.Windows.Forms.Label installIndicator;
    }
}

