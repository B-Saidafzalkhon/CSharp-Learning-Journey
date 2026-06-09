namespace _03_student
{
    internal class Program
    {
        public class Student
        {
            private string _name;
            private int _age;

            public string Name
            {
                get { return _name; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Name cannot be empty!", nameof(Name));

                    _name = value;
                }
            }
            public int Age
            {
                get { return _age; }
                set
                {
                    if (value < 14 || value > 100)
                        throw new ArgumentOutOfRangeException(nameof(Age), "Input is out of the range!");

                    _age = value;
                }
            }

            public Student(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Describe()
            {
                return $"{Name}, {Age} years old";
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

                Console.WriteLine("String cannot be empty!");
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

                Console.WriteLine("Invalid input!");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("====== Student Class ======");
            try
            {

                string name = ReadString("Enter name: ");
                int age = ReadInt("Enter age: ");

                Student s = new Student(name, age);
                string message = s.Describe();

                Console.WriteLine(message);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
