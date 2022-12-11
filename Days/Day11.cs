namespace Days;

public static class Day11
{
    public static (int FirstAnswer, int SecondAnswer) Resolve(IEnumerable<string> data)
    {
        var monkeys = ParseData(data);

        for (int round = 0; round < 20; round++)
        {
            PlayRound(monkeys);
        }
        var mostActive = monkeys.Select(x => x.InspectionCount).OrderByDescending(x => x).Take(2).ToArray();
        int result = mostActive[0] * mostActive[1];

        return (result, 0);
    }
    

    public static List<Monkey> ParseData(IEnumerable<string> data)
    {
        var dataList = data.ToList();
        List<Monkey> monkeys = new();

        for (int i = 0; i < dataList.Count; i += 7)
        {
            monkeys.Add(new Monkey(dataList.GetRange(i, 6)));
        }

        return monkeys;

    }

    public static void PlayRound(List<Monkey> monkeys)
    {
        foreach (Monkey monkey in monkeys)
        {
            while (monkey.ItemsList.Count > 0)
            {
                int item = monkey.ItemsList.Dequeue();
                monkey.InspectionCount++;
                item = monkey.ApplyOperation(item);
                item = item / 3;
                int targetMonkey;
                if (item % monkey.DivisibleBy == 0)
                {
                    targetMonkey = monkey.ThrowDirection.True;
                }
                else
                {
                    targetMonkey = monkey.ThrowDirection.False;
                }
                monkeys[targetMonkey].ItemsList.Enqueue(item);
            }
        }
    }

    

}


public class Monkey
{
    public int InspectionCount { get; set; } = 0;
    public Queue<int> ItemsList { get; init; }
    public string Operation { get; init; }
    public (int True, int False) ThrowDirection { get; init; }
    public int DivisibleBy { get; init; }

    public Monkey(List<string> dataList)
    {
        List<int> startingItems = dataList[1][18..]
            .Split(", ")
            .Select(x => int.Parse(x))
            .ToList();
        string operation = dataList[2][19..];
        int divisibleBy = int.Parse(dataList[3][21..]);
        (int True, int False) throwDirection;
        throwDirection.True = int.Parse(dataList[4][29..]);
        throwDirection.False = int.Parse(dataList[5][29..]);

        ItemsList = new Queue<int>(startingItems);
        Operation = operation;
        DivisibleBy = divisibleBy;
        ThrowDirection = throwDirection;
    }

    public int ApplyOperation(int item)
    {
        string[] operation = Operation.Split(' ');
        int left;
        int right;
        if (!int.TryParse(operation[0], out left))
        {
            left = item;
        }
        if (!int.TryParse(operation[2], out right))
        {
            right = item;
        }
        return operation[1] switch
        {
            "*" => left * right,
            "/" => left / right,
            "+" => left + right,
            "-" => left - right,
            _ => throw new FormatException($"{operation[1]} is incorrect operation!")
        };
    }

}

