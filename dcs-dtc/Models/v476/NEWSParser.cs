namespace DTC.Models.v476.coordinates
{
    public struct Coordinate
    {
        public readonly string Major;
        public readonly string Minor;
        public readonly string Fraction;
        public readonly string Hemisphere;
        public readonly CoordinatePrecision Precision;
        public readonly CoordinateFormat Format;

        public Coordinate(string hemisphere, string major, string minor, string fraction,
            CoordinatePrecision precision,
            CoordinateFormat format)
        {
            Major = major;
            Minor = minor;
            Fraction = fraction;
            Precision = precision;
            Format = format;
            Hemisphere = hemisphere;
        }
    }

    public class NEWSParser
    {
        private ParserState mostRecentlyParsed = ParserState.Unknown;
        private CoordinateFormat format = CoordinateFormat.Unknown;
        private CoordinatePrecision precision = CoordinatePrecision.Unknown;
        private string hemisphere = "";
        private string[] components = new string[3];
        private string accumulator = "";
        private List<Coordinate> results = new();

        private void ResetState()
        {
            accumulator = "";
            components = new string[3];
            hemisphere = "";
            precision = CoordinatePrecision.Unknown;
            format = CoordinateFormat.Unknown;
            mostRecentlyParsed = ParserState.Unknown;
        }

        public List<Coordinate> parse(string line)
        {
            ResetState();
            results.Clear();
            var trimmed = line.Trim();
            for (var i = 0; i < trimmed.Length; i++)
            {
                var c = trimmed.Substring(i, 1);
                switch (c)
                {
                    case "N":
                    case "E":
                    case "+":
                    case "S":
                    case "W":
                    case "-":
                        ResetAccumulator();
                        mostRecentlyParsed = ParserState.Hemisphere;
                        hemisphere = c;
                        break;
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        AccumulateDigit(c);
                        break;
                    case " ":
                    case "\u00b0":
                    case "º":
                    case "\"":
                        ResetAccumulator();
                        break;
                    case "'":
                    case "`":
                        if (mostRecentlyParsed == ParserState.Minor)
                        {
                            format = CoordinateFormat.DDMMSS;
                        }

                        ResetAccumulator();
                        precision = CoordinatePrecision.DescendingUnits;
                        break;
                    case ".":
                    case ",":
                        if (mostRecentlyParsed == ParserState.Minor)
                        {
                            format = CoordinateFormat.DDMMMM;
                        }

                        ResetAccumulator();
                        precision = CoordinatePrecision.Fractions;
                        break;
                }
            }

            ResetAccumulator();
            var outcome = new List<Coordinate>(results);
            results.Clear();

            return outcome;
        }

        private void AccumulateDigit(string c)
        {
            if (accumulator.Length == 0)
            {
                mostRecentlyParsed = Next(mostRecentlyParsed);
            }

            accumulator += c;
            switch (mostRecentlyParsed)
            {
                case ParserState.Major:
                    components[0] = accumulator;
                    break;
                case ParserState.Minor:
                    components[1] = accumulator;
                    break;
                case ParserState.Fractional:
                    components[2] = accumulator;
                    break;
            }
        }

        private void ResetAccumulator()
        {
            if (accumulator.Length > 0)
            {
                if (mostRecentlyParsed == ParserState.Fractional)
                {
                    results.Add(CollectCoords());
                    ResetState();
                }

                accumulator = "";
            }
        }

        private Coordinate CollectCoords()
        {
            return new Coordinate(hemisphere,
                components[0],
                components[1],
                components[2],
                precision,
                format);
        }

        private static ParserState Next(ParserState input)
        {
            switch (input)
            {
                case ParserState.Hemisphere:
                    return ParserState.Major;
                case ParserState.Major:
                    return ParserState.Minor;
                case ParserState.Minor:
                    return ParserState.Fractional;
                case ParserState.Fractional:
                    return ParserState.Finished;
                default:
                    return ParserState.Unknown;
            }
        }
    }

    enum ParserState
    {
        Unknown,
        Hemisphere,
        Major,
        Minor,
        Fractional,
        Finished
    };

    public enum CoordinateFormat
    {
        Unknown,
        DDMMSS,
        DDMMMM,
    }

    public enum CoordinatePrecision
    {
        Unknown,
        DescendingUnits,
        Fractions
    }
}