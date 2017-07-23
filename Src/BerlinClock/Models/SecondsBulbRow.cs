using System;
using System.Collections.Generic;
using System.Linq;

namespace BerlinClock.Models
{
    /// <summary>
    /// Represents seconds bulb row with specific <see cref="SetValue"/> method.
    /// </summary>
    public class SecondsBulbRow: BulbRow
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bulbs">Bulbs collection containing exactly one <see cref="IBulb"/>, otherwise <see cref="ArgumentException"/> is thrown</param>
        /// <param name="bulbValue">Bulb value</param>
        public SecondsBulbRow(IEnumerable<IBulb> bulbs, int bulbValue) : base(bulbs, bulbValue)
        {
            if (bulbs.Count() != 1)
                throw new ArgumentException("Seconds row must contain exactly 1 bulb.");
        }

        /// <summary>
        /// Sets value to <see cref="SecondsBulbRow"/>. If value is even, bulb is turned on.
        /// </summary>
        /// <param name="value">Value to be set</param>
        /// <returns>Always 0</returns>
        public override int SetValue(int value)
        {
            if (value % 2 == 0)
            {
                Bulbs.ToList().ForEach(b => b.TurnOn());
            }
            return 0;
        }
    }
}
