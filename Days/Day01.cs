namespace Days;
using Helpers;

public static class Day01
{
    public static (int TopOne, int TopThree) Resolve()
    {
        int elveCount = 0;
        List<int> elveCalories = new();
        elveCalories.Add(0); //Add first elve
        foreach (string input in new Data().ForYear(2022).ForDay(1))
        {
            if (input != string.Empty)
            {
                int.TryParse(input, out int calories);
                elveCalories[elveCount] += calories;
            }
            else
            {
                elveCalories.Add(0);
                elveCount++;
            }
        }

        int topOne = elveCalories.Max();
        int topThree = (from i in elveCalories
                            orderby i descending
                            select i).Take(3).Sum();
        return (topOne, topThree);
    }

}