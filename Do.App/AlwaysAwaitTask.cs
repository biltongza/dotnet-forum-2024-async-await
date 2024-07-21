using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do.App
{
    public static class AlwaysAwaitTask
    {

        public static async Task DoSomethingAsync()
        {
            Console.WriteLine("Doing something async.");
            await throwAnErrorAsync();
        }

        public static Task  throwAnErrorAsync() => throw new NotImplementedException();

        public static async Task <int> doSomethingAsync(int taskId){
            await Task.Delay(1000);
            Console.WriteLine("Done doing something async with: "+ taskId);
            return taskId;

        }


    }
}
