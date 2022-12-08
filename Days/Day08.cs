namespace Days;

public static class Day08
{
    public static (int FirstAnswer, int SecondAnswer) Resolve(IEnumerable<string> data)
    {
        var matrix = ParseData(data);
        int matrixWidth = matrix[0].Count;
        int matrixHeight = matrix[0].Count;
        int perimeter = (matrixWidth + matrixHeight) * 2 - 4;
        int visibleTrees = 0;
        List<int> scenicScores = new();
        for (int row = 1; row < matrixHeight - 1; row++)
        {
            for (int col = 1; col < matrixWidth - 1; col++)
            {
                if (matrix.Visible(row, col))
                {
                    visibleTrees++;
                }
                scenicScores.Add(matrix.ScenicScore(row, col));
            }
        }
        return (visibleTrees + perimeter, scenicScores.Max());
    }

    private static List<List<int>> ParseData(IEnumerable<string> data)
    {
        List<List<int>> matrix = new();
        foreach (string input in data)
        {
            List<int> x = input.Select(x => x - 48).ToList();
            matrix.Add(x);
        }
        return matrix;
    }

    private static bool Visible(this List<List<int>> matrix, int row, int col)
    {
        return matrix.Surround(row, col).Any(vector => matrix[row][col] > vector.Max());
    }

    private static int ScenicScore(this List<List<int>> matrix, int row, int col)
    {
        int val = matrix[row][col];
        var surround = matrix.Surround(row, col);
        int score = 1;
        foreach (var vector in surround)
        {
            int i = 1;

            while (i < vector.Count)
            {
                if (val <= vector[i-1])
                    break;
                i++;
            }
            score *= i;
        }
        return score;
    }

    private static List<List<int>> Surround(this List<List<int>> matrix, int row, int col)
    {
        List<int> rowList = matrix[row];
        List<int> colList = matrix.Select(x => x[col]).ToList();
        return new List<List<int>>()
        {
            rowList.GetRange(0, col).Reverse<int>().ToList(),
            rowList.GetRange(col + 1, rowList.Count - col - 1),
            colList.GetRange(0, row).Reverse<int>().ToList(),
            colList.GetRange(row + 1, colList.Count - row - 1),
        };
    }
}