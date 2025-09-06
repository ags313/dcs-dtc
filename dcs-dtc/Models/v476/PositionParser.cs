using System.Text.RegularExpressions;
using DTC.Models.v476.coordinates;

namespace DTC.Models.v476
{
    public class PositionParser
    {
        // Accept both compact and spaced MGRS variants by stripping spaces before matching
        private const string MGRS10_FORMAT = @"\d{2}[A-Z]{3}\d{5}\d+";
        private static readonly Regex REGEX_MGRS10 = new Regex(MGRS10_FORMAT);
        
        public static Tuple<Longitude, Latitude>? ParseLatLong(string value)
        {
            var noSpaces = value.Replace(" ", "");
            if (REGEX_MGRS10.IsMatch(noSpaces))
            {
                // CoordinateSharp supports MGRS with spaces
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

            var parser = new NEWSParser();
            var coords = parser.parse(value);
            
            if (coords.Count > 1)
            {
                var latitude = Latitude.Parse(coords[0]);
                var longitude = Longitude.Parse(coords[1]);
                if(longitude != null && latitude != null)
                {
                    return new Tuple<Longitude, Latitude>(longitude, latitude);
                }
            }

            return null;
        }
    }
}