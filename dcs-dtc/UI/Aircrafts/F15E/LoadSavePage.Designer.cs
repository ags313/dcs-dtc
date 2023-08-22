﻿
using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.F15E
{
	partial class LoadSavePage
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.optFile = new System.Windows.Forms.RadioButton();
            this.optClipboard = new System.Windows.Forms.RadioButton();
            this.grpLoad = new DTC.UI.Controls.DTCGroupBox();
            this.chkLoadMisc = new System.Windows.Forms.CheckBox();
            this.chkLoadDisplays = new System.Windows.Forms.CheckBox();
            this.btnLoadApply = new DTC.UI.Base.Controls.DTCButton();
            this.btnLoad = new DTC.UI.Base.Controls.DTCButton();
            this.chkLoadWaypoints = new System.Windows.Forms.CheckBox();
            this.grpSave = new DTC.UI.Controls.DTCGroupBox();
            this.chkSaveMisc = new System.Windows.Forms.CheckBox();
            this.chkSaveDisplays = new System.Windows.Forms.CheckBox();
            this.btnSave = new DTC.UI.Base.Controls.DTCButton();
            this.chkSaveWaypoints = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkLoadRadios = new System.Windows.Forms.CheckBox();
            this.chkSaveRadios = new System.Windows.Forms.CheckBox();
            this.grpLoad.SuspendLayout();
            this.grpSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "dtc.json";
            // 
            // saveFileDlg
            // 
            this.saveFileDlg.DefaultExt = "json";
            // 
            // optFile
            // 
            this.optFile.AutoSize = true;
            this.optFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.optFile.Location = new System.Drawing.Point(16, 18);
            this.optFile.Name = "optFile";
            this.optFile.Size = new System.Drawing.Size(48, 21);
            this.optFile.TabIndex = 7;
            this.optFile.TabStop = true;
            this.optFile.Text = "File";
            this.optFile.UseVisualStyleBackColor = true;
            this.optFile.CheckedChanged += new System.EventHandler(this.optFile_CheckedChanged);
            // 
            // optClipboard
            // 
            this.optClipboard.AutoSize = true;
            this.optClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.optClipboard.Location = new System.Drawing.Point(74, 18);
            this.optClipboard.Name = "optClipboard";
            this.optClipboard.Size = new System.Drawing.Size(86, 21);
            this.optClipboard.TabIndex = 7;
            this.optClipboard.TabStop = true;
            this.optClipboard.Text = "Clipboard";
            this.optClipboard.UseVisualStyleBackColor = true;
            this.optClipboard.CheckedChanged += new System.EventHandler(this.optClipboard_CheckedChanged);
            // 
            // grpLoad
            // 
            this.grpLoad.BorderColor = System.Drawing.Color.Black;
            this.grpLoad.BorderRadius = 5;
            this.grpLoad.BorderWidth = 2;
            this.grpLoad.Controls.Add(this.chkLoadRadios);
            this.grpLoad.Controls.Add(this.chkLoadMisc);
            this.grpLoad.Controls.Add(this.chkLoadDisplays);
            this.grpLoad.Controls.Add(this.btnLoadApply);
            this.grpLoad.Controls.Add(this.btnLoad);
            this.grpLoad.Controls.Add(this.chkLoadWaypoints);
            this.grpLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpLoad.LabelIndent = 10;
            this.grpLoad.Location = new System.Drawing.Point(16, 50);
            this.grpLoad.Name = "grpLoad";
            this.grpLoad.Size = new System.Drawing.Size(205, 318);
            this.grpLoad.TabIndex = 6;
            this.grpLoad.TabStop = false;
            this.grpLoad.Text = "Load";
            this.grpLoad.Visible = false;
            // 
            // chkLoadMisc
            // 
            this.chkLoadMisc.Enabled = false;
            this.chkLoadMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadMisc.Location = new System.Drawing.Point(18, 153);
            this.chkLoadMisc.Name = "chkLoadMisc";
            this.chkLoadMisc.Size = new System.Drawing.Size(102, 25);
            this.chkLoadMisc.TabIndex = 1;
            this.chkLoadMisc.Text = "Misc";
            this.chkLoadMisc.UseVisualStyleBackColor = true;
            // 
            // chkLoadDisplays
            // 
            this.chkLoadDisplays.Enabled = false;
            this.chkLoadDisplays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadDisplays.Location = new System.Drawing.Point(18, 91);
            this.chkLoadDisplays.Name = "chkLoadDisplays";
            this.chkLoadDisplays.Size = new System.Drawing.Size(102, 25);
            this.chkLoadDisplays.TabIndex = 1;
            this.chkLoadDisplays.Text = "Displays";
            this.chkLoadDisplays.UseVisualStyleBackColor = true;
            // 
            // btnLoadApply
            // 
            this.btnLoadApply.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnLoadApply.Enabled = false;
            this.btnLoadApply.FlatAppearance.BorderSize = 0;
            this.btnLoadApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLoadApply.Location = new System.Drawing.Point(18, 274);
            this.btnLoadApply.Name = "btnLoadApply";
            this.btnLoadApply.Size = new System.Drawing.Size(120, 25);
            this.btnLoadApply.TabIndex = 0;
            this.btnLoadApply.Text = "Apply";
            this.btnLoadApply.UseVisualStyleBackColor = false;
            this.btnLoadApply.Click += new System.EventHandler(this.btnLoadApply_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLoad.Location = new System.Drawing.Point(18, 30);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 25);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // chkLoadWaypoints
            // 
            this.chkLoadWaypoints.Enabled = false;
            this.chkLoadWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadWaypoints.Location = new System.Drawing.Point(18, 60);
            this.chkLoadWaypoints.Name = "chkLoadWaypoints";
            this.chkLoadWaypoints.Size = new System.Drawing.Size(102, 25);
            this.chkLoadWaypoints.TabIndex = 0;
            this.chkLoadWaypoints.Text = "Waypoints";
            this.chkLoadWaypoints.UseVisualStyleBackColor = true;
            // 
            // grpSave
            // 
            this.grpSave.BorderColor = System.Drawing.Color.Black;
            this.grpSave.BorderRadius = 5;
            this.grpSave.BorderWidth = 2;
            this.grpSave.Controls.Add(this.chkSaveRadios);
            this.grpSave.Controls.Add(this.chkSaveMisc);
            this.grpSave.Controls.Add(this.chkSaveDisplays);
            this.grpSave.Controls.Add(this.btnSave);
            this.grpSave.Controls.Add(this.chkSaveWaypoints);
            this.grpSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpSave.LabelIndent = 10;
            this.grpSave.Location = new System.Drawing.Point(243, 50);
            this.grpSave.Name = "grpSave";
            this.grpSave.Size = new System.Drawing.Size(203, 318);
            this.grpSave.TabIndex = 7;
            this.grpSave.TabStop = false;
            this.grpSave.Text = "Save";
            this.grpSave.Visible = false;
            // 
            // chkSaveMisc
            // 
            this.chkSaveMisc.Checked = true;
            this.chkSaveMisc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveMisc.Location = new System.Drawing.Point(18, 153);
            this.chkSaveMisc.Name = "chkSaveMisc";
            this.chkSaveMisc.Size = new System.Drawing.Size(102, 25);
            this.chkSaveMisc.TabIndex = 1;
            this.chkSaveMisc.Text = "Misc";
            this.chkSaveMisc.UseVisualStyleBackColor = true;
            // 
            // chkSaveDisplays
            // 
            this.chkSaveDisplays.Checked = true;
            this.chkSaveDisplays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveDisplays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveDisplays.Location = new System.Drawing.Point(18, 91);
            this.chkSaveDisplays.Name = "chkSaveDisplays";
            this.chkSaveDisplays.Size = new System.Drawing.Size(102, 25);
            this.chkSaveDisplays.TabIndex = 1;
            this.chkSaveDisplays.Text = "Displays";
            this.chkSaveDisplays.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(18, 274);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkSaveWaypoints
            // 
            this.chkSaveWaypoints.Checked = true;
            this.chkSaveWaypoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveWaypoints.Location = new System.Drawing.Point(18, 60);
            this.chkSaveWaypoints.Name = "chkSaveWaypoints";
            this.chkSaveWaypoints.Size = new System.Drawing.Size(102, 25);
            this.chkSaveWaypoints.TabIndex = 0;
            this.chkSaveWaypoints.Text = "Waypoints";
            this.chkSaveWaypoints.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(-15, -15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkLoadRadios
            // 
            this.chkLoadRadios.Enabled = false;
            this.chkLoadRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadRadios.Location = new System.Drawing.Point(18, 122);
            this.chkLoadRadios.Name = "chkLoadRadios";
            this.chkLoadRadios.Size = new System.Drawing.Size(102, 25);
            this.chkLoadRadios.TabIndex = 1;
            this.chkLoadRadios.Text = "Radios";
            this.chkLoadRadios.UseVisualStyleBackColor = true;
            // 
            // chkSaveRadios
            // 
            this.chkSaveRadios.Checked = true;
            this.chkSaveRadios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveRadios.Location = new System.Drawing.Point(18, 122);
            this.chkSaveRadios.Name = "chkSaveRadios";
            this.chkSaveRadios.Size = new System.Drawing.Size(102, 25);
            this.chkSaveRadios.TabIndex = 1;
            this.chkSaveRadios.Text = "Radios";
            this.chkSaveRadios.UseVisualStyleBackColor = true;
            // 
            // LoadSavePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.grpSave);
            this.Controls.Add(this.grpLoad);
            this.Controls.Add(this.optClipboard);
            this.Controls.Add(this.optFile);
            this.Name = "LoadSavePage";
            this.Size = new System.Drawing.Size(1006, 1019);
            this.grpLoad.ResumeLayout(false);
            this.grpSave.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.OpenFileDialog openFileDlg;
		private System.Windows.Forms.SaveFileDialog saveFileDlg;
		private System.Windows.Forms.RadioButton optFile;
		private System.Windows.Forms.RadioButton optClipboard;
		private Controls.DTCGroupBox grpLoad;
		private DTCButton btnLoadApply;
		private DTCButton btnLoad;
		private System.Windows.Forms.CheckBox chkLoadWaypoints;
		private Controls.DTCGroupBox grpSave;
		private DTCButton btnSave;
		private System.Windows.Forms.CheckBox chkSaveWaypoints;
		private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkLoadDisplays;
        private System.Windows.Forms.CheckBox chkSaveDisplays;
        private System.Windows.Forms.CheckBox chkLoadMisc;
        private System.Windows.Forms.CheckBox chkSaveMisc;
        private System.Windows.Forms.CheckBox chkLoadRadios;
        private System.Windows.Forms.CheckBox chkSaveRadios;
    }
}
