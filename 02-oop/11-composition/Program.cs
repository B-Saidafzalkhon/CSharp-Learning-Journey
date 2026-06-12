namespace _11_composition
{
    internal class Program
    {
        public class Car
        {
            public class Engine
            {
                public double Power { get; set; }

                public Engine(double power)
                {
                    Power = power;
                }
                public void Start() => Console.WriteLine($"Engine power: {Power}hp | Car is started...");
            }
            // Car : Engine would be wrong because a car is not a type of engine.
            // This would not be an appropriate "is-a" relationship.
            // A car has an engine, so composition is the better choice here.
            public string Name { get; set; }
            public Engine CarEngine { get; set; }
            public Car(string name, double power)
            {
                Name = name;
                CarEngine = new Engine(power);
            }

            public void Start()
            {
                Console.WriteLine($"{Name} is starting...");
                CarEngine.Start();
            }
        }
        static void Main(string[] args)
        {
            Car car = new Car("Nissan", 2000);
            car.Start();
        }
    }
}
