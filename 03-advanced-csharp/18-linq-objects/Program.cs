using System.Text;

namespace _18_linq_objects
{
    internal class Program
    {
        public class Person
        {
            private static int _nextId = 1;

            public int Id { get; }
            public string Name { get; }
            public int Age { get; }
            public string City { get; }

            public Person(string name, int age, string city)
            {
                Id = _nextId++;

                Name = name;
                Age = age;
                City = city;
            }

            public override string ToString()
            {
                return $"ID: {Id,-2} | Name: {Name,-8} | Age: {Age,-2} | City: {City,-15}";
            }
        }
        static void Print<T>(IEnumerable<T> intems)
        {
            foreach (var item in intems)
            {
                Console.WriteLine(item);
            }
        }
        static void Pause()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }
        static void Main(string[] args)
        {
            List<Person> people = new()
            {
                new Person("Frank", 37, "Vienna"),
                new Person("Erick", 25, "Rome"),
                new Person("David", 17, "New-York"),
                new Person("Charles", 32, "Frankfurt"),
                new Person("Brandon", 15, "San-Francisco"),
                new Person("Adeline", 39, "Frankfurt")
            };

            var adults = people.Where(p => p.Age >= 18);
            var names = people.Select(p => p.Name);
            var specificCity = people.Where(p => p.City == "Frankfurt");
            var orderedByAge = people.OrderBy(p => p.Age);
            double averageAge = people.Average(p => p.Age);
            var oldest = people.OrderByDescending(p => p.Age).First();
            int youngCount = people.Count(p => p.Age < 30);
            bool fromBerlin = people.Any(p => p.City == "Berlin");

            var special = people
                .Where(p => p.Age >= 18)
                .OrderBy(p => p.Name)
                .Select(p => p.Name);

            Console.WriteLine("=== Adults ===");
            Print(adults);
            Pause();

            Console.WriteLine("=== All Names ===");
            Print(names);
            Pause();

            Console.WriteLine("=== From Frankfurt ===");
            Print(specificCity);
            Pause();

            Console.WriteLine("=== Ordered by Age ===");
            Print(orderedByAge);
            Pause();

            Console.WriteLine("=== Average Age ===");
            Console.WriteLine(averageAge);
            Pause();

            Console.WriteLine("=== Oldest ===");
            Console.WriteLine(oldest);
            Pause();

            Console.WriteLine("=== Count of People Younger than 30 ===");
            Console.WriteLine(youngCount);
            Pause();

            if (fromBerlin)
            {
                Console.WriteLine("=== There is someone from Berlin! ===");
            }
            else
            {
                Console.WriteLine("=== There is no one from Berlin! ===");
            }

            Pause();

            Console.WriteLine("=== Adults (>= 18) Ordered by Name | Only Names Shown ===");
            Print(special);
        }
    }
}
