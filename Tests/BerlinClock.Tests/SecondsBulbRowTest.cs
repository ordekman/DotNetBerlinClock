using System;
using System.Collections.Generic;
using System.Linq;
using BerlinClock.Models;
using Moq;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    class SecondsBulbRowTest
    {
        [Test]
        public void Constructor_InvalidBulbsCount_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new SecondsBulbRow(Enumerable.Empty<IBulb>(), 1));
        }

        [TestCaseSource(nameof(_oddTestCases))]
        public void SetValue_ValueIsOdd_BulbWasNotTurnedOn(int valueToBeSet, bool bulbIsOn)
        {
            var bulbMock = PrepareBulbMock();
            var row = new SecondsBulbRow(new List<IBulb> {bulbMock.Object}, 1);

            row.SetValue(valueToBeSet);

            bulbMock.Verify(m => m.TurnOn(), Times.Never);
        }

        [TestCaseSource(nameof(_evenTestCases))]
        public void SetValue_ValueIsEven_BulbWasTurnedOn(int valueToBeSet, bool bulbIsOn)
        {
            var bulbMock = PrepareBulbMock();
            var row = new SecondsBulbRow(new List<IBulb> { bulbMock.Object }, 1);

            row.SetValue(valueToBeSet);

            bulbMock.Verify(m => m.TurnOn(), Times.Once);
        }

        private static object[][] _oddTestCases = GenerateTestCases(1, 60, true);
        private static object[][] _evenTestCases = GenerateTestCases(0, 60, false);

        private static object[][] GenerateTestCases(int mod, int limit, bool bulbIsOn)
        {
            var numbers = new List<object[]>();
            for (int i = 0; i < limit; i++)
            {
                if (i % 2 == mod)
                {
                    numbers.Add(new [] {(object)i, bulbIsOn});
                }
            }
            return numbers.ToArray();
        }

        protected static Mock<IBulb> PrepareBulbMock()
        {
            var bulb = new Mock<IBulb>(MockBehavior.Strict);
            bulb.Setup(m => m.TurnOn());
            bulb.Setup(m => m.Draw()).Returns("Y");
            return bulb;
        }
    }
}
