using BerlinClock.Models;

namespace BerlinClock
{
    /// <inheritdoc />
    public class BulbFactory: IBulbFactory
    {
        /// <inheritdoc />
        public IBulb CreateRedBulb()
        {
            return new Bulb('R', 'O');
        }

        /// <inheritdoc />
        public IBulb CreateYellowBulb()
        {
            return new Bulb('Y', 'O');
        }
    }
}
