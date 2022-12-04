using Helpers;
using static Days.Day04;
namespace UnitTests;

[TestClass]
public class Day04Tests
{
    [TestMethod]
    public void CalculateSolution()
    {
        var result = Resolve(new Data().ForDay(4).ForYear(2022));
        Console.WriteLine($"Total included pairs: {result.FirstAnswer}");
        Console.WriteLine($"Total overlapping pairs: {result.SecondAnswer}");
    }
    
    [TestMethod]
    public void TestSolution()
    {
        var result = Resolve(SampleData());
        Assert.AreEqual(2, result.FirstAnswer);
        Assert.AreEqual(4, result.SecondAnswer);
    }

    [TestMethod]
    public void TestParse()
    {
        var result = ParseInput("2-4,6-8");
        Assert.AreEqual(2, result.FirstFrom);
        Assert.AreEqual(4, result.FirstTo);
        Assert.AreEqual(6, result.SecondFrom);
        Assert.AreEqual(8, result.SecondTo);
    }

    [TestMethod]
    public void TestIsOverlapping()
    {
        foreach (string input in SampleData())
        {
            var pos = ParseInput(input);
            Console.WriteLine($"Input is {input}, and the overlapping is {IsIncluding(pos)}");
        }
    }
    
    
    private IEnumerable<string> SampleData()
    {
        yield return "2-4,6-8";
        yield return "2-3,4-5";
        yield return "5-7,7-9";
        yield return "2-8,3-7";
        yield return "6-6,4-6";
        yield return "2-6,4-8";
    }
    
    
}






