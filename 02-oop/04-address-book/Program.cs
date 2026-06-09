using System.Text;

namespace _04_address_book
{
    internal class Program
    {
        public class AddressBook
        {
            private Dictionary<string, string> _book;

            public AddressBook()
            {
                _book = new();
            }

            public int Count
            {
                get { return _book.Count; }
            }

            public bool Add(string name, string phone)
            {
                if (_book.ContainsKey(name))
                {
                    return false;
                }

                _book.Add(name, phone);
                return true;
            }

            public bool Update(string name, string phone)
            {
                if (!_book.ContainsKey(name))
                {
                    return false;
                }

                _book[name] = phone;
                return true;
            }

            public string? Find(string name)
            {
                if (_book.TryGetValue(name, out string? phone))
                {
                    return phone;
                }

                return null;
            }

            public bool Remove(string name)
            {
                return _book.Remove(name);
            }

            public string ShowBook()
            {
                StringBuilder sb = new StringBuilder();

                foreach (var contact in _book)
                {
                    sb.AppendLine($"{contact.Key,-15} {contact.Value}");
                }

                return sb.ToString();
            }
        }

        static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.WriteLine("Cannot be empty!");
            }
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    return number;
                }

                Console.WriteLine("Invalid input! Try again.");
            }
        }

        static void Main(string[] args)
        {
            AddressBook book = new AddressBook();

            while (true)
            {
                Console.WriteLine("====== Address Book ======");
                Console.WriteLine("1. Add contact");
                Console.WriteLine("2. Update contact");
                Console.WriteLine("3. Find contact");
                Console.WriteLine("4. Show all contacts");
                Console.WriteLine("5. Exit");

                int choice = ReadInt("Choose an option: ");

                switch (choice)
                {
                    case 1:
                        {
                            string name = ReadString("Enter name: ");
                            string phone = ReadString("Enter phone: ");

                            if (book.Add(name, phone))
                            {
                                Console.WriteLine("Contact added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Contact already exists.");
                            }

                            break;
                        }

                    case 2:
                        {
                            string name = ReadString("Enter name: ");
                            string phone = ReadString("Enter new phone: ");

                            if (book.Update(name, phone))
                            {
                                Console.WriteLine("Contact updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Contact not found.");
                            }

                            break;
                        }

                    case 3:
                        {
                            string name = ReadString("Enter name: ");
                            string? phone = book.Find(name);

                            if (phone != null)
                            {
                                Console.WriteLine($"{name}: {phone}");
                            }
                            else
                            {
                                Console.WriteLine("Contact not found.");
                            }

                            break;
                        }

                    case 4:
                        {
                            if (book.Count == 0)
                            {
                                Console.WriteLine("Address book is empty.");
                            }
                            else
                            {
                                Console.WriteLine(book.ShowBook());
                            }

                            break;
                        }

                    case 5:
                        {
                            return;
                        }

                    default:
                        {
                            Console.WriteLine("Unknown option. Try again.");
                            break;
                        }
                }

                Console.WriteLine();
            }
        }
    }
}