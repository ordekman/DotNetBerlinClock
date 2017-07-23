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
        /// Creates instance of <see cref="IBulbRow"/> for first minutes row.
        /// </summary>
        /// <returns>Instance of <see cref="IBulbRow"/> for first minutes row</returns>
        IBulbRow CreateMinutesFirstRow();


        /// <summary>
        /// Creates row with red bulbs.
        /// </summary>
        /// <param name="bulbCount">Count of bulbs</param>
        /// <param name="bulbValue">Bulb value</param>
        /// <returns>Instance of <see cref="IBulbRow"/></returns>
        IBulbRow CreateAllRedBulbRow(int bulbCount, int bulbValue);

        /// <summary>
        /// Creates row with yellow bulbs.
        /// </summary>
        /// <param name="bulbCount">Count of bulbs</param>
        /// <param name="bulbValue">Bulb value</param>
        /// <returns>Instance of <see cref="IBulbRow"/></returns>
        IBulbRow CreateAllYellowBulbRow(int bulbCount, int bulbValue);
    }
}
