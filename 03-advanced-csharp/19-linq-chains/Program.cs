namespace _19_linq_chains
{
    internal class Program
    {
        static void Pause()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            {
                // This is exactly what deferred execution is:
                // the query was executed during the iteration and picked up the modified list.
                Console.WriteLine("=== Deferred execution ===");
                List<int> numbers = new()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

                var even = numbers.Where(n => n % 2 == 0);

                numbers.AddRange(new int[] { 11, 12, 13, 14, 15 });

                foreach (var item in even)
                {
                    Console.Write(item + " ");
                }
                Pause();
            }

            {
                // Immediate execution is:
                // ToList() executed the query immediately and saved the result.
                // Later changes to the original list did not affect the saved list.
                Console.WriteLine("=== Immediate execution ===");
                List<int> numbers = new()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

                var even = numbers.Where(n => n % 2 == 0).ToList();

                numbers.AddRange(new int[] { 11, 12, 13, 14, 15 });

                foreach (var item in even)
                {
                    Console.Write(item + " ");
                }
                Pause();
            }
        }
    }
}
