using System;

namespace BerlinClock
{
    /// <summary>
    /// Parser for turning <see cref="string"/> into <see cref="TimeSpan"/>
    /// </summary>
    public interface ITimeParser
    {
        /// <summary>
        /// Parses <see cref="string"/> value
        /// </summary>
        /// <param name="time">Time string to be parsed</param>
        /// <returns><see cref="TimeSpan"/> value</returns>
        TimeSpan Parse(string time);
    }
}
