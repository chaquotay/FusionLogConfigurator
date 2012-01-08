/* FusionLogConfigurator - a .NET Fusion log configuration utility
 * Copyright (C) 2012  Stephan Müller
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FusLogConfig
{
    public partial class ConfigDialog : Form
    {
        private FusionLogConfiguration _configuration;

        public ConfigDialog()
        {
            InitializeComponent();
        }

        private void btnBrowseLogPath_Click(object sender, EventArgs e)
        {
            using(var dlg = new FolderBrowserDialog())
            {
                var oldPath = txtLogPath.Text;
                if(!string.IsNullOrEmpty(oldPath) && Directory.Exists(oldPath))
                {
                    dlg.SelectedPath = oldPath;
                }
                dlg.Description = "Select Fusion log path:";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var selectedPath = dlg.SelectedPath;
                    txtLogPath.Text = selectedPath;
                }
            }
        }

        private void FusionConfigDialog_Load(object sender, EventArgs e)
        {
            _configuration = FusionRegistry.ReadLogConfiguration();
            chkForceLog.Checked = _configuration.ForceLog;
            chkLogFailures.Checked = _configuration.LogFailures;
            chkLogResourceBinds.Checked = _configuration.LogResourceBinds;
            txtLogPath.Text = _configuration.LogPath ?? "";

            if (AdminProcessStarter.ElevationRequired)
            {
                AddShieldToButton(btnApply);
                AddShieldToButton(btnOK);
            }

            chkForceLog.CheckStateChanged += delegate
                                                 {
                                                     _configuration.ForceLog = chkForceLog.Checked;
                                                     btnApply.Enabled = true;
                                                 };
            chkLogFailures.CheckStateChanged += delegate
                                                    {
                                                        _configuration.LogFailures = chkLogFailures.Checked;
                                                        btnApply.Enabled = true;
                                                    };
            chkLogResourceBinds.CheckStateChanged += delegate
                                                         {
                                                             _configuration.LogResourceBinds =
                                                                 chkLogResourceBinds.Checked;
                                                             btnApply.Enabled = true;
                                                         };
            txtLogPath.TextChanged += delegate
                                          {
                                              _configuration.LogPath = txtLogPath.Text;
                                              btnApply.Enabled = true;
                                          };
        }

        private bool Apply()
        {
            var args = CommandLine.Format(_configuration);
            return AdminProcessStarter.StartSelf(args);
        }

        private void Exit()
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Apply();
            Exit();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(Apply())
                btnApply.Enabled = false;
        }


        // http://www.codeproject.com/KB/vista-security/UAC_Shield_for_Elevation.aspx
        [DllImport("user32")]
        public static extern UInt32 SendMessage (IntPtr hWnd, UInt32 msg, UInt32 wParam, UInt32 lParam);

        private const int BCM_FIRST = 0x1600; //Normal button

        private const int BCM_SETSHIELD = (BCM_FIRST + 0x000C); //Elevated button

        static internal void AddShieldToButton(Button b)
        {
            SendMessage(b.Handle, BCM_SETSHIELD, 0, 0xFFFFFFFF);
        }
    }
}
