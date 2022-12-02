using static Days.Day02;
using Helpers;

namespace UnitTests;

[TestClass]
public class Day02Tests
{
    [TestMethod]
    public void TestSolution()
    {
        var result = Resolve(SampleData());
        Assert.AreEqual(15, result.FirstAnswer);
        Assert.AreEqual(12, result.SecondAnswer);
    }
    
    [TestMethod]
    public void TestCalculateScore()
    {
        Assert.AreEqual(8, CalculateScore(ParseInput("A Y")));
        Assert.AreEqual(1, CalculateScore(ParseInput("B X")));
        Assert.AreEqual(6, CalculateScore(ParseInput("C Z")));
    }

    [TestMethod]
    public void TestCalculateScoreAlternate()
    {
        Assert.AreEqual(4, CalculateScore(ParseInputAlternate("A Y")));
        Assert.AreEqual(1, CalculateScore(ParseInputAlternate("B X")));
        Assert.AreEqual(7, CalculateScore(ParseInputAlternate("C Z")));
    }

    
    [TestMethod]
    public void CalculateSolution()
    {
        var result = Resolve(new Data().ForDay(2).ForYear(2022));
        Console.WriteLine($"Total score when you follow strategy guide is {result.FirstAnswer}");
        Console.WriteLine($"But, when the second sign is the game result, the score is {result.SecondAnswer}");
    }

    private IEnumerable<string> SampleData()
    {
        yield return "A Y";
        yield return "B X";
        yield return "C Z";
    }
}