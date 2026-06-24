namespace _17_linq_basics
{
    internal class Program
    {
        static void Print<T>(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 30; i++)
                numbers.Add(i);

            var even = numbers.Where(n => n % 2 == 0);

            var doubled = numbers.Select(n => n * 2);

            var evenAndDoubled = numbers
                .Where(n => n % 2 == 0)
                .Select(n => n * 2);

            var squareOfNumbers = numbers
                .Where(n => n > 10)        
                .Select(n => n * n);        

            Print(even);
            Print(doubled);
            Print(evenAndDoubled);
            Print(squareOfNumbers);

            // Where - Filter from previous theme
            // Select - Transform from previous theme
        }
    }
}
