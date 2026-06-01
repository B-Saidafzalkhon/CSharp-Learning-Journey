namespace _07_methods
{
    internal class Program
    {
        // ---------------------- Exercise 1 Methods Start ----------------------

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                    return number;

                Console.WriteLine("Invalid input! Try again!");
            }
        }
        static int Sum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
        static double Average(int[] array)
        {

            int sum = Sum(array);
            double average = (double)sum / array.Length;
            return average;
        }
        static int Min(int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min) min = array[i];
            }
            return min;
        }
        static int Max(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max) max = array[i];
            }
            return max;
        }
        static int[] ReadArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = ReadInt($"Enter number #{i + 1}: ");
            }
            return array;
        }
        static void PrintStatistics(int[] array)
        {
            Console.WriteLine($"Sum: {Sum(array)}");
            Console.WriteLine($"Min: {Min(array)}");
            Console.WriteLine($"Max: {Max(array)}");
            Console.WriteLine($"Average: {Average(array):F2}");
        }
        // ----------------------- Exercise 1 Methods end -----------------------

        static void PauseAndClear()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        // ---------------------- Exercise 2 Methods Start ----------------------
        static decimal ReadDecimal(string message)
        {
            Console.Write(message);
            while (true)
            {
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal value))
                    return value;

                Console.WriteLine("Invalid input! Try again!");
            }
        }
        static char ReadOperator(string message)
        {
            Console.Write(message);
            while (true)
            {
                string? input = Console.ReadLine();
                if (char.TryParse(input, out char op) && (op == '+' || op == '-' || op == '*' || op == '/'))
                    return op;

                Console.WriteLine("Invalid operator! Use + - * /");
            }
        }
        static decimal Sum(decimal a, decimal b)
        {
            return a + b;
        }
        static decimal Diff(decimal a, decimal b)
        {
            return a - b;
        }
        static decimal Product(decimal a, decimal b)
        {
            return a * b;
        }
        static decimal Quotient(decimal a, decimal b)
        {
            return a / b;
        }
        static decimal? Calculate(decimal a, decimal b, char op)
        {
            decimal? result = op switch
            {
                '+' => Sum(a, b),
                '-' => Diff(a, b),
                '*' => Product(a, b),
                '/' when b != 0 => Quotient(a, b),
                _ => null
            };
            return result;
        }
        static void Main(string[] args)
        {
            // Exercise 1
            {
                Console.WriteLine("====== Array Statistics ======");

                int n = ReadInt("Amount of numbers: ");
                int[] numbers = ReadArray(n);
                PrintStatistics(numbers);

                PauseAndClear();
            }

            // Exercise 2
            {
                Console.WriteLine("====== Calculator ======");
                decimal a = ReadDecimal("Enter a: ");
                char op = ReadOperator("Enter operation: ");
                decimal b = ReadDecimal("Enter b: ");

                decimal? result = Calculate(a, b, op);
                if (result.HasValue)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Cannot compute result.");
                }
            }
        }
    }
}