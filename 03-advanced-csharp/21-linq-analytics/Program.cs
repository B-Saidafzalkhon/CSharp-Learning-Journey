using System.Text;

namespace _21_linq_analytics
{
    internal class Program
    {
        public class Order
        {
            private static int _nextId = 1;

            public int Id { get; }
            public string Customer { get; set; }
            public decimal Amount { get; set; }
            public string City { get; set; }

            public Order(string customer, decimal amount, string city)
            {
                Id = _nextId++;

                Customer = customer;
                Amount = amount;
                City = city;
            }

            public override string ToString()
            {
                return $"Id: {Id,-5} | Customer: {Customer,-10} | Amount: {Amount,-10} | City: {City,-10}";
            }
        }

        static string Print<T>(IEnumerable<T> items)
        {
            StringBuilder sb = new StringBuilder();
            foreach (T item in items)
            {
                sb.AppendLine(item?.ToString());
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            List<Order> orders = new()
            {
                new Order("Anna", 12m, "Berlin"),
                new Order("Mark", 25m, "Paris"),
                new Order("Sophie", 8m, "London"),
                new Order("Anna", 31m, "Rome"),
                new Order("David", 15m, "Madrid"),
                new Order("Emma", 42m, "Berlin"),
                new Order("Mark", 7m, "Vienna"),
                new Order("Sophie", 18m, "Paris"),
                new Order("David", 29m, "London"),
                new Order("Emma", 9m, "Rome")
            };

            decimal totalAmount = orders.Sum(o => o.Amount);

            decimal averageAmount = orders.Average(o => o.Amount);

            var topThreeAmount = orders
                .OrderByDescending(o => o.Amount)
                .Take(3);

            var ordersAboveAverage = orders
                .Where(o => o.Amount > averageAmount)
                .OrderByDescending(o => o.Amount);

            int countOfUniqueCities = orders
                .Select(o => o.City)
                .Distinct()
                .Count();

            var groupedByCity = orders.GroupBy(o => o.City);

            // ------------ Printing List -------------
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Print(orders));
            Console.ResetColor();

            // ---------------- Report ----------------
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Report ===");

            foreach (var group in groupedByCity)
            {
                Console.WriteLine($"City: {group.Key,-10} | Total amount: {group.Sum(o => o.Amount)}");
            }

            StringBuilder report = new StringBuilder();
            report.AppendLine($"\nTotal amount of all orders: {totalAmount}");
            report.AppendLine($"\nTop order amount:\n{Print(topThreeAmount)}");
            report.AppendLine($"Orders above average amount:\n{Print(ordersAboveAverage)}");
            report.AppendLine($"Average order amount: {averageAmount}");
            report.AppendLine($"Count of unique cities: {countOfUniqueCities}");

            Console.WriteLine(report.ToString());
            Console.ResetColor();
        }
    }
}