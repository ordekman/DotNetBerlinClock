using System;
using System.Collections.Generic;
using BerlinClock.Models;

namespace BerlinClock
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
        public IBulbRow CreateHoursFirstRow()
        {
            var bulbs = new List<IBulb>();
            for (int i = 0; i < 4; i++)
            {
                bulbs.Add(_bulbFactory.CreateRedBulb());
            }
            return new BulbRow(bulbs, 5);
        }

        /// <inheritdoc/>
        public IBulbRow CreateHoursSecondRow()
        {
            var bulbs = new List<IBulb>();
            for (int i = 0; i < 4; i++)
            {
                bulbs.Add(_bulbFactory.CreateRedBulb());
            }
            return new BulbRow(bulbs, 1);
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

        /// <inheritdoc/>
        public IBulbRow CreateMinutesSecondRow()
        {
            var bulbs = new List<IBulb>();
            for (int i = 0; i < 4; i++)
            {
                bulbs.Add(_bulbFactory.CreateYellowBulb());
            }
            return new BulbRow(bulbs, 1);
        }
    }
}
