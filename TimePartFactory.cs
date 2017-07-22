﻿using System;
using System.Collections.Generic;
using BerlinClock.Models;

namespace BerlinClock
{
    /// <inheritdoc />
    public class TimePartFactory: ITimePartFactory
    {
        private readonly IBulbRowFactory _bulbRowFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        public TimePartFactory(): this(new BulbRowFactory())
        {
        }

        internal TimePartFactory(IBulbRowFactory bulbRowFactory)
        {
            _bulbRowFactory = bulbRowFactory ?? throw new ArgumentNullException(nameof(bulbRowFactory));
        }

        /// <inheritdoc />
        public ITimePart CreateHoursPart()
        {
            return new TimePart(0, 24, new List<IBulbRow> {_bulbRowFactory.CreateHoursFirstRow(), _bulbRowFactory.CreateHoursSecondRow()});
        }

        /// <inheritdoc />
        public ITimePart CreateMinutesPart()
        {
            return new TimePart(0, 59, new List<IBulbRow> {_bulbRowFactory.CreateMinutesFirstRow(), _bulbRowFactory.CreateMinutesSecondRow()});
        }

        /// <inheritdoc />
        public ITimePart CreateSecondsPart()
        {
            return new TimePart(0, 59, new List<IBulbRow> { _bulbRowFactory.CreateSecondsRow() });
        }
    }
}
