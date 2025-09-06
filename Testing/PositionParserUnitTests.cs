using DTC.Models.v476;
using DTC.Models.v476.coordinates;
using CoordinateFormat = DTC.Models.v476.coordinates.CoordinateFormat;

namespace Testing
{
    public class PositionParserUnitTests : LocaleAwareUnitTestBase
    {
        public PositionParserUnitTests(string locale) : base(locale)
        {
        }


        [TestCase("11 SNB 7237 4531 49", 
            Longitude.Hemisphere.West, Latitude.Hemisphere.North,
            116, 10.858, 37, 31.348)]        
        [TestCase("11SNB7237453149", 
            Longitude.Hemisphere.West, Latitude.Hemisphere.North,
            116, 10.858, 37,  31.348)]        
        [TestCase("11S PA 76000 12000", 
            Longitude.Hemisphere.West, Latitude.Hemisphere.North,
            115, 2.487, 36, 14.212)]
        public void Parser_Understands_MGRS(string input,
            Longitude.Hemisphere lonHemisphere,
            Latitude.Hemisphere latHemisphere,
            int lonDeg, double lonTail,
            int latDeg, double latTail)
        {
            var maybeTuple = PositionParser.ParseLatLong(input);

            Assert.That(maybeTuple, Is.Not.Null);
            Assert.That(maybeTuple?.Item1._hemisphere, Is.EqualTo(lonHemisphere));
            Assert.That(maybeTuple?.Item2._hemisphere, Is.EqualTo(latHemisphere));

            var expectedLon = lonDeg + "\u00b0" + lonTail.ToString("00.###") + "’";
            var expectedLat = latDeg + "\u00b0" + latTail.ToString("00.###") + "’";
            Assert.That(maybeTuple?.Item1.ddmmmm.ddmm_mmm(), Is.EqualTo(expectedLon));
            Assert.That(maybeTuple?.Item2.ddmmmm.ddmm_mmm(), Is.EqualTo(expectedLat));
        }

        [Test]
        public void Parser_Troublesome_Coordinates()
        {
            var maybeTuple = PositionParser.ParseLatLong("N 36\u00b018,617' W 115\u00b002,367'");

            Assert.That(maybeTuple, Is.Not.Null);
            Assert.That(maybeTuple?.Item1._hemisphere, Is.EqualTo(Longitude.Hemisphere.West));
            Assert.That(maybeTuple?.Item2._hemisphere, Is.EqualTo(Latitude.Hemisphere.North));

            Assert.That(maybeTuple?.Item1.ddmmmm.ddmm_mmm(), Is.EqualTo("115\u00b00" + 2.367 + "’"));
            Assert.That(maybeTuple?.Item2.ddmmmm.ddmm_mmm(), Is.EqualTo("36\u00b0" + 18.617 + "’"));
        }


        [Test]
        public void Parser_should_parse_degree_less_coordinates()
        {
            var input = """
                        N 37°10.333' W 114°59.534'
                        N 37°38.500' W 115°24.000'
                        N37° 34.000 W116° 26.000
                        N37° 33.000 W116° 39.000
                        N37° 17.000 W116° 44.000
                        N 36 25.62 W 115 30.70
                        """;
            var lines = input.Trim().Split("\n");
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                PositionParser.ParseLatLong(line.Trim());
            }
        }
    }
}