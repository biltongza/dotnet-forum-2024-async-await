namespace Async.Api.Repositories;

public static class CounterRepository
{
    private static long Counter;

    public static async Task<long> GetCounterValueAsync()
    {
        await Task.Delay(Random.Shared.Next(0, 10));
        Interlocked.Increment(ref Counter);
        return Interlocked.Read(ref Counter);
    }
}