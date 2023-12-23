using DTC.Models.v476;
using Microsoft.VisualBasic.CompilerServices;

namespace Testing
{
    public class WaypointParserUnitTests
    {
        private WaypointSystemParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new WaypointSystemParser();
        }

        [Test]
        public void shouldDetectTopLine()
        {
            Assert.That(RecordType.FlightPlanIndicator, Is.EqualTo(_parser.detect("Flight Plan")));
        }

        [Test]
        public void shouldDetectFlightPlanHeader()
        {
            Assert.That(RecordType.FlightPlanHeader, Is.EqualTo(_parser.detect("#	Type	Name	Fix/Point	Location	Elev	Alt	SPD	ETE/TOT")));
        }

        [Test]
        public void shouldDetectWaypoint()
        {
            Assert.That(RecordType.Waypoint, Is.EqualTo(_parser.detect("13\tOBJ\t\t4808A.1\tN 37\u00b028.000' W 116\u00b000.050'")));
        }
       
        [Test]
        public void DetectLine_ReturnsEmptyRow_ForEmptyWaypoint()
        {
            Assert.That(_parser.detect("17\t\t\t\t\t\t\t\t\t"), Is.EqualTo(RecordType.EmptyRow)); 
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
    }
}