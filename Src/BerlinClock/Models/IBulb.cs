namespace BerlinClock.Models
{
    /// <summary>
    /// Represents one bulb
    /// </summary>
    public interface IBulb: IDrawable
    {
        /// <summary>
        /// Turns on bulb.
        /// </summary>
        void TurnOn();

        /// <summary>
        /// Determines whether bulb is turned on.
        /// </summary>
        bool IsOn { get; }
    }
}
