using Helpers;

namespace UnitTests;
using static Days.Day03;

[TestClass]
public class Day03Tests
{
    [TestMethod]
    public void CalculateSolution()
    {
        var result = Resolve(new Data().ForDay(3).ForYear(2022));
        Console.WriteLine($"Sum of priorities of common items in all rucksacks is: {result.FirstAnswer}");
    }
    
    private IEnumerable<string> SampleData()
    {
        yield return "vJrwpWtwJgWrhcsFMMfFFhFp";
        yield return "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL";
        yield return "PmmdzqPrVvPwwTWBwg";
        yield return "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn";
        yield return "ttgJtRGJQctTZtZT";
        yield return "CrZsJsPPZsGzwwsLwLmpwMDw";
    }

    [TestMethod]
    public void TestSolution()
    {
        var result = Resolve(SampleData());
        Assert.AreEqual(157, result.FirstAnswer);
    }

    [TestMethod]
    public void TestFindCommonItems()
    {
        var commonItems = FindCommonItems(SampleData());
        Assert.AreEqual(String.Join(string.Empty, commonItems), "pLPvts");
    }

    [TestMethod]
    public void TestCalculateScore()
    {
        Assert.AreEqual(157, CalculateScore("pLPvts"));
    }
    
}



