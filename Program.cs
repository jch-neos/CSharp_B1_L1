using System.Diagnostics;

var ts = Stopwatch.GetTimestamp();

Stopwatch.GetElapsedTime(ts);

var arr = Enumerable.Range(1, 20).Select(Test).ToArray();
var t = Task.WhenAny(arr);
var finished = await t;
Console.WriteLine($"task #{Array.IndexOf(arr, finished)} : {await finished}");

Console.WriteLine(Stopwatch.GetElapsedTime(ts));

async Task<string> Test(int x)
{
    var delay = Random.Shared.Next(2000) * 100;
    await Task.Delay(delay);
    return $"task delay {delay}";
}