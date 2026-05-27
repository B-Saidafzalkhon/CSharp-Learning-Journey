namespace _01_hello_world;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your name: ");
        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine($"Hello stranger! Nice to meet you!");
        }
        else
        {
            Console.WriteLine($"Hello {name}! Nice to meet you!");
        }
    }
}
