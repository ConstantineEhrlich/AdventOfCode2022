using System.Text.RegularExpressions;

namespace Days;

public static class Day05
{
    public static (string FirstAnswer, string SecondAnswer) Resolve(IEnumerable<string> data)
    {
        List<string> dataList = data.ToList();

        var crateMover9000 = ParseCrates(dataList);
        var crateMover9001 = crateMover9000.Clone();
        
        int fromLine = dataList.FindIndex(s => s == string.Empty) + 1;
        for (int i = fromLine; i < dataList.Count; i++)
        {
            var order = ParseOrder(dataList[i]);
            
            // CrateMover 9000
            for (int j = 0; j < order.Amount; j++)
            {
                crateMover9000[order.To].Push(crateMover9000[order.From].Pop());
            }
            
            // CrateMover 9001
            Stack<char> temp = new();
            for (int j = 0; j < order.Amount; j++)
            {
                temp.Push(crateMover9001[order.From].Pop());
            }
            for (int j = 0; j < order.Amount; j++)
            {
                crateMover9001[order.To].Push(temp.Pop());
            }
        }

        return (crateMover9000.TopCrates(), crateMover9001.TopCrates());
    }

    private static string TopCrates(this List<Stack<char>> stacks)
    {
        return new string(stacks.Select(stack => stack.Peek()).ToArray());
    }

    private static List<Stack<char>> Clone(this List<Stack<char>> stacks)
    {
        return stacks.Select(stack => new Stack<char>(stack)).ToList();
    }
    
    public static List<Stack<char>> ParseCrates(List<string> data)
    {
        List<Stack<char>> stacks = new();
        
        // Find first line in the list which is empty
        int indexLine = data.FindIndex(s => s == string.Empty) - 1;
        
        // Match any number
        Regex r = new(@"\d+");
        foreach (Match match in r.Matches(data[indexLine]))
        {
            // Get column index
            int.TryParse(match.Value, out int column);
            stacks.Add(new Stack<char>());
            // Shift column index for column index > 10
            int index = column >= 10 ? match.Index+1 : match.Index;
            
            // Run through lines bottom up and add character to the stack
            for (int i = indexLine - 1; i >= 0; i--)
            {
                char c = data[i][index];
                if (c != ' ')
                    stacks[^1].Push(c);
            }
        }
        return stacks;
    }

    public static (int Amount, int From, int To) ParseOrder(string input)
    {
        string[] splitInput = input.Split(' ');
        int.TryParse(splitInput[1], out int amount);
        int.TryParse(splitInput[3], out int from);
        int.TryParse(splitInput[5], out int to);
        return (amount, from - 1, to - 1);
    }
}