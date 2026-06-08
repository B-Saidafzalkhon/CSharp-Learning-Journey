namespace _10_error_handling
{
    internal class Program
    {
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
            }
        }
    }
}
