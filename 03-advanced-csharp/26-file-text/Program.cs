namespace _26_file_text
{
    internal class Program
    {
        static void FileExists(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found!");
        }
        static void Main(string[] args)
        {
            string mainFolderPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "../../.."));
            string fileFolderPath = Path.Combine(mainFolderPath, "data");
            Directory.CreateDirectory(fileFolderPath);

            string filePath = Path.Combine(fileFolderPath, "text.txt");
            try
            {
                File.WriteAllLines(filePath, new string[] { "line 1", "line 2", "line 3" });

                FileExists(filePath);
                string readText = File.ReadAllText(filePath);
                Console.WriteLine($"Read text:\n{readText}");

                File.AppendAllText(filePath, Environment.NewLine + "new line added");

                FileExists(filePath);
                readText = File.ReadAllText(filePath);
                Console.WriteLine($"After AppendAllText:\n{readText}");

                File.WriteAllText(filePath, "old text was overwritten");

                FileExists(filePath);
                readText = File.ReadAllText(filePath);
                Console.WriteLine($"\nAfter WriteAllText overwrite:\n{readText}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}