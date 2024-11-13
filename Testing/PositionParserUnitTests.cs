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

        [Test]
        public void Parser_Understands_MGRS()
        {
            var maybeTuple = PositionParser.ParseLatLong("11SNB7237453149");

            Assert.That(maybeTuple, Is.Not.Null);
            Assert.That(maybeTuple?.Item1._hemisphere, Is.EqualTo(Longitude.Hemisphere.West));
            Assert.That(maybeTuple?.Item2._hemisphere, Is.EqualTo(Latitude.Hemisphere.North));

            Assert.That(maybeTuple?.Item1.ddmmmm.ddmm_mmm(), Is.EqualTo("116\u00b0" + 10.858 + "’"));
            Assert.That(maybeTuple?.Item2.ddmmmm.ddmm_mmm(), Is.EqualTo("37\u00b0" + 31.348 + "’"));
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