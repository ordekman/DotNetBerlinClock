using BerlinClock.Models;

namespace BerlinClock.Factories
{
    /// <summary>
    /// Factory for creating time parts <see cref="ITimePart"/>
    /// </summary>
    public interface ITimePartFactory
    {
        /// <summary>
        /// Creates hours <see cref="ITimePart"/>
        /// </summary>
        /// <returns>Hours <see cref="ITimePart"/></returns>
        ITimePart CreateHoursPart();

        /// <summary>
        /// Creates minutes <see cref="ITimePart"/>
        /// </summary>
        /// <returns>Minutes <see cref="ITimePart"/></returns>
        ITimePart CreateMinutesPart();

        /// <summary>
        /// Creates seconds <see cref="ITimePart"/>
        /// </summary>
        /// <returns>Seconds <see cref="ITimePart"/></returns>
        ITimePart CreateSecondsPart();
    }
}
