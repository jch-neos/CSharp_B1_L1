using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

public class C {

  static async Task Main() {
    using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(300));
    var token = cts.Token;
    await foreach (var item in GetSequence().WithCancellation(token)) {
      Console.WriteLine(item);
    }
  }

  static async IAsyncEnumerable<int> GetSequence(
  [EnumeratorCancellation] CancellationToken ct = default
  ) {
    for (int i = 1; i <= 100; i++) {
      ct.ThrowIfCancellationRequested();
      if (i % 20 == 0) await Task.Delay(100);
      yield return i;
    }
  }


}



// var tasks = Enumerable.Range(1,20).Select(i=> new Task(() => {
//   Thread.Sleep(1000);
//   if(i%4 ==0) throw new Exception();
//   Thread.Sleep(1000);
//   Console.WriteLine(i);
// })).ToList();

// tasks.ForEach(x=>x.Start());
// Task t;
// try {
//    t = Task.WhenAll(tasks);
//    await t;
// } catch(Exception e) {
//   var arr = tasks.Where(x=>x.IsFaulted).ToList();
//       arr.ForEach(x=>x.Start());
// }



