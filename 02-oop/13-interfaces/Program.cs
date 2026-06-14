namespace _13_interfaces
{
    internal class Program
    {
        public interface ISoundable
        {
            string MakeSound();
        }
        public interface IDescribable
        {
            string Describe();
        }

        public class Dog : ISoundable
        {
            public string MakeSound() => "Woof!";
        }
        public class Car : ISoundable
        {
            public string MakeSound() => "Some engine sound...!";
        }
        public class Phone : ISoundable, IDescribable 
        {
            public string MakeSound() => "Some alarm sound...";
            public string Describe() => $"Some Phone description...";
            
        }
        static void Main(string[] args)
        {
            List<ISoundable> things = new()
            {
                new Dog(),
                new Car(),
                new Phone()
            };

            foreach (ISoundable thing in things)
            {
                Console.WriteLine(thing.MakeSound());

                if(thing is IDescribable describable)
                    Console.WriteLine(describable.Describe());
            }
        }
    }
}
