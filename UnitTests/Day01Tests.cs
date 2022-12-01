namespace UnitTests;
using Days;

[TestClass]
public class Day01Tests
{
    [TestMethod]
    public void TestSolution()
    {
        var result = Day01.Resolve();
        Console.WriteLine($"Max weight for one elf is {result.TopOne}.");
        Console.WriteLine($"Total weight for top three elves is {result.TopThree}");
    }
}