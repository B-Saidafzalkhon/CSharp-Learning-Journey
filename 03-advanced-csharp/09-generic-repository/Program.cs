namespace _09_generic_repository
{
    internal class Program
    {
        public interface IEntity
        {
            int Id { get; }
        }
        public class Repository<T> where T : IEntity
        {
            private List<T> _entities = new List<T>();

            public void Add(T item) => _entities.Add(item);
            public T? GetById(int id)
            {
                foreach (T item in _entities)
                {
                    if (item.Id == id)
                        return item;
                }
                return default;
            }
            public IEnumerable<T> GetAll()
            {
                return _entities;
            }
            public bool Remove(int id)
            {
                T itemToRemove = default!;
                bool found = false;

                foreach (T item in _entities)
                {
                    if (item.Id == id)
                    {
                        itemToRemove = item;
                        found = true;
                        break;
                    }
                }
                if (!found)
                    return false;

                _entities.Remove(itemToRemove);
                return true;
            }

        }
        public class User : IEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public User(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public override string ToString()
            {
                return $"Id: {Id} | Name: {Name}";
            }
        }
        public class Product : IEntity
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
            public Product(int id, string title, decimal price)
            {
                Id = id;
                Title = title;
                Price = price;
            }
            public override string ToString()
            {
                return $"Id: {Id} | Title: {Title} | Price: {Price}";
            }
        }
        static void Main(string[] args)
        {
            Repository<User> users = new Repository<User>();

            users.Add(new User(1, "Mika"));
            users.Add(new User(2, "Alex"));

            foreach(User user in users.GetAll())
                Console.WriteLine(user);

            Console.WriteLine();

            User? foundUser = users.GetById(2);

            if (foundUser != null)
                Console.WriteLine($"Found: {foundUser}");

            bool removed = users.Remove(2);

            if (removed)
                Console.WriteLine("User removed");
            else
                Console.WriteLine("User not found");

            Console.WriteLine();

            Repository<Product> products = new Repository<Product>();

            products.Add(new Product(1, "Laptop", 1200));
            products.Add(new Product(2, "Phone", 800));

            foreach (Product product in products.GetAll())
            {
                Console.WriteLine(product);
            }

            // where T : IEntity allows Repository<T> to work only with types that have an Id.
            // Because of this, GetById can safely access item.Id.
        }
    }
}
