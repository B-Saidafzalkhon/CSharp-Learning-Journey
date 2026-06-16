namespace _05_ienumerable_methods
{
    internal class Program
    {
        static void PrintAll<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.Write(item + " ");
            }
        }
        static void CountItems<T>(IEnumerable<T> items)
        {
            int count = 0;
            foreach (var item in items)
            {
                count++;
            }
            Console.WriteLine($"| Count: {count}\n");
        }

        static void Main(string[] args)
        {
            // All Collections Example
            List<int> ints = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            HashSet<string> strings = new HashSet<string>()
            {
                "Text-1", "Text-2", "Text-3", "Text-4"
            };

            Queue<int> numbers = new Queue<int>();
            int[] array = new int[10];

            for (int i = 0; i < array.Length; i++)
            {
                numbers.Enqueue(i);
                array[i] = i;
            }
            // ----------------------

            Console.WriteLine("List: ");
            PrintAll(ints);
            CountItems(ints);

            Console.WriteLine("Hash Set: ");
            PrintAll(strings);
            CountItems(strings);

            Console.WriteLine("Queue: ");
            PrintAll(numbers);
            CountItems(numbers);

            Console.WriteLine("Array: ");
            PrintAll(array);
            CountItems(array);


            // I use IEnumerable<T> because these methods only need to read items one by one.
            // They do not need index access, adding, removing, or changing the collection.
            // IEnumerable<T> is enough for foreach, so the methods work with many collection types.
            //
            // Thanks to IEnumerable<T>, I can pass List<int>, HashSet<string>, Queue<int>, and int[].
            // If I used List<T>, the method would work only with List<T>.
            // If I used IList<T>, List<T> and int[] would work, but Queue<T>, Stack<T>, and HashSet<T> would not,
            // because they do not provide index-based access.
            //
            // This follows the idea: ask only for the minimum interface you really need.
            // In this case, I only need enumeration, so IEnumerable<T> is the best choice.


        }
    }
}
