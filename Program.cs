AppDomain.CurrentDomain.UnhandledException += (object sender, UnhandledExceptionEventArgs e) =>{
    Console.WriteLine("------------------------------");
    Console.WriteLine(e.ExceptionObject.ToString());
    Console.WriteLine(e.IsTerminating);
    Console.WriteLine(sender.GetType().FullName);
    Console.WriteLine("------------------------------");
};

Test();
await Task.Delay(10000);
async void Test() {
    await Task.Delay(100);
    throw new Exception("test");
}