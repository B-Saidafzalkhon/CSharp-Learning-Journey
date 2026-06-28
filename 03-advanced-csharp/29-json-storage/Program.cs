using System.Text.Json;
namespace _29_json_storage
{
    internal class Program
    {
        public class Contact
        {
            public string Name { get; set; }
            public string Phone { get; set; }
            public Contact(string name, string phone)
            {
                Name = name;
                Phone = phone;
            }

            public override string ToString() => $"Name: {Name,-10} | Phone: {Phone}";
        }
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

                Console.WriteLine("Invalid input! Cannot be empty!");
            }
        }
        static void EnsureFileExists(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found!", nameof(path));
        }
        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Print<T>(IEnumerable<T> items)
        {
            int count = 1;
            foreach (T item in items) Console.WriteLine($"{count++}) {item}");
        }
        static bool IsEmpty<T>(IEnumerable<T> items)
        {
            return items.Count() == 0;
        }
        static void Main(string[] args)
        {
            string mainFolderPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "../../.."));
            string fileFolderPath = Path.Combine(mainFolderPath, "Storage");
            Directory.CreateDirectory(fileFolderPath);

            string filePath = Path.Combine(fileFolderPath, "storage.json");

            List<Contact>? contacts = new List<Contact>();
            try
            {
                EnsureFileExists(filePath);
                string loaded = File.ReadAllText(filePath);
                contacts = JsonSerializer.Deserialize<List<Contact>>(loaded);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Contacts are loaded.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=== Contacts ===");
                Console.WriteLine("1. Add new contact\n" +
                    "2. Show all\n" +
                    "3. Remove contact\n" +
                    "4. Exit");
                Console.ResetColor();
                int choice = ReadInt("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("=== Adding contact ===");
                        string name = ReadString("Enter name: ");
                        string phone = ReadString("Enter phone: ");

                        Contact contact = new Contact(name, phone);
                        contacts!.Add(contact);

                        Pause();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("=== Showing all contacts ===");
                        if (IsEmpty(contacts!))
                        {
                            Console.WriteLine("Contacts are empty!");
                        }
                        else
                        {
                            Print(contacts!);
                        }
                        Pause();
                        break;

                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("=== Removing contact ===");
                            if (IsEmpty(contacts!))
                            {
                                Console.WriteLine("Contacts are empty!");
                            }
                            else
                            {
                                Print(contacts!);
                                int index = ReadInt("Enter contact's index: ");
                                if (index < 1 || index > contacts!.Count)
                                {
                                    Console.WriteLine("=== Invalid index! ===");
                                    Pause();
                                    break;
                                }
                                contacts!.RemoveAt(index - 1);
                            }
                            Pause();
                        }
                        break;

                    case 4:
                        {
                            Console.WriteLine("Goodbye!");
                            string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText(filePath, json);
                            Pause();
                        }
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