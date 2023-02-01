using System.Diagnostics;

var ts = Stopwatch.GetTimestamp();

Stopwatch.GetElapsedTime(ts);

var arr = Enumerable.Range(1, 200).Select(Test);
var t = Task.WhenAll(arr);
try {
  await t;
} catch (Exception e) {
  Console.WriteLine(e);
}


Console.WriteLine(Stopwatch.GetElapsedTime(ts));

async Task Test(int x) {
  await Task.Delay(1000);
  if (x == 199) {
  }
  if (x > 190) {
    throw new OperationCanceledException();
    throw new Exception($"{x} > 190");
  }
  await Console.Out.WriteLineAsync($"Test  : {System.Threading.Thread.CurrentThread.ManagedThreadId}");
}