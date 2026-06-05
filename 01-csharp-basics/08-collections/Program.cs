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

        // ------------------------ Exercise 4 Methods ------------------------
        static void ShowMenu()
        {
            Console.WriteLine("1. Add\n" +
                "2. Find\n" +
                "3. Remove\n" +
                "4. Show all\n" +
                "5. Exit");
        }

        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Add(Dictionary<string, string> book)
        {
            string name = ReadString("Enter a name: ");
            string telNumber = ReadString("Enter telefon number: ");

            book[name] = telNumber;
        }

        static bool Remove(Dictionary<string, string> book)
        {
            string name = ReadString("Remove contact: ");

            return book.Remove(name);
        }

        static string? Find(Dictionary<string, string> book, string name)
        {
            if (book.TryGetValue(name, out string? phone))
            {
                return phone;
            }

            return null;
        }

        static void ShowAll(Dictionary<string, string> book)
        {
            if (book.Count == 0)
            {
                Console.WriteLine("Contact book is empty!");
                return;
            }

            foreach (KeyValuePair<string, string> contact in book)
            {
                Console.WriteLine($"{contact.Key}: {contact.Value}");
            }
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

                Message("");
            }

            // Exercise 3
            {
                Console.WriteLine("====== Character frequency counter ======");
                string word = ReadString("Enter a word: ").ToLower();

                Dictionary<char, int> valuePairs = new();
                foreach (char c in word)
                {
                    if (valuePairs.ContainsKey(c))
                    {
                        valuePairs[c]++;
                    }
                    else
                    {
                        valuePairs[c] = 1;
                    }
                }

                foreach (char letter in valuePairs.Keys.OrderBy(k => k))
                {
                    Console.WriteLine($"{letter}: {valuePairs[letter]}");
                }
            }

            // Exercise 4
            {
                Dictionary<string, string> names = new();

                while (true)
                {
                    ShowMenu();
                    int choice = ReadInt("Enter a choice: ");

                    if (choice == 5)
                    {
                        Console.WriteLine("Goodbye");
                        break;
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("====== Add contact ======");
                            Add(names);
                            Message("Operation completed!");
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("====== Find contact ======");

                            string name = ReadString("Enter a name: ");
                            string? phone = Find(names, name);

                            if (phone != null)
                            {
                                Console.WriteLine($"{name}: {phone}");
                            }
                            else
                            {
                                Console.WriteLine("Contact not found!");
                            }

                            Pause();
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("====== Remove contact ======");

                            bool isRemoved = Remove(names);

                            if (isRemoved)
                            {
                                Message("Contact removed!");
                            }
                            else
                            {
                                Message("Contact not found!");
                            }

                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("====== Contact list ======");
                            ShowAll(names);
                            Pause();
                            break;

                        default:
                            Message("Invalid input!");
                            break;
                    }
                }
            }
        }
    }
}
