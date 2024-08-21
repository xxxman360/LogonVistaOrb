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

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogonVistaOrbInit
{
    public partial class Configuration : Form
    {
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal;
        bool isAdmin = false;
        string color;
        bool[] settings = new bool[5];
        string[] args = Environment.GetCommandLineArgs();
        public Configuration()
        {
            if (args.Length == 1) {
                args = new string[2];
            }
            principal = new WindowsPrincipal(identity);
            isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            if (isAdmin && (args[1] == "-config" || args[1] == "-shutdown"))//Yup, this app is also used as the settings for LogonVistaOrb! 
            {
                InitializeComponent();
                if (args[1] == "-config")
                {

                    ReloadSettings();
                    Debug.Print("Current color: " + color + "\nEnabled? " + settings[0] + "\nStartup Sound? " + settings[1] + "\nLogon Sound? " + settings[2] + "\nShutdown Sound? " + settings[3] + "\nAudio service check? " + settings[4]);

                    //Set the window accordingly

                    colorText.Text = color;
                    enableCheck.Checked = settings[0];
                    startupCheck.Checked = settings[1];
                    logonCheck.Checked = settings[2];
                    shutdownCheck.Checked = settings[3];
                    audioCheck.Checked = settings[4];
                }
                else if (args[1] == "-shutdown") {
                    ReloadSettings();
                    if (settings[0]) { //App enabled
                        string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\LogonUI.exe";
                        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
                        {
                            key.SetValue("Debugger", @"C:\WINDOWS\system32\LogonVistaOrb.exe", RegistryValueKind.String);
                        }
                    }
                    if (settings[3]) { //Shutdown sound enabled
                        SoundPlayer player = new SoundPlayer(Directory.GetCurrentDirectory() + @"\Sounds\Shutdown.wav");
                        player.PlaySync();
                    }
                    Environment.Exit(0);
                }
            }
            else {
                MessageBox.Show("If you're looking for settings, check your start menu shortcuts. If you do not have a start menu shortcut, create a shortcut to this program with \"-config\" as an argument, and grant administrative privileges.", "Access Denied",MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

        }
        private void ReloadSettings() {
            //Open the registry and check for settings
            string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\LogonUI.exe\LogonVistaOrb";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
            {
                //Background color
                if (key.GetValueNames().Contains("backgroundColor"))
                {
                    color = key.GetValue("backgroundColor").ToString();
                }
                else
                {
                    color = "#FF000000";
                }
                //Is app enabled?
                if (key.GetValueNames().Contains("Enabled"))
                {
                    settings[0] = Convert.ToBoolean(Int32.Parse(key.GetValue("Enabled").ToString()));
                }
                else
                {
                    settings[0] = true;
                }
                //Play startup sound?
                if (key.GetValueNames().Contains("noStartupSound"))
                {
                    settings[1] = !Convert.ToBoolean(Int32.Parse(key.GetValue("noStartupSound").ToString()));
                }
                else
                {
                    settings[1] = true;
                }
                //Play logon sound?
                if (key.GetValueNames().Contains("noLogonSound"))
                {
                    settings[2] = !Convert.ToBoolean(Int32.Parse(key.GetValue("noLogonSound").ToString()));
                }
                else
                {
                    settings[2] = true;
                }
                //Play shutdown sound?
                if (key.GetValueNames().Contains("noShutdownSound"))
                {
                    settings[3] = !Convert.ToBoolean(Int32.Parse(key.GetValue("noShutdownSound").ToString()));
                }
                else
                {
                    settings[3] = true;
                }
                //Wait for audio services?
                if (key.GetValueNames().Contains("awaitAudioServices"))
                {
                    settings[4] = Convert.ToBoolean(Int32.Parse(key.GetValue("awaitAudioServices").ToString()));
                }
                else
                {
                    settings[4] = true;
                }
            }
            
        }
        private static String ToHex(System.Drawing.Color c) => $"#FF{c.R:X2}{c.G:X2}{c.B:X2}";

        //Main handling of settings change
        private void colorPicker_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colorText.Text = ToHex(colorDialog1.Color);
            string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\LogonUI.exe\LogonVistaOrb";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
            {
                key.SetValue("backgroundColor", colorText.Text, RegistryValueKind.String);
            }
        }

        private void enableCheck_CheckedChanged(object sender, EventArgs e)
        {
            string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\LogonUI.exe\LogonVistaOrb";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true)) {
                key.SetValue("Enabled",enableCheck.Checked,RegistryValueKind.DWord);
            }
        }

        private void startupCheck_CheckedChanged(object sender, EventArgs e)
        {
            string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\LogonUI.exe\LogonVistaOrb";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
            {
                key.SetValue("noStartupSound", !startupCheck.Checked, RegistryValueKind.DWord);
            }
        }

        private void logonCheck_CheckedChanged(object sender, EventArgs e)
        {
            string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\LogonUI.exe\LogonVistaOrb";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
            {
                key.SetValue("noLogonSound", !logonCheck.Checked, RegistryValueKind.DWord);
            }
        }

        private void shutdownCheck_CheckedChanged(object sender, EventArgs e)
        {
            string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\LogonUI.exe\LogonVistaOrb";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
            {
                key.SetValue("noShutdownSound", !shutdownCheck.Checked, RegistryValueKind.DWord);
            }
        }

        private void audioCheck_CheckedChanged(object sender, EventArgs e)
        {
            string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\LogonUI.exe\LogonVistaOrb";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
            {
                key.SetValue("awaitAudioServices", audioCheck.Checked, RegistryValueKind.DWord);
            }
        }

        private void AttemptedClose(object sender, FormClosingEventArgs e) //Prevent the app from being immediately terminated during shutdown
        {
            if (args[1] == "-shutdown") {
                e.Cancel = true;
            }
        }
    }
}
