﻿using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities.Extensions;

namespace DTC.New.Uploader.Aircrafts.F16;

public partial class F16Uploader
{
    public void BuildWaypoints()
    {
        if (!config.Upload.Waypoints || config.Waypoints == null || config.Waypoints.Waypoints == null || config.Waypoints.Waypoints.Count == 0) return;

        BuildWaypoints(config.Waypoints.Waypoints);
        BuildVIP(config.Waypoints.Waypoints);
        BuildVRP(config.Waypoints.Waypoints);
    }

    private void BuildWaypoints(List<Waypoint> wpts)
    {
        Cmd(UFC.RTN);
        Cmd(UFC.RTN);
        Cmd(UFC.LIST);
        Cmd(UFC.D1);
        Cmd(UFC.SEQ);

        foreach (var wpt in wpts)
        {
            if (string.IsNullOrEmpty(wpt.Longitude)) //This is needed to skip empty lines in MDC
                continue;
            Cmd(Digits(UFC, wpt.Sequence.ToString()));
            Cmd(UFC.ENTR);
            Cmd(UFC.DOWN);

            Coord(wpt.Latitude);
            Cmd(UFC.ENTR);
            Cmd(UFC.DOWN);

            Coord(wpt.Longitude);
            Cmd(UFC.ENTR);
            Cmd(UFC.DOWN);

            Cmd(Digits(UFC, wpt.Elevation.ToString()));
            Cmd(UFC.ENTR);
            Cmd(UFC.DOWN);

            if (wpt.TimeOverSteerpoint != null)
            {
                Time(wpt.TimeOverSteerpoint);
                Cmd(UFC.ENTR);
            }
            Cmd(UFC.DOWN);

            if (wpt.UseOA)
            {
                BuildOA(wpt, wpt.OffsetAimpoint1);
                BuildOA(wpt, wpt.OffsetAimpoint2);
                Cmd(UFC.SEQ);
                Cmd(UFC.SEQ);
            }
        }

        Cmd(UFC.D1);
        Cmd(UFC.ENTR);
        Cmd(UFC.RTN);
    }

    private void BuildOA(Waypoint wpt, Offset offset)
    {
        Cmd(UFC.SEQ);
        Cmd(Digits(UFC, wpt.Sequence.ToString()));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);

        Cmd(Digits(UFC, IntegerString(offset.Range)));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);

        Cmd(Digits(UFC, DecimalString(offset.Bearing)));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);

        if (offset.Elevation < 0)
        {
            Cmd(UFC.D0);
            Cmd(UFC.D0);
        }

        Cmd(Digits(UFC, IntegerString(Math.Abs(offset.Elevation))));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);
    }

    private void BuildVIP(List<Waypoint> wpts)
    {
        Waypoint? wpt = null;
        foreach (var w in wpts)
        {
            if (w.UseVIP)
            {
                wpt = w;
            }
        }

        if (wpt == null) return;

        Cmd(UFC.RTN);
        Cmd(UFC.RTN);
        Cmd(UFC.LIST);
        Cmd(UFC.D3);
        Cmd(Wait());

        If(IsVIPtoTGTNotSelected(), UFC.SEQ);
        If(IsVIPtoTGTNotHighlighted(), UFC.D0);

        BuildVIPDetail(wpt, wpt.VIPtoTGT);
        Cmd(UFC.SEQ);

        If(IsVIPtoPUPNotHighlighted(), UFC.D0);

        BuildVIPDetail(wpt, wpt.VIPtoPUP);
        Cmd(UFC.SEQ);
        Cmd(UFC.RTN);
    }

    private void BuildVIPDetail(Waypoint wpt, Offset offset)
    {
        Cmd(UFC.DOWN);
        Cmd(Digits(UFC, wpt.Sequence.ToString()));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);

        Cmd(Digits(UFC, DecimalString(offset.Bearing)));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);

        Cmd(Digits(UFC, DecimalString(offset.Range)));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);

        if (offset.Elevation < 0)
        {
            Cmd(UFC.D0);
            Cmd(UFC.D0);
        }

        Cmd(Digits(UFC, IntegerString(Math.Abs(offset.Elevation))));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);
    }

    private void BuildVRP(List<Waypoint> wpts)
    {
        Waypoint? wpt = null;
        foreach (var w in wpts)
        {
            if (w.UseVRP)
            {
                wpt = w;
            }
        }

        if (wpt == null) return;

        Cmd(UFC.RTN);
        Cmd(UFC.RTN);
        Cmd(UFC.LIST);
        Cmd(UFC.D9);
        Cmd(Wait());

        If(IsTGTtoVRPNotSelected(), UFC.SEQ);
        If(IsTGTtoVRPNotHighlighted(), UFC.D0);

        BuildVRPDetail(wpt, wpt.TGTtoVRP);
        Cmd(UFC.SEQ);

        If(IsTGTtoPUPNotHighlighted(), UFC.D0);

        BuildVRPDetail(wpt, wpt.TGTtoPUP);
        Cmd(UFC.SEQ);
        Cmd(UFC.RTN);
    }

    private void BuildVRPDetail(Waypoint wpt, Offset offset)
    {
        Cmd(UFC.DOWN);
        Cmd(Digits(UFC, wpt.Sequence.ToString()));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);

        Cmd(Digits(UFC, DecimalString(offset.Bearing)));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);

        Cmd(Digits(UFC, IntegerString(offset.Range)));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);

        if (offset.Elevation < 0)
        {
            Cmd(UFC.D0);
            Cmd(UFC.D0);
        }

        Cmd(Digits(UFC, IntegerString(Math.Abs(offset.Elevation))));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);
    }

    private void Coord(string coord)
    {
        int pos = coord.IndexOf("°");
        var (direction, (numbers, _)) = coord.Replace("°", "").Replace("’", "").Split(' ');
        numbers = numbers.Replace(".", "");

        if (direction == "N")
        {
            Cmd(UFC.D2);
        }
        else if (direction == "S")
        {
            Cmd(UFC.D8);
        }
        else if (direction == "E")
        {
            if (pos == 4)
                numbers = "0" + numbers;
            Cmd(UFC.D6);
        }
        else if (direction == "W")
        {
            if (pos == 4)
                numbers = "0" + numbers;
            Cmd(UFC.D4);
        }

        Cmd(Digits(UFC, numbers));
    }

    private void Time(string time)
    {
        time = time.Replace(":", "");
        Cmd(Digits(UFC, time));
    }

    private Condition IsVIPtoTGTNotSelected()
    {
        return new Condition("VIP_TO_TGT_NotSelected()");
    }

    private Condition IsVIPtoTGTNotHighlighted()
    {
        return new Condition("VIP_TO_TGT_NotHighlighted()");
    }

    private Condition IsVIPtoPUPNotHighlighted()
    {
        return new Condition("VIP_TO_PUP_NotHighlighted()");
    }

    private Condition IsTGTtoVRPNotSelected()
    {
        return new Condition("TGT_TO_VRP_NotSelected()");
    }

    private Condition IsTGTtoVRPNotHighlighted()
    {
        return new Condition("TGT_TO_VRP_NotHighlighted()");
    }

    private Condition IsTGTtoPUPNotHighlighted()
    {
        return new Condition("TGT_TO_PUP_NotHighlighted()");
    }
}
