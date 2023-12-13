﻿using DTC.Utilities;
using DTC.Models.F16.Waypoints;
using DTC.UI.Base;
using DTC.UI.CommonPages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DTC.Models.v476;

namespace DTC.UI.Aircrafts.F16
{
    public partial class WaypointsPage : AircraftSettingPage
    {
        private WaypointSystem _waypoints;
        private WaypointEdit _wptEditDialog;

        public WaypointsPage(AircraftPage parent, WaypointSystem wpts) : base(parent)
        {
            InitializeComponent();

            _waypoints = wpts;
            _wptEditDialog = new WaypointEdit(_waypoints, this.WptDialogEditCallback);
            _wptEditDialog.Visible = false;
            dgWaypoints.ReorderCallback = Reorder;
            this.Controls.Add(this._wptEditDialog);

            RefreshList();
        }

        private void Reorder(int indexFrom, int indexTo)
        {
            _waypoints.Reorder(indexFrom, indexTo);
            RefreshList();
        }

        public override string GetPageTitle()
        {
            return "Waypoints";
        }

        private void WptDialogEditCallback()
        {
            _parent.DataChangedCallback();
            this.RefreshList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowWptDialog();
        }

        private void ShowWptDialog(Waypoint wpt = null)
        {
            this._wptEditDialog.Location = new Point(0, 0);
            this._wptEditDialog.Size = this.Size;
            _wptEditDialog.ShowDialog(wpt);
            this.RefreshList();
        }

        public void RefreshList()
        {
            dgWaypoints.RefreshList(_waypoints.Waypoints);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!DTCMessageBox.ShowQuestion("Are you sure you want to delete this waypoint?"))
            {
                return;
            }

            var wptsToDelete = new List<Waypoint>();

            foreach (DataGridViewRow row in dgWaypoints.SelectedRows)
            {
                var wpt = (Waypoint)row.DataBoundItem;
                wptsToDelete.Add(wpt);
            }

            foreach (var wpt in wptsToDelete)
            {
                _waypoints.Remove(wpt);
            }

            _parent.DataChangedCallback();
            RefreshList();
            dgWaypoints.Focus();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            var cap = new WaypointCaptureCrosshair();
            cap.Show();
        }

        private void dgWaypoints_SelectionChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = dgWaypoints.Enabled && dgWaypoints.SelectedRows.Count > 0;
        }

        private void dgWaypoints_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine("error");
        }

        private void dgWaypoints_DoubleClick(object sender, EventArgs e)
        {
            if (dgWaypoints.SelectedRows.Count > 0)
            {
                ShowWptDialog((Waypoint)dgWaypoints.SelectedRows[0].DataBoundItem);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            this._waypoints.Waypoints.Clear();
            this.RefreshList();
        }

        private void btnImport476_Click(object sender, EventArgs e)
        {
            var clipboardContent = Clipboard.GetText();
            WaypointSystemParser parser = new WaypointSystemParser();
            foreach (Waypoint waypoint in parser.parseForF16(clipboardContent))
            {
                this._waypoints.Add(waypoint);
            }
            this.RefreshList();
            this._parent.DataChangedCallback();
        }
    }
}
