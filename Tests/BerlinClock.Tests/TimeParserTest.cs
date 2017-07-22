using System;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    class TimeParserTest
    {
        [TestCase("00:00:00", 0, 0, 0, 0)]
        [TestCase("0:0:0", 0, 0, 0, 0)]
        [TestCase("01:01:01", 0, 1, 1, 1)]
        [TestCase("1:1:1", 0, 1, 1, 1)]
        [TestCase("23:59:59", 0, 23, 59, 59)]
        [TestCase("24:59:59", 1, 0, 59, 59)]
        public void Parse_InputTimeStringIsValid_StringIsParsed(string input, int expectedDays, int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            TimeSpan timeSpan = new TimeParser().Parse(input);
            Assert.AreEqual(expectedDays, timeSpan.Days);
            Assert.AreEqual(expectedHours, timeSpan.Hours);
            Assert.AreEqual(expectedMinutes, timeSpan.Minutes);
            Assert.AreEqual(expectedSeconds, timeSpan.Seconds);
        }

        [TestCase("")]
        [TestCase("00:00")]
        [TestCase("00:00:60")]
        [TestCase("00:60:00")]
        [TestCase("25:00:00")]
        [TestCase("a:00:00")]
        [TestCase("00:a:00")]
        [TestCase("00:00:a")]
        public void Parse_InputTimeStringIsInvalid_ExceptionIsThrown(string input)
        {
            Assert.Throws<FormatException> (() => new TimeParser().Parse(input));
        }
    }
}
