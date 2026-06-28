using System.Text.Json;

namespace _28_json_basics
{
    internal class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string City { get; set; }

            public Person(string name, int age, string city)
            {
                Name = name;
                Age = age;
                City = city;
            }

            public override string ToString()
            {
                return $"Name: {Name,-10} | Age: {Age,-2} | City: {City,-10}";
            }
        }
        static void Main(string[] args)
        {
            string mainFolderPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "../../.."));
            string fileFolderPath = Path.Combine(mainFolderPath, "Data");
            Directory.CreateDirectory(fileFolderPath);

            string filePath = Path.Combine(fileFolderPath, "people.json");


            var option = new JsonSerializerOptions { WriteIndented = true };

            List<Person> people = new List<Person>()
            {
                new Person("Anastasiya", 25, "Moscow"),
                new Person("Leo", 23, "Toronto"),
                new Person("Mark", 28, "Berlin")
            };
            string json = JsonSerializer.Serialize(people, option);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Json ===");
            Console.WriteLine(json);
            Console.ResetColor();

            File.WriteAllText(filePath, json);

            string loaded = File.ReadAllText(filePath);
            List<Person>? restored = JsonSerializer.Deserialize<List<Person>>(loaded);

            Console.WriteLine("=== Restored From Json ===");
            if (restored != null)
            {
                foreach (var person in restored)
                {
                    Console.WriteLine(person);
                }
            }
        }
    }
}
