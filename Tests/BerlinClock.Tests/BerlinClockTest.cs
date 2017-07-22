using System;
using BerlinClock.Exceptions;
using BerlinClock.Models;
using Moq;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    class BerlinClockTest
    {
        private Mock<ITimePartFactory> _factoryMock;
        private Mock<ITimePart> _secondsTimePartMock;
        private Mock<ITimePart> _hoursTimePartMock;
        private Mock<ITimePart> _minutesTimePartMock;

        [SetUp]
        public void SetUp()
        {
            _factoryMock = PrepareTimePartFactoryMock();
        }

        [TestCase(0, 0, 0)]
        [TestCase(59, 23, 59)]
        [TestCase(30, 12, 30)]
        public void Constructor_CorrectDateTimeIsPassed_CorrectValuesAreSetToComponents(int seconds, int hours, int minutes)
        {
            var time = new DateTime(1, 1, 1, hours, minutes, seconds);
            var clock = new Models.BerlinClock(time, _factoryMock.Object);

            VerifyMocks(seconds, hours, minutes);
        }

        [TestCase(0, 0, 0)]
        [TestCase(59, 23, 59)]
        [TestCase(30, 12, 30)]
        [TestCase(59, 24, 59)]
        [TestCase(59, 100, 59)]
        public void Constructor_CorrectTimeSpanIsPassed_CorrectValuesAreSetToComponents(int seconds, int hours, int minutes)
        {
            var timespan = new TimeSpan(0, hours, minutes, seconds);
            var clock = new Models.BerlinClock(timespan, _factoryMock.Object);

            VerifyMocks(seconds, hours, minutes);
        }

        [Test]
        public void Constructor_ComponentThrowsException_ExceptionIsThrown()
        {
            _secondsTimePartMock.Setup(m => m.SetValue(It.IsAny<int>())).Throws<ArgumentOutOfRangeException>();
            var ex = Assert.Throws<BerlinClockException>(() => new Models.BerlinClock(TimeSpan.MinValue, _factoryMock.Object));
            Assert.IsNotNull(ex.InnerException);
            Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.InnerException.GetType());
        }

        [Test]
        public void Constructor_ArgumentFactoryIsNull_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new Models.BerlinClock(TimeSpan.MinValue, null));
        }

        [Test]
        public void Draw_CorrectStringIsDrawn()
        {
            var clock = new Models.BerlinClock(TimeSpan.MinValue, _factoryMock.Object);
            Assert.AreEqual("O\r\nOOROOR\r\nO\r\nOOROOR\r\nO\r\nOOROOR", clock.Draw());
        }

        private void VerifyMocks(int seconds, int hours, int minutes)
        {
            _factoryMock.Verify(m => m.CreateSecondsPart(), Times.Once);
            _factoryMock.Verify(m => m.CreateHoursPart(), Times.Once);
            _factoryMock.Verify(m => m.CreateMinutesPart(), Times.Once);

            _secondsTimePartMock.Verify(m => m.SetValue(It.Is<int>(p => p == seconds)), Times.Once);
            _hoursTimePartMock.Verify(m => m.SetValue(It.Is<int>(p => p == hours)), Times.Once);
            _minutesTimePartMock.Verify(m => m.SetValue(It.Is<int>(p => p == minutes)), Times.Once);
        }

        private Mock<ITimePartFactory> PrepareTimePartFactoryMock()
        {
            var factoryMock = new Mock<ITimePartFactory>(MockBehavior.Strict);

            _secondsTimePartMock = PrepareTimePartMock();
            _hoursTimePartMock = PrepareTimePartMock();
            _minutesTimePartMock = PrepareTimePartMock();

            factoryMock.Setup(m => m.CreateHoursPart()).Returns(_hoursTimePartMock.Object);
            factoryMock.Setup(m => m.CreateMinutesPart()).Returns(_minutesTimePartMock.Object);
            factoryMock.Setup(m => m.CreateSecondsPart()).Returns(_secondsTimePartMock.Object);
            return factoryMock;
        }

        private static Mock<ITimePart> PrepareTimePartMock()
        {
            var timePartMock = new Mock<ITimePart>(MockBehavior.Strict);
            timePartMock.Setup(m => m.SetValue(It.IsAny<int>()));
            timePartMock.Setup(m => m.Draw()).Returns("O\r\nOOROOR");
            return timePartMock;
        }
    }
}
