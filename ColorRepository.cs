using System.Drawing;

namespace CableColorMapping
{
    /// <summary>
    /// Repository of available primary and secondary colors for pairing.
    /// </summary>
    public static class ColorRepository
    {
        public static readonly List<Color> PrimaryColors = new List<Color>
        {
            Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet
        };

        public static readonly List<Color> SecondaryColors = new List<Color>
        {
            Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.Gray
        };
    }
}
