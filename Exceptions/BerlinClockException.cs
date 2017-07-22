using System;

namespace BerlinClock.Exceptions
{
    /// <summary>
    /// Generic exception used in <see cref="BerlinClock"/>
    /// </summary>
    public class BerlinClockException: Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BerlinClockException()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error message</param>
        public BerlinClockException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Inner exception which causes currently created exception</param>
        public BerlinClockException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
