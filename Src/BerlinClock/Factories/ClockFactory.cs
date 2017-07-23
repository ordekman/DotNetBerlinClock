using System;
using BerlinClock.Models;

namespace BerlinClock.Factories
{
    /// <inheritdoc/>
    public class ClockFactory: IClockFactory
    {
        private readonly ITimePartFactory _timePartFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        public ClockFactory(): this(new TimePartFactory())
        {
        }

        internal ClockFactory(ITimePartFactory timePartFactory)
        {
            _timePartFactory = timePartFactory ?? throw new ArgumentNullException(nameof(timePartFactory));
        }

        /// <inheritdoc/>
        public IBerlinClock CreateBerlinClock(DateTime dateTime)
        {
            return CreateBerlinClock(dateTime.TimeOfDay);
        }

        /// <inheritdoc/>
        public IBerlinClock CreateBerlinClock(TimeSpan timeSpan)
        {
            return new Models.BerlinClock(timeSpan, _timePartFactory);
        }
    }
}
