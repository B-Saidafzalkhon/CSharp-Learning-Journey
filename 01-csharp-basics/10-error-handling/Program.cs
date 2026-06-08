namespace _10_error_handling
{
    internal class Program
    {
        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        static double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Divisor cannot be equal to zero.");
            }

            return (double)a / b;
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    return number;
                }

                Console.WriteLine("Invalid input! Try again...");
            }
        }

        static void SafeInput()
        {
            Console.WriteLine("====== Safe input reader ======");
            try
            {
                Console.Write("Input: ");
                string? input = Console.ReadLine();

                if (input == null)
                {
                    throw new ArgumentNullException("Input is null.");
                }

                int value = int.Parse(input);
                Console.WriteLine($"Value {value} converted into integer.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Calculator()
        {
            Console.WriteLine("====== Calculator with exception ======");

            int a = ReadInt("Enter a: ");
            int b = ReadInt("Enter b: ");

            try
            {
                double result = Divide(a, b);
                Console.WriteLine($"Result: {result:F2}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void FileReader()
        {
            Console.WriteLine("====== File reader ======");

            string pathFolder = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "../../.."));
            string pathFile = Path.Combine(pathFolder, "test.txt");
            try
            {
                string content = File.ReadAllText(pathFile);
                Console.WriteLine(content);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Done.");
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("====== Error Handling Menu ======");
            Console.WriteLine("1. Safe input");
            Console.WriteLine("2. Calculator");
            Console.WriteLine("3. File reader");
            Console.WriteLine("4. Exit");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();

                int choice = ReadInt("Choose an option: ");
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        SafeInput();
                        Pause();
                        break;

                    case 2:
                        Calculator();
                        Pause();
                        break;

                    case 3:
                        FileReader();
                        Pause();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid option! Try again...");
                        Pause();
                        break;
                }
            }
        }
    }
}