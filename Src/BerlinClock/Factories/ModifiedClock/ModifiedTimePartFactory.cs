using System;
using System.Collections.Generic;
using BerlinClock.Models;

namespace BerlinClock.Factories
{
    /// <summary>
    /// Factory for creating rows for Modified BerlinClock.
    /// </summary>
    public class ModifiedTimePartFactory : ITimePartFactory
    {
        private readonly IBulbRowFactory _bulbRowFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        public ModifiedTimePartFactory() : this(new BulbRowFactory())
        {
        }

        internal ModifiedTimePartFactory(IBulbRowFactory bulbRowFactory)
        {
            _bulbRowFactory = bulbRowFactory ?? throw new ArgumentNullException(nameof(bulbRowFactory));
        }

        /// <inheritdoc />
        public ITimePart CreateHoursPart()
        {
            return new TimePart(0, 24, new List<IBulbRow> { _bulbRowFactory.CreateAllRedBulbRow(4, 5), _bulbRowFactory.CreateAllRedBulbRow(4, 1) });
        }

        /// <inheritdoc />
        public ITimePart CreateMinutesPart()
        {
            return new TimePart(0, 59, new List<IBulbRow> { _bulbRowFactory.CreateMinutesFirstRow(), _bulbRowFactory.CreateAllYellowBulbRow(4, 1) });
        }

        /// <inheritdoc />
        public ITimePart CreateSecondsPart()
        {
            return new TimePart(0, 59, new List<IBulbRow> { _bulbRowFactory.CreateAllYellowBulbRow(2, 20), _bulbRowFactory.CreateAllYellowBulbRow(3, 5), _bulbRowFactory.CreateAllYellowBulbRow(4, 1) });
        }
    }
}
