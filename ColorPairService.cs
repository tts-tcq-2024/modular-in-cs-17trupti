using System;
using System.Collections.Generic;
using System.Drawing;

namespace TelecomColorCode
{
    /// <summary>
    /// Service to map color codes to numbers and vice versa.
    /// </summary>
    public class ColorPairService
    {
        private readonly IReadOnlyList<Color> _primaryColors;
        private readonly IReadOnlyList<Color> _secondaryColors;
        private readonly int _totalPairs;

        public ColorPairService()
        {
            _primaryColors = ColorRepository.GetPrimaryColors();
            _secondaryColors = ColorRepository.GetSecondaryColors();
            _totalPairs = _primaryColors.Count * _secondaryColors.Count;
        }

        /// <summary>
        /// Maps a numeric value to its corresponding color combination.
        /// </summary>
        public ColorPair MapNumberToColors(int pairNumber)
        {
            if (!IsPairNumberValid(pairNumber))
            {
                throw new ArgumentOutOfRangeException(nameof(pairNumber),
                    $"Pair number must be in the range of 1 to {_totalPairs}");
            }

            int majorColorIdx = (pairNumber - 1) / _secondaryColors.Count;
            int minorColorIdx = (pairNumber - 1) % _secondaryColors.Count;

            return CreateColorPair(majorColorIdx, minorColorIdx);
        }

        /// <summary>
        /// Translates a color pair back into its numeric representation.
        /// </summary>
        public int MapColorsToNumber(ColorPair colorPair)
        {
            if (colorPair == null)
            {
                throw new ArgumentNullException(nameof(colorPair), "Color pair cannot be null.");
            }

            int primaryIndex = GetPrimaryColorIndex(colorPair.MajorColor);
            int secondaryIndex = GetSecondaryColorIndex(colorPair.MinorColor);

            if (primaryIndex == -1 || secondaryIndex == -1)
            {
                throw new ArgumentException("Color combination does not exist in the mapping.");
            }

            return CalculatePairNumber(primaryIndex, secondaryIndex);
        }

        private bool IsPairNumberValid(int pairNumber)
        {
            return pairNumber >= 1 && pairNumber <= _totalPairs;
        }

        private ColorPair CreateColorPair(int majorIndex, int minorIndex)
        {
            Color majorColor = _primaryColors[majorIndex];
            Color minorColor = _secondaryColors[minorIndex];

            return new ColorPair(majorColor, minorColor);
        }

        private int CalculatePairNumber(int majorIndex, int minorIndex)
        {
            return (majorIndex * _secondaryColors.Count) + minorIndex + 1;
        }

        private int GetPrimaryColorIndex(Color majorColor)
        {
            return _primaryColors.IndexOf(majorColor);
        }

        private int GetSecondaryColorIndex(Color minorColor)
        {
            return _secondaryColors.IndexOf(minorColor);
        }
    }
}
