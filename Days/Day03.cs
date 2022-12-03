namespace Days;

public static class Day03
{
    public static (int FirstAnswer, int SecondAnswer) Resolve(IEnumerable<string> data)
    {
        List<string> dataList = data.ToList();
        
        // Solution for the first part:
        int commonItemsScore = CalculateScore(FindCommonItems(dataList));
        
        // Solution for the second part
        int counter = 0;
        int totalScore = 0;
        foreach (string input in dataList)
        {
            counter++;
            if (counter % 3 == 0)
            {
                HashSet<char> uniqueItems = new(dataList[counter-3].ToCharArray());
                uniqueItems.IntersectWith(new HashSet<char>(dataList[counter-2].ToCharArray()));
                uniqueItems.IntersectWith(new HashSet<char>(dataList[counter-1].ToCharArray()));
                totalScore += CalculateScore(uniqueItems);
            }
        }
        
        
        return (commonItemsScore, totalScore);
    }

    public static (HashSet<char> FirstCompartment, HashSet<char> SecondCompartment) ParseInput(string input)
    {
        if (input.Length % 2 != 0)
            throw new ArgumentException($"The string {input} has lenght of {input.Length}, which is odd!");
        
        int len = input.Length / 2;
        HashSet<char> firstCompartment = new HashSet<char>(input.Substring(0, len).ToCharArray());
        HashSet<char> secondCompartment = new HashSet<char>(input.Substring(len, len).ToCharArray());
        return (firstCompartment, secondCompartment);
    }

    public static List<char> FindCommonItems(IEnumerable<string> data)
    {
        List<char> commonItems = new();
        foreach (string input in data)
        {
            var rucksack = ParseInput(input);
            rucksack.FirstCompartment.IntersectWith(rucksack.SecondCompartment);
            commonItems.AddRange(rucksack.FirstCompartment);
        }

        return commonItems;
    }

    public static int CalculateScore(IEnumerable<char> itemsSet)
    {
        int score = 0;
        foreach (char item in itemsSet)
        {
            if (!char.IsLetter(item))
                throw new ArgumentException($"Character {item} is not a letter!");
            score += char.IsUpper(item) switch
            {
                true => item - 38,
                false => item - 96
            };
        }

        return score;
    }
}
    