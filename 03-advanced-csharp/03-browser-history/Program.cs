namespace _03_browser_history
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

                Console.WriteLine("Invalid input!");
            }
        }
        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Invalid input!");
            }
        }
        static void Main(string[] args)
        {
            Stack<string> pages = new Stack<string>();

            while (true)
            {
                Console.WriteLine("=== Browser History Imitation ===");
                if (pages.Count == 0)
                {
                    Console.WriteLine("Current page: (empty)");
                    Console.Write("Full path: (empty)");
                }
                else
                {
                    Console.WriteLine($"Current page: {pages.Peek()}");
                    Console.Write("Full path: ");
                    foreach (var page in pages)
                    {
                        Console.Write("/" + page);
                    }
                }

                Console.WriteLine("\n\n1. Go to a new Page\n" +
                    "2. Go back\n" +
                    "3. Exit");

                int choice = ReadInt("Choice: ");
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("=== New Page ===");

                        string newPage = ReadString("Enter new page name: ");

                        pages.Push(newPage);
                        Console.Clear();
                        break;

                    case 2:
                        if (pages.Count == 0)
                        {
                            Console.WriteLine("History is empty!");
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                        else
                        {
                            pages.Pop();
                            Console.Clear();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid input! Try again!");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
