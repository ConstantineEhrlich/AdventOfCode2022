using System.Collections;
using System.Net;

namespace Helpers;

public class Data: IEnumerable<string>
{
    public int? Year { get; private set; }
    public int? Day { get; private set; }

    private const string Url = "https://adventofcode.com/";
    private static readonly string? Cookie = Environment.GetEnvironmentVariable("ADVENT_COOKIE");

    public IEnumerator<string> GetEnumerator()
    {
        Task<HttpContent> task = GetContentAsync();
        task.Wait();
        StreamReader reader = new StreamReader(task.Result.ReadAsStream());
        while (!reader.EndOfStream)
        {
            yield return reader.ReadLine() ?? string.Empty;
        }
    }

    public Data ForDay(int day)
    {
        Day = day;
        return this;
    }

    public Data ForYear(int year)
    {
        Year = year;
        return this;
    }
    
    private async Task<HttpContent> GetContentAsync()
    {
        if (Year == null) 
            throw new NullReferenceException("Must specify year!");

        if (Day == null)
            throw new NullReferenceException("Must specify day!");

        using HttpClient client = new(MakeHandler());
        {
            string requestUrl = $"{Url}{Year}/day/{Day}/input";
            HttpResponseMessage message = await client.GetAsync(requestUrl);
            message.EnsureSuccessStatusCode();
            return message.Content;
        }        
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