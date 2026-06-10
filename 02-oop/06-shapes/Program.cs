namespace _06_shapes
{
    internal class Program
    {
        public abstract class Shape
        {
            public abstract double Area();
        }

        public class Circle : Shape
        {
            public double Radius {  get; private set; }
            public Circle(double radius)
            {
                this.Radius = radius;
            }
            public override double Area() => Math.PI * (Radius * Radius);
        }
        public class Rectangle : Shape
        {
            public double Width { get; private set; }
            public double Height { get; private set; }
            public Rectangle(double width, double height)
            {
                this.Width = width;
                this.Height = height;
            }
            public override double Area() => Width * Height;
        }

        public class Triangle : Shape
        {
            public double TriangleBase { get; private set; }
            public double Height { get; private set; }

            public Triangle(double triangleBase, double height)
            {
                this.TriangleBase = triangleBase;
                this.Height = height;
            }

            public override double Area() => 0.5 * TriangleBase * Height;
        }
        static void Main(string[] args)
        {
            List<Shape> shapes = new()
            {
                new Circle(10),
                new Rectangle(10,5),
                new Triangle(10,5)
            };

            foreach (Shape shape in shapes)
            {
                double area = shape.Area();
                Console.WriteLine($"{area:F2}");
            }
        }
    }
}
