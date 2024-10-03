using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    internal class ColorPair
    {
        internal Color MajorColor { get; set; }
        internal Color MinorColor { get; set; }

        public override string ToString()
        {
            return $"MajorColor: {MajorColor.Name}, MinorColor: {MinorColor.Name}";
        }
    }

    internal static class ColorMapper
    {
        private static readonly Color[] ColorMapMajor = { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
        private static readonly Color[] ColorMapMinor = { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };

        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            ValidatePairNumber(pairNumber);

            int minorSize = ColorMapMinor.Length;
            int majorIndex = (pairNumber - 1) / minorSize;
            int minorIndex = (pairNumber - 1) % minorSize;

            return new ColorPair
            {
                MajorColor = ColorMapMajor[majorIndex],
                MinorColor = ColorMapMinor[minorIndex]
            };
        }

        public static int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = Array.IndexOf(ColorMapMajor, pair.MajorColor);
            int minorIndex = Array.IndexOf(ColorMapMinor, pair.MinorColor);

            if (majorIndex == -1 || minorIndex == -1)
                throw new ArgumentException($"Unknown Colors: {pair}");

            return (majorIndex * ColorMapMinor.Length) + (minorIndex + 1);
        }

        private static void ValidatePairNumber(int pairNumber)
        {
            int totalPairs = ColorMapMajor.Length * ColorMapMinor.Length;
            if (pairNumber < 1 || pairNumber > totalPairs)
            {
                throw new ArgumentOutOfRangeException($"Pair number {pairNumber} is out of range.");
            }
        }
    }
}
