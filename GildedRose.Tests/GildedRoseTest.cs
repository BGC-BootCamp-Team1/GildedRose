using GildedRose;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        [Fact]
        public void TestConsoleOutputString()
        {
            string pathToExpectedFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\GildedRose.benchmark.txt"); 
            string pathToResultFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\GildedRose.result.txt"); 

            string expectedOutput = File.ReadAllText(pathToExpectedFile);
            expectedOutput = expectedOutput.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
            
            string outputStr = Program.GenerateGildedRoseConsoleOutput();
            outputStr = outputStr.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
            File.WriteAllText(pathToResultFile, outputStr);

            Assert.Equal(expectedOutput, outputStr);
        }

    }
}
