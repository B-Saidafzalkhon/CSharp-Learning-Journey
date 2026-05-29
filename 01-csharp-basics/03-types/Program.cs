namespace _03_types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exersice 1
            Console.WriteLine("====== Temperature converter ======");

            Console.Write("Enter temperature in Celsius: ");
            double celsius = double.Parse(Console.ReadLine());

            double fahrenheit = celsius * 9 / 5 + 32;
            Console.WriteLine($"{celsius:F1}°C = {fahrenheit:F2}°F " +
                $"\nPress any key to continue...");
            Console.ReadLine();
            Console.Clear();

            // Exercise 2
            Console.WriteLine("====== Division with remainder ======");

            Console.Write("Dividend: ");
            int dividend = int.Parse(Console.ReadLine());

            Console.Write("Divisor: ");
            int divisor = int.Parse(Console.ReadLine());
   
            Console.WriteLine($"{dividend} / {divisor} = {dividend / divisor} remainder {dividend % divisor}" +
                $"\nPress any key to continue...");
            Console.ReadLine();
            Console.Clear();

            // Exercise 3
            Console.WriteLine("====== Overflow demonstration ======");

            int max = int.MaxValue;
            long maxlong = long.MaxValue;
            Console.WriteLine($"Max int: {max}");
            Console.WriteLine($"Max + 1: {max + 1}");
            Console.WriteLine($"Max long: {maxlong}" +
                $"\nPress any key to continue...");

            Console.ReadLine();
            Console.Clear();

            // Exercise 4
            Console.WriteLine("====== Price including VAT ======");

            Console.Write("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            int vat = 20;

            decimal finalPrice = ((price * vat) / 100) + price;
            Console.Write($"Price with VAT (20%): {finalPrice:F2}" +
                $"\nPress any key to continue...");
        }
    }
}