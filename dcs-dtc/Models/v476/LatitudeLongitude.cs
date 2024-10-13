using System.Globalization;
using DTC.Models.v476.coordinates;

namespace DTC.Models.v476
{
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

        public static Longitude Parse(Coordinate coordinate)
        {
            var hemisphere = coordinate.Hemisphere switch
            {
                "E" => Hemisphere.East,
                "W" => Hemisphere.West,
                _ => throw new ArgumentException()
            };
            
            switch (coordinate.Format)
            {
                case CoordinateFormat.DDMMMM:
                {
                    var minutes = coordinate.Minor + "." + coordinate.Fraction;
                    var pos = new DDMMMM(Int32.Parse(coordinate.Major),
                        Decimal.Parse(minutes, new NumberFormatInfo() { NumberDecimalSeparator = "." }));
                    return new Longitude(hemisphere, pos);
                }

                case CoordinateFormat.DDMMSS:
                {
                    var pos = new DDMMSS(Int32.Parse(coordinate.Major),
                        Int32.Parse(coordinate.Minor),
                        Decimal.Parse(coordinate.Fraction));
                    return new Longitude(hemisphere, pos);
                }
            }
            
            throw new ArgumentException();
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

    public record class Latitude(
        Latitude.Hemisphere _hemisphere,
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

        public static Latitude Parse(Coordinate coordinate)
        {
            var hemisphere = coordinate.Hemisphere switch
            {
                "N" => Hemisphere.North,
                "S" => Hemisphere.South,
                _ => throw new ArgumentException()
            };


            switch (coordinate.Format)
            {
                case CoordinateFormat.DDMMMM:
                {
                    var minutes = coordinate.Minor + "." + coordinate.Fraction;
                    var pos = new DDMMMM(Int32.Parse(coordinate.Major),
                        Decimal.Parse(minutes, new NumberFormatInfo() { NumberDecimalSeparator = "." }));
                    return new Latitude(hemisphere, pos);
                }

                case CoordinateFormat.DDMMSS:
                {
                    var pos = new DDMMSS(Int32.Parse(coordinate.Major),
                        Int32.Parse(coordinate.Minor),
                        Decimal.Parse(coordinate.Fraction));
                    return new Latitude(hemisphere, pos);
                }
            }
            
            throw new ArgumentException();
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