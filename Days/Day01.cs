namespace Days;
using Helpers;

public static class Day01
{
    public static (int TopOne, int TopThree) Resolve()
    {
        List<int> elfCalories = new() { 0 }; // New list with one elf.
        foreach (string input in new Data().ForYear(2022).ForDay(1))
        {
            if (input != string.Empty)
            {
                int.TryParse(input, out int calories);
                elfCalories[^1] += calories;
            }
            else
            {
                elfCalories.Add(0);
            }
        }

        int topOne = elfCalories.Max();
        int topThree = (from i in elfCalories
                        orderby i descending
                        select i).Take(3).Sum();
        return (topOne, topThree);
    }

}