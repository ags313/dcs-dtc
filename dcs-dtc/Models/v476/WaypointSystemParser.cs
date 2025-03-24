using System.Text.RegularExpressions;
using DTC.New.Presets.V2.Aircrafts.F15E.Systems;

namespace DTC.Models.v476
{
    public class WaypointSystemParser
    {
        Dictionary<int, Column> columns = new Dictionary<int, Column>();
        private ParserState parserState = ParserState.Parsing476thData;
        //public string PilotCallsign { get; set; }
        private string pilotCallsign = "";
        private string flightCallsign = "";
        private string pilotTN = "";
        private short pilotPosition = -1; //default - pilot not recognized
        private string[]flightTNs = new string[4];
        
        public string PilotCallsign { get => pilotCallsign;  }
        public string PilotTN { get => pilotTN;  }
        public short PilotPosition { get => pilotPosition;  }
        public string[] FlightTNs { get => flightTNs;  }
        public string FlightCallsign { get => flightCallsign; }

        private List<ReturnType> parse<ReturnType>(
            String contentToParse,
            Func<WaypointBuilder, ReturnType> singleParse)
        {
            List<ReturnType> result = new List<ReturnType>();

            using (StringReader reader = new StringReader(contentToParse))
            {
                try
                { 
                    var line = "";
                    var idx = 0;

                    //TODO: This needs to be stateful and finish parsing after detection of last waypoint. Free text notes can be in format resembling waypoints and thus can cause problems.
                    while ((line = reader.ReadLine()) != null)
                    {
                        idx++;
                        var lineType = detect(line);
                        if (lineType == RecordType.FlightPlanHeader)
                        {
                            columns = parseHeaders(line);
                            parserState = ParserState.ParsingFlightPlan;
                        }
                        if(lineType == RecordType.Radios)
                        {
                            parserState = ParserState.Parsing476thData;//TODO: this needs to change should we ever want to parse radio info
                        }
                        if ((lineType == RecordType.Waypoint || lineType == RecordType.EmptyRow) && parserState == ParserState.ParsingFlightPlan)
                        {
                            var waypoint = parseWaypoint(line);
                            result.Add(singleParse(waypoint));
                            //TODO: Most likely we should not be parsing empty waypoints; just ommit it in the sequence when entering?
                        }
                        if(lineType == RecordType.UserCallsignLine)
                        {
                            string[] spliced = line.Split("*");
                            this.pilotCallsign = spliced[1];
                            //next line is flight callsign, 
                            line = reader.ReadLine();
                            int lineEnd = line.IndexOf("Mission");
                            if(lineEnd == -1) lineEnd = line.Length;
                            this.flightCallsign = line.Substring(10, lineEnd - 10);
                        }
                        if (lineType == RecordType.FlightInfo)
                        {
                            parserState = ParserState.ParsingFlightInfo;
                        }
                        if (lineType == RecordType.Comment)
                        {
                            //if Comment prior to flight info, continue. If comment after parsing waypoints, terminate
                            if (parserState == ParserState.Parsing476thData)
                                continue;
                            if(parserState == ParserState.ParsingFlightInfo)
                            {
                                string[] finfo = line.Split("\t");
                                short wingNumber = 0;
                                if (line.StartsWith("Pilot") || finfo.Length <2)
                                    continue;
                                wingNumber = short.Parse(finfo[0].Substring(1));
                                if (finfo[1].ToLower().Equals(this.pilotCallsign.ToLower()))
                                    this.pilotPosition = wingNumber;
                                this.flightTNs[wingNumber-1] = finfo[3];
                            }
                            else if (parserState == ParserState.ParsingFlightPlan)
                            {
                                this.parserState = ParserState.FinishedParsing;
                                break;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    //Oops, something went wrong. Let's set the proper parser state
                    this.parserState = ParserState.BadFormatUnableToParse;
                    throw;
                }
            }

            return result;
        }

        public List<Waypoint> parseForF15(String contentToParse)
        {
            return parse<Waypoint>(contentToParse,
                (builder) => builder.buildForF15E()); ;
        }

        public List<New.Presets.V2.Aircrafts.FA18.Systems.Waypoint> parseForFA18(String contentToParse)
        {
            return parse<New.Presets.V2.Aircrafts.FA18.Systems.Waypoint>(contentToParse,
                (builder) => builder.buildForFA18()); ;
        }

        public List<New.Presets.V2.Aircrafts.F16.Systems.Waypoint> parseForF16(String contentToParse)
        {
            return parse<New.Presets.V2.Aircrafts.F16.Systems.Waypoint>(contentToParse,
                (builder) => builder.buildForF16());
        }

        WaypointBuilder parseWaypoint(String input)
        {
            var strings = input.Trim().Split("\t");
            var builder = new WaypointBuilder();
            for (int i = 0; i < strings.Length; i++)
            {
                var value = strings[i].Trim();
                var column = columns[i];
                switch (column)
                {
                    case Column.Ordinal:
                        builder.ordinal(value);
                        break;
                    case Column.WaypointType:
                        builder.ignore(value);
                        break;
                    case Column.Name:
                        builder.name(value);
                        break;
                    case Column.KnownFixPoint:
                        builder.name(value);
                        break;
                    case Column.Location:
                        builder.location(value);
                        break;
                    case Column.Elevation:
                        builder.elevation(value);
                        break;
                    case Column.Altitude:
                        builder.altitude(value);
                        break;
                    case Column.Speed:
                        builder.ignore(value);
                        break;
                    case Column.TOT:
                        builder.ignore(value);
                        break;
                    case Column.LegFuel:
                        builder.ignore(value);
                        break;
                    case Column.Unknown:
                        builder.ignore(value);
                        break;
                }
            }

            return builder;
        }

        Dictionary<int, Column> parseHeaders(String input)
        {
            var line = input.Trim();
            var indexes = new Dictionary<int, Column>();
            foreach (var segment in line.Split("\t"))
            {
                var kind = segment.Trim() switch
                {
                    "#" => Column.Ordinal,
                    "Type" => Column.WaypointType,
                    "Name" => Column.Name,
                    "Fix/Point" => Column.KnownFixPoint,
                    "Location" => Column.Location,
                    "Elev" => Column.Elevation,
                    "Alt" => Column.Altitude,
                    "SPD" => Column.Speed,
                    "ETE/TOT" => Column.TOT,
                    "Leg Fuel" => Column.LegFuel,
                    _ => Column.Unknown
                };
                indexes.Add(indexes.Count, kind);
            }

            return indexes;
        }

        public RecordType detect(String input)
        {
            var line = input.Trim();
            if(line.StartsWith("Mission Data Card - *"))
            {
                return RecordType.UserCallsignLine;
            }
            if(line.Equals("Flight"))
            {
                return RecordType.FlightInfo;
            }
            if(line.Equals("Radios"))
            {
                return RecordType.Radios;
            }
            if (line.Equals("Flight Plan"))
            {
                return RecordType.FlightPlanIndicator;
            }

            if (line.Contains("Fix/Point") && line.Contains("Location"))
            {
                return RecordType.FlightPlanHeader;
            }

            if (Regex.IsMatch(line, @"^\d+") && line.Length < 5)
            {
                return RecordType.EmptyRow;
            }
            if (Regex.IsMatch(line, @"^\d+\s"))
            {
                return RecordType.Waypoint;
            }
            return RecordType.Comment;
        }
    }

    enum ParserState
    {
        Parsing476thData,
        ParsingFlightPlan,
        ParsingNotes,
        FinishedParsing,
        BadFormatUnableToParse,
        ParsingFlightInfo
    }
    public enum RecordType
    {
        FlightPlanIndicator,
        EmptyRow,
        Waypoint,
        FlightPlanHeader,
        Comment,
        FlightInfo,
        Radios,
        UserCallsignLine
    }

    enum Column
    {
        Ordinal,
        WaypointType,
        Name,
        KnownFixPoint,
        Location,
        Elevation,
        Altitude,
        Speed,
        TOT,
        LegFuel,
        Unknown
    }



}