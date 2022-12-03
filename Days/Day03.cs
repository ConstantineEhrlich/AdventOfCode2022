namespace Days;

public static class Day03
{
    public static (int FirstAnswer, int SecondAnswer) Resolve(IEnumerable<string> data)
    {
        List<char> commonItems = FindCommonItems(data);

        int groupCounter = 0;
        List<string> threePack = new();
        int score = 0;
        foreach (string input in data)
        {
            
            groupCounter++;
            threePack.Add(input);
            //threePack.UnionWith(new HashSet<char>(input.ToCharArray()));
            
            if (groupCounter % 3 == 0)
            {
                HashSet<char> firstRucksack = new(threePack[0].ToCharArray());
                firstRucksack.IntersectWith(new HashSet<char>(threePack[1].ToCharArray()));
                firstRucksack.IntersectWith(new HashSet<char>(threePack[2].ToCharArray()));
                score += CalculateScore(firstRucksack);
                threePack.Clear();
            }
            
        }
        
        
        return (CalculateScore(commonItems), score);
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
    