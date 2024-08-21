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
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogonVistaOrbInstaller
{
    public partial class Form1 : Form
    {
        bool installStatus = false;
        string tempFolder = Path.GetTempPath() + "LogonVistaOrb";
        PrivateFontCollection segoeUI = new PrivateFontCollection();
        string appVersion = "1.0.0";
        Version installedVersion = new Version();

        private void CheckOSVersion()
        {
            Version osVersion = Environment.OSVersion.Version;
            // Windows 10 is the minimum version of Windows this program ran successfully on. Thankfully, majority of people use this OS. I do apologize to the Windows 7 and 8.1 readers out there...
            if (osVersion < new Version(10,0))
            {
                MessageBox.Show("This program was determined to not work properly on Windows versions older than Windows 10.\nFortunately, if you're on Windows 7, you can install the official Windows Vista logon animation\nby using the original Vista files.\n(authui.dll, authui.dll.mui, imageres.dll, LogonUI.exe)", "Sorry! :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
        private bool updateInstallerStatus()
        {
            installStatus = false; //Status is deemed uninstalled until evidence on the system is found
            installIndicator.Text = "Status: NOT INSTALLED!";
            installIndicator.ForeColor = Color.FromArgb(192, 0, 0);

            string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\LogonUI.exe\LogonVistaOrb"; //Open our initial key
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
            {
                if (File.Exists(@"C:\Windows\System32\LogonVistaOrb.exe") && Directory.Exists(@"C:\Windows\System32\LogonVistaOrb"))
                { //First of all, are the files actually on the machine?
                    if (key != null) //Does the registry key exist?
                    {
                        if (key.GetValueNames().Contains("Installed") && key.GetValueNames().Contains("Version"))
                        { //It does! Lets check for this value
                            if (key.GetValue("Installed").ToString() == "1")
                            {
                                installStatus = true; //It's true, so that means the animation is currently installed
                                installIndicator.Text = "Status: INSTALLED!";
                                installIndicator.ForeColor = Color.FromArgb(0, 64, 0);
                                installedVersion = new Version(key.GetValue("Version").ToString());
                                return true;
                            }
                        }
                    }
                }

            }
            return false;

        }

        private void CheckArchitecture() //We need to prevent registry entries from being written to WOW6432Node
        {
            if (Environment.Is64BitProcess == false && Environment.Is64BitOperatingSystem == true) {
                MessageBox.Show("You cannot use the 32 bit version on 64 bit Windows as it will fail to access registry keys correctly.\nPlease download the 64 bit version instead.", "Invalid Architecture", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(8008135); //( ͡° ͜ʖ ͡°)
            }
        }

        public void LoadSegoeUI() {
            //Load font
            int fontLength = Properties.Resources.segoeuisl.Length;
            byte[] fontdata = Properties.Resources.segoeuisl;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            segoeUI.AddMemoryFont(data, fontLength);
            //Apply font
            installerLabel.Font = new Font(segoeUI.Families[0], 14.25F);
            installButton.Font = new Font(segoeUI.Families[0], 14.25F);
            uninstallButton.Font = new Font(segoeUI.Families[0], 14.25F);
            installIndicator.Font = new Font(segoeUI.Families[0], 14.25F);
        }

        public Form1() //Entrypoint (If you're new to C#, this is the first function the app runs)
        {
            CheckArchitecture();
            CheckOSVersion();
            InitializeComponent();
            LoadSegoeUI();
            updateInstallerStatus();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            SoundPlayer sound = new SoundPlayer(Properties.Resources.WAVE5051);
            sound.Play();
        }

        private void ShutdownSound(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
            SoundPlayer sound = new SoundPlayer(Properties.Resources.Shutdown);
            sound.Play();
            Thread.Sleep(1500);
            Environment.Exit(0);
        }


        private void installButton_Click(object didntUseThisVar, EventArgs didntUseThisVarEither)
        {
            BackgroundWorker worker = new BackgroundWorker();
            if (!installStatus)
            {
                worker.DoWork += (sender, e) => //Gotta update that progressbar!
                {
                    string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\LogonUI.exe"; //The key to install
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true);
                    if (key == null) //See if it's not in existence yet
                    {
                        //It's not, let's create it
                        Registry.LocalMachine.CreateSubKey(keyName, true);

                        //Reset the variable
                        key = Registry.LocalMachine.OpenSubKey(keyName, true);
                    }
                    Registry.LocalMachine.CreateSubKey(keyName + @"\LogonVistaOrb", true);
                    RegistryKey vistaKey = Registry.LocalMachine.OpenSubKey(keyName + @"\LogonVistaOrb", true);
                    vistaKey.SetValue("Version", appVersion, RegistryValueKind.String);
                    vistaKey.SetValue("Installed", 1, RegistryValueKind.DWord); //We have now ensured that our program knows it has installed itself


                    //Extract files from the program to the temp folder
                    if (!Directory.Exists(tempFolder))
                    { //Check if it's not there (It shouldn't be, but to prevent crashing in the event it is, we must check)
                        Directory.CreateDirectory(tempFolder);
                    }
                    File.WriteAllBytes(tempFolder + @"\temp.bin", Properties.Resources.app);
                    File.WriteAllText(tempFolder + @"\LogonVistaOrb.xml", Properties.Resources.LogonVistaOrb);
                    try
                    {
                        ZipFile.ExtractToDirectory(tempFolder + @"\temp.bin", @"C:\Windows\System32");
                    }
                    catch
                    {
                        this.Invoke((MethodInvoker)delegate //This error shouldn't appear. If it does, it's a bad sign. As in, the registry is improperly configured bad sign.
                        {
                            MessageBox.Show("Failed to extract the files to system32...\nDo the files already exist?", "I/O ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }

                    //Install the task with powershell (Allows the animation to be reloaded on system shutdown/reboot)
                    Process powerShell = new Process();
                    powerShell.StartInfo.FileName = "powershell.exe";
                    powerShell.StartInfo.WorkingDirectory = tempFolder;
                    powerShell.StartInfo.Arguments = "Register-ScheduledTask -Xml (get-content 'LogonVistaOrb.xml' | out-string) -TaskName \"LogonVistaOrb\"";
                    powerShell.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    powerShell.Start();
                    powerShell.WaitForExit();

                    Directory.Delete(tempFolder, true); //Cleanup afterwards as to not waste space on the user's PC
                    
                };
                worker.RunWorkerCompleted += (sender, e) =>
                {
                    installProgress.Style = ProgressBarStyle.Blocks;
                    installProgress.Hide();
                    if (updateInstallerStatus())
                    { //If this is true, we know that it was a total success!
                        DialogResult result = MessageBox.Show("The Windows Vista logon animation was successfully installed!\nReboot your system if you want to see it in action!\n\nWould you also like to add a start menu shortcut to configure the program later?", "Installation success!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        // Check which button was clicked
                        if (result == DialogResult.Yes)
                        {
                            File.WriteAllBytes(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\LogonVistaOrb Settings.lnk", Properties.Resources.Settings);
                        }
                        else if (result == DialogResult.No)
                        {
                            File.WriteAllBytes(@"C:\Windows\System32\LogonVistaOrb\Settings.lnk", Properties.Resources.Settings);
                            MessageBox.Show("If you ever want to configure the app in the future, you can find the config shortcut at:\nC:\\Windows\\System32\\LogonVistaOrb\\Settings.lnk", "Notice", MessageBoxButtons.OK);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("An error occured during installation. If you need to remove traces of the program manually, please check for any of the following:\nLocal files: C:\\Windows\\System32\\LogonVistaOrb.exe\n\nLocal Folders: C:\\Windows\\System32\\LogonVistaOrb\n\nRegistry: HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\LogonUI.exe\\LogonVistaOrb\n\nScheduled Tasks: LogonVistaOrb\n\nMuch apologies for the inconvenience.", "Installation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                installProgress.Style = ProgressBarStyle.Marquee;
                installProgress.Show();
                worker.RunWorkerAsync();
                


            }
            else {
                MessageBox.Show("You've already installed the animation!", "Animation already installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void uninstallButton_Click(object didntUseThisVar, EventArgs didntUseThisVarEither)
        {
            BackgroundWorker worker = new BackgroundWorker();
            if (installStatus) {
                worker.DoWork += (s, e) =>
                {
                    string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\LogonUI.exe"; //The key to remove
                    Registry.LocalMachine.DeleteSubKeyTree(keyName);

                    //Remove the local files
                    Directory.Delete(@"C:\Windows\System32\LogonVistaOrb", true);
                    File.Delete(@"C:\Windows\System32\LogonVistaOrb.exe");

                    //Remove the scheduled task
                    Process powerShell = new Process();
                    powerShell.StartInfo.FileName = "powershell.exe";
                    powerShell.StartInfo.WorkingDirectory = tempFolder;
                    powerShell.StartInfo.Arguments = "Unregister-ScheduledTask -TaskName \"LogonVistaOrb\" -Confirm:$false";
                    powerShell.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    powerShell.Start();
                    powerShell.WaitForExit();

                    //Remove the start menu shortcut if it exists
                    if (File.Exists("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\LogonVistaOrb Settings.lnk")) {
                        File.Delete("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\LogonVistaOrb Settings.lnk");
                    }
                };

                worker.RunWorkerCompleted += (s, e) =>
                {
                    installProgress.Style = ProgressBarStyle.Blocks;
                    installProgress.Hide();
                    if (!updateInstallerStatus())
                    { //Removal success
                        MessageBox.Show("The Windows Vista logon animation was successfully uninstalled!", "Uninstallation success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("An error occured trying to uninstall. If you need to remove traces of the program manually, please check for any of the following:\nLocal files: C:\\Windows\\System32\\LogonVistaOrb.exe\n\nLocal Folders: C:\\Windows\\System32\\LogonVistaOrb\n\nRegistry: HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\LogonUI.exe\n\nScheduled Tasks: LogonVistaOrb\n\nMuch apologies for the inconvenience.", "Installation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                installProgress.Style = ProgressBarStyle.Marquee;
                installProgress.Show();
                worker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("You have not installed the animation to your computer.", "Nothing to uninstall", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void installIndicator_Click(object sender, EventArgs e)
        {
            if (installStatus) {
                MessageBox.Show("You have version " + installedVersion.ToString() + " installed.","Current version info",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }
    }
}
