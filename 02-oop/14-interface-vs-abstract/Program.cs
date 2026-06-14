namespace _14_interface_vs_abstract
{
    internal class Program
    {
        public abstract class Animal
        {
            public string Name { get; set; }
            public int Age { get; set; }

            protected Animal(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Describe() => $"Name: {Name,-10} | Age: {Age,-10}";

            public abstract string MakeSound();
        }

        public interface ITrainable
        {
            string Train();
        }

        public class Dog : Animal, ITrainable
        {
            public Dog(string name, int age) : base(name, age)
            {
            }

            public override string MakeSound() => "Woof!";

            public string Train() => "I am trainable!";
        }

        public class Cat : Animal
        {
            public Cat(string name, int age) : base(name, age)
            {
            }

            public override string MakeSound() => "Meow!";
        }

        static void Main(string[] args)
        {
            List<Animal> animals = new()
            {
                new Dog("Hachiko", 10),
                new Dog("Rex", 11),
                new Cat("Kitty", 8)
            };

            // General animal behavior
            foreach (Animal animal in animals)
            {
                Console.WriteLine($"{animal.Describe()} | Sound: {animal.MakeSound()}");
            }

            Console.WriteLine("\nTrainable animals:");

            // Trainable behavior exists only for some animals
            foreach (Animal animal in animals)
            {
                if (animal is ITrainable trainable)
                {
                    Console.WriteLine($"{animal.Describe()} | {trainable.Train()}");
                }
            }

            /*
             Name, Age and Describe() are in the abstract class because they describe
             the common nature and shared code of all animals.

             Train() is in the interface because it is only an ability.
             Not every animal is trainable.

             If Train() were inside Animal, then every animal would be forced to have
             training behavior, even Cat. That would be incorrect.

             If Name and Describe() were only in an interface, then every class would
             have to repeat the same code again and again.
            */
        }
    }
}