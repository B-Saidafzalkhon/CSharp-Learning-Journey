namespace _30_null_operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Null-coalescing assignment example.
            // The variable is nullable and may contain null.
            // Without ??=, the variable could stay null.
            // Without ?.Length, calling input.Length on null would cause a NullReferenceException.
            {
                Console.Write("Enter any string: ");
                string? input = Console.ReadLine();

                input ??= "Default string";
                int? stringLength = input?.Length;

                Console.WriteLine($"String: {input} | String length: {stringLength}");
            }

            // Null-conditional and null-coalescing example.
            // ?.Trim() calls Trim only if input is not null.
            // Without ?., input.Trim() would crash if input were null.
            // ?? gives a default value if the left side is null.
            {
                Console.Write("Enter any string: ");
                string? input = Console.ReadLine();

                string name = input?.Trim() ?? "Anonymous";
                Console.WriteLine($"Your name: {name}. Welcome!");
            }

            // Null pattern matching example.
            // is null checks whether the variable contains null.
            // is not null checks whether the variable has a real value.
            // Without this check, using the variable as non-null could be unsafe.
            {
                Console.Write("Enter any string: ");
                string? input = Console.ReadLine();

                if (input is null)
                    Console.WriteLine("Input is null.");
                else if (input is not null)
                    Console.WriteLine("Input is not null.");
            }
        }
    }
}