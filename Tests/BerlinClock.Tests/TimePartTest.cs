using System;
using System.Collections.Generic;
using System.Linq;
using BerlinClock.Models;
using Moq;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    class TimePartTest
    {
        [Test]
        public void Constructor_MinIsGreaterThanMax_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new TimePart(10, 5, Enumerable.Empty<IBulbRow>()));
        }

        [Test]
        public void Constructor_ArgumentRowsIsNull_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new TimePart(1, 2, null));
        }

        [TestCase(1, 10, 1)]
        [TestCase(10, 100, 10)]
        [TestCase(100, 1000, 10)]
        public void SetValue_ValueIsValid_CorrectValueIsSetToRows(int bulbRowCount, int valueToBeSet, int remainingValue)
        {
            List<Mock<IBulbRow>> bulbRowMocks = PrepareBulbRowCollection(bulbRowCount, remainingValue);
            var timePart = new TimePart(1, 1000, bulbRowMocks.Select(br => br.Object));

            timePart.SetValue(valueToBeSet);

            VerifyRowsWasSetWithCorrectValues(bulbRowMocks, valueToBeSet, remainingValue);
        }

        [TestCase(-1, "value")]
        [TestCase(101, "value")]
        public void SetValue_ValueIsIncorrect_ExceptionIsThrown(int valueToBeSet, string paramName)
        {
            var timePart = new TimePart(1, 100, Enumerable.Empty<IBulbRow>());
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => timePart.SetValue(valueToBeSet));
            Assert.AreEqual(ex.ParamName, paramName);
        }

        [TestCase(1, ExpectedResult = "YYYY")]
        [TestCase(2, ExpectedResult = "YYYY\r\nYYYY")]
        [TestCase(10, ExpectedResult = "YYYY\r\nYYYY\r\nYYYY\r\nYYYY\r\nYYYY\r\nYYYY\r\nYYYY\r\nYYYY\r\nYYYY\r\nYYYY")]
        public string Draw_PartContainsRows_CorrectStringIsDrawn(int bulbRowCount)
        {
            List<Mock<IBulbRow>> bulbRowMocks = PrepareBulbRowCollection(bulbRowCount, 1);
            var timePart = new TimePart(1, 1000, bulbRowMocks.Select(br => br.Object));

            return timePart.Draw();
        }

        public void Draw_PartConstainsNoRow_EmptyStringIsDrawn()
        {
            var timePart = new TimePart(1, 1000, new List<IBulbRow> {PrepareBulbRow(1).Object});
            Assert.AreEqual("", timePart.Draw());
        }

        private void VerifyRowsWasSetWithCorrectValues(List<Mock<IBulbRow>> bulbRowMocks, int valueToBeSet, int remainingValue)
        {
            for (int i = 0; i < bulbRowMocks.Count; i++)
            {
                var rowMock = bulbRowMocks[i];
                var rowValue = i == 0 ? valueToBeSet : remainingValue;
                rowMock.Verify(m => m.SetValue(It.Is<int>(p => p == rowValue)), Times.Once);
            }
        }

        private List<Mock<IBulbRow>> PrepareBulbRowCollection(int count, int rowReturnValue)
        {
            var bulbRows = new List<Mock<IBulbRow>>();
            for (int i = 0; i < count; i++)
            {
                bulbRows.Add(PrepareBulbRow(rowReturnValue));
            }
            return bulbRows;
        }

        private Mock<IBulbRow> PrepareBulbRow(int rowReturnValue)
        {
            var mock = new Mock<IBulbRow>();
            mock.Setup(m => m.SetValue(It.IsAny<int>())).Returns(rowReturnValue);
            mock.Setup(m => m.Draw()).Returns("YYYY");
            return mock;
        }
    }
}
