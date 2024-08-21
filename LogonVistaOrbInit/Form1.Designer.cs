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

namespace LogonVistaOrbInit
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.logonCheck = new System.Windows.Forms.CheckBox();
            this.startupCheck = new System.Windows.Forms.CheckBox();
            this.enableCheck = new System.Windows.Forms.CheckBox();
            this.audioCheck = new System.Windows.Forms.CheckBox();
            this.bkgClrLabel = new System.Windows.Forms.Label();
            this.colorText = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorPicker = new System.Windows.Forms.Button();
            this.shutdownCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // logonCheck
            // 
            this.logonCheck.AutoSize = true;
            this.logonCheck.Checked = true;
            this.logonCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logonCheck.Location = new System.Drawing.Point(12, 58);
            this.logonCheck.Name = "logonCheck";
            this.logonCheck.Size = new System.Drawing.Size(107, 17);
            this.logonCheck.TabIndex = 0;
            this.logonCheck.Text = "Play logon sound";
            this.logonCheck.UseVisualStyleBackColor = true;
            this.logonCheck.CheckedChanged += new System.EventHandler(this.logonCheck_CheckedChanged);
            // 
            // startupCheck
            // 
            this.startupCheck.AutoSize = true;
            this.startupCheck.Checked = true;
            this.startupCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startupCheck.Location = new System.Drawing.Point(12, 35);
            this.startupCheck.Name = "startupCheck";
            this.startupCheck.Size = new System.Drawing.Size(113, 17);
            this.startupCheck.TabIndex = 1;
            this.startupCheck.Text = "Play startup sound";
            this.startupCheck.UseVisualStyleBackColor = true;
            this.startupCheck.CheckedChanged += new System.EventHandler(this.startupCheck_CheckedChanged);
            // 
            // enableCheck
            // 
            this.enableCheck.AutoSize = true;
            this.enableCheck.Checked = true;
            this.enableCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableCheck.Location = new System.Drawing.Point(12, 12);
            this.enableCheck.Name = "enableCheck";
            this.enableCheck.Size = new System.Drawing.Size(132, 17);
            this.enableCheck.TabIndex = 2;
            this.enableCheck.Text = "Enable LogonVistaOrb";
            this.enableCheck.UseVisualStyleBackColor = true;
            this.enableCheck.CheckedChanged += new System.EventHandler(this.enableCheck_CheckedChanged);
            // 
            // audioCheck
            // 
            this.audioCheck.AutoSize = true;
            this.audioCheck.Checked = true;
            this.audioCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.audioCheck.Location = new System.Drawing.Point(12, 98);
            this.audioCheck.Name = "audioCheck";
            this.audioCheck.Size = new System.Drawing.Size(256, 30);
            this.audioCheck.TabIndex = 3;
            this.audioCheck.Text = "Wait for audio services before running animation \n(Recommended for slower compute" +
    "rs)";
            this.audioCheck.UseVisualStyleBackColor = true;
            this.audioCheck.CheckedChanged += new System.EventHandler(this.audioCheck_CheckedChanged);
            // 
            // bkgClrLabel
            // 
            this.bkgClrLabel.AutoSize = true;
            this.bkgClrLabel.Location = new System.Drawing.Point(13, 137);
            this.bkgClrLabel.Name = "bkgClrLabel";
            this.bkgClrLabel.Size = new System.Drawing.Size(95, 13);
            this.bkgClrLabel.TabIndex = 4;
            this.bkgClrLabel.Text = "Background Color:";
            // 
            // colorText
            // 
            this.colorText.Location = new System.Drawing.Point(114, 134);
            this.colorText.Name = "colorText";
            this.colorText.Size = new System.Drawing.Size(100, 20);
            this.colorText.TabIndex = 5;
            this.colorText.Text = "#FF000000";
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            this.colorDialog1.SolidColorOnly = true;
            // 
            // colorPicker
            // 
            this.colorPicker.Location = new System.Drawing.Point(220, 123);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(75, 40);
            this.colorPicker.TabIndex = 6;
            this.colorPicker.Text = "Choose Color";
            this.colorPicker.UseVisualStyleBackColor = true;
            this.colorPicker.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // shutdownCheck
            // 
            this.shutdownCheck.AutoSize = true;
            this.shutdownCheck.Checked = true;
            this.shutdownCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shutdownCheck.Location = new System.Drawing.Point(12, 81);
            this.shutdownCheck.Name = "shutdownCheck";
            this.shutdownCheck.Size = new System.Drawing.Size(127, 17);
            this.shutdownCheck.TabIndex = 7;
            this.shutdownCheck.Text = "Play shutdown sound";
            this.shutdownCheck.UseVisualStyleBackColor = true;
            this.shutdownCheck.CheckedChanged += new System.EventHandler(this.shutdownCheck_CheckedChanged);
            // 
            // Configuration
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(300, 167);
            this.Controls.Add(this.shutdownCheck);
            this.Controls.Add(this.colorPicker);
            this.Controls.Add(this.colorText);
            this.Controls.Add(this.bkgClrLabel);
            this.Controls.Add(this.audioCheck);
            this.Controls.Add(this.enableCheck);
            this.Controls.Add(this.startupCheck);
            this.Controls.Add(this.logonCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AttemptedClose);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox logonCheck;
        private System.Windows.Forms.CheckBox startupCheck;
        private System.Windows.Forms.CheckBox enableCheck;
        private System.Windows.Forms.CheckBox audioCheck;
        private System.Windows.Forms.Label bkgClrLabel;
        private System.Windows.Forms.TextBox colorText;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button colorPicker;
        private System.Windows.Forms.CheckBox shutdownCheck;
    }
}

