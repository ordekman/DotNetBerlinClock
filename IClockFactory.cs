using System;
using BerlinClock.Models;

namespace BerlinClock
{
    /// <summary>
    /// Interface for creating clock objects.
    /// </summary>
    public interface IClockFactory
    {
        /// <summary>
        /// Creates instance of <see cref="IBerlinClock"/>
        /// </summary>
        /// <param name="dateTime">Initial clock time</param>
        /// <returns>Instance of <see cref="IBerlinClock"/></returns>
        IBerlinClock CreateBerlinClock(DateTime dateTime);

        /// <summary>
        /// Creates instance of <see cref="IBerlinClock"/>
        /// </summary>
        /// <param name="timeSpan">Initial clock value</param>
        /// <returns>Instance of <see cref="IBerlinClock"/></returns>
        IBerlinClock CreateBerlinClock(TimeSpan timeSpan);
    }
}
