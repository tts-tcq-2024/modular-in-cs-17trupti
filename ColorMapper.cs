using System;
using System.Collections.Generic;
using System.Drawing;

namespace CableColorMapping
{
    /// <summary>
    /// Responsible for translating pair indices into color combinations.
    /// </summary>
    public class ColorMapper
    {
        private readonly int _primaryColorCount;
        private readonly int _secondaryColorCount;

        public ColorMapper()
        {
            _primaryColorCount = ColorRepository.PrimaryColors.Count;
            _secondaryColorCount = ColorRepository.SecondaryColors.Count;
        }

        /// <summary>
        /// Retrieves the color pair based on the given index.
        /// </summary>
        public ColorPair GetColorsFromIndex(int index)
        {
            ValidateIndex(index);
            int adjustedIndex = index - 1;
            int primaryIndex = adjustedIndex / _secondaryColorCount;
            int secondaryIndex = adjustedIndex % _secondaryColorCount;

            var primary = ColorRepository.PrimaryColors[primaryIndex];
            var secondary = ColorRepository.SecondaryColors[secondaryIndex];

            return new ColorPair(primary, secondary);
        }

        private void ValidateIndex(int index)
        {
            if (index < 1 || index > _primaryColorCount * _secondaryColorCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), 
                    $"Index must be between 1 and {_primaryColorCount * _secondaryColorCount}");
            }
        }

        /// <summary>
        /// Finds the index for the given color pair.
        /// </summary>
        public int GetIndexFromColors(ColorPair pair)
        {
            if (pair == null)
                throw new ArgumentNullException(nameof(pair));
            return CalculateIndex(pair);
        }

        private int CalculateIndex(ColorPair pair)
        {
            int primaryIndex = ColorRepository.PrimaryColors.IndexOf(pair.PrimaryColor);
            int secondaryIndex = ColorRepository.SecondaryColors.IndexOf(pair.SecondaryColor);

            if (primaryIndex == -1 || secondaryIndex == -1)
            {
                throw new ArgumentException("Color pair is not recognized.");
            }

            return (primaryIndex * _secondaryColorCount) + (secondaryIndex + 1);
        }
    }
}
