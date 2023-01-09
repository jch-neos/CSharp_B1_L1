// exercise 5 : Run and observe results

using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
[MemoryDiagnoser]
public class Test
{
    [Benchmark]
    public int RunValueSync()
    {
        var a = GetSync();
        var b = GetSync();
        var c = GetSync();

        return a + b + c;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    int GetSync() => 10;


    [Benchmark]
    public async Task<int> RunValue()
    {
        var a = await GetValue();
        var b = await GetValue();
        var c = await GetValue();

        return a + b + c;
    }
    [Benchmark]
    public async Task<int> RunValueAsync()
    {
        var a = await GetValueAsync();
        var b = await GetValueAsync();
        var c = await GetValueAsync();

        return a + b + c;
    }
#pragma warning disable CS1998
    async ValueTask<int> GetValueAsync()
    {
        return 10;
    }
#pragma warning restore CS1998
    [MethodImpl(MethodImplOptions.NoInlining)]
    ValueTask<int> GetValue()
    {
        return ValueTask.FromResult(10);
    }

    [Benchmark]
    public async Task<int> Run()
    {
        var a = await Get();
        var b = await Get();
        var c = await Get();

        return a + b + c;
    }
    [Benchmark]
    public async Task<int> RunAsync()
    {
        var a = await GetAsync();
        var b = await GetAsync();
        var c = await GetAsync();

        return a + b + c;
    }

#pragma warning disable CS1998
    async Task<int> GetAsync()
    {
        return 10;
    }
#pragma warning restore CS1998

    [MethodImpl(MethodImplOptions.NoInlining)]
    Task<int> Get()
    {
        return Task.FromResult(10);
    }
}