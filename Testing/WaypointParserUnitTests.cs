using DTC.Models.v476;

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
            _parser.parseForFA18(Data.viperPlanWithNotes);
        }
    }
}