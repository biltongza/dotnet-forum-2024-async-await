// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

MyAwaitable<int> t = new();

t.SetResult(123);
var result = await t;
Console.WriteLine(result);