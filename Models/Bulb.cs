namespace BerlinClock.Models
{
    /// <inheritdoc />
    public class Bulb: IBulb
    {
        private readonly char _onChar;
        private readonly char _offChar;
        private bool _isLightedOn;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="onChar">Character which represents turned on <see cref="Bulb"/></param>
        /// <param name="offChar">Character which represents turned off <see cref="Bulb"/></param>
        public Bulb(char onChar, char offChar)
        {
            _onChar = onChar;
            _offChar = offChar;
        }

        /// <inheritdoc />
        public bool IsOn => _isLightedOn;

        /// <inheritdoc />
        public string Draw()
        {
            return _isLightedOn ? _onChar.ToString() : _offChar.ToString();
        }

        /// <inheritdoc />
        public void TurnOn()
        {
            _isLightedOn = true;
        }
    }
}
