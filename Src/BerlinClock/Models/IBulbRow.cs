namespace BerlinClock.Models
{
    /// <summary>
    /// Represents one row of bulbs <see cref="IBulb"/>.
    /// </summary>
    public interface IBulbRow: IDrawable
    {
        /// <summary>
        /// Sets value to row.
        /// </summary>
        /// <param name="value">Value to be set</param>
        /// <returns>Remaining value to be set to next row.</returns>
        int SetValue(int value);
    }
}
