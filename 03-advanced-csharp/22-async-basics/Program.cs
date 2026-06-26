namespace _22_async_basics
{
    internal class Program
    {
        static async Task<string> FetchDataAsync()
        {
            Console.WriteLine("Installation...");
            await Task.Delay(3000);
            Console.WriteLine("Installed.");
            return "Data is ready!";
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("== Start ==");

            string result = await FetchDataAsync();
            Console.WriteLine(result);

            Console.WriteLine("== End ==");
        }
        // await waits for the asynchronous operation to complete but does not block the thread.
        // Task.Delay is used instead of Thread.Sleep because Task.Delay does not freeze the thread while waiting.
    }
}
