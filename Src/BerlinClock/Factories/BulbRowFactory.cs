using System;
using System.Collections.Generic;
using BerlinClock.Models;

namespace BerlinClock.Factories
{
    /// <inheritdoc/>
    public class BulbRowFactory: IBulbRowFactory
    {
        private readonly IBulbFactory _bulbFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        public BulbRowFactory(): this(new BulbFactory())
        {
        }

        internal BulbRowFactory(IBulbFactory bulbFactory)
        {
            _bulbFactory = bulbFactory ?? throw new ArgumentNullException(nameof(bulbFactory));
        }

        /// <inheritdoc/>
        public IBulbRow CreateSecondsRow()
        {
            return new SecondsBulbRow(new List<IBulb> {_bulbFactory.CreateYellowBulb()}, 1);
        }

        /// <inheritdoc/>
        public IBulbRow CreateAllRedBulbRow(int bulbCount, int bulbValue)
        {
            var bulbs = new List<IBulb>();
            for (int i = 0; i < bulbCount; i++)
            {
                bulbs.Add(_bulbFactory.CreateRedBulb());
            }
            return new BulbRow(bulbs, bulbValue);
        }

        /// <inheritdoc/>
        public IBulbRow CreateAllYellowBulbRow(int bulbCount, int bulbValue)
        {
            var bulbs = new List<IBulb>();
            for (int i = 0; i < bulbCount; i++)
            {
                bulbs.Add(_bulbFactory.CreateYellowBulb());
            }
            return new BulbRow(bulbs, bulbValue);
        }

        /// <inheritdoc/>
        public IBulbRow CreateMinutesFirstRow()
        {
            var bulbs = new List<IBulb>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    bulbs.Add(_bulbFactory.CreateYellowBulb());
                }
                if (i != 3)
                {
                    bulbs.Add(_bulbFactory.CreateRedBulb());
                }
            }
            return new BulbRow(bulbs, 5);
        }
    }
}
