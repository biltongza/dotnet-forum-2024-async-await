namespace Dont.App;

public static class Task_Completed
{
    public static async Task TaskCompleted()
    {
        Console.WriteLine("Doing some sync work");
        var sumOf42 = Enumerable.Range(0, 42).Sum();

    }
}