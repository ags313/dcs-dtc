using System.Text.RegularExpressions;

namespace DTC.Models.v476
{
    public class WaypointBuilder
    {
        private int? _ordinal;
        private int? _elevation; // of waypoint
        private string? _name;
        private Latitude? _latitude;
        private Longitude? _longitude;
        private int? _altitude; // how high to fly

        public WaypointBuilder ignore(string value)
        {
            return this;
        }

        public WaypointBuilder ordinal(string value)
        {
            this._ordinal = Int32.Parse(value);
            return this;
        }

        public WaypointBuilder elevation(string input)
        {
            var maybeInt = ParseHeightData(input);
            if (maybeInt.HasValue)
            {
                this._elevation = maybeInt.Value;
            }

            return this;
        }

        public WaypointBuilder altitude(string input)
        {
            var maybeInt = ParseHeightData(input);
            if (maybeInt.HasValue)
            {
                this._altitude = maybeInt.Value;
            }

            return this;
        }

        public static int? ParseHeightData(string input)
        {
            var value = input.ToUpper().Trim();
            if (value.Contains("FL"))
            {
                return Int32.Parse(value.Replace("FL", "")) * 100;
            } 
            else if (value.Contains("A"))
            {
                // do something
                return null;
            }
            else if (value.Contains("B"))
            {
                // do something
                return null;
            }
            else if (value.Trim().Length > 2)
            {
                int height = 0;
                if (int.TryParse(value, out height))
                    return height;
            }

            return null;
        }

        public WaypointBuilder location(string value)
        {
            var maybeLocation = ParseLatLong(value);
            if (maybeLocation != null)
            {
                this._longitude = maybeLocation.Item1;
                this._latitude = maybeLocation.Item2;
            }
            
            return this;
        }
        
        public static Tuple<Longitude, Latitude>? ParseLatLong(string value)
        {
            string mgrs10 = @"\d{2}[A-Z]{3}\d{5}\d+";
            if (new Regex(mgrs10).IsMatch(value))
            {
                // mgrs10 
                var parsed = CoordinateSharp.Coordinate.Parse(value);
                var parsedLon = parsed.Longitude;
                var parsedLat = parsed.Latitude;

                return new Tuple<Longitude, Latitude>(
                    new Longitude(
                        parsedLon.DecimalDegree > 0 ? Longitude.Hemisphere.East : Longitude.Hemisphere.West,
                        new DDMMMM(parsedLon.Degrees, new Decimal(parsedLon.DecimalMinute))
                    ),
                    new Latitude(
                        parsedLat.DecimalDegree > 0 ? Latitude.Hemisphere.North : Latitude.Hemisphere.South,
                        new DDMMMM(parsedLat.Degrees, new Decimal(parsedLat.DecimalMinute))
                    )
                );
            }
            
            var midPoint = value.IndexOfAny(new[] { 'E', 'W' }, 0);
            if (midPoint > 0)
            {
                var latitude = Latitude.parse(value[..midPoint]);
                var longitude = Longitude.parse(value.Substring(midPoint));
                if(longitude != null && latitude != null)
                {
                    return new Tuple<Longitude, Latitude>(longitude, latitude);
                }
            }

            return null;
        }

        public WaypointBuilder name(string input)
        {
            if (input != null && input.Trim().Length > 0)
            {
                this._name = input.Trim();
            }
            return this;
        }

        public F16.Waypoints.Waypoint buildForF16()
        {
            if (!_ordinal.HasValue)
            {
                throw new Exception("Missing required fields");
            }

            F16.Waypoints.Waypoint wp = new(_ordinal.Value);
            
            if(_latitude != null && _longitude != null)
            {
                wp.Latitude = _latitude?.viperString();
                wp.Longitude = _longitude?.viperString();
            }
            else
            {
                wp.Latitude = "";
                wp.Longitude = "";
            }
            if (_name != null)
            {
                wp.Name = _name;
            }
            else
            {
                wp.Name = "";
            }
            if(_elevation != null)
            {
                wp.Elevation = _elevation.Value;
            }

            wp.TimeOverSteerpoint = "";

            return wp;
        }

        public F15E.Waypoints.Waypoint buildForF15E()
        {
            if (!_ordinal.HasValue)
            {
                throw new Exception("Missing required fields");
            }

            F15E.Waypoints.Waypoint wp = new(_ordinal.Value);

            if (_latitude != null && _longitude != null)
            {
                wp.Latitude = _latitude?.viperString();
                wp.Longitude = _longitude?.viperString();
            }
            else
            {
                wp.Latitude = "";
                wp.Longitude = "";
            }
            if (_name != null)
            {
                wp.Name = _name;
            }
            else
            {
                wp.Name = "";
            }
            if (_elevation != null)
            {
                wp.Elevation = _elevation.Value;
            }
            return wp;
        }
        public FA18.Waypoints.Waypoint buildForFA18()
        {
            if (!_ordinal.HasValue)
            {
                throw new Exception("Missing required fields");
            }

            FA18.Waypoints.Waypoint wp = new(_ordinal.Value);

            if (_latitude != null && _longitude != null)
            {
                wp.Latitude = _latitude?.viperString();
                wp.Longitude = _longitude?.viperString();
            }
            else
            {
                wp.Latitude = "";
                wp.Longitude = "";
            }
            if (_name != null)
            {
                wp.Name = _name;
            }
            else
            {
                wp.Name = "";
            }
            if (_elevation != null)
            {
                wp.Elevation = _elevation.Value;
            }
            return wp;
        }
    }
}