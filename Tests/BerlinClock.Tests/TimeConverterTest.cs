using System;
using BerlinClock.Classes;
using BerlinClock.Factories;
using BerlinClock.Models;
using Moq;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    class TimeConverterTest
    {
        [Test]
        public void Constructor_ArgumentsAreNull_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new TimeConverter(null, null));
        }

        [Test]
        public void Convert_InputStringIsCorrect_TimeIsConverted()
        {
            var inputString = "testString";
            var outputString = "testOutputString";
            var convertedTimeSpan = TimeSpan.FromHours(23);

            var timeParserMock = new Mock<ITimeParser>(MockBehavior.Strict);
            timeParserMock.Setup(m => m.Parse(It.Is<string>(p => p == inputString))).Returns(convertedTimeSpan);

            var berlinClockMock = new Mock<IBerlinClock>(MockBehavior.Strict);
            berlinClockMock.Setup(m => m.Draw()).Returns(outputString);

            var clockFactoryMock = new Mock<IClockFactory>(MockBehavior.Strict);
            clockFactoryMock.Setup(m => m.CreateBerlinClock(It.Is<TimeSpan>(p => p == convertedTimeSpan))).Returns(berlinClockMock.Object);

            var timeConverter = new TimeConverter(timeParserMock.Object, clockFactoryMock.Object);
            string result = timeConverter.ConvertTime(inputString);

            Assert.AreEqual(outputString, result);
            timeParserMock.Verify(m => m.Parse(It.Is<string>(p => p == inputString)), Times.Once);
            clockFactoryMock.Verify(m => m.CreateBerlinClock(It.Is<TimeSpan>(p => p == convertedTimeSpan)), Times.Once);
            berlinClockMock.Verify(m => m.Draw(), Times.Once);
        }
    }
}
