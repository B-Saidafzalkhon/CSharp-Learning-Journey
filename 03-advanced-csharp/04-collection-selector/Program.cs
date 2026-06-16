using System.Text;
namespace _04_collection_selector
{
    internal class Program
    {
        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                    return number;

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
            Console.ReadKey();
            Console.Clear();
        }
        static string Print(IEnumerable<string> items)
        {
            StringBuilder sb = new StringBuilder();
            int index = 1;
            foreach (string item in items)
            {
                sb.AppendLine($"{index,2} | " + item);
                index++;
            }
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            // Exercise 1: Shopping List 
            // I use List<string> here because the order of products matters. 
            // A List keeps items in the same order as they were added. 
            // It also allows access by index, so the user can remove a product by its number.
            {
                List<string> shoppingList = new List<string>();
                bool active = true;

                while (active)
                {
                    Console.WriteLine("=== Shopping List ===");
                    Console.WriteLine("1. Add Product\n" +
                        "2. Remove Product (by index)\n" +
                        "3. Show All\n" +
                        "4. Exit");

                    int choice = ReadInt("Choice: ");
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("=== Adding Product ===");

                            string productName = ReadString("Enter product name: ");
                            shoppingList.Add(productName);
                            Pause();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("=== Removing Product ===");
                            if (shoppingList.Count == 0)
                            {
                                Console.WriteLine("List is empty! Enter any product first!");
                            }
                            else
                            {
                                Console.WriteLine(Print(shoppingList));
                                int index = ReadInt("Enter the index of the product: ");

                                if (index < 1 || index > shoppingList.Count)
                                {
                                    Console.WriteLine("Invalid index!");
                                }
                                else
                                {
                                    shoppingList.RemoveAt(index - 1);
                                }
                            }
                            Pause();
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("=== All Products ===");
                            if (shoppingList.Count == 0)
                            {
                                Console.WriteLine("List is empty! Enter any product first!");
                            }
                            else
                            {
                                Console.WriteLine(Print(shoppingList));
                            }
                            Pause();
                            break;

                        case 4:
                            Console.WriteLine("Goodbye!");
                            active = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option!");
                            Pause();
                            break;
                    }
                }
                Pause();
            }

