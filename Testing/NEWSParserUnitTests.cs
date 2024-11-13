using DTC.Models.v476.coordinates;
using NUnit.Framework;

namespace Testing
{
    public class NEWSParserUnitTests
    {

        [Test]
        [TestCase("N37\u00b0 33.74' ", "N", "37", "33", "74", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N 37 33 74 ", "N", "37", "33", "74", CoordinateFormat.Unknown, CoordinatePrecision.Unknown)]
        [TestCase("N 37 33.74 ", "N", "37", "33", "74", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N 37 33,74 ", "N", "37", "33", "74", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N37 33.74", "N", "37", "33", "74", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N37 33'74\"", "N", "37", "33", "74", CoordinateFormat.DDMMSS, CoordinatePrecision.DescendingUnits)]
        [TestCase("N37º33.74\"", "N", "37", "33", "74", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N37º33.74'", "N", "37", "33", "74", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N37º33,74", "N", "37", "33", "74", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N 38 14.044 W", "N", "38", "14", "044", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N 38 14,044 W", "N", "38", "14", "044", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N 13\u00b034.82514'", "N", "13", "34", "82514", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        public void Should_recognise_formats(string input,
            string hemisphere,
            string major,
            string minor,
            string fractions,
            CoordinateFormat coordinateFormat,
            CoordinatePrecision coordinatePrecision)
        {
            var parser = new NEWSParser();
            var coordinates = parser.parse(input);
            Assert.That(coordinates.Count, Is.EqualTo(1));

            var first = coordinates[0];
            Assert.That(first.Major, Is.EqualTo(major));
            Assert.That(first.Minor, Is.EqualTo(minor));
            Assert.That(first.Fraction, Is.EqualTo(fractions));
            Assert.That(first.Hemisphere, Is.EqualTo(hemisphere));

            Assert.That(first.Format, Is.EqualTo(coordinateFormat));
            Assert.That(first.Precision, Is.EqualTo(coordinatePrecision));
        }

        [Test]
        [TestCase("N37\u00b0 33.74' W116\u00b0 39.85'", "W", "116", "39", "85", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N37\u00b0 33.74' W 116 39.85\"", "W", "116", "39", "85", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N37\u00b0 33,74' W 116 39.85\"", "W", "116", "39", "85", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N37\u00b0 33.74' W 116 39.85'", "W", "116", "39", "85", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N37\u00b0 33,74' W 116 39.85'", "W", "116", "39", "85", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N37 33.74W116 39.85", "W", "116", "39", "85", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N37 33,74W116 39.85", "W", "116", "39", "85", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N 38 14.044 W 115 00.170", "W", "115", "00", "170", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        [TestCase("N 38 14,044 W 115 00.170", "W", "115", "00", "170", CoordinateFormat.DDMMMM, CoordinatePrecision.Fractions)]
        public void Should_Parse_Second_Coordinate(string input,
            string hemisphere,
            string major,
            string minor,
            string fractions,
            CoordinateFormat coordinateFormat,
            CoordinatePrecision coordinatePrecision)
        {
            var parser = new NEWSParser();
            var coordinates = parser.parse(input);
            Assert.That(coordinates.Count, Is.EqualTo(2));

            var second = coordinates[1];
            Assert.That(second.Major, Is.EqualTo(major));
            Assert.That(second.Minor, Is.EqualTo(minor));
            Assert.That(second.Fraction, Is.EqualTo(fractions));
            Assert.That(second.Hemisphere, Is.EqualTo(hemisphere));

            Assert.That(second.Format, Is.EqualTo(coordinateFormat));
            Assert.That(second.Precision, Is.EqualTo(coordinatePrecision));
        }
    }
}