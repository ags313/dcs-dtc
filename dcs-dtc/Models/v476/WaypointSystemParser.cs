using System.Collections;

namespace DTC.Models.v476
{
    public class WaypointSystemParser
    {
        Dictionary<int, Column> columns = new Dictionary<int, Column>();
        
        public void parse(String contentToParse)
        {
            var result = new ArrayList();
            
            
            using (StringReader reader = new StringReader(contentToParse))
            {
                var line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    var lineType = detect(line);
                    if (lineType == RecordType.FlightPlanHeader)
                    {
                        columns = parseHeaders(line);
                    }
                    if (lineType == RecordType.Waypoint)
                    {
                        var waypoint = parseWaypoint(line);
                        result.Add(waypoint);
                    }
                }
            }
        }

        object parseWaypoint(String input)
        {
            var strings = input.Trim().Split("\t");
            var builder = new WaypointBuilder();
            for (int i = 0; i < strings.Length; i++)
            {
                var value = strings[i];
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
                        builder.ignore(value);
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

            return builder.build();
        }

        Dictionary<int, Column> parseHeaders(String input)
        {
            var line = input.Trim();
            var indexes = new Dictionary<int, Column>();
            foreach (var segment in line.Split("\t"))
            {
                var kind = segment switch
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

            if (line.Length < 5)
            {
                return RecordType.EmptyRow;
            }

            return RecordType.Waypoint;
        }
    }

    class WaypointBuilder
    {
        private int? _ordinal;
        private int? _elevation;
        private string _name;
        private object? _latitude;
        private object? _longitude;
        private int? _altitude;

        public WaypointBuilder ignore(string value)
        {
            return this;
        }

        public WaypointBuilder ordinal(string value)
        {
            this._ordinal = Int32.Parse(value);
            return this;
        }

        public WaypointBuilder elevation(string value)
        {
            if (value.Trim().Length > 2)
            {
                this._elevation = Int32.Parse(value);                
            }
            return this;
        }

        public WaypointBuilder altitude(string value)
        {
            if (value.Trim().Length > 2)
            {
                this._altitude = Int32.Parse(value);                
            }
            return this;
        }

        public WaypointBuilder location(string value)
        {
            var midPoint = value.IndexOfAny(new []{'E', 'W'}, 0);
            this._latitude = Latitude.parse(value[..midPoint]);
            this._longitude = Longitude.parse(value.Substring(midPoint));
            return this;
        }

        public object build()
        {
            throw new NotImplementedException();
        }

        public WaypointBuilder name(string value)
        {
            this._name = value;
            return this;
        }
    }
    
    public enum RecordType
    {
        FlightPlanIndicator,
        EmptyRow,
        Waypoint,
        FlightPlanHeader
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

    class Longitude
    {
        private readonly Hemisphere _hemisphere;
        private DDMMMM ddmmmm;

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

        public static Longitude? parse(string substring)
        {
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
                var minutes = Int32.Parse(substring.Substring(degreeSymbolIdx + 1, minuteSymbolIdx - degreeSymbolIdx - 1));

                var secondsString = substring.Substring(minuteSymbolIdx + 1, secondSymbolIdx - minuteSymbolIdx - 1);
                var pos = new DDMMSS(degrees,
                    minutes,
                    Decimal.Parse(secondsString));

                return new Longitude(hemisphere, pos);
            }
            else
            {
                var minuteString = substring.Substring(degreeSymbolIdx + 1, minuteSymbolIdx - degreeSymbolIdx - 1);
                var pos = new DDMMMM(degrees, Decimal.Parse(minuteString));

                return new Longitude(hemisphere, pos);
            }
        }
    }
    
    class Latitude
    {
        private readonly Hemisphere _hemisphere;
        private DDMMMM ddmmmm;

        public Latitude(Hemisphere hemisphere, DDMMMM ddmmmm)
        {
            _hemisphere = hemisphere;
            this.ddmmmm = ddmmmm;
        }

        public Latitude(Hemisphere hemisphere, DDMMSS ddmmss)
        {
            _hemisphere = hemisphere;
            this.ddmmmm = ddmmss.ToDDMMMM();
        }
        
        public enum Hemisphere
        {
            North,
            South
        }

        public static Latitude? parse(string substring)
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
                var minutes = Int32.Parse(substring.Substring(degreeSymbolIdx + 1, minuteSymbolIdx - degreeSymbolIdx - 1));

                var pos = new DDMMSS(degrees,
                    minutes,
                    Decimal.Parse(substring.Substring(minuteSymbolIdx + 1, secondSymbolIdx - minuteSymbolIdx - 1)));
                
                return new Latitude(hemisphere, pos);
            }
            else
            {
                var minutes = substring.Substring(degreeSymbolIdx + 1, minuteSymbolIdx - degreeSymbolIdx - 1);
                var pos = new DDMMMM(degrees,
                    Decimal.Parse(minutes));
                return new Latitude(hemisphere, pos);
            }
        }
    }
    

    class DDMMMM
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
    }

    class DDMMSS
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