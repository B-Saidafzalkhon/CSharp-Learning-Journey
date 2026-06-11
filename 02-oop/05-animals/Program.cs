namespace _05_animals
{
    internal class Program
    {
        public class Animal
        {
            public string Name { get; private set; }
            public int Age {  get; private set; }

            public Animal(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            public virtual void MakeSound() => Console.WriteLine("Some generic sound...");
            public void Describe() => Console.WriteLine($"Name: {Name}, Age: {Age}");
        }

        public class Dog : Animal
        {
            public Dog(string name, int age) : base(name, age) { }
            public override void MakeSound() => Console.WriteLine("Woof!");
        }
        public class Cat : Animal
        {
            public Cat(string name, int age) : base(name, age) { }
            public override void MakeSound() => Console.WriteLine("Meow!");        
        }
        static void Main(string[] args)
        {
            List<Animal> zoo = new()
            {
                new Dog("Wolter", 10),
                new Cat("Kitty", 5),
                new Dog("Hanz", 11)
            };

            foreach (Animal a in zoo)
            {
                a.Describe();
                a.MakeSound();
            }
        }
    }
}
