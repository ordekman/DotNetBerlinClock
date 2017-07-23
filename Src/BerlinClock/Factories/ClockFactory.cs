using System;
using BerlinClock.Models;

namespace BerlinClock.Factories
{
    /// <inheritdoc/>
    public class ClockFactory: IClockFactory
    {
        /// <inheritdoc/>
        public IBerlinClock CreateBerlinClock(DateTime dateTime)
        {
            return CreateBerlinClock(dateTime.TimeOfDay);
        }

        /// <inheritdoc/>
        public IBerlinClock CreateBerlinClock(TimeSpan timeSpan)
        {
            return new Models.BerlinClock(timeSpan);
        }
    }
}
