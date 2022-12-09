using Days;
using Helpers;

namespace UnitTests;
using static Day09;

[TestClass]
public class Day09Tests
{
    [TestMethod]
    public void CalculateSolution()
    {
        var result = Resolve(new Data().ForDay(9).ForYear(2022));
        Console.WriteLine($"First Answer: {result.FirstAnswer}");
        Console.WriteLine($"Second Answer: {result.SecondAnswer}");
    }

    [TestMethod]
    public void TestSolution()
    {
        var result = Resolve(SampleData());
        Assert.AreEqual(13, result.FirstAnswer);
        Assert.AreEqual(1, result.SecondAnswer);
    }

    [TestMethod]
    public void TestLargerSolution()
    {
        var result = Resolve(LargerExample());
        Assert.AreEqual(36, result.SecondAnswer);
    }
    
    [TestMethod]
    public void TestWrongDirection()
    {
        try
        {
            Rope r = new(2);
            r.Move("E 3");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    private IEnumerable<string> SampleData()
    {
        yield return "R 4";
        yield return "U 4";
        yield return "L 3";
        yield return "D 1";
        yield return "R 4";
        yield return "D 1";
        yield return "L 5";
        yield return "R 2";
    }

    private IEnumerable<string> LargerExample()
    {
        yield return "R 5";
        yield return "U 8";
        yield return "L 8";
        yield return "D 3";
        yield return "R 17";
        yield return "D 10";
        yield return "L 25";
        yield return "U 20";
    }
}