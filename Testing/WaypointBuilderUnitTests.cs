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
    }
}