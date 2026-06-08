namespace _10_error_handling
{
    internal class Program
    {
        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static double Divide(int a, int b)
        {
            if(b == 0)
                throw new DivideByZeroException("Divisor cannot be equal to zero");

            return (double)a / b;
        }
        static int ReadInt(string message)
        {
            while(true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if(int.TryParse(input, out int number))
                    return number;

                Console.WriteLine("Invalid input! Try again...");
            }
        }
        static void Main(string[] args)
        {       
            // Exercise 1
            {
                Console.WriteLine("====== Safe input reader ======");

                // Version A (With TryParse)
                {
                    Console.WriteLine("\n=== Try Parse ===");

                    Console.Write("Input: ");
                    string? input = Console.ReadLine();

                    if (int.TryParse(input, out int value))
                    {
                        Console.WriteLine($"Value {value} converted into integer.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                // Version B
                {
                    Console.WriteLine("\n=== Try Catch ===");

                    try
                    {
                        Console.Write("Input: ");
                        int input = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Value {input} converted into integer.");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Pause();
            }

            // Exercise 2
            {
                Console.WriteLine("====== Calculator with exeption ======");

                int a = ReadInt("Enter a: ");
                int b = ReadInt("Enter b: ");
                try
                {
                    double result = Divide(a, b);
                    Console.WriteLine($"Result: {result:F2}");
                }
                catch(DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Pause();
            }           
        }
    }
}
