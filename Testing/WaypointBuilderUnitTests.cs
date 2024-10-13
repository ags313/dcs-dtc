using System.Globalization;
using DTC.Models.v476;

namespace Testing
{
    public class WaypointBuilderUnitTests: LocaleAwareUnitTestBase
    {
        public WaypointBuilderUnitTests(string locale): base(locale)
        {
        }
        
        [Test]
        public void Parser_Understands_Different_Height_Formats()
        {
            Assert.That(WaypointBuilder.ParseHeightData("FL100"), Is.EqualTo(10000));
            Assert.That(WaypointBuilder.ParseHeightData("1234"), Is.EqualTo(1234));
            Assert.That(WaypointBuilder.ParseHeightData(""), Is.Null);
        }

        [Test]
        public void Parser_Understands_Restriction_Formats()
        {
            Assert.That(WaypointBuilder.ParseHeightData("17000A"), Is.EqualTo(17000));
            Assert.That(WaypointBuilder.ParseHeightData("17000B"), Is.EqualTo(17000));
        }
        
        [Test]
        public void Parser_Understands_MGRS()
        {
            var maybeTuple = WaypointBuilder.ParseLatLong("11SNB7237453149");

            Assert.That(maybeTuple, Is.Not.Null);
            Assert.That(maybeTuple?.Item1._hemisphere, Is.EqualTo(Longitude.Hemisphere.West));
            Assert.That(maybeTuple?.Item2._hemisphere, Is.EqualTo(Latitude.Hemisphere.North));

            Assert.That(maybeTuple?.Item1.ddmmmm.ddmm_mmm(), Is.EqualTo( "116\u00b0" + 10.858 + "’"));
            Assert.That(maybeTuple?.Item2.ddmmmm.ddmm_mmm(), Is.EqualTo("37\u00b0" + 31.348 + "’"));
        }
        
        [Test]
        public void Parser_Troublesome_Coordinates()
        {
            var maybeTuple = WaypointBuilder.ParseLatLong("N 36\u00b018,617' W 115\u00b002,367'");

            Assert.That(maybeTuple, Is.Not.Null);
            Assert.That(maybeTuple?.Item1._hemisphere, Is.EqualTo(Longitude.Hemisphere.West));
            Assert.That(maybeTuple?.Item2._hemisphere, Is.EqualTo(Latitude.Hemisphere.North));

            Assert.That(maybeTuple?.Item1.ddmmmm.ddmm_mmm(), Is.EqualTo("115\u00b00" + 2.367 + "’"));
            Assert.That(maybeTuple?.Item2.ddmmmm.ddmm_mmm(), Is.EqualTo("36\u00b0" + 18.617 + "’"));
        }
    }
}