namespace Days;

public static class Day06
{
    public static (int FirstAnswer, int SecondAnswer) Resolve(IEnumerable<string> data)
    {
        string input = data.First();
        return (input.FindStartMarker(Marker.Packet), input.FindStartMarker(Marker.Message));
    }

    private static int FindStartMarker(this string input, Marker marker)
    {
        int startIndex;
        for (startIndex = 0; startIndex < input.Length - (int)marker; startIndex++)
        {
            string substr = input.Substring(startIndex, (int)marker);
            if (new HashSet<char>(substr).Count == (int)marker)
            {
                return startIndex + (int)marker;
            }
        }
        return 0;
    }

    private enum Marker
    {
        Packet = 4,
        Message = 14
    }
}