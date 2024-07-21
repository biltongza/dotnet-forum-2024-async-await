

namespace Do.App
{
    internal class ConsiderUsingWhenAnyAndWhenAll
    {

        public async static Task DoingAsyncThing(CancellationToken cancellationToken = default)
        {
            Console.WriteLine("Doing async thing.");

            List<Task<int>> tasks = new List<Task<int>> {
                DoALongThingAsync(3),
                DoALongThingAsync(2),
                DoALongThingAsync(3),
                DoALongThingAsync(4)
            };

            Console.WriteLine("Done doing async thing.");

        }

        public static async Task<int> DoALongThingAsync(int taskNumber)
        {
            Console.WriteLine("Task: " + taskNumber);
            //throw new Exception("Swomthing went wrong: " + taskNumber);
            await Task.Delay((TimeSpan.FromSeconds(taskNumber)));
            return taskNumber;
        }
    }
}
