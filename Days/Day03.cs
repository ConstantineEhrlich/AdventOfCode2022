namespace Days;

public static class Day03
{
    public static (int FirstAnswer, int SecondAnswer) Resolve(IEnumerable<string> data)
    {
        List<char> commonItems = FindCommonItems(data);
        return (CalculateScore(commonItems), 0);
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
            score += DecodeCharacter(item);
        }

        return score;
    }
    
    private static int DecodeCharacter(char c)
    {
        if (!char.IsLetter(c))
            throw new ArgumentException($"Character {c} is not a letter!");
        
        switch (char.IsUpper(c))
        {
            case true:
                return (int)c - 38;
            case false:
                return (int)c - 96;
        }
    }
    
}