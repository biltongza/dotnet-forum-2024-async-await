using Dont.App;

Console.WriteLine("Starting don'ts");

//Console.WriteLine("Async void");
//AsyncVoidClass.AsyncVoid();

//Console.WriteLine("Using Task.Result");
await TaskResult.GetByIdWithTaskResultAsync();

//Console.WriteLine("Using Task.Completed");
//await Task_Completed.TaskCompleted();

//Console.WriteLine("Mixing sync and async");
//await MixSyncAsyncClass.MixSyncAsync();

Console.WriteLine("Done with don'ts");

