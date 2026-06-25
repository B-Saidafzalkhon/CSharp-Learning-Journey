namespace _20_linq_groupby
{
    internal class Program
    {
        public class Product
        {
            public string? Name { get; set; }
            public string? Category { get; set; }
            private decimal _price;
            public decimal Price
            {
                get { return _price; }
                set
                {
                    if (value <= 0)
                        throw new ArgumentOutOfRangeException(nameof(Price), "Price is out of the range!");

                    _price = value;
                }
            }
            public Product(string name, string category, decimal price)
            {
                Name = name;
                Category = category;
                Price = price;
            }
            public override string ToString()
            {
                return $"Category: {Category,-10} | Name: {Name,-10} | Price: {Price}$";
            }
        }
        static void Main(string[] args)
        {
            List<Product> products = new()
            { 
                // Custom data!
                new Product("Apple", "Fruit", 100.5m),
                new Product("Banana", "Fruit", 130.4m),
                new Product("Orange", "Fruit", 120.7m),

                new Product("Potato", "Vegetables", 90.5m),
                new Product("Carrot", "Vegetables", 93.5m),
                new Product("Cucumber", "Vegetables", 97.5m),

                new Product("Milk", "Dairy", 75.9m),
                new Product("Cheese", "Dairy", 210.4m),
                new Product("Yogurt", "Dairy", 65.5m),

                new Product("Bread", "Bakery", 45.0m),
                new Product("Croissant", "Bakery", 85.5m),
                new Product("Baguette", "Bakery", 70.2m)
            };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Product List ===");
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
            Console.ResetColor();

            Console.WriteLine("\n=== Info ===");
            var grouped = products.GroupBy(n => n.Category);
            var topCategory = products
                .GroupBy(p => p.Category)
                .OrderByDescending(group => group.Sum(p => p.Price))
                .First();

            foreach (var group in grouped)
            {
                Console.WriteLine($"Category: {group.Key,-10} | Count: ({group.Count()}) items | Average price: {group.Average(n => n.Price):F2}$");
            }
            Console.WriteLine($"\nTop category: {topCategory.Key} | total: {topCategory.Sum(p => p.Price)}$");
        }
    }
}
