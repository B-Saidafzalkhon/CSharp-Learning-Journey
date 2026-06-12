namespace _09_override_vs_hide
{
    internal class Program
    {
        public class Animal
        {
            public virtual void MakeSound() => Console.WriteLine("Some generic sound...");
        }
        public class Dog : Animal
        {
            public override void MakeSound() => Console.WriteLine("Woof!");
        }
        public class Cat : Animal
        {
            // This method hides Animal.MakeSound() instead of overriding it.
            // Because Cat is stored as an Animal in List<Animal>, polymorphism does not call this method.
            // The base Animal.MakeSound() method is called instead.
            public new void MakeSound() => Console.WriteLine("Meow!");
        }
        static void Main(string[] args)
        {
            List<Animal> animals = new()
            {
                new Dog(),
                new Animal(),
                new Cat()
            };

            foreach (Animal animal in animals)
            {
                animal.MakeSound();
            }
        }
    }
}
