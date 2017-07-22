namespace BerlinClock.Models
{
    /// <summary>
    /// Interface represents exactly one time part of clock.
    /// </summary>
    public interface ITimePart: IDrawable
    {
        /// <summary>
        /// Sets time part value to component.
        /// </summary>
        /// <param name="value">Value to be set</param>
        void SetValue(int value);

        /// <summary>
        /// Gets value of time component
        /// </summary>
        int Value { get; }
    }
}
