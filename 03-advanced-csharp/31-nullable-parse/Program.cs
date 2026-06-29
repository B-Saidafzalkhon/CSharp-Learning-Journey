namespace _31_nullable_parse
{
    internal class Program
    {
        // int? is better than returning -1 because null clearly means "no valid value".
        // -1 is a magic number: it can be accidentally treated as a real age
        // and used in calculations or comparisons.
        static int? TryParseAge(string? input)
        {
            if(int.TryParse(input, out int value))
                return value;

            return null;
        }
        static void Main(string[] args)
        {
            string?[] inputs = { "25", "abc", "", null };

            foreach (string? input in inputs)
            {
                int? age = TryParseAge(input);

                if (age is null)
                    Console.WriteLine($"Input: {input ?? "null"} - age is not specified");
                else
                    Console.WriteLine($"Input: {input} - valid age: {age}");

                int ageOrDefault = age ?? 0;
                Console.WriteLine($"Age or default: {ageOrDefault}");
                Console.WriteLine();
            }
        }
    }
}
