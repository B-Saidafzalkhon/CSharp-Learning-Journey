namespace _08_generic_max
{
    internal class Program
    {
        static T Max<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) > 0) return a;
            return b;
        }
        static T MaxOf<T>(IEnumerable<T> items) where T : IComparable<T>
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            T? max = default;
            bool isFirst = true;

            foreach (T item in items)
            {
                if (isFirst)
                {
                    max = item;
                    isFirst = false;
                }
                else if (item.CompareTo(max) > 0)
                    max = item;
            }
            if (isFirst)
                throw new InvalidOperationException("Collection is empty");
            return max!;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== \"Max\" Example ===");
            Console.WriteLine($"A: 3 | B: 9\n Max: {Max(3,9)}\n");
            Console.WriteLine($"A: 2.5 | B: 1.1\n Max: {Max(2.5,1.1)}\n");
            Console.WriteLine($"A: Apple | B: Banana\n Max: {Max("Apple", "Banana")}");

            Console.WriteLine("\n=== \"MaxOf \"Example ===");
            Console.WriteLine(MaxOf(new List<int> { 3, 7, 2, 9, 1 }));
            Console.WriteLine(MaxOf(new List<double> { 2.5, 1.1, 9.8, 4.4 }));
            Console.WriteLine(MaxOf(new List<string> { "cat", "zebra", "ant" }));

            try
            {
                Console.WriteLine(MaxOf(new List<int>()));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
