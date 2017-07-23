using System;

namespace BerlinClock
{
    class TimeParser: ITimeParser
    {
        public TimeSpan Parse(string time)
        {
            var timeParts = time.Split(':');
            if (timeParts.Length != 3)
            {
                throw new FormatException("Incorrect time format.");
            }
            if (Int32.TryParse(timeParts[0], out int hours) && hours < 25 &&
                Int32.TryParse(timeParts[1], out int minutes) && minutes < 60 &&
                Int32.TryParse(timeParts[2], out int seconds) && seconds < 60)
            {
                return new TimeSpan(0, hours, minutes, seconds);
            }
            throw new FormatException("Incorrect time format.");
        }
    }
}
