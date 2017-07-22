using System;
using BerlinClock.Models;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    class BulbTest
    {
        [Test]
        public void TurnOn_BulbIsOff_BulbIsOn()
        {
            var bulb = new Bulb(Char.MaxValue, Char.MinValue);
            Assert.IsFalse(bulb.IsOn);

            bulb.TurnOn();

            Assert.IsTrue(bulb.IsOn);
        }

        [Test]
        public void Draw_BulbIsOff_BulbOffStringIsDrawn()
        {
            var bulb = new Bulb(Char.MaxValue, Char.MinValue);
            Assert.IsFalse(bulb.IsOn);

            Assert.AreEqual(Char.MinValue.ToString(), bulb.Draw());
        }

        [Test]
        public void Draw_BulbIsOn_BulbOnStringIsDrawn()
        {
            var bulb = new Bulb(Char.MaxValue, Char.MinValue);
            bulb.TurnOn();
            Assert.IsTrue(bulb.IsOn);

            Assert.AreEqual(Char.MaxValue.ToString(), bulb.Draw());
        }
    }
}
