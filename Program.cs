using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    class Program
    {
        private static Color[] colorMapMajor;
        private static Color[] colorMapMinor;

        internal class ColorPair
        {
            internal Color majorColor;
            internal Color minorColor;

            public override string ToString()
            {
                return $"MajorColor:{majorColor.Name}, MinorColor:{minorColor.Name}";
            }
        }

        static Program()
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }

        private static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            int minorSize = colorMapMinor.Length;
            int majorSize = colorMapMajor.Length;
            ValidatePairNumber(pairNumber, majorSize, minorSize);

            int zeroBasedPairNumber = pairNumber - 1;
            return new ColorPair
            {
                majorColor = colorMapMajor[zeroBasedPairNumber / minorSize],
                minorColor = colorMapMinor[zeroBasedPairNumber % minorSize]
            };
        }

        private static int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = GetColorIndex(pair.majorColor, colorMapMajor);
            int minorIndex = GetColorIndex(pair.minorColor, colorMapMinor);

            return (majorIndex * colorMapMinor.Length) + (minorIndex + 1);
        }

        private static void ValidatePairNumber(int pairNumber, int majorSize, int minorSize)
        {
            if (pairNumber < 1 || pairNumber > majorSize * minorSize)
                throw new ArgumentOutOfRangeException($"PairNumber:{pairNumber} is outside the allowed range");
        }

        private static int GetColorIndex(Color color, Color[] colorMap)
        {
            for (int i = 0; i < colorMap.Length; i++)
            {
                if (colorMap[i] == color)
                    return i;
            }
            throw new ArgumentException($"Unknown Color: {color.Name}");
        }
    }
}
