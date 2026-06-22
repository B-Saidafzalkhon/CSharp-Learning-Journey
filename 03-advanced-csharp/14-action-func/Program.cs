using System.Text;

namespace _14_action_func
{
    internal class Program
    {
        static void ForEach<T>(IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }
        static List<int> Transform(List<int> numbers, Func<int, int> transformer)
        {
            List<int> result = new List<int>();
            foreach (var item in numbers)
            {
                result.Add(transformer(item));
            }
            return result;
        }
        static void Print<T>(IEnumerable<T> items)
        {
            foreach(T item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== Action: Printing ===");
            List<string> values = new List<string>();
            for (int i = 0; i < 11; i++)
            {
                values.Add($"string #{i + 1}");
            }
            Action<string> action = Console.WriteLine;
            ForEach(values, action);
            Pause();

            Console.WriteLine("=== Function: Transforming ===");
            List<int> numbers = new List<int>();
            for (int i = 0; i < 11; i++)
            {
                numbers.Add(i);
            }
            Console.WriteLine("=== Original List ===");
            Print(numbers);

            Func<int, int> doubleIt = n => n * 2;
            Func<int, int> square = n => n * n;
            Func<int, int> increaseByTen = n => n + 10;

            Console.WriteLine("\n=== Increased ===");
            List<int> increased = Transform(numbers, doubleIt);
            Print(increased);

            Console.WriteLine("\n=== Squared ===");
            List<int> squared = Transform(numbers, square);
            Print(squared);

            Console.WriteLine("\n=== Increased by 10 ===");
            List<int> increasedByTen = Transform(numbers, increaseByTen);
            Print(increasedByTen);
        }
    }
}
