using Helpers;

namespace UnitTests;
using static Days.Day08;

[TestClass]
public class Day08Tests
{
    [TestMethod]
    public void CalculateSolution()
    {
        var result = Resolve(new Data().ForDay(8).ForYear(2022));
        Console.WriteLine($"Total visible trees: {result.FirstAnswer}");
        Console.WriteLine($"Maximum scenic score: {result.SecondAnswer}");
    }
    
    [TestMethod]
    public void TestSolution()
    {
        var result = Resolve(SampleData());
        Assert.AreEqual(21, result.FirstAnswer);
        Assert.AreEqual(8, result.SecondAnswer);
    }
    
    private IEnumerable<string> SampleData()
    {
        yield return "30373";
        yield return "25512";
        yield return "65332";
        yield return "33549";
        yield return "35390";
    }
}