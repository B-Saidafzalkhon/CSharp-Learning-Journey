namespace _27_file_journal
{
    internal class Program
    {
        static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if(!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Input cannot be empty!");
            }
        }
        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if(int.TryParse(input, out int number))
                    return number;

                Console.WriteLine("Invalid input! Try again!");
            }
        }
        static void EnsureFileExists(string path)
        {
            if(!File.Exists(path))
                throw new FileNotFoundException("File not exists!");
        }
        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            string mainFolderPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "../../.."));
            string fileFolderPath = Path.Combine(mainFolderPath, "Data");
            Directory.CreateDirectory(fileFolderPath);

            string filePath = Path.Combine(fileFolderPath, "journal.txt");

            while (true)
            {
                Console.WriteLine("=== File Journal ===");
                Console.WriteLine("1. Add text\n" +
                    "2. Show all text\n" +
                    "3. Exit");

                int choice = ReadInt("Enter a choice: ");

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("=== Adding text ===");
                        try
                        {
                            string text = ReadString("Enter text: ");
                            File.AppendAllText(filePath, $"{DateTime.Now}: {text}{Environment.NewLine}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Pause();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("=== Showing All Text ===");
                        try
                        {
                            EnsureFileExists(filePath);
                            string readText = File.ReadAllText(filePath);

                            Console.WriteLine("Readed text: \n" + readText);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Pause();
                        break;

                    case 3:
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid input! Try again!");
                        Pause();
                        break;
                }
            }
        }
    }
}
