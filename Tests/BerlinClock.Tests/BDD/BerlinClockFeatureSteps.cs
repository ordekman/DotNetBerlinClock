using System;
using BerlinClock.Classes;
using BerlinClock.Factories;
using BerlinClock.Factories.ModifiedClock;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BerlinClock.Tests.BDD
{
    [Binding]
    class TheBerlinClockSteps
    {
        private readonly ITimeConverter _berlinClock = new TimeConverter();
        private readonly ITimeConverter _modifiedBerlinClock = new TimeConverter(new TimeParser(), new ClockFactory(new ModifiedTimePartFactory()));
        private String _theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            _theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(theExpectedBerlinClockOutput, _berlinClock.ConvertTime(_theTime));
        }

        [Then(@"the modified clock should look like")]
        public void ThenTheModifiedClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(theExpectedBerlinClockOutput, _modifiedBerlinClock.ConvertTime(_theTime));
        }

        [Then(@"the format exception should be thrown")]
        public void ThenTheFormatExceptionShouldBeThrown()
        {
            Assert.Throws<FormatException>(() => _berlinClock.ConvertTime(_theTime));
        }
    }
}
