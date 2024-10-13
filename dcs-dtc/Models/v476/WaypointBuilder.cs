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
            else if (value.EndsWith("A"))
            {
                return ParseHeightData(value.Substring(0, value.Length - 1));
            }
            else if (value.EndsWith("B"))
            {
                return ParseHeightData(value.Substring(0, value.Length - 1));
            }
            else if (value.Trim().Length > 0)
            {
                int height = 0;
                if (int.TryParse(value, out height))
                    return height;
            }

            return null;
        }

        public WaypointBuilder location(string value)
        {
            var maybeLocation = PositionParser.ParseLatLong(value);
            if (maybeLocation != null)
            {
                this._longitude = maybeLocation.Item1;
                this._latitude = maybeLocation.Item2;
            }
            
            return this;
        }
        
        public WaypointBuilder name(string input)
        {
            if (input != null && input.Trim().Length > 0)
            {
                this._name = input.Trim();
            }
            return this;
        }

        public DTC.New.Presets.V2.Aircrafts.F16.Systems.Waypoint buildForF16()
        {
            if (!_ordinal.HasValue)
            {
                throw new Exception("Missing required fields");
            }

            DTC.New.Presets.V2.Aircrafts.F16.Systems.Waypoint wp = new();
            wp.Sequence = _ordinal.Value;
            
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

        public DTC.New.Presets.V2.Aircrafts.F15E.Systems.Waypoint buildForF15E()
        {
            if (!_ordinal.HasValue)
            {
                throw new Exception("Missing required fields");
            }

            DTC.New.Presets.V2.Aircrafts.F15E.Systems.Waypoint wp = new();
            wp.Sequence = _ordinal.Value;

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
        public DTC.New.Presets.V2.Aircrafts.FA18.Systems.Waypoint buildForFA18()
        {
            if (!_ordinal.HasValue)
            {
                throw new Exception("Missing required fields");
            }

            DTC.New.Presets.V2.Aircrafts.FA18.Systems.Waypoint wp = new();
            wp.Sequence = _ordinal.Value;

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