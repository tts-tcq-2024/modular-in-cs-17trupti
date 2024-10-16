using CableColorMapping;
using System.Diagnostics;
using System.Drawing;

public class ColorMapperTester
{
    public void ExecuteIndexToColorTests()
    {
        var mapper = new ColorMapper();

        // Test Case 1
        int index = 4;
        ColorPair expected = new ColorPair(Color.White, Color.Brown);
        ColorPair result = mapper.GetColorsFromIndex(index);
        Debug.Assert(result.Equals(expected), $"Test Failed: Expected {expected}, Got {result}");

        // Test Case 2
        index = 5;
        expected = new ColorPair(Color.White, Color.Gray);
        result = mapper.GetColorsFromIndex(index);
        Debug.Assert(result.Equals(expected), $"Test Failed: Expected {expected}, Got {result}");

        // Test Case 3
        index = 23;
        expected = new ColorPair(Color.Violet, Color.Green);
        result = mapper.GetColorsFromIndex(index);
        Debug.Assert(result.Equals(expected), $"Test Failed: Expected {expected}, Got {result}");
    }

    public void ExecuteColorToIndexTests()
    {
        var mapper = new ColorMapper();

        // Test Case 1
        ColorPair testPair = new ColorPair(Color.Yellow, Color.Green);
        int expectedIndex = 18;
        int resultIndex = mapper.GetIndexFromColors(testPair);
        Debug.Assert(resultIndex == expectedIndex, $"Test Failed: Expected {expectedIndex}, Got {resultIndex}");

        // Test Case 2
        testPair = new ColorPair(Color.Red, Color.Blue);
        expectedIndex = 6;
        resultIndex = mapper.GetIndexFromColors(testPair);
        Debug.Assert(resultIndex == expectedIndex, $"Test Failed: Expected {expectedIndex}, Got {resultIndex}");
    }
}
