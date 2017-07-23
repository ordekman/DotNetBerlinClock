using BerlinClock.Models;

namespace BerlinClock.Factories
{
    /// <summary>
    /// Factory for creating <see cref="IBulbRow"/>
    /// </summary>
    public interface IBulbRowFactory
    {
        /// <summary>
        /// Creates instance of <see cref="IBulbRow"/> for seconds row.
        /// </summary>
        /// <returns>Instance of <see cref="IBulbRow"/> for seconds row</returns>
        IBulbRow CreateSecondsRow();

        /// <summary>
        /// Creates instance of <see cref="IBulbRow"/> for first hours row.
        /// </summary>
        /// <returns>Instance of <see cref="IBulbRow"/> for first hours row</returns>
        IBulbRow CreateHoursFirstRow();

        /// <summary>
        /// Creates instance of <see cref="IBulbRow"/> for second hours row.
        /// </summary>
        /// <returns>Instance of <see cref="IBulbRow"/> for second hours row</returns>
        IBulbRow CreateHoursSecondRow();

        /// <summary>
        /// Creates instance of <see cref="IBulbRow"/> for first minutes row.
        /// </summary>
        /// <returns>Instance of <see cref="IBulbRow"/> for first minutes row</returns>
        IBulbRow CreateMinutesFirstRow();

        /// <summary>
        /// Creates instance of <see cref="IBulbRow"/> for second minutes row.
        /// </summary>
        /// <returns>Instance of <see cref="IBulbRow"/> for second minutes row</returns>
        IBulbRow CreateMinutesSecondRow();
    }
}
