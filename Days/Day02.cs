using Helpers;

namespace Days;

public static class Day02
{
    private static Dictionary<char, char> parse = new()
    {
        { 'A', 'R' },
        { 'B', 'P' },
        { 'C', 'S' },
        { 'X', 'R' },
        { 'Y', 'P' },
        { 'Z', 'S' },
    };
    
    private static Dictionary<char, char> win = new()
    {
        { 'R', 'S' }, // Rock wins scissors
        { 'P', 'R' }, // Paper wins rock
        { 'S', 'P' } // Scissors wins paper
    };

    private static Dictionary<char, char> lose = new()
    {
        { 'R', 'P' }, // Rock looses to paper
        { 'P', 'S' }, // Paper looses to scissors
        { 'S', 'R' }, // Scissors looses to rock
    };
    
    private enum GameResult: int
    {
        Win = 6,
        Lose = 0,
        Draw = 3,
    }
    
    public static (int FirstAnswer, int SecondAnswer) Resolve(IEnumerable<string> data)
    {
        int finalScore = 0;
        int finalScoreAlternate = 0;
        foreach (string input in data)
        {
            finalScore += CalculateScore(ParseInput(input));
            finalScoreAlternate += CalculateScore(ParseInputAlternate(input));
        }
        
        return (finalScore, finalScoreAlternate);
    }

    public static (char Opponent, char You) ParseInput(string input)
    {
        
        if (input.Length == 3)
        {
            return (parse[input[0]], parse[input[2]]);
        }
        else
        {
            throw new ArgumentException("String {} is not three characters");
        }
    }

    public static (char Opponent, char You) ParseInputAlternate(string input)
    {
        if (input.Length == 3)
        {
            char opponent = parse[input[0]];

            char you = input[2] switch
            {
                'Y' => opponent, // draw
                'X' => win[opponent], // opponent looses, you win
                'Z' => lose[opponent], // you lose, opponent wins
                _ => '_'
            };

            return (opponent, you);
        }
        else
        {
            throw new ArgumentException("String {} is not three characters");
        }
    }

    public static int CalculateScore((char Opponent, char You) signs)
    {
        int signScore = signs.You switch
        {
            'R' => 1,
            'P' => 2,
            'S' => 3,
            _ => 0
        };

        GameResult gameResult;
        if (signs.You == signs.Opponent)
            gameResult = GameResult.Draw;
        else if (signs.You == win[signs.Opponent])
            gameResult = GameResult.Lose;
        else
            gameResult = GameResult.Win;

        return signScore + (int)gameResult;
    }
    
}