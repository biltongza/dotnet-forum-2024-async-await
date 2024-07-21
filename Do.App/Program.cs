// See https://aka.ms/new-console-template for more information

using Do.App;

Console.WriteLine("Hello, World!");


/* Do's
		Always await a task (5 mins)
			Ensure control flow
			Unobserved exceptions
		Pass cancellation tokens (5 mins)
			Having a way to cancel a process all the way to the bottom of the call stack
			An example, include a cancellation token in your ASP.NET controller path.  When the connection closes, whole request closes
		Postfix async methods with "Async" (2 min)
			People might just call "DoSomething" without realising it's an async method
			Write two methods, one sync, one async, and "forget" to use the async one
		Use helpers e.g. Task.WhenAll for parallel work (5 mins)
			use select with Task.WhenAll
			Task.WhenAll
			Task.WhenAny
			Task.Delay
		Return task when you don't have to await
*/
await ConsiderUsingWhenAnyAndWhenAll.DoingAsyncThing();

