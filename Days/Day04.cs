namespace Days;

public static class Day04
{
    public static (int FirstAnswer, int SecondAnswer) Resolve(IEnumerable<string> data)
    {
        int included = 0;
        int overlap = 0;

        foreach (string input in data)
        {
            if (IsIncluding(ParseInput(input)))
                included++;
            if (IsOverlapping(ParseInput(input)))
                overlap++;
        }
        return (included, overlap);
    }

    public static bool IsIncluding((int FirstFrom,
                                      int FirstTo,
                                      int SecondFrom,
                                      int SecondTo)
                                            pos)
    {
        if(pos.FirstTo >= pos.SecondTo && pos.FirstFrom <= pos.SecondFrom)
            return true;
        if (pos.SecondTo >= pos.FirstTo && pos.SecondFrom <= pos.FirstFrom)
            return true;

        return false;
    }

    public static bool IsOverlapping((int FirstFrom,
                                      int FirstTo,
                                      int SecondFrom,
                                      int SecondTo)
                                            pos)
    {
        if (pos.SecondTo >= pos.FirstFrom && pos.SecondTo <= pos.FirstTo)
            return true;
        if (pos.SecondFrom >= pos.FirstFrom && pos.SecondFrom <= pos.FirstTo)
            return true;
        if (pos.FirstFrom >= pos.SecondFrom && pos.FirstFrom <= pos.SecondTo)
            return true;
        if (pos.FirstTo >= pos.SecondFrom && pos.FirstTo <= pos.SecondFrom)
            return true;
        
        return false;
    }
    
    public static (int FirstFrom,
                   int FirstTo,
                   int SecondFrom,
                   int SecondTo)
                                ParseInput(string input)
    {
        if (!(input.Contains('-') && input.Contains(',')))
            throw new ArgumentException($"Dash and comma not found in {input}");
        string[] splitInput = input.Split(',');
        string[] first = splitInput[0].Split('-');
        string[] second = splitInput[1].Split('-');
        int.TryParse(first[0], out int firstFrom);
        int.TryParse(first[1], out int firstTo);
        int.TryParse(second[0], out int secondFrom);
        int.TryParse(second[1], out int secondTo);
        return (firstFrom, firstTo, secondFrom, secondTo);
    }
}