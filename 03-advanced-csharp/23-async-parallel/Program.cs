namespace _23_async_parallel
{
    internal class Program
    {
        static async Task<string> DownloadAsync(string name, int seconds)
        {
            Console.WriteLine($"Started Task: {name}");
            await Task.Delay(seconds * 1000);
            return $"Task: {name} - completed.";
        }
        static async Task Main(string[] args)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();

            Console.ForegroundColor = ConsoleColor.Yellow;
            string a = await DownloadAsync("Task-A", 2);
            string b = await DownloadAsync("Task-B", 2);
            string c = await DownloadAsync("Task-C", 2);

            sw.Stop();

            Console.ResetColor();
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Sequential time: {sw.Elapsed}\n");
            Console.ResetColor();

            sw.Restart();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Task<string> taskA = DownloadAsync("Task-A1", 2);
            Task<string> taskB = DownloadAsync("Task-B1", 2);
            Task<string> taskC = DownloadAsync("Task-C1", 2);
            string[] result = await Task.WhenAll(taskA, taskB, taskC);
            sw.Stop();

            Console.ResetColor();
            foreach (string s in result)
            {
                Console.WriteLine(s);
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Parallel time: {sw.Elapsed}");
            Console.ResetColor();
        }
        // Parallel version is faster because all tasks wait at the same time.
        // In the sequential version each task starts only after the previous one finishes.
        // So sequential time is about the sum of all delays, while parallel time is about the longest delay.
    }
}
