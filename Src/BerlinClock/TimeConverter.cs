using System;
using BerlinClock.Factories;

namespace BerlinClock.Classes
{
    /// <inheritdoc/>
    public class TimeConverter : ITimeConverter
    {
        private readonly IClockFactory _clockFactory;
        private readonly ITimeParser _timeParser;

        /// <summary>
        /// Constructor
        /// </summary>
        public TimeConverter(): this(new TimeParser(), new ClockFactory())
        {
        }

        internal TimeConverter(ITimeParser timeParser, IClockFactory clockFactory)
        {
            _clockFactory = clockFactory ?? throw new ArgumentNullException(nameof(clockFactory));
            _timeParser = timeParser ?? throw new ArgumentNullException(nameof(timeParser));
        }

        /// <inheritdoc/>
        public string ConvertTime(string time)
        {
            TimeSpan timeSpan = _timeParser.Parse(time);
            string result = _clockFactory.CreateBerlinClock(timeSpan).Draw();
            return result;
        }
    }
}
