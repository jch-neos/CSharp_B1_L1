// exercise 1.1 : why is the code slow to run ? can you correct it ?
using System.Diagnostics;

const int count = 100;
Task[] tasks = new Task[count];
var start = Stopwatch.GetTimestamp();
for (int i = 0; i < count; i++)
{
    tasks[i] = Run();
}
for (int i = 0; i < count; i++)
{
    await tasks[i];
}
var end = Stopwatch.GetElapsedTime(start);
Console.WriteLine($"Elapsed : {end.TotalMilliseconds}");

async Task<int> Run() {
    Thread.Sleep(100);
    return await Task.FromResult(1);
}