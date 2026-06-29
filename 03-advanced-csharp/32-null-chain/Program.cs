namespace _32_null_chain
{
    internal class Program
    {
        public class User
        {
            public string? Name { get; set; }
            public Address? Address { get; set; }

            public User(string name)
            {
                Name = name;
            }
        }

        public class Address
        {
            public string? City { get; set; }
        }

        static string GetUserCity(User? user)
        {
            // Without ?. this code could crash with NullReferenceException.
            // For example, user.Address.City would fail if the user has no address.
            // ?. safely stops the chain when something is null, and ?? returns "Unknown".
            return user?.Address?.City ?? "Unknown";
        }
        static void Main(string[] args)
        {
            User user1 = new User("Mark");
            user1.Address = new Address { City = "Berlin" };

            User user2 = new User("Anna");
            user2.Address = new Address();

            User user3 = new User("Sophie");

            string city1 = GetUserCity(user1);
            string city2 = GetUserCity(user2);
            string city3 = GetUserCity(user3);

            Console.WriteLine($"{user1.Name}: {city1}");
            Console.WriteLine($"{user2.Name}: {city2}");
            Console.WriteLine($"{user3.Name}: {city3}");
        }
    }
}