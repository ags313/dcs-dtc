﻿
using DTC.UI.Base;

namespace DTC.UI.Aircrafts.F15E
{
	partial class WaypointsPage
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            panel1 = new Panel();
            clearBtn = new Base.Controls.DTCButton();
            importClipBtn = new Base.Controls.DTCButton();
            btnDelete = new Base.Controls.DTCButton();
            btnAdd = new Base.Controls.DTCButton();
            dgWaypoints = new Base.Controls.DTCDataGrid();
            colSequence = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colLatitude = new DataGridViewTextBoxColumn();
            colLongitude = new DataGridViewTextBoxColumn();
            colElevation = new DataGridViewTextBoxColumn();
            colExtra = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgWaypoints).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(clearBtn);
            panel1.Controls.Add(importClipBtn);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnAdd);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(689, 35);
            panel1.TabIndex = 99;
            // 
            // clearBtn
            // 
            clearBtn.BackColor = Color.DarkKhaki;
            clearBtn.FlatAppearance.BorderSize = 0;
            clearBtn.FlatStyle = FlatStyle.Flat;
            clearBtn.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            clearBtn.Location = new Point(438, 5);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(77, 25);
            clearBtn.TabIndex = 5;
            clearBtn.Text = "Clear";
            clearBtn.UseVisualStyleBackColor = false;
            clearBtn.Click += clearBtn_Click;
            // 
            // importClipBtn
            // 
            importClipBtn.BackColor = Color.DarkKhaki;
            importClipBtn.FlatAppearance.BorderSize = 0;
            importClipBtn.FlatStyle = FlatStyle.Flat;
            importClipBtn.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            importClipBtn.Location = new Point(312, 5);
            importClipBtn.Name = "importClipBtn";
            importClipBtn.Size = new Size(120, 25);
            importClipBtn.TabIndex = 4;
            importClipBtn.Text = "Import v476th";
            importClipBtn.UseVisualStyleBackColor = false;
            importClipBtn.Click += importClipBtn_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DarkKhaki;
            btnDelete.Enabled = false;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Location = new Point(131, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 25);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DarkKhaki;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(5, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 25);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgWaypoints
            // 
            dgWaypoints.AllowDrop = true;
            dgWaypoints.AllowUserToAddRows = false;
            dgWaypoints.AllowUserToDeleteRows = false;
            dgWaypoints.AllowUserToResizeColumns = false;
            dgWaypoints.AllowUserToResizeRows = false;
            dgWaypoints.BackgroundColor = Color.Beige;
            dgWaypoints.BorderStyle = BorderStyle.None;
            dgWaypoints.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgWaypoints.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.DarkKhaki;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.DarkKhaki;
            dataGridViewCellStyle7.SelectionForeColor = Color.Black;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgWaypoints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgWaypoints.ColumnHeadersHeight = 30;
            dgWaypoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgWaypoints.Columns.AddRange(new DataGridViewColumn[] { colSequence, colName, colLatitude, colLongitude, colElevation, colExtra });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.Beige;
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgWaypoints.DefaultCellStyle = dataGridViewCellStyle9;
            dgWaypoints.Dock = DockStyle.Fill;
            dgWaypoints.EnableHeadersVisualStyles = false;
            dgWaypoints.Location = new Point(0, 35);
            dgWaypoints.Name = "dgWaypoints";
            dgWaypoints.ReadOnly = true;
            dgWaypoints.RowHeadersVisible = false;
            dgWaypoints.ScrollBars = ScrollBars.Vertical;
            dgWaypoints.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgWaypoints.ShowCellToolTips = false;
            dgWaypoints.Size = new Size(689, 448);
            dgWaypoints.TabIndex = 100;
            dgWaypoints.DataError += dgWaypoints_DataError;
            dgWaypoints.SelectionChanged += dgWaypoints_SelectionChanged;
            dgWaypoints.DoubleClick += dgWaypoints_DoubleClick;
            // 
            // colSequence
            // 
            colSequence.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colSequence.DataPropertyName = "Sequence";
            colSequence.HeaderText = "Seq";
            colSequence.Name = "colSequence";
            colSequence.ReadOnly = true;
            colSequence.Width = 58;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Name";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colLatitude
            // 
            colLatitude.DataPropertyName = "Latitude";
            colLatitude.HeaderText = "Latitude";
            colLatitude.Name = "colLatitude";
            colLatitude.ReadOnly = true;
            // 
            // colLongitude
            // 
            colLongitude.DataPropertyName = "Longitude";
            colLongitude.HeaderText = "Longitude";
            colLongitude.Name = "colLongitude";
            colLongitude.ReadOnly = true;
            // 
            // colElevation
            // 
            colElevation.DataPropertyName = "Elevation";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            colElevation.DefaultCellStyle = dataGridViewCellStyle8;
            colElevation.HeaderText = "Elevation";
            colElevation.Name = "colElevation";
            colElevation.ReadOnly = true;
            colElevation.Width = 75;
            // 
            // colExtra
            // 
            colExtra.DataPropertyName = "ExtraDescription";
            colExtra.HeaderText = "";
            colExtra.Name = "colExtra";
            colExtra.ReadOnly = true;
            // 
            // WaypointsPage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(dgWaypoints);
            Controls.Add(panel1);
            Name = "WaypointsPage";
            Size = new Size(689, 483);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgWaypoints).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
		private Base.Controls.DTCButton btnDelete;
		private Base.Controls.DTCButton btnAdd;
		private Base.Controls.DTCDataGrid dgWaypoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLatitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLongitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElevation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExtra;
        private Base.Controls.DTCButton clearBtn;
        private Base.Controls.DTCButton importClipBtn;
    }
}