namespace _01_rectangle
{
    internal class Program
    {
        public class Rectangle
        {
            public double width;
            public double height;

            public Rectangle(double w, double h)
            {
                this.width = w;
                this.height = h;
            }

            public double Area()
            {
                return width * height;
            }
            public double Perimeter()
            {
                return 2 * (width + height);
            }
        }

        static double ReadDouble(string message)
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
        static void Main(string[] args)
        {
            Console.WriteLine("====== Class Rectangle ======");
            double width = ReadDouble("Enter width: ");
            double height = ReadDouble("Enter height: ");

            Rectangle r1 = new Rectangle(width, height);

            Console.WriteLine($"Area: {r1.Area()}");
            Console.WriteLine($"Perimeter: {r1.Perimeter()}");
        }
    }
}
