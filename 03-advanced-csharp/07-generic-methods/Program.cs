namespace _07_generic_methods
{
    internal class Program
    {
        static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        static T[] Repeat<T>(T item, int count)
        {
            T[] array = new T[count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = item;
            }
            return array;
        }

        static void PrintPair<T1, T2>(T1 a, T2 b)
        {
            Console.WriteLine($"Pair: {a,-5}{b}");
        }

        static void Print<T>(IEnumerable<T> values)
        {
            foreach (T t in values) Console.Write(t + " ");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== Repeat Example ===");
            int[] ints = Repeat(1, 10);
            Print(ints);

            Console.WriteLine();

            string[] strings = Repeat<string>("String",10);
            Print(strings);


            Console.WriteLine("\n\n=== Swap / Pair Example ===");
            int a = 0, b = 1;

            Console.WriteLine($"a: {a} | b: {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"Swapped: \na: {a} | b: {b}");

            PrintPair("Mika | Number: +",987654321);
        }
    }
}
