namespace CableColorMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            var tester = new ColorMapperTester();
            tester.ExecuteIndexToColorTests();
            tester.ExecuteColorToIndexTests();
        }
    }
}
