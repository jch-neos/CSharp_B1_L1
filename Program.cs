// exercise 3 : Manage exceptions so that there is no error when the timeout is exceeded
// exercise 3.1 : detect when cancellation was requested
const int timeout = 300;
using var cts = new CancellationTokenSource(timeout);
Random r = new Random();

async Task RunLongProcessExceptions(int num, int milliseconds, CancellationToken ct = default)
{
    if (r.NextDouble() > 0.999)
    {
        throw new Exception("Random Exception");
    }
    Console.WriteLine($"OK : {num}");
    await Task.Delay(milliseconds, ct);
}

for (int i = 0; i < 100; i++)
{
    await RunLongProcessExceptions(i, 20, cts.Token);
}
Console.WriteLine("OK");
