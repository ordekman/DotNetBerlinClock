using System;

namespace BerlinClock.Classes
{
    /// <summary>
    /// Represents time convertor, which formats input strings to different string formats.
    /// </summary>
    public interface ITimeConverter
    {
        /// <summary>
        /// Converts string time to different string format.
        /// </summary>
        /// <param name="time">Time string to be converted</param>
        /// <returns></returns>
        string ConvertTime(String time);
    }
}
