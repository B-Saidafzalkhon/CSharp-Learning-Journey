namespace _02_balanced_brackets
{
    internal class Program
    {
        static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Input cannot be empty!");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== Stack Exercise ===");

            Stack<char> chars = new Stack<char>();
            string text = ReadString("Enter a string (with closed brackets): ");
            bool isValid = true;

            foreach (char c in text)
            {           
                if (c == '(' || c == '[' || c == '{')
                {
                    chars.Push(c);
                }
                else if(c == ')' || c == ']' || c == '}')
                {
                    if(chars.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    char lastOpen = chars.Pop();
                    if((c == ')' && lastOpen != '(') ||
                        (c == ']' && lastOpen != '[')||
                        (c == '}' && lastOpen != '{'))
                    {
                        isValid = false;
                        break;
                    }
                }
            }
            if (chars.Count > 0)
            {
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Brackets are balanced.");
            }
            else
            {
                Console.WriteLine("Brackets are not balanced.");
            }
        }
    }
}
