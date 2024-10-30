using GildedRose;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        [Fact]
        public void TestConsoleOutputString()
        {
            string expectedOutput = File.ReadAllText("GildedRoseOutput.txt");
            expectedOutput = expectedOutput.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
            
            string outputStr = Program.GenerateGildedRoseConsoleOutput();
            outputStr = outputStr.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);

            //Assert.Equal(10516, outputStr.Length);
            Assert.Equal(expectedOutput, outputStr);
        }

    }
}
