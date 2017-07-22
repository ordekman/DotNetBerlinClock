using System;
using System.Text;
using BerlinClock.Exceptions;

namespace BerlinClock.Models
{
    /// <inheritdoc/>
    public class BerlinClock: IBerlinClock
    {
        private readonly ITimePartFactory _timePartFactory;
        private readonly ITimePart _seconds;
        private readonly ITimePart _hours;
        private readonly ITimePart _minutes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dateTime">Initialization DateTime</param>
        public BerlinClock(DateTime dateTime): this(dateTime.TimeOfDay, new TimePartFactory())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="timeSpan">Initialization TimeSpan</param>
        public BerlinClock(TimeSpan timeSpan) : this(timeSpan, new TimePartFactory())
        {
        }

        internal BerlinClock(DateTime dateTime, ITimePartFactory timePartFactory): this(dateTime.TimeOfDay, timePartFactory)
        { 
        }

        internal BerlinClock(TimeSpan timeSpan, ITimePartFactory timePartFactory)
        {
            _timePartFactory = timePartFactory ?? throw new ArgumentNullException(nameof(timePartFactory));

            _seconds = _timePartFactory.CreateSecondsPart();
            _hours = _timePartFactory.CreateHoursPart();
            _minutes = _timePartFactory.CreateMinutesPart();

            Initialize(timeSpan);
        }

        private void Initialize(TimeSpan dateTime)
        {
            try
            {
                _seconds.SetValue(dateTime.Seconds);
                _hours.SetValue((int) Math.Floor(dateTime.TotalHours));
                _minutes.SetValue(dateTime.Minutes);
            }
            catch (Exception e)
            {
                var errorMsg = "Error occured during initialization.";
                Console.WriteLine(errorMsg);
                throw new BerlinClockException(errorMsg, e);
            }
        }

        /// <inheritdoc/>
        public string Draw()
        {
            var builder = new StringBuilder();
            builder.AppendLine(_seconds.Draw());
            builder.AppendLine(_hours.Draw()); 
            builder.Append(_minutes.Draw());
            return builder.ToString();
        }
    }
}
