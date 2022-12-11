namespace Days;

public static class Day11
{
    public static (ulong FirstAnswer, ulong SecondAnswer) Resolve(IEnumerable<string> data)
    {
        var monkeys1 = ParseData(data);
        for (int round = 0; round < 20; round++)
        {
            PlayRound1(monkeys1);
        }
        var mostActive1 = monkeys1.Select(x => x.InspectionCount).OrderByDescending(x => x).Take(2).ToArray();
        ulong result1 = mostActive1[0] * mostActive1[1];
        
        var monkeys2 = ParseData(data);
        for (int round = 0; round < 10000; round++)
        {
            PlayRound2(monkeys2);
        }
        var mostActive2 = monkeys2.Select(x => x.InspectionCount).OrderByDescending(x => x).Take(2).ToArray();
        ulong result2 = mostActive2[0] * mostActive2[1];
        
        return (result1, result2);
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

    public static void PlayRound1(List<Monkey> monkeys)
    {
        foreach (Monkey monkey in monkeys)
        {
            monkey.InspectionCount += (uint)monkey.ItemsList.Count;
            while (monkey.ItemsList.TryDequeue(out ulong item))
            {
                item = monkey.ApplyOperation(item);
                item = item / 3;
                item = (ulong)Math.Floor((double)item);
                int targetMonkey = item % monkey.DivisibleBy == 0
                    ? monkey.ThrowDirection.True
                    : monkey.ThrowDirection.False;
                monkeys[targetMonkey].ItemsList.Enqueue(item);
            }
        }
    }

    public static void PlayRound2(List<Monkey> monkeys)
    {
        // Thanks to Timmoth for commonDeviser
        // https://github.com/Timmoth/AdventOfCode2022/blob/main/Solutions/Day11.cs
        ulong commonDeviser = 1;
        foreach (Monkey monkey in monkeys)
        {
            commonDeviser *= monkey.DivisibleBy;
        }
        
        foreach (Monkey monkey in monkeys)
        {
            monkey.InspectionCount += (uint)monkey.ItemsList.Count;
            while (monkey.ItemsList.TryDequeue(out ulong item))
            {
                item = monkey.ApplyOperation(item);
                var newItem = item % commonDeviser;
                int targetMonkey = newItem % monkey.DivisibleBy == 0
                    ? monkey.ThrowDirection.True
                    : monkey.ThrowDirection.False;
                monkeys[targetMonkey].ItemsList.Enqueue(newItem);
            }
        }
    }
}

public class Monkey
{
    public ulong InspectionCount { get; set; } = 0;
    public Queue<ulong> ItemsList { get; }
    public string Operation { get; }
    public (int True, int False) ThrowDirection { get; }
    public uint DivisibleBy { get; }

    public Monkey(List<string> dataList)
    {
        List<ulong> startingItems = dataList[1][18..]
            .Split(", ")
            .Select(x => ulong.Parse(x))
            .ToList();
        string operation = dataList[2][19..];
        uint divisibleBy = uint.Parse(dataList[3][21..]);
        (int True, int False) throwDirection;
        throwDirection.True = int.Parse(dataList[4][29..]);
        throwDirection.False = int.Parse(dataList[5][30..]);
        
        ItemsList = new Queue<ulong>(startingItems);
        Operation = operation;
        DivisibleBy = divisibleBy;
        ThrowDirection = throwDirection;
    }

    public ulong ApplyOperation(ulong item)
    {
        string[] operation = Operation.Split(' ');
        if (!ulong.TryParse(operation[0], out ulong left))
        {
            left = item;
        }
        if (!ulong.TryParse(operation[2], out ulong right))
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
