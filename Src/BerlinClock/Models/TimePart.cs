using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock.Models
{
    /// <inheritdoc />
    public class TimePart: ITimePart
    {
        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly IEnumerable<IBulbRow> _rows;

        private int _value;

        internal TimePart(int minValue, int maxValue, IEnumerable<IBulbRow> rows)
        {
            _rows = rows ?? throw new ArgumentNullException(nameof(rows));
            if (minValue > maxValue)
                throw new ArgumentException($" {nameof(minValue)} cannot be greater than {nameof(maxValue)}");

            _minValue = minValue;
            _maxValue = maxValue;
            
        }

        /// <inheritdoc />
        public void SetValue(int value)
        {
            if (value > _maxValue || value < _minValue)
                throw new ArgumentOutOfRangeException(nameof(value));

            _value = value;
            var remainingValue = value;
            foreach (var bulbRow in _rows)
            {
                remainingValue = bulbRow.SetValue(remainingValue);
            }      
        }

        /// <inheritdoc />
        public int Value => _value;

        /// <inheritdoc />
        public string Draw()
        {
            if (!_rows.Any())
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            var last = _rows.Last();
            foreach (var bulbRow in _rows)
            {
                builder.Append(bulbRow.Draw());
                if (bulbRow != last)
                {
                    builder.AppendLine();
                }
            }
            return builder.ToString();
        }
    }
}
