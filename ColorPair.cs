using System.Drawing;

namespace CableColorMapping
{
    /// <summary>
    /// Class representing a pair of primary and secondary colors.
    /// </summary>
    public class ColorPair
    {
        public Color PrimaryColor { get; }
        public Color SecondaryColor { get; }

        public ColorPair(Color primary, Color secondary)
        {
            PrimaryColor = primary;
            SecondaryColor = secondary;
        }

        public override string ToString()
        {
            return $"Primary: {PrimaryColor.Name}, Secondary: {SecondaryColor.Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is ColorPair otherPair)
            {
                return PrimaryColor.Equals(otherPair.PrimaryColor) && SecondaryColor.Equals(otherPair.SecondaryColor);
            }
            
            return false;
        }

        public override int GetHashCode()
        {
            return (PrimaryColor, SecondaryColor).GetHashCode();
        }
    }
}
