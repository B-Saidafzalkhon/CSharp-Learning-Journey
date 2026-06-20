namespace _12_delegates_basics
{
    internal class Program
    {
        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static double Divide(double a, double b) => a / b;

        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (double.TryParse(input, out double number))
                    return number;

                Console.WriteLine("Invalid input!");
            }
        }
        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                    return number;

                Console.WriteLine("Invalid input!");
            }
        }
        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        static void Main(string[] args)
        {
            Func<double, double, double>? op = null;
            while (true)
            {
                Console.WriteLine("=== Delegates Example ===");
                Console.WriteLine("Options:\n" +
                    "1. Add\n" +
                    "2. Subtract\n" +
                    "3. Multiply\n" +
                    "4. Divide\n" +
                    "5. Exit");

                int option = ReadInt("Enter the option: ");
                string title = "";
                switch (option)
                {
                    case 1:
                        op = Add;
                        title = "=== Add ===";
                        break;

                    case 2:
                        op = Subtract;
                        title = "=== Subtract ===";
                        break;

                    case 3:
                        op = Multiply;
                        title = "=== Multiply ===";
                        break;

                    case 4:
                        op = Divide;
                        title = "=== Divide ===";
                        break;

                    case 5:
                        Console.WriteLine("Goodbye...");
                        Pause();
                        return;

                    default:
                        Console.WriteLine("Invalid input!");
                        Pause();
                        continue;
                }
                Console.Clear();
                Console.WriteLine(title);

                double a = ReadDouble("Enter number (a): ");
                double b = ReadDouble("Enter number (b): ");

                if(option == 4 && b == 0)
                {
                    Console.WriteLine("Cannot devide by 0!");
                    Pause();
                    continue;
                }

                double result = op(a, b);
                Console.WriteLine($"Result: {result}");
                Pause();
            }
        }
    }
}
