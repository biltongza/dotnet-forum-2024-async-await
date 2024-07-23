Console.WriteLine("[Main] Creating promise");
var promise = new Promise((resolve, reject) =>
{
    WriteConsoleColour($"[Resolver] Hello from resolver!", ConsoleColor.Green);
    resolve();
    //reject(new Exception("Hello!"));
});
Console.WriteLine($"[Main] promise = {promise}");
var thenPromise = promise.Then(() =>
{
    WriteConsoleColour($"[Then] Hello from then!", ConsoleColor.Yellow);
});

var catchPromise = promise.Catch(ex =>
{
    WriteConsoleColour($"[Catch] Exception caught!", ConsoleColor.Red);
});

var finallyPromise = promise.Finally(() =>
{
    WriteConsoleColour($"[Finally] Hello from finally!", ConsoleColor.Blue);
    ManualResetEventSlim sleep = new ManualResetEventSlim();
    Task.Delay(1000).ContinueWith(_ => sleep.Set());
    sleep.Wait();
    WriteConsoleColour($"[Finally] Byeeee", ConsoleColor.Blue);
});
Console.WriteLine("[Main] Awaiting promise...");
await promise;
Console.WriteLine("[Main] All done!");


void WriteConsoleColour(string str, ConsoleColor colour = ConsoleColor.Gray)
{
    Console.ForegroundColor = colour;
    Console.WriteLine(str);
    Console.ForegroundColor = ConsoleColor.Gray;
}


