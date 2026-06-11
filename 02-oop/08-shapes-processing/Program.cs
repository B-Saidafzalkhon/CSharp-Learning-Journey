namespace _08_shapes_processing
{
    internal class Program
    {
        public abstract class Shape
        {
            public abstract double Area();
        }

        public class Circle : Shape
        {
            public double Radius { get; private set; }
            public Circle(double radius)
            {
                Radius = radius;
            }
            public override double Area() => Math.PI * (Radius * Radius);
            public double Diameter() => 2 * Radius;

            public override string ToString()
            {
                return $"Circle Area: {Area():F2}";
            }
        }
        public class Rectangle : Shape
        {
            public double Width { get; private set; }
            public double Height { get; private set; }
            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }
            public override double Area() => Width * Height;

            public override string ToString()
            {
                return $"Rectangle Area: {Area():F2}";
            }
        }

        public class Triangle : Shape
        {
            public double TriangleBase { get; private set; }
            public double Height { get; private set; }

            public Triangle(double triangleBase, double height)
            {
                TriangleBase = triangleBase;
                Height = height;
            }

            public override double Area() => 0.5 * TriangleBase * Height;
            public override string ToString()
            {
                return $"Triangle Area: {Area():F2}";
            }
        }
        static void Main(string[] args)
        {
            List<Shape> shapes = new()
            {
                new Rectangle(15,10),
                new Triangle(10,10),
                new Circle(15),
                new Circle(10),
                new Rectangle(10,15)
            };

            double totalArea = 0;
            foreach (Shape shape in shapes)
            {
                totalArea += shape.Area();

                Console.WriteLine(shape);
                if (shape is Circle circle) // The diameter is specific to a circle,
                                            // so making it virtual in Shape makes no sense — a rectangle does not have a diameter.
                                            // This is exactly when is is justified.
                {               
                    Console.WriteLine($"Circle Radius: {circle.Radius:F2}");
                    Console.WriteLine($"Circle Diameter: {circle.Diameter():F2}");
                }
            }
            Console.WriteLine($"\nTotal area: {totalArea:F2}");
        }
    }
}
