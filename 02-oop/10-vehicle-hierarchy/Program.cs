namespace _10_vehicle_hierarchy
{
    internal class Program
    {
        public class Vehicle
        {
            public int YearOfManufacture { get; set; }
            public string Name { get; set; }
            public double Mass { get; set; }

            public Vehicle(int yearOfManufacture, string name, double mass)
            {
                YearOfManufacture = yearOfManufacture;
                Name = name;
                Mass = mass;

                Console.WriteLine("Vehicle built");
            }

            public virtual void ShowInfo()
            {
                Console.WriteLine($"Year: {YearOfManufacture}");
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Mass: {Mass} kg");
            }
        }
        public class Car : Vehicle
        {
            public string BodyType { get; set; }

            public Car(int yearOfManufacture, string name, double mass, string bodyType)
                : base(yearOfManufacture, name, mass)
            {
                BodyType = bodyType;
                Console.WriteLine("Car built");
            }

            public override void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine($"Body type: {BodyType}");
            }
        }
        public class SportCar : Car
        {
            public string DrivingType { get; set; }

            public SportCar(int yearOfManufacture, string name, double mass, string bodyType, string drivingType)
                : base(yearOfManufacture, name, mass, bodyType)
            {
                DrivingType = drivingType;
                Console.WriteLine("Sport car built");
            }

            public override void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine($"Driving type: {DrivingType}");
            }
        }
        static void Main(string[] args)
        {
            SportCar sc = new SportCar(2025, "Formula", 30000, "Sport car", "Race");

            Console.WriteLine();

            sc.ShowInfo();
        }
    }
}
