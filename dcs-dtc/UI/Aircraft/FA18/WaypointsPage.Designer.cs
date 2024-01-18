
using DTC.UI.Base;

namespace DTC.UI.Aircrafts.FA18
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnClear = new Base.Controls.DTCButton();
            btnImport476 = new Base.Controls.DTCButton();
            btnDelete = new Base.Controls.DTCButton();
            btnAdd = new Base.Controls.DTCButton();
            dgWaypoints = new Base.Controls.DTCDataGrid();
            colSequence = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colLatitude = new DataGridViewTextBoxColumn();
            colLongitude = new DataGridViewTextBoxColumn();
            colElevation = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgWaypoints).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnImport476);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnAdd);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(689, 35);
            panel1.TabIndex = 99;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.DarkKhaki;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.Location = new Point(410, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(129, 28);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click_1;
            // 
            // btnImport476
            // 
            btnImport476.BackColor = Color.DarkKhaki;
            btnImport476.FlatAppearance.BorderSize = 0;
            btnImport476.FlatStyle = FlatStyle.Flat;
            btnImport476.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnImport476.Location = new Point(284, 5);
            btnImport476.Name = "btnImport476";
            btnImport476.Size = new Size(120, 25);
            btnImport476.TabIndex = 4;
            btnImport476.Text = "Import v476th";
            btnImport476.UseVisualStyleBackColor = false;
            btnImport476.Click += btnImport476_Click;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DarkKhaki;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.DarkKhaki;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgWaypoints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgWaypoints.ColumnHeadersHeight = 30;
            dgWaypoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgWaypoints.Columns.AddRange(new DataGridViewColumn[] { colSequence, colName, colLatitude, colLongitude, colElevation });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Beige;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgWaypoints.DefaultCellStyle = dataGridViewCellStyle4;
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
            colLatitude.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colLatitude.DataPropertyName = "Latitude";
            colLatitude.HeaderText = "Latitude";
            colLatitude.MinimumWidth = 120;
            colLatitude.Name = "colLatitude";
            colLatitude.ReadOnly = true;
            colLatitude.Width = 120;
            // 
            // colLongitude
            // 
            colLongitude.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colLongitude.DataPropertyName = "Longitude";
            colLongitude.HeaderText = "Longitude";
            colLongitude.MinimumWidth = 120;
            colLongitude.Name = "colLongitude";
            colLongitude.ReadOnly = true;
            colLongitude.Width = 120;
            // 
            // colElevation
            // 
            colElevation.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colElevation.DataPropertyName = "Elevation";
            colElevation.HeaderText = "Elevation";
            colElevation.Name = "colElevation";
            colElevation.ReadOnly = true;
            colElevation.Width = 91;
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
        private Base.Controls.DTCButton btnImport476;
        private Base.Controls.DTCButton btnClear;
    }
}
