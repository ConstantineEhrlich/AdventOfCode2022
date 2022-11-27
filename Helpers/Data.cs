using System.Collections;
using System.Net;

namespace Helpers;

public class Data: IEnumerable<string>
{
    private const string Url = "https://adventofcode.com/";
    private static readonly string? Cookie = Environment.GetEnvironmentVariable("ADVENT_COOKIE");
    
    private int? _day;
    private int? _year;

    public IEnumerator<string> GetEnumerator()
    {
        Task<HttpContent> task = GetContent();
        task.Wait();
        StreamReader reader = new StreamReader(task.Result.ReadAsStream());
        while (!reader.EndOfStream)
        {
            yield return reader.ReadLine() ?? string.Empty;
        }
    }
    
    public Data ForDay(int day)
    {
        _day = day;
        return this;
    }

    public Data ForYear(int year)
    {
        _year = year;
        return this;
    }
    
    private async Task<HttpContent> GetContent()
    {
        if (_year == null) 
            throw new NullReferenceException("Must specify year!");

        if (_day == null)
            throw new NullReferenceException("Must specify day!");

        using HttpClient client = new(MakeHandler());

        string requestUrl = $"{Url}{_year}/day/{_day}/input";
        HttpResponseMessage message = await client.GetAsync(requestUrl);
        
        // This may throw HttpRequestException
        message.EnsureSuccessStatusCode();
        
        return message.Content;
    }
    
    private static HttpClientHandler MakeHandler()
    {
        if (Cookie == null | Cookie == string.Empty)
            throw new NullReferenceException("Please set environment variable ADVENT_COOKIE");

        var handler = new HttpClientHandler();
        handler.CookieContainer.Add(new Uri(Url), new Cookie("session", Cookie));
        return handler;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}