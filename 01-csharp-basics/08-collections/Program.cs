using System.Transactions;

namespace _08_collections
{
    internal class Program
    {
        // ------------------------ Exercise 1 Methods ------------------------
        static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Invalid input! Try again!");
            }
        }  
        static void ShowTasks(List<string> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {tasks[i]}");
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

                Console.WriteLine("Invalid input! Try again!");
            }
        }
        static void Menu()
        {
            Console.WriteLine("1. Add task\n" +
                "2. Remove task\n" +
                "3. Show all tasks\n" +
                "4. Clear list\n" +
                "5. Exit\n");
        }
        static void Message(string message)
        {
            Console.WriteLine(message + " Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        
        static void Main(string[] args)
        {
            // Exercise 1
            {
                List<string> tasks = new List<string>();

                while (true)
                {
                    Menu();
                    int choice = ReadInt("Enter choice: ");
                    if (choice == 5)
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("====== Add task ======");

                            string task = ReadString("Enter a task: ");
                            tasks.Add(task);
                            Message("Operation completed!");
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("====== Remove task by number ======");
                            if (tasks.Count == 0)
                            {
                                Message("No tasks added yet!");
                            }
                            else
                            {
                                ShowTasks(tasks);

                                int number = ReadInt("Remove task number: ");
                                if (number < 1 || number > tasks.Count)
                                {
                                    Message("Invalid input!");
                                }
                                else
                                {
                                    tasks.RemoveAt(number - 1);
                                    Message("Operation completed!");
                                }
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("====== Show Tasks ======");
                            if (tasks.Count == 0)
                            {
                                Message("No tasks added yet!");
                            }
                            else
                            {
                                ShowTasks(tasks);
                                Message("");
                            }
                            break;

                        case 4:
                            Console.Clear();
                            if (tasks.Count == 0)
                            {
                                Message("No tasks added yet!");
                                break;
                            }

                            string confirmation = ReadString("Are you sure? (y/n): ");
                            if (confirmation.Trim().ToLower() == "y")
                            {
                                tasks.Clear();
                                Message("All tasks removed!");
                            }
                            else
                            {
                                Message("Cancelled.");
                            }
                            break;

                        default:
                            Message("Invalid input!");
                            break;
                    }
                }
                Message("");
            }

            // Exercise 2
            {
                Console.WriteLine("====== Unique words ======");

                HashSet<string> result = new();
                string sentence = ReadString("Enter a sentence: ").ToLower();
                string[] words = sentence.Split(' ');

               foreach (string word in words)
                {
                    result.Add(word);
                }
                Console.WriteLine($"Unique words: {string.Join(", ", result)}");
                Console.WriteLine($"Count: {result.Count}");
            }
        }
    }
}
