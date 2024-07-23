using Dont.App;

Console.WriteLine("Starting don'ts");

//Console.WriteLine("Async void");
await AsyncVoidClass.AsyncVoid();

//  Task.Result will always throw AggregateException
/// Task.GetAwaiter().GetResult() will throw the first exception, or AggregateException if there are multiple exceptions

//Console.WriteLine("Using Task.Result");
await TaskResult.GetByIdWithTaskResultAsync();

Console.WriteLine("Using Task.Completed");
await Task_Completed.TaskCompleted();

Console.WriteLine("Done with don'ts");

