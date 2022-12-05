using Helpers;

namespace UnitTests;
using static Days.Day05;

[TestClass]
public class Day05Tests
{
    [TestMethod]
    public void CalculateSolution()
    {
        var result = Resolve(new Data().ForYear(2022).ForDay(5));
        Console.WriteLine($"For CrateMover 9000, the crates are {result.FirstAnswer}");
        Console.WriteLine($"For CrateMover 9001, the crates are {result.SecondAnswer}");
    }

    [TestMethod]
    public void TestSolution()
    {
        var result = Resolve(SampleData());
        Assert.AreEqual("CMZ", result.FirstAnswer);
    }

    private IEnumerable<string> SampleData()
    {
        yield return "    [D]    ";
        yield return "[N] [C]    ";
        yield return "[Z] [M] [P]";
        yield return " 1   2   3 ";
        yield return "";
        yield return "move 1 from 2 to 1";
        yield return "move 3 from 1 to 3";
        yield return "move 2 from 2 to 1";
        yield return "move 1 from 1 to 2";
    }

    [TestMethod]
    public void TestParseCrates()
    {
        List<string> cratesInput = new()
        {
            "    [G]                     [D]      [Q]          ",
            "    [U] [H]                 [O] [C]  [J]          ",
            "    [B] [U]                 [X] [D]  [P]       [S]",
            "[Z] [H] [W] [Z] [D]         [A] [R]  [U]       [G]",
            "[K] [V] [A] [F] [W]         [M] [A]  [D]       [G]",
            "[Y] [D] [I] [C] [B]     [A] [C] [F]  [W]       [S]",
            "[V] [C] [W] [D] [L]     [Z] [H] [C]  [K]       [N]",
            "[R] [O] [T] [A] [E]     [Y] [Z] [L]  [K]  [W]  [W]",
            "[N] [O] [Y] [B] [J] [D] [Z] [G] [X]  [G]  [G]  [D]",
            " 1   2   3   4   5   6   7   8   9   10   11   12 ",
            "",
        };

        List<Stack<char>> stacks = ParseCrates(cratesInput);
        
        Assert.AreEqual("ZKYVRN", string.Join("", stacks[0]));
        Assert.AreEqual("GUBHVDCOO", string.Join("", stacks[1]));
        Assert.AreEqual("HUWAIWTY", string.Join("", stacks[2]));
        Assert.AreEqual("ZFCDAB", string.Join("", stacks[3]));
        Assert.AreEqual("DWBLEJ", string.Join("", stacks[4]));
        Assert.AreEqual("D", string.Join("", stacks[5]));
        Assert.AreEqual("AZYZ", string.Join("", stacks[6]));
        Assert.AreEqual("DOXAMCHZG", string.Join("", stacks[7]));
        Assert.AreEqual("CDRAFCLX", string.Join("", stacks[8]));
        Assert.AreEqual("QJPUDWKKG", string.Join("", stacks[9]));
        Assert.AreEqual("WG", string.Join("", stacks[10]));
        Assert.AreEqual("SGGSNWD", string.Join("", stacks[11]));
    }

    [TestMethod]
    public void TestParseOrder()
    {
        string input = "move 12 from 345 to 67";
        var order = ParseOrder(input);
        Assert.AreEqual(12, order.Amount);
        Assert.AreEqual(344, order.From);
        Assert.AreEqual(66, order.To);
    }
    
    
}