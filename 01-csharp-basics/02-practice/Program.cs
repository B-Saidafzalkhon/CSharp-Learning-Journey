namespace _02_practice;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== Exercise #1 =====");
        Console.Write("Enter Your Name: ");
        string? name = Console.ReadLine();

        Console.Write("Enter Your Age: ");
        string? age = Console.ReadLine();

        int ageValue = int.Parse(age!);

        Console.WriteLine($"Hello, {name}! You have {100 - ageValue} years until you turn 100. \nEnter any key to continue...");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("===== Exercise #2 =====");
       
        Console.WriteLine("Arguments passed to the program:");
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine($"Argument #{i + 1}: {args[i]}");
        }

        Console.WriteLine("Enter any key to continue...");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("===== Exercise #3 =====");
        Console.Write("Enter First Number: ");
        int firstNumber = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Second Number: ");
        int secondNumber = int.Parse(Console.ReadLine()!);

        int sum = firstNumber + secondNumber;
        int diff = firstNumber - secondNumber;
        int product = firstNumber * secondNumber;

        Console.WriteLine($"Sum: {sum}" +
            $"\nDifference: {diff}" +
            $"\nProduct: {product}");
    }
}