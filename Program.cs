// exercise 6 : Use Debugger

using System.Diagnostics;

var tasks = Enumerable.Range(1,500).Select(i => Task.Run(delegate {
    var j=0;
    while(i>0) {
        j*=j;
        i--;
    }
})).ToArray();
Thread.Sleep(10);
if(Debugger.IsAttached)
    Debugger.Break();
Task.WhenAll(tasks);