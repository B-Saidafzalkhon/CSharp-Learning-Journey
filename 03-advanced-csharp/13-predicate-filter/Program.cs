using System.Text;
namespace _13_predicate_filter
{
    internal class Program
    {
        static List<int> Filter(List<int> numbers, Predicate<int> condition)
        {
            List<int> result = new();
            foreach (int number in numbers)
            {
                if (condition(number))
                    result.Add(number);
            }
            return result;
        }
        static string Print(List<int> numbers)
        {
            StringBuilder sb = new StringBuilder();

            foreach (int number in numbers)
                sb.Append(number + " ");

            return sb.ToString();
        }
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = -10; i <= 20; i++)
                numbers.Add(i);

            var even = Filter(numbers, n => n % 2 == 0);
            var big = Filter(numbers, n => n > 10);
            var negative = Filter(numbers, n => n < 0);
            var divisibleByThree = Filter(numbers, n => n % 3 == 0);

            Console.WriteLine($"Even numbers: {Print(even)}\n" +
                $"Bigger than 10: {Print(big)}\n" +
                $"Negative numbers: {Print(negative)}\n" +
                $"Numbers divisible by 3: {Print(divisibleByThree)}");
        }
    }
}
