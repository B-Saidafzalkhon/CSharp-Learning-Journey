namespace _12_shape_calculator
{
    internal class Program
    {
        public abstract class Shape
        {
            public abstract double Area();
        }

        public class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            //public string ShapeName = nameof(Rectangle);

            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }
            public override double Area()
            {
                return Width * Height;
            }
            public override string ToString()
            {
                return $"Width: {Width,-10} | Height: {Height,-10} | Rectangle area: {Area():F2}";
            }
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }
            //public string ShapeName = nameof(Circle);
            public Circle(double radius)
            {
                Radius = radius;
            }
            public override double Area()
            {
                return Math.PI * (Radius * Radius);
            }
            public override string ToString()
            {
                return $"Radius: {Radius,-10} | Circle area: {Area():F2}";
            }
        }

        public class Triangle : Shape
        {
            public double TriangleBase { get; set; }
            public double Height { get; set; }
            //public string ShapeName = nameof(Triangle);

            public Triangle(double triangleBase, double height)
            {
                TriangleBase = triangleBase;
                Height = height;
            }
            public override double Area()
            {
                return 0.5 * TriangleBase * Height;
            }
            public override string ToString()
            {
                return $"Base: {TriangleBase,-11} | Height: {Height,-10} | Triangle area: {Area():F2}";
            }
        }

        public class ShapeCalculator
        {
            readonly List<Shape> _shapes = new List<Shape>();

            public ShapeCalculator(List<Shape> shapes)
            {
                _shapes = shapes;
            }

            public double TotalArea()
            {
                double totalArea = 0;
                foreach (Shape shape in _shapes)
                {
                    totalArea += shape.Area();
                }
                return totalArea;
            }
            public double AverageArea()
            {
                double totalArea = TotalArea();
                return totalArea / _shapes.Count;
            }
            public Shape BiggestShape()
            {
                Shape shape = _shapes[0];
                foreach (var s in _shapes)
                {
                    if (s.Area() > shape.Area())
                    {
                        shape = s;
                    }
                }
                return shape;
            }
            public string ShapesCount()
            {
                int RectangleCount = 0;
                int CircleCount = 0;
                int TriangleCount = 0;

                foreach (Shape s in _shapes)
                {
                    if (s is Rectangle)
                        RectangleCount++;

                    if (s is Circle)
                        CircleCount++;

                    if (s is Triangle)
                        TriangleCount++;
                }
                return $"Triangles: {TriangleCount} | Circles: {CircleCount} | Rectangle: {RectangleCount}";
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
        static double ReadIDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (double.TryParse(input, out double value))
                    return value;

                Console.WriteLine("Invalid input!");
            }
        }
        static void Menu()
        {
            Console.WriteLine("====== Shape Calculator ======");
            Console.WriteLine("1. Create shape\n" +
                "2. Shapes area\n" +
                "3. Total area\n" +
                "4. Average area\n" +
                "5. Biggest shape\n" +
                "6. Shapes count\n" +
                "7. Exit");
        }
        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        static bool IsEmpty(List<Shape> shapes)
        {
            if (shapes.Count == 0)
            {
                return true;
            }

            return false;
        }
        static void Main(string[] args)
        {

            List<Shape> shapes = new List<Shape>();
            ShapeCalculator shapeCalculator = new ShapeCalculator(shapes);

            bool isWorking = true;

            while (isWorking)
            {
                Menu();
                int choice = ReadInt("Choice: ");
                switch (choice)
                {
                    case 1:
                        {
                            bool caseIsWorking = true;
                            while (caseIsWorking)
                            {
                                Console.Clear();
                                Console.WriteLine("====== Create Shape ======");
                                Console.WriteLine("1. Rectangle\n" +
                                    "2. Circle\n" +
                                    "3. Triangle\n" +
                                    "4. Exit");

                                int shapeChoice = ReadInt("Choice: ");
                                switch (shapeChoice)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Shape number: {shapes.Count + 1} | Current: Rectangle");
                                            double width = ReadIDouble("Enter width: ");
                                            double height = ReadIDouble("Enter height: ");

                                            shapes.Add(new Rectangle(width, height));
                                            Pause();
                                        }
                                        break;

                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Shape number: {shapes.Count + 1} | Current: Circle");
                                            double radius = ReadIDouble("Enter radius: ");

                                            shapes.Add(new Circle(radius));
                                            Pause();
                                        }
                                        break;

                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Shape number: {shapes.Count + 1} | Current: Triangle");
                                            double triangleBase = ReadIDouble("Enter base length: ");
                                            double height = ReadIDouble("Enter height: ");

                                            shapes.Add(new Triangle(triangleBase, height));
                                            Pause();
                                        }
                                        break;
                                    case 4:
                                        Console.Clear();
                                        caseIsWorking = false;                                    
                                        break;

                                    default:
                                        Console.WriteLine("Invalid input");
                                        Pause();
                                        break;
                                }
                            }
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("====== Shapes Area ======");
                        if (!IsEmpty(shapes))
                        {
                            foreach (Shape s in shapes)
                            {
                                Console.WriteLine(s);
                            }
                            Pause();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No shapes added!");
                            Pause();
                            break;
                        }

                    case 3:
                        Console.Clear();
                        Console.WriteLine("====== Total Area ======");
                        if (!IsEmpty(shapes))
                        {
                            Console.WriteLine($"Total area: {shapeCalculator.TotalArea():F2}\n");
                            Pause();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No shapes added!");
                            Pause();
                            break;
                        }

                    case 4:
                        Console.Clear();
                        Console.WriteLine("====== Average Area ======");
                        if (!IsEmpty(shapes))
                        {
                            Console.WriteLine($"Average area: {shapeCalculator.AverageArea():F2}\n");
                            Pause();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No shapes added!");
                            Pause();
                            break;
                        }   

                    case 5:
                        Console.Clear();
                        Console.WriteLine("====== Biggest Shape ======");
                        if (!IsEmpty(shapes))
                        {
                            Console.WriteLine($"Biggest shape: {shapeCalculator.BiggestShape()}");
                            Pause();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No shapes added!");
                            Pause();
                            break;
                        }   

                    case 6:
                        Console.Clear();
                        Console.WriteLine("====== Shapes Count ======");
                        if (!IsEmpty(shapes))
                        {
                            Console.WriteLine($"Shapes count: {shapeCalculator.ShapesCount()}");
                            Pause();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No shapes added!");
                            Pause();
                            break;
                        }
                      
                    case 7:
                        Console.WriteLine("Goodbye");
                        isWorking = false;
                        break;
                }
            }
        }
    }
}