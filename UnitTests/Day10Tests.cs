using Days;
using Helpers;

namespace UnitTests;
using static Day10;

[TestClass]
public class Day10Tests
{
    [TestMethod]
    public void CalculateSolution()
    {
        Resolve(new Data().ForDay(10).ForYear(2022));
    }

    [TestMethod]
    public void TestDisplay()
    {
        Display d = new();
        d.Print();
    }
    
    [TestMethod]
    public void TestLargerExample()
    {
        var result = Resolve(SampleData());
        Assert.AreEqual(13140, result);
    }

    private IEnumerable<string> SampleData()
    {
        yield return "addx 15"; //146 x = 16
        yield return "addx -11"; //145 x = 5
        yield return "addx 6"; //144 x = 11
        yield return "addx -3"; //143 x = 8
        yield return "addx 5"; //142 x = 13
        yield return "addx -1"; //141 x = 12
        yield return "addx -8"; //140 x = 4
        yield return "addx 13"; //139 x = 17
        yield return "addx 4"; //138 x = 21
        yield return "noop"; //137 x = 21
        yield return "addx -1"; //136 x = 20
        yield return "addx 5"; //135 x = 25
        yield return "addx -1"; //134 x = 24
        yield return "addx 5"; //133 x = 29
        yield return "addx -1"; //132 x = 28
        yield return "addx 5"; //131 x = 33
        yield return "addx -1"; //130 x = 32
        yield return "addx 5"; //129 x = 37
        yield return "addx -1"; //128 x = 36
        yield return "addx -35"; //127 x = 1
        yield return "addx 1"; //126 x = 2
        yield return "addx 24"; //125 x = 26
        yield return "addx -19"; //124 x = 7
        yield return "addx 1"; //123 x = 8
        yield return "addx 16"; //122 x = 24
        yield return "addx -11"; //121 x = 13
        yield return "noop"; //120 x = 13
        yield return "noop"; //119 x = 13
        yield return "addx 21"; //118 x = 34
        yield return "addx -15"; //117 x = 19
        yield return "noop"; //116 x = 19
        yield return "noop"; //115 x = 19
        yield return "addx -3"; //114 x = 16
        yield return "addx 9"; //113 x = 25
        yield return "addx 1"; //112 x = 26
        yield return "addx -3"; //111 x = 23
        yield return "addx 8"; //110 x = 31
        yield return "addx 1"; //109 x = 32
        yield return "addx 5"; //108 x = 37
        yield return "noop"; //107 x = 37
        yield return "noop"; //106 x = 37
        yield return "noop"; //105 x = 37
        yield return "noop"; //104 x = 37
        yield return "noop"; //103 x = 37
        yield return "addx -36"; //102 x = 1
        yield return "noop"; //101 x = 1
        yield return "addx 1"; //100 x = 2
        yield return "addx 7"; //99 x = 9
        yield return "noop"; //98 x = 9
        yield return "noop"; //97 x = 9
        yield return "noop"; //96 x = 9
        yield return "addx 2"; //95 x = 11
        yield return "addx 6"; //94 x = 17
        yield return "noop"; //93 x = 17
        yield return "noop"; //92 x = 17
        yield return "noop"; //91 x = 17
        yield return "noop"; //90 x = 17
        yield return "noop"; //89 x = 17
        yield return "addx 1"; //88 x = 18
        yield return "noop"; //87 x = 18
        yield return "noop"; //86 x = 18
        yield return "addx 7"; //85 x = 25
        yield return "addx 1"; //84 x = 26
        yield return "noop"; //83 x = 26
        yield return "addx -13"; //82 x = 13
        yield return "addx 13"; //81 x = 26
        yield return "addx 7"; //80 x = 33
        yield return "noop"; //79 x = 33
        yield return "addx 1"; //78 x = 34
        yield return "addx -33"; //77 x = 1
        yield return "noop"; //76 x = 1
        yield return "noop"; //75 x = 1
        yield return "noop"; //74 x = 1
        yield return "addx 2"; //73 x = 3
        yield return "noop"; //72 x = 3
        yield return "noop"; //71 x = 3
        yield return "noop"; //70 x = 3
        yield return "addx 8"; //69 x = 11
        yield return "noop"; //68 x = 11
        yield return "addx -1"; //67 x = 10
        yield return "addx 2"; //66 x = 12
        yield return "addx 1"; //65 x = 13
        yield return "noop"; //64 x = 13
        yield return "addx 17"; //63 x = 30
        yield return "addx -9"; //62 x = 21
        yield return "addx 1"; //61 x = 22
        yield return "addx 1"; //60 x = 23
        yield return "addx -3"; //59 x = 20
        yield return "addx 11"; //58 x = 31
        yield return "noop"; //57 x = 31
        yield return "noop"; //56 x = 31
        yield return "addx 1"; //55 x = 32
        yield return "noop"; //54 x = 32
        yield return "addx 1"; //53 x = 33
        yield return "noop"; //52 x = 33
        yield return "noop"; //51 x = 33
        yield return "addx -13"; //50 x = 20
        yield return "addx -19"; //49 x = 1
        yield return "addx 1"; //48 x = 2
        yield return "addx 3"; //47 x = 5
        yield return "addx 26"; //46 x = 31
        yield return "addx -30"; //45 x = 1
        yield return "addx 12"; //44 x = 13
        yield return "addx -1"; //43 x = 12
        yield return "addx 3"; //42 x = 15
        yield return "addx 1"; //41 x = 16
        yield return "noop"; //40 x = 16
        yield return "noop"; //39 x = 16
        yield return "noop"; //38 x = 16
        yield return "addx -9"; //37 x = 7
        yield return "addx 18"; //36 x = 25
        yield return "addx 1"; //35 x = 26
        yield return "addx 2"; //34 x = 28
        yield return "noop"; //33 x = 28
        yield return "noop"; //32 x = 28
        yield return "addx 9"; //31 x = 37
        yield return "noop"; //30 x = 37
        yield return "noop"; //29 x = 37
        yield return "noop"; //28 x = 37
        yield return "addx -1"; //27 x = 36
        yield return "addx 2"; //26 x = 38
        yield return "addx -37"; //25 x = 1
        yield return "addx 1"; //24 x = 2
        yield return "addx 3"; //23 x = 5
        yield return "noop"; //22 x = 5
        yield return "addx 15"; //21 x = 20
        yield return "addx -21"; //20 x = -1
        yield return "addx 22"; //19 x = 21
        yield return "addx -6"; //18 x = 15
        yield return "addx 1"; //17 x = 16
        yield return "noop"; //16 x = 16
        yield return "addx 2"; //15 x = 18
        yield return "addx 1"; //14 x = 19
        yield return "noop"; //13 x = 19
        yield return "addx -10"; //12 x = 9
        yield return "noop"; //11 x = 9
        yield return "noop"; //10 x = 9
        yield return "addx 20"; //9 x = 29
        yield return "addx 1"; //8 x = 30
        yield return "addx 2"; //7 x = 32
        yield return "addx 2"; //6 x = 34
        yield return "addx -6"; //5 x = 28
        yield return "addx -11"; //4 x = 17
        yield return "noop"; //3 x = 17
        yield return "noop"; //2 x = 17
        yield return "noop"; //1 x = 17
    }
}