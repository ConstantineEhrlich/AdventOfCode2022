namespace UnitTests;
using Helpers;

[TestClass]
public class HelpersTest
{
    [TestMethod]
    public void GetDataForOneDay()
    {
        try
        {
            foreach (string s in new Data().ForYear(2022).ForDay(1))
            {
                Console.WriteLine(s);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Assert.Fail();
        }
    }

    [TestMethod]
    public void GetDataWithoutDay()
    {
        try
        {
            foreach (var _ in new Data())
            {
                Assert.Fail();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    
}

