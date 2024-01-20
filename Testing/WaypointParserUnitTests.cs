using System.Globalization;
using DTC.Models.v476;
using Microsoft.VisualBasic.CompilerServices;
using static DTC.Models.v476.RecordType;

namespace Testing
{
    [TestFixture("en-US")]
    [TestFixture("en-GB")] 
    [TestFixture("pl-PL")]
    [TestFixture("de-DE")]
    public class WaypointParserUnitTests
    {
        private WaypointSystemParser _parser;
        private string locale;

        public WaypointParserUnitTests(string locale)
        {
            this.locale = locale;
        }

        [SetUp]
        public void Setup()
        {
            _parser = new WaypointSystemParser();
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(locale);
        }

        [Test]
        public void Should_DetectTopLine()
        {
            Assert.That(_parser.detect("Flight Plan"), Is.EqualTo(FlightPlanIndicator));
        }

        [Test]
        public void Should_DetectFlightPlanHeader()
        {
            Assert.That(_parser.detect("#	Type	Name	Fix/Point	Location	Elev	Alt	SPD	ETE/TOT"),
                Is.EqualTo(FlightPlanHeader));
        }

        [Test]
        public void shouldDetectWaypoint()
        {
            Assert.That(_parser.detect("13\tOBJ\t\t4808A.1\tN 37\u00b028.000' W 116\u00b000.050'"),
                Is.EqualTo(Waypoint));
        }

        [Test]
        public void DetectLine_ReturnsEmptyRow_ForEmptyWaypoint()
        {
            Assert.That(_parser.detect("17\t\t\t\t\t\t\t\t\t"), Is.EqualTo(EmptyRow));
        }

        [Test]
        public void shouldParseTestInput()
        {
            _parser.parseForF16(Data.viperPlanWithNotes);
        }

        [Test]
        public void ParseForFA18_ParsesTestInput()
        {
            var result = _parser.parseForFA18(Data.hornetFail2);
            Assert.That(result[4].Name, Is.EqualTo("R74B/C Centr"));
        }

        [Test]
        public void Parser_Understands_Different_Height_Formats()
        {
            Assert.That(WaypointBuilder.ParseHeightData("FL100"), Is.EqualTo(10000));
            Assert.That(WaypointBuilder.ParseHeightData("1234"), Is.EqualTo(1234));
            Assert.That(WaypointBuilder.ParseHeightData(""), Is.Null);
        }

        [Test]
        public void Parser_Understands_MGRS()
        {
            var maybeTuple = WaypointBuilder.ParseLatLong("11SNB7237453149");

            Assert.That(maybeTuple, Is.Not.Null);
            Assert.That(maybeTuple?.Item1._hemisphere, Is.EqualTo(Longitude.Hemisphere.West));
            Assert.That(maybeTuple?.Item2._hemisphere, Is.EqualTo(Latitude.Hemisphere.North));

            Assert.That(maybeTuple?.Item1.ddmmmm.ddmm_mmm(), Is.EqualTo("116\u00b010.858’"));
            Assert.That(maybeTuple?.Item2.ddmmmm.ddmm_mmm(), Is.EqualTo("37\u00b031.348’"));
        }

        [Test]
        public void Parser_Troublesome_Coordinates()
        {
            var maybeTuple = WaypointBuilder.ParseLatLong("N 36\u00b018,617' W 115\u00b002,367'");

            Assert.That(maybeTuple, Is.Not.Null);
            Assert.That(maybeTuple?.Item1._hemisphere, Is.EqualTo(Longitude.Hemisphere.West));
            Assert.That(maybeTuple?.Item2._hemisphere, Is.EqualTo(Latitude.Hemisphere.North));

            Assert.That(maybeTuple?.Item1.ddmmmm.ddmm_mmm(), Is.EqualTo("115\u00b002.367’"));
            Assert.That(maybeTuple?.Item2.ddmmmm.ddmm_mmm(), Is.EqualTo("36\u00b018.617’"));
        }
    }
}