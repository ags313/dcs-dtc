using DTC.Models.v476;
using Microsoft.VisualBasic.CompilerServices;
using static DTC.Models.v476.RecordType;

namespace Testing
{
    public class WaypointParserUnitTests : LocaleAwareUnitTestBase
    {
        private WaypointSystemParser _parser;

        public WaypointParserUnitTests(string locale) : base(locale)
        {
        }

        [SetUp]
        public new void Setup()
        {
            _parser = new WaypointSystemParser();
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

            _parser.parseForFA18(Data.karma20240106);
        }

        [Test]
        public void LocoFormats()
        {
            var input = """
                        Flight Plan
                        #	Type	Name	Fix/Point	Location	Elev	Alt	SPD	ETE/TOT	Leg Fuel
                        8	TGT		SA-2	N 26°34.736' E 055°22.962'	25				
                        9	TGT		SA-5	N 26°43.768' E 055°55.410'	25				
                        10									
                        11	RVIP		THEBES	N 25°15.000' E 056°00.000'	27000		
                        """;
            var waypoints = _parser.parseForF16(input);
        }
    }
}