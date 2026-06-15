namespace _01_print_queue
{
    internal class Program
    {
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
        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        static void Main(string[] args)
        {
            Queue<string> documents = new Queue<string>();

            while (true)
            {
                Console.WriteLine("====== Queue Exercise ======");
                Console.WriteLine("1. Add document\n" +
                    "2. Print next document\n" +
                    "3. Show next document\n" +
                    "4. Document count\n" +
                    "5. Exit");

                int choice = ReadInt("Choice: ");

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("=== Adding Document ===");

                        string text = ReadString("Enter the document text: ");
                        documents.Enqueue(text);

                        Pause();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("=== Printing next document ===");

                        if (documents.Count == 0)
                        {
                            Console.WriteLine("Queue is empty! Add any document first!");
                        }
                        else
                        {
                            Console.WriteLine($"Printing: {documents.Dequeue()}");
                        }
                        Pause();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("=== Showing next document ===");

                        if (documents.Count == 0)
                        {
                            Console.WriteLine("Queue is empty! Add any document first!");
                        }
                        else
                        {
                            Console.WriteLine(documents.Peek());
                        }
                        Pause();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("=== Total Document Count ===");

                        Console.WriteLine($"{documents.Count} - document(s) left");
                        Pause();
                        break;

                    case 5:
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid input!");
                        Pause();
                        break;
                }
            }
        }
    }
}
