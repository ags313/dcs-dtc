﻿using DTC.Models.DCS;
using DTC.New.Presets.V2.Base.Systems;
using DTC.Utilities;

namespace DTC.New.UI.Base.Systems;

public class WaypointEdit<T> : WaypointEditControl where T : class, IWaypoint, new()
{
    private readonly Action refreshListCallback;
    private readonly IWaypointEditCustomPanel? customPanel;

    private readonly WaypointSystem<T> waypoints;
    private T waypoint;
    private bool adding = false;

    public WaypointEdit(Action callback, WaypointSystem<T> waypoints, T? wpt, IWaypointEditCustomPanel? customPanel, int maxWptElevation)
    {
        this.cboAirbases.Items.AddRange(Theater.GetAirbaseListItems());
        this.refreshListCallback = callback;
        this.customPanel = customPanel;
        this.waypoints = waypoints;
        this.txtElevation.MaximumValue = maxWptElevation;

        if (customPanel != null)
        {
            this.pnlCustomControls.Controls.Add(customPanel.GetControl());
        }

        this.waypoint = this.ShowDialog(wpt);
    }

    #region UI Events

    protected override void AirbasesListSelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.cboAirbases.SelectedIndex > -1)
        {
            var item = (AirbaseListItem)this.cboAirbases.SelectedItem;
            this.txtName.Text = item.Airbase;
            this.txtCoordinate.Coordinate = Coordinate.FromString(item.Latitude, item.Longitude);
            this.txtElevation.Value = item.Elevation;
        }
    }

    protected override void SaveButtonClick(object sender, EventArgs e)
    {
        if (!this.SaveWaypoint()) return;

        if (this.adding)
        {
            this.waypoints.Add(this.waypoint);
            this.ShowDialog();
        }

        this.refreshListCallback();
    }

    protected override void CancelButtonClick(object sender, EventArgs e)
    {
        this.refreshListCallback();
    }

    protected override void ElevationPasted(int elev)
    {
        this.txtElevation.Value = elev;
    }

    #endregion

    private T ShowDialog(T? wpt = null)
    {
        this.cboAirbases.SelectedIndex = -1;
        this.lblValidation.Text = "";

        if (wpt == null)
        {
            this.adding = true;
            this.waypoint = this.waypoints.NewWaypoint();
        }
        else
        {
            this.adding = false;
            this.waypoint = wpt;
        }

        this.LoadWaypoint();
        this.txtName.Focus();

        return this.waypoint;
    }

    private void LoadWaypoint()
    {
        this.txtName.Text = this.waypoint.Name;
        this.txtSequence.Value = this.waypoint.Sequence;
        this.txtCoordinate.Coordinate = Coordinate.FromString(this.waypoint.Latitude, this.waypoint.Longitude);
        this.txtElevation.Value = this.waypoint.Elevation;
        this.txtTimeOverSteerpoint.Text = this.waypoint.TimeOverSteerpoint ?? "";
        this.chkTarget.Checked = this.waypoint.Target;
        this.customPanel?.LoadWaypoint(this.waypoint);
    }

    private bool SaveWaypoint()
    {
        if (this.txtName.Text == "")
        {
            this.lblValidation.Text = "Name required";
            this.txtName.Focus();
            return false;
        }

        if (this.txtCoordinate.Coordinate == null || !this.txtCoordinate.Valid)
        {
            this.lblValidation.Text = "Invalid coordinate";
            this.txtCoordinate.Focus();
            return false;
        }

        if (this.txtElevation.Value == null)
        {
            this.lblValidation.Text = "Invalid elevation";
            this.txtElevation.Focus();
            return false;
        }

        if (this.txtSequence.Value == null)
        {
            this.lblValidation.Text = "Invalid sequence";
            this.txtSequence.Focus();
            return false;
        }

        if (this.waypoints.IsSequenceInUse((int)this.txtSequence.Value.Value, this.waypoint))
        {
            this.lblValidation.Text = "Sequence already in use";
            this.txtSequence.Focus();
            return false;
        }

        if (!txtTimeOverSteerpoint.Valid)
        {
            lblValidation.Text = "Invalid time-over-steerpoint";
            txtTimeOverSteerpoint.Focus();
            return false;
        }

        if (this.customPanel != null && !this.customPanel.Validate(out string? msg))
        {
            this.lblValidation.Text = msg;
            return false;
        }

        var c = this.txtCoordinate.Coordinate.ToDegreesMinutesThousandths();

        this.waypoint.Name = this.txtName.Text;
        this.waypoint.Latitude = c.Lat;
        this.waypoint.Longitude = c.Lon;
        this.waypoint.Elevation = (int)this.txtElevation.Value;
        this.waypoint.Sequence = (int)this.txtSequence.Value;
        this.waypoint.TimeOverSteerpoint = txtTimeOverSteerpoint.Text;
        this.waypoint.Target = this.chkTarget.Checked;

        this.customPanel?.Save(this.waypoint);
        this.waypoints.ReorderBySequence();

        return true;
    }
}