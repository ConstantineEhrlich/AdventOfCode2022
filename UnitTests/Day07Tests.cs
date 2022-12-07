using Days;
using Helpers;

namespace UnitTests;
using static Days.Day07;

[TestClass]
public class Day07Tests
{
    [TestMethod]
    public void CalculateSolution()
    {
        var result = Resolve(new Data().ForDay(7).ForYear(2022));
        Console.WriteLine($"Total size of directories is {result.FirstAnswer}");
        Console.WriteLine($"Smallest dir to remove is {result.SecondAnswer}");
    }
    
    [TestMethod]
    public void TestSolution()
    {
        var result = Resolve(SampleData());
        Assert.AreEqual(95437, result.FirstAnswer);
        Assert.AreEqual(24933642, result.SecondAnswer);
    }

    [TestMethod]
    public void TestTraverse()
    {
        FileNode rootNode = ParseInput(SampleData().ToList());
        List<FileNode> nodeList = rootNode.Traverse();
        List<string> expected = new()
        {
            "/",
            "a",
            "e",
            "i",
            "f",
            "g",
            "h.lst",
            "b.txt",
            "c.dat",
            "d",
            "j",
            "d.log",
            "d.ext",
            "k",
        };
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.AreEqual(expected[i], nodeList[i].Name);
        }
    }

    private IEnumerable<string> SampleData()
    {
        yield return "$ cd /";
        yield return "$ ls";
        yield return "dir a";
        yield return "14848514 b.txt";
        yield return "8504156 c.dat";
        yield return "dir d";
        yield return "$ cd a";
        yield return "$ ls";
        yield return "dir e";
        yield return "29116 f";
        yield return "2557 g";
        yield return "62596 h.lst";
        yield return "$ cd e";
        yield return "$ ls";
        yield return "584 i";
        yield return "$ cd ..";
        yield return "$ cd ..";
        yield return "$ cd d";
        yield return "$ ls";
        yield return "4060174 j";
        yield return "8033020 d.log";
        yield return "5626152 d.ext";
        yield return "7214296 k";
    }
}