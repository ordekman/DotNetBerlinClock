using System;
using BerlinClock.Classes;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BerlinClock.Tests.BDD
{
    [Binding]
    class TheBerlinClockSteps
    {
        private readonly ITimeConverter _berlinClock = new TimeConverter();
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

        [Then(@"the format exception should be thrown")]
        public void ThenTheFormatExceptionShouldBeThrown()
        {
            Assert.Throws<FormatException>(() => _berlinClock.ConvertTime(_theTime));
        }
    }
}
