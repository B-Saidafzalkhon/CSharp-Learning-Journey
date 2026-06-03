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
        // ----------------------- Exercise 2 Methods end -----------------------

        // ---------------------- Exercise 3 Methods Start ----------------------
        static bool IsPalindrome(string text)
        {
            text = text.Trim().ToLower().Replace(" ", "");

            int left = 0;
            int right = text.Length - 1;

            while (left < right)
            {
                if (text[left] != text[right])
                {
                    return false;
                }
                left += 1;
                right -= 1;
            }
            return true;
        }

        static string ReadString(string message)
        {
            Console.Write(message);
            while (true)
            {
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Invalid Input! Try Again!");
            }
        }
        // ----------------------- Exercise 3 Methods end -----------------------

        // ---------------------- Exercise 4 Methods Start ----------------------
        static double ReadDouble(string message)
        {
            Console.Write(message);
            while (true)
            {
                string? input = Console.ReadLine();
                if (double.TryParse(input, out double value))
                    return value;

                Console.WriteLine("Invalid input! Try again!");
            }
        }

        static double RectangleArea(double width, double height)
        {
            double area = width * height;
            return area;
        }

        static double CircleArea(double radius)
        {
            double area = Math.PI * Math.Pow(radius, 2);
            return area;
        }

        static double TriangleArea(double triangleBase, double height)
        {
            double area = (triangleBase * height) / 2;
            return area;
        }

        static int ShowMenuAndReadChoice()
        {
            Console.WriteLine("====== Area calculator ======");
            Console.WriteLine("1. Rectangle area\n" +
                "2. Circle area\n" +
                "3. Triangle area\n" +
                "4. Exit");

            int choice = ReadInt("Enter choice: ");
            return choice;
        }

        static void Main(string[] args)
        {
            // Exercise 1 Array Statistics
            {
                Console.WriteLine("====== Array Statistics ======");

                int n = ReadInt("Amount of numbers: ");
                int[] numbers = ReadArray(n);
                PrintStatistics(numbers);

                PauseAndClear();
            }

            // Exercise 2 Calculator
            {
                Console.WriteLine("====== Calculator ======");
                decimal a = ReadDecimal("Enter a: ");
                char op = ReadOperator("Enter operation: ");
                decimal b = ReadDecimal("Enter b: ");

                decimal? result = Calculate(a, b, op);
                if (result.HasValue)
                {
                    Console.WriteLine($"Result: {result}");
                }
                else
                {
                    Console.WriteLine("Cannot compute result.");
                }
                PauseAndClear();
            }

            // Exercise 3 Palindrome
            {
                bool isWorking = true;
                while (isWorking)
                {
                    Console.WriteLine("====== Palindrome ======");

                    string input = ReadString("Enter a string (or 'exit'): ");
                    if (input.Trim().ToLower().Replace(" ", "") == "exit")
                    {
                        Console.WriteLine("Goodbye!");
                        isWorking = false;
                        PauseAndClear();
                    }
                    else
                    {
                        bool isPalindrome = IsPalindrome(input);
                        if (isPalindrome)
                        {
                            Console.WriteLine($"'{input}' is Palindrome!");
                        }
                        else
                        {
                            Console.WriteLine($"'{input}' is not Palindrome!");
                        }
                        PauseAndClear();
                    }
                }
            }

            // Exercise 4 Area calculator
            {
                while (true)
                {
                    int choice = ShowMenuAndReadChoice();

                    switch (choice)
                    {
                        case 1:
                            {
                                double width = ReadDouble("Enter Width: ");
                                double height = ReadDouble("Enter Height: ");

                                double result = RectangleArea(width, height);
                                Console.WriteLine($"Rectangle Area: {result}");

                                PauseAndClear();
                            }
                            break;

                        case 2:
                            {
                                double radius = ReadDouble("Enter Radius: ");

                                double result = CircleArea(radius);
                                Console.WriteLine($"Circle Area: {result}");
                                PauseAndClear();
                            }
                            break;

                        case 3:
                            {
                                double triangleBase = ReadDouble("Enter Triangle Base: ");
                                double height = ReadDouble("Enter Height: ");

                                double result = TriangleArea(triangleBase, height);
                                Console.WriteLine($"Triangle Area: {result}");
                                PauseAndClear();
                            }
                            break;

                        case 4:
                            Console.WriteLine("Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid Input! Try again!");
                            PauseAndClear();
                            break;
                    }

                    if (choice == 4)
                        break;
                }
            }
        }
    }
}