using System;
using System.Collections.Generic;
using System.Linq;
using BerlinClock.Models;
using Moq;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    class BulbRowTest
    {
        [Test]
        public void Constructor_ArgumentBulbsIsNull_ExceptionIsThrown()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new BulbRow(null, 1));
            Assert.AreEqual(ex.ParamName, "bulbs");
        }

        [Test]
        public void Constructor_ArgumentBulbValueIsInvalid_ExceptionIsThrown()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new BulbRow(Enumerable.Empty<IBulb>(), 0));
            Assert.AreEqual(ex.ParamName, "bulbValue");
        }

        [TestCase(1, 1, 0, 0)]
        [TestCase(1, 1, 1, 1)]
        [TestCase(4, 1, 4, 4)]
        [TestCase(4, 5, 0, 0)]
        [TestCase(4, 5, 20, 4)]
        [TestCase(4, 5, 17, 3)]
        public void SetValue_ValueIsValid_CorrectNumberOfBulbWasTurnedOn(int bulbCount, int bulbValue, int valueToBeSet, int onBulbCount)
        {
            List<Mock<IBulb>> bulbs = PrepareBulbMockCollection(bulbCount);
            var row = new BulbRow(bulbs.Select(b => b.Object), bulbValue);

            int remaining = row.SetValue(valueToBeSet);

            Assert.AreEqual(valueToBeSet % bulbValue, remaining);
            VerifyFirstNBulbsWasTurnedOn(onBulbCount, bulbs);
        }

        [TestCase(1, 1, -1)]
        [TestCase(1, 1, 2)]
        [TestCase(5, 5, 30)]
        public void SetValue_ValueIsIncorrect_ExceptionIsThrown(int bulbCount, int bulbValue, int valueToBeSet)
        {
            List<Mock<IBulb>> bulbs = PrepareBulbMockCollection(bulbCount);
            var row = new BulbRow(bulbs.Select(b => b.Object), bulbValue);
            Assert.Throws<ArgumentOutOfRangeException>(() => row.SetValue(valueToBeSet));
        }

        [TestCase(1, ExpectedResult = "Y")]
        [TestCase(10, ExpectedResult = "YYYYYYYYYY")]
        public string Draw_RowContainsBulbs_CorrectStringIsDrawn(int bulbCount)
        {
            List<Mock<IBulb>> bulbs = PrepareBulbMockCollection(bulbCount);
            var row = new BulbRow(bulbs.Select(b => b.Object), 5);
            return row.Draw();
        }

        [Test]
        public void Draw_RowHasNoBulb_EmptyStringIsDrawn()
        {
            var row = new BulbRow(Enumerable.Empty<IBulb>(), 5);
            Assert.AreEqual("", row.Draw());
        }

        private static List<Mock<IBulb>> PrepareBulbMockCollection(int count)
        {
            var bulbs = new List<Mock<IBulb>>();
            for (int i = 0; i < count; i++)
            {
                bulbs.Add(PrepareBulbMock());
            }
            return bulbs;
        }

        protected static Mock<IBulb> PrepareBulbMock()
        {
            var bulb = new Mock<IBulb>(MockBehavior.Strict);
            bulb.Setup(m => m.TurnOn());
            bulb.Setup(m => m.Draw()).Returns("Y");
            return bulb;
        }

        private static void VerifyFirstNBulbsWasTurnedOn(int n, IList<Mock<IBulb>> bulbs)
        {
            var onBulbs = bulbs.Take(n);
            onBulbs.ToList().ForEach(b => b.Verify(m => m.TurnOn(), Times.Once));

            var offBulbs = bulbs.Skip(n);
            offBulbs.ToList().ForEach(b => b.Verify(m => m.TurnOn(), Times.Never));
        }
    }
}
