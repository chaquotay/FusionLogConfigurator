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

namespace FusLogConfig
{
    partial class ConfigDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigDialog));
            this.chkLogFailures = new System.Windows.Forms.CheckBox();
            this.chkForceLog = new System.Windows.Forms.CheckBox();
            this.chkLogResourceBinds = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseLogPath = new System.Windows.Forms.Button();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLogFailures
            // 
            this.chkLogFailures.AutoSize = true;
            this.chkLogFailures.Location = new System.Drawing.Point(18, 34);
            this.chkLogFailures.Name = "chkLogFailures";
            this.chkLogFailures.Size = new System.Drawing.Size(183, 17);
            this.chkLogFailures.TabIndex = 0;
            this.chkLogFailures.Text = "Bind failures of normal assemblies";
            this.chkLogFailures.UseVisualStyleBackColor = true;
            // 
            // chkForceLog
            // 
            this.chkForceLog.AutoSize = true;
            this.chkForceLog.Location = new System.Drawing.Point(18, 57);
            this.chkForceLog.Name = "chkForceLog";
            this.chkForceLog.Size = new System.Drawing.Size(165, 17);
            this.chkForceLog.TabIndex = 1;
            this.chkForceLog.Text = "All binds of normal assemblies";
            this.chkForceLog.UseVisualStyleBackColor = true;
            // 
            // chkLogResourceBinds
            // 
            this.chkLogResourceBinds.AutoSize = true;
            this.chkLogResourceBinds.Location = new System.Drawing.Point(18, 80);
            this.chkLogResourceBinds.Name = "chkLogResourceBinds";
            this.chkLogResourceBinds.Size = new System.Drawing.Size(256, 17);
            this.chkLogResourceBinds.TabIndex = 2;
            this.chkLogResourceBinds.Text = "Resource binds, e.g. binds of satellite assemblies";
            this.chkLogResourceBinds.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(204, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnApply.Location = new System.Drawing.Point(366, 229);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(285, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLogFailures);
            this.groupBox1.Controls.Add(this.chkLogResourceBinds);
            this.groupBox1.Controls.Add(this.chkForceLog);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 117);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enable logging";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowseLogPath);
            this.groupBox2.Controls.Add(this.txtLogPath);
            this.groupBox2.Location = new System.Drawing.Point(12, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 71);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log path";
            // 
            // btnBrowseLogPath
            // 
            this.btnBrowseLogPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowseLogPath.Location = new System.Drawing.Point(401, 27);
            this.btnBrowseLogPath.Name = "btnBrowseLogPath";
            this.btnBrowseLogPath.Size = new System.Drawing.Size(22, 23);
            this.btnBrowseLogPath.TabIndex = 8;
            this.btnBrowseLogPath.Text = "...";
            this.btnBrowseLogPath.UseVisualStyleBackColor = true;
            this.btnBrowseLogPath.Click += new System.EventHandler(this.btnBrowseLogPath_Click);
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(18, 29);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(377, 20);
            this.txtLogPath.TabIndex = 7;
            // 
            // FusionConfigDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(453, 264);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FusionConfigDialog";
            this.Text = "Fusion Log Configurator";
            this.Load += new System.EventHandler(this.FusionConfigDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkLogFailures;
        private System.Windows.Forms.CheckBox chkForceLog;
        private System.Windows.Forms.CheckBox chkLogResourceBinds;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowseLogPath;
        private System.Windows.Forms.TextBox txtLogPath;
    }
}

