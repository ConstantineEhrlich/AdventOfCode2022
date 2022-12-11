using Helpers;
using static Days.Day11;

namespace UnitTests
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public void CalculateSolution()
        {
            var result = Resolve(new Data().ForDay(11).ForYear(2022));
            Console.WriteLine($"Level of monkey business after 20 rounds is: {result.FirstAnswer}");
            Console.WriteLine($"Level of monkey business after 10000 rounds is: {result.SecondAnswer}");
        }
        
        [TestMethod]
        public void TestSolution()
        {
            var result = Resolve(SampleData());
            Assert.AreEqual((ulong)10605, result.FirstAnswer);
            Assert.AreEqual(2713310158, result.SecondAnswer);
        }

        
        private IEnumerable<string> SampleData()
        {
            yield return "Monkey 0:";
            yield return "  Starting items: 79, 98";
            yield return "  Operation: new = old * 19";
            yield return "  Test: divisible by 23";
            yield return "    If true: throw to monkey 2";
            yield return "    If false: throw to monkey 3";
            yield return "";
            yield return "Monkey 1:";
            yield return "  Starting items: 54, 65, 75, 74";
            yield return "  Operation: new = old + 6";
            yield return "  Test: divisible by 19";
            yield return "    If true: throw to monkey 2";
            yield return "    If false: throw to monkey 0";
            yield return "";
            yield return "Monkey 2:";
            yield return "  Starting items: 79, 60, 97";
            yield return "  Operation: new = old * old";
            yield return "  Test: divisible by 13";
            yield return "    If true: throw to monkey 1";
            yield return "    If false: throw to monkey 3";
            yield return "";
            yield return "Monkey 3:";
            yield return "  Starting items: 74";
            yield return "  Operation: new = old + 3";
            yield return "  Test: divisible by 17";
            yield return "    If true: throw to monkey 0";
            yield return "    If false: throw to monkey 1";
        }

    }


    



}


/*
Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3


 
 *
 */
