
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class C {
    public static async ValueTask<int> M(CancellationToken ct) {
        await Task.Delay(100, ct);        
        await Task.Delay(100, ct);
        if(ct.IsCancellationRequested) return await ValueTask.FromCanceled<int>(ct);
        return 2;
    }
    public static async Task Main() {

        var cts = new CancellationTokenSource();

        cts.CancelAfter(10);

        var t = M(cts.Token);
        await Task.Delay(100);        
        var r = t.GetAwaiter();

        Console.WriteLine((
            t.IsCanceled,
            t.IsCompleted,
            t.IsFaulted,
            t.IsCompletedSuccessfully
        ));
        Console.WriteLine(r.IsCompleted);
        Console.WriteLine(r.GetResult());

    }
    
}
