namespace Days;
using static Math;

public static class Day09
{
    public static (int FirstAnswer, int SecondAnswer) Resolve(IEnumerable<string> data)
    {
        Rope ropeOne = new(2);
        Rope ropeTwo = new(10);
        foreach (string direction in data)
        {
            ropeOne.Move(direction);
            ropeTwo.Move(direction);
        }
        
        return (ropeOne.TailHistory.Count, ropeTwo.TailHistory.Count);
    }
}

public class Rope
{
    public HashSet<(int x, int y)> TailHistory { get; } = new();

    private (int x, int y) Head
    {
        get => Knots[0];
        set => Knots[0] = value;
    }

    private (int x, int y) Tail => Knots[^1];

    private List<(int x, int y)> Knots { get; } = new();
    
    public Rope(int knots)
    {
        for (int i = 0; i < knots; i++)
        {
            Knots.Add((0, 0));
        }
    }
    
    public void Move(string direction)
    {
        int.TryParse(direction.Substring(2, direction.Length - 2), out int distance);

        for (int step = 0; step < distance; step++)
        {
            (int x, int y) head = Head;
            switch (direction[0])
            {
                case 'U':
                    head.y++;
                    break;
                case 'D':
                    head.y--;
                    break;
                case 'R':
                    head.x++;
                    break;
                case 'L':
                    head.x--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), $"'{direction[0]}' is wrong direction!");
            }
            Head = head;

            for (int i = 1; i < Knots.Count; i++)
            {
                (int x, int y) knot = Knots[i-1];
                (int x, int y) tail = Knots[i];
                Catch(knot, ref tail);
                Knots[i] = tail;
            }
            
            TailHistory.Add(Tail);
        } 
    }

    private static void Catch((int x, int y) head, ref (int x, int y) tail)
    {
        (int x, int y) diff = (head.x - tail.x, head.y - tail.y);
        (int x, int y) diffAbs = (Abs(diff.x), Abs(diff.y));
        
        if (diffAbs.x <= 1 & diffAbs.y <= 1)
            return;

        if (diffAbs.x == 2)
        {
            tail.x += diff.x / 2;
            if (diffAbs.y == 1)
            {
                tail.y += diff.y;                
            }
        }

        if (diffAbs.y == 2)
        {
            tail.y += diff.y / 2;
            if (diffAbs.x == 1)
            {
                tail.x += diff.x;
            }
        }
    }
}