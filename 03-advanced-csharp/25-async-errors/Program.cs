namespace _25_async_errors
{
    internal class Program
    {
        // This method returns Task<double>, not async void,
        // because the caller needs to await it, get the result, and catch exceptions.
        //
        // With async Task<double>:
        // - await waits until the operation is completed;
        // - the result can be returned to the caller;
        // - exceptions are stored inside the Task and can be caught by try/catch around await.
        //
        // If this method were async void, the caller could not await it,
        // could not receive a result, and exceptions thrown after await would not be caught
        // by the caller's try/catch. async void is mainly used for event handlers.
        static async Task<double> DivideAsync(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by 0!");

            Console.WriteLine("Dividing...");
            await Task.Delay(1000);
            return a / b;
        }
        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (double.TryParse(input, out double value))
                    return value;

                Console.WriteLine("Invalid input!");
            }
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Async calculator ===");
            try
            {
                double a = ReadDouble("Enter a: ");
                double b = ReadDouble("Enter b: ");
                double result = await DivideAsync(a, b);

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
