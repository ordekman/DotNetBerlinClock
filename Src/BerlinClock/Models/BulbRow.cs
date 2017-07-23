using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock.Models
{
    /// <inheritdoc/>
    public class BulbRow: IBulbRow
    {
        private readonly int _bulbValue;

        /// <summary>
        /// Bulb collection
        /// </summary>
        protected readonly IEnumerable<IBulb> Bulbs;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bulbs">Bulbs collection</param>
        /// <param name="bulbValue">Value of each bulb</param>
        public BulbRow(IEnumerable<IBulb> bulbs, int bulbValue)
        {
            if (bulbValue <= 0)
                throw new ArgumentOutOfRangeException(nameof(bulbValue));
            _bulbValue = bulbValue;

            Bulbs = bulbs ?? throw new ArgumentNullException(nameof(bulbs));
        }

        /// <inheritdoc/>
        public string Draw()
        {
            var builder = new StringBuilder();
            Bulbs.ToList().ForEach(b => builder.Append(b.Draw()));
            return builder.ToString();
        }

        /// <inheritdoc/>
        public virtual int SetValue(int value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));

            var toLightOn = value / _bulbValue;
            if (toLightOn > Bulbs.Count())
                throw new ArgumentOutOfRangeException(nameof(value));

            Bulbs.Take(toLightOn).ToList().ForEach(b => b.TurnOn());

            return value % _bulbValue;
        }
    }
}