            // Exercise 2: User Logins 
            // I use HashSet<string> because logins must be unique. 
            // A HashSet does not allow duplicates. 
            // It is also fast for checking whether a login already exists.
            {
                HashSet<string> logins = new HashSet<string>();

                bool active = true;
                while (active)
                {
                    Console.WriteLine("=== User logins ===");
                    Console.WriteLine("1. Add New Login\n" +
                        "2. Show All Logins\n" +
                        "3. Exit");

                    int choice = ReadInt("Choice: ");
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("=== Adding New Login ===");
                            string login = ReadString("Enter a Login: ");

                            if (logins.Add(login))
                            {
                                Console.WriteLine("Login Added!");
                            }
                            else
                            {
                                Console.WriteLine("Login Already Exists!");
                            }
                            Pause();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("=== Showing All Logins ===");
                            if (logins.Count == 0)
                            {
                                Console.WriteLine("List is empty! Enter any login first!");
                            }
                            else
                            {
                                Console.WriteLine(Print(logins));
                            }
                            Pause();
                            break;

                        case 3:
                            Console.WriteLine("Goodbye!");
                            active = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option!");
                            Pause();
                            break;
                    }
                }
                Pause();
            }

            // Exercise 3: Phone Book 
            // I use Dictionary<string, string> because each name is connected with one phone number. 
            // The name is the key, and the phone number is the value. 
            // This allows me to quickly find a phone number by contact name.
            {
                Dictionary<string, string> phoneBook = new Dictionary<string, string>();

                bool active = true;
                while (active)
                {
                    Console.WriteLine("=== Phone Book ===");
                    Console.WriteLine("1. Add Contact\n" +
                        "2. Find Contact (by name)\n" +
                        "3. Show All Contacts\n" +
                        "4. Exit");

                    int choice = ReadInt("Choice: ");
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.Clear();
                                Console.WriteLine("=== Adding Contact ===");

                                string name = ReadString("Enter the Name: ");
                                string number = ReadString("Enter the number: ");

                                if (phoneBook.ContainsKey(name))
                                {
                                    string value = ReadString("Update? (y/n): ").Trim().ToLower();

                                    if (value == "y")
                                    {
                                        phoneBook[name] = number;
                                        Console.WriteLine("Contact Updated!");
                                    }
                                    else if (value == "n")
                                    {
                                        Console.WriteLine("Update canceled. Contact was not changed.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid answer. Contact was not changed.");
                                    }
                                }
                                else
                                {
                                    phoneBook.Add(name, number);
                                    Console.WriteLine("Contact Added!");
                                }
                                Pause();
                                break;
                            }

                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine("=== Searching for Contact ===");

                                if (phoneBook.Count == 0)
                                {
                                    Console.WriteLine("Phone book is empty! Enter any contact first!");
                                }
                                else
                                {
                                    string name = ReadString("Enter the Contact's Name: ");
                                    if (phoneBook.TryGetValue(name, out string? number))
                                    {
                                        Console.WriteLine($"Contact: {name,-10} | Number: {number}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Contact not Found");
                                    }
                                }
                                Pause();
                                break;
                            }

                        case 3:
                            Console.Clear();
                            Console.WriteLine("=== Printing All Contacts ===");
                            if (phoneBook.Count == 0)
                            {
                                Console.WriteLine("Phone book is empty! Enter any contact first!");
                            }
                            else
                            {
                                foreach (var contact in phoneBook)
                                {
                                    Console.WriteLine($"Name: {contact.Key,-10} | Number: {contact.Value}");
                                }
                            }
                            Pause();
                            break;

                        case 4:
                            Console.WriteLine("Goodbye!");
                            active = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option!");
                            Pause();
                            break;
                    }
                }
                Pause();
            }

            // Exercise 4: Request Processing 
            // I use Queue<string> because requests must be processed in the order they arrive. 
            // The first request added should be the first request processed. 
            // This is called FIFO: First In, First Out.
            {
                Queue<string> requests = new Queue<string>();
                bool active = true;

                while (active)
                {
                    Console.WriteLine("=== Request Processing ===");
                    Console.WriteLine("1. Add Request\n" +
                        "2. Process the Request\n" +
                        "3. Exit");

                    if (requests.Count == 0)
                    {
                        Console.WriteLine($"Requests are empty.");
                    }
                    else
                    {
                        Console.WriteLine($"Total: {requests.Count} Requests.");
                        Console.WriteLine("Requests: ");
                        int count = 0;

                        foreach (var request in requests)
                        {
                            Console.WriteLine($"{++count,2} | {request}");
                        }
                    }

                    Console.WriteLine("========================");
                    int choice = ReadInt("Choice: ");

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("=== Adding New Request ===");

                            string request = ReadString("Request text: ");
                            requests.Enqueue(request);
                            Pause();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("=== Processing Request ===");

                            if (requests.Count == 0)
                            {
                                Console.WriteLine("Requests are empty! Enter any request first!");
                            }
                            else
                            {
                                string removed = requests.Dequeue();
                                Console.WriteLine($"Request: \"{removed}\" is Processed and Removed");
                            }

                            Pause();
                            break;

                        case 3:
                            Console.WriteLine("Goodbye!");
                            active = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option!");
                            Pause();
                            break;
                    }
                }
                Pause();
            }

            // Exercise 5: Undo Manager 
            // I use Stack<string> because the last action should be undone first. 
            // This is how undo usually works in editors. 
            // This is called LIFO: Last In, First Out.
            {
                Stack<string> actions = new Stack<string>();
                bool active = true;

                while (active)
                {
                    Console.WriteLine("=== Undo Manager ===");
                    Console.WriteLine("1. Add action\n" +
                        "2. Undo\n" +
                        "3. Exit");

                    int choice = ReadInt("Choice: ");
                    switch(choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("=== Adding Action ===");

                            string action = ReadString("Enter Action: ");
                            actions.Push(action);

                            Pause();
                            break;

                        case 2:
                            if(actions.Count == 0)
                            {
                                Console.WriteLine("Actions are empty! Enter any action first!");
                            }
                            else
                            {
                                string removed = actions.Pop();
                                Console.WriteLine($"Action: \"{removed}\" is removed.");
                            }
                            Pause();
                            break;

                        case 3:
                            Console.WriteLine("Goodbye!");
                            active = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option!");
                            Pause();
                            break;
                    }
                }
            }

        }
    }
}