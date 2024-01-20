using System.Collections;
using System.Globalization;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace DTC.Models.v476
{
    public class WaypointSystemParser
    {
        Dictionary<int, Column> columns = new Dictionary<int, Column>();
        private ParserState parserState = ParserState.Parsing476thData;

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
                    //TODO: This needs to be statefull and finish parsing after detection of last waypoint. Free text notes can be in format resembling waypoints and thus can cause problems.
                    while ((line = reader.ReadLine()) != null)
                    {
                        idx++;
                        var lineType = detect(line);
                        if (lineType == RecordType.FlightPlanHeader)
                        {
                            columns = parseHeaders(line);
                            parserState = ParserState.ParsingFlightPlan;
                        }

                        if ((lineType == RecordType.Waypoint || lineType == RecordType.EmptyRow) && parserState == ParserState.ParsingFlightPlan)
                        {
                            var waypoint = parseWaypoint(line);
                            result.Add(singleParse(waypoint));
                            //TODO: Most likely we should not be parsing empty waypoints; just ommit it in the sequence when entering?
                        }
                        if (lineType == RecordType.Comment)
                        {
                            //if Comment prior to flight plan, continue. If comment after parsing waypoints, terminate
                            if (parserState == ParserState.Parsing476thData)
                                continue;
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

        public List<DTC.New.Presets.V2.Aircrafts.F15E.Systems.Waypoint> parseForF15(String contentToParse)
        {
            return parse<DTC.New.Presets.V2.Aircrafts.F15E.Systems.Waypoint>(contentToParse,
                (builder) => builder.buildForF15E()); ;
        }

        public List<DTC.New.Presets.V2.Aircrafts.FA18.Systems.Waypoint> parseForFA18(String contentToParse)
        {
            return parse<DTC.New.Presets.V2.Aircrafts.FA18.Systems.Waypoint>(contentToParse,
                (builder) => builder.buildForFA18()); ;
        }

        public List<DTC.New.Presets.V2.Aircrafts.F16.Systems.Waypoint> parseForF16(String contentToParse)
        {
            return parse<DTC.New.Presets.V2.Aircrafts.F16.Systems.Waypoint>(contentToParse,
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
        BadFormatUnableToParse
    }
    public enum RecordType
    {
        FlightPlanIndicator,
        EmptyRow,
        Waypoint,
        FlightPlanHeader,
        Comment
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

    public class Longitude
    {
        public Hemisphere _hemisphere { get; }
        public DDMMMM ddmmmm { get; }

        public Longitude(Hemisphere hemisphere, DDMMMM ddmmmm)
        {
            _hemisphere = hemisphere;
            this.ddmmmm = ddmmmm;
        }

        public Longitude(Hemisphere hemisphere, DDMMSS ddmmss)
        {
            _hemisphere = hemisphere;
            this.ddmmmm = ddmmss.ToDDMMMM();
        }

        public enum Hemisphere
        {
            East,
            West
        }

        public static Longitude? parse(string input)
        {
            var substring = input.Trim().Replace(" ", "");
            var hemisphere = substring[0] switch
            {
                'E' => Hemisphere.East,
                'W' => Hemisphere.West,
                _ => throw new ArgumentException()
            };

            var degreeSymbolIdx = substring.IndexOf("°");
            var minuteSymbolIdx = substring.IndexOf("'");
            var degrees = Int32.Parse(substring.Substring(1, degreeSymbolIdx - 1));

            if (substring.Contains("\""))
            {
                var secondSymbolIdx = substring.IndexOf("\"");
                var minutes =
                    Int32.Parse(substring.Substring(degreeSymbolIdx + 1, minuteSymbolIdx - degreeSymbolIdx - 1));

                var secondsString = substring.Substring(minuteSymbolIdx + 1, secondSymbolIdx - minuteSymbolIdx - 1);
                var pos = new DDMMSS(degrees,
                    minutes,
                    Decimal.Parse(secondsString));

                return new Longitude(hemisphere, pos);
            }
            else
            {
                var minuteString = substring.Substring(degreeSymbolIdx + 1, minuteSymbolIdx - degreeSymbolIdx - 1).Replace(",", ".");
                var pos = new DDMMMM(degrees, Decimal.Parse(minuteString, new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                return new Longitude(hemisphere, pos);
            }
        }
        
        public override string ToString()
        {
            return viperString();
        }
        
        public string viperString()
        {
            return $"{_hemisphere.ToString()[0]} {ddmmmm.ddmm_mmm()}";
        }
    }

    public record class Latitude(Latitude.Hemisphere _hemisphere, 
        DDMMMM ddmmmm)
    {
        public Latitude(Hemisphere hemisphere, DDMMSS ddmmss) : this(hemisphere, ddmmss.ToDDMMMM())
        {
        }

        public enum Hemisphere
        {
            North,
            South
        }

        public static Latitude parse(string substring)
        {
            var hemisphere = substring[0] switch
            {
                'N' => Hemisphere.North,
                'S' => Hemisphere.South,
                _ => throw new ArgumentException()
            };

            var degreeSymbolIdx = substring.IndexOf("°");
            var minuteSymbolIdx = substring.IndexOf("'");
            var degrees = Int32.Parse(substring.Substring(1, degreeSymbolIdx - 1));

            if (substring.Contains("\""))
            {
                var secondSymbolIdx = substring.IndexOf("\"");
                var minutes =
                    Int32.Parse(substring.Substring(degreeSymbolIdx + 1, minuteSymbolIdx - degreeSymbolIdx - 1));

                var pos = new DDMMSS(degrees,
                    minutes,
                    Decimal.Parse(substring.Substring(minuteSymbolIdx + 1, secondSymbolIdx - minuteSymbolIdx - 1)));

                return new Latitude(hemisphere, pos);
            }
            else
            {
                var minutes = substring.Substring(degreeSymbolIdx + 1, minuteSymbolIdx - degreeSymbolIdx - 1).Replace(",", ".");
                var pos = new DDMMMM(degrees,
                    Decimal.Parse(minutes, new NumberFormatInfo() { NumberDecimalSeparator = "." }));
   
                return new Latitude(hemisphere, pos);
            }
        }

        public override string ToString()
        {
            return viperString();
        }

        public string viperString()
        {
            return $"{_hemisphere.ToString()[0]} {ddmmmm.ddmm_mmm()}";
        }
    }


    public class DDMMMM
    {
        int degrees;
        decimal minutes;

        public DDMMSS ToDDMMSS()
        {
            int wholeMinutes = (int)minutes;
            decimal fractionalMinutes = minutes - wholeMinutes;
            decimal seconds = (int)(fractionalMinutes * 60);

            return new DDMMSS(degrees, wholeMinutes, seconds);
        }

        public DDMMMM(int degrees, decimal minutes)
        {
            this.degrees = degrees;
            this.minutes = minutes;
        }

        public string ddmm_mmm()
        {
            return $"{degrees:00}°{minutes:00.000}’";
        }
    }

    public class DDMMSS
    {
        private int degrees;
        private int minutes;
        private decimal seconds;

        public DDMMSS(int degrees, int minutes, decimal seconds)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public DDMMMM ToDDMMMM()
        {
            decimal fractionalMinutes = minutes + seconds / 60;
            return new DDMMMM(degrees, fractionalMinutes);
        }
    }
}