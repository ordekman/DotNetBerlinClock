using BerlinClock.Models;

namespace BerlinClock
{
    /// <summary>
    /// Factory for creating <see cref="IBulb"/> instances.
    /// </summary>
    public interface IBulbFactory
    {
        /// <summary>
        /// Creates instance of <see cref="IBulb"/> for red bulb.
        /// </summary>
        /// <returns>Instance of <see cref="IBulb"/> for red bulb</returns>
        IBulb CreateRedBulb();

        /// <summary>
        /// Creates instance of <see cref="IBulb"/> for yellow bulb.
        /// </summary>
        /// <returns>Instance of <see cref="IBulb"/> for yellow bulb</returns>
        IBulb CreateYellowBulb();
    }
}
