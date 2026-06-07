using System.Text;
namespace _09_strings
{
    internal class Program
    {
        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Invalid input! Try again!");
            }
        }
        static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("String cannot be empty!");
            }
        }

        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            // Exercise 1
            {
                Console.WriteLine("====== Name/Number Output ======");
                Dictionary<string, string> contacts = new();

                int n = ReadInt("Enter amount of contacts: ");
                for (int i = 0; i < n; i++)
                {
                    string name = ReadString($"Enter Contact's Name ${i + 1}: ");
                    string number = ReadString($"Enter Contact's Phone ${i + 1}: ");

                    contacts[name] = number;
                }

                foreach (var c in contacts)
                {
                    Console.WriteLine($"{c.Key,-15} {c.Value}");
                }
                Pause();
            }

            // Exercise 2
            {
                Console.WriteLine("====== Report builder via StringBuilder ======");

                string sentence = ReadString("Enter a sentence: ");

                string[] words = sentence.Split(' ');
                string sentenceLength = sentence.Trim().Replace(" ", "");

                HashSet<string> unique = new HashSet<string>();
                foreach (var word in words)           
                    unique.Add(word);
                

                string longestWord = words[0];
                for (int i = 0; i < words.Length; i++)               
                    if (words[i].Length > longestWord.Length)       
                        longestWord = words[i];
                         
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("=== Report ===");
                sb.AppendLine($"Total words: {words.Length}");
                sb.AppendLine($"Unique words: {unique.Count}");
                sb.AppendLine($"Longest word: {longestWord}");
                sb.AppendLine($"Sentence length: {sentenceLength.Length} Characters (no spaces):");

                Console.WriteLine(sb.ToString());
                Pause();
            }
        }
    }
}
