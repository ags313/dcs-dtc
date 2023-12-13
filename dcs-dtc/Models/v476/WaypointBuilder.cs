namespace DTC.Models.v476
{
    class WaypointBuilder
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
            var midPoint = value.IndexOfAny(new[] { 'E', 'W' }, 0);
            this._latitude = Latitude.parse(value[..midPoint]);
            this._longitude = Longitude.parse(value.Substring(midPoint));
            return this;
        }

        public WaypointBuilder name(string value)
        {
            this._name = value;
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