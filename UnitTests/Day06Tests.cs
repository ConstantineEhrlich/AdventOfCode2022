using Helpers;

namespace UnitTests;
using static Days.Day06;

[TestClass]
public class Day06Tests
{
    [TestMethod]
    public void TestSolution()
    {
        var result = Resolve(new Data().ForDay(6).ForYear(2022));
        Console.WriteLine($"First start-of-packet marker is detected after {result.FirstAnswer} characters");
        Console.WriteLine($"First start-of-message marker is detected after {result.SecondAnswer} characters");
    }
}