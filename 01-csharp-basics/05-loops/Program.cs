namespace _05_loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exercise 1
            {
                Console.WriteLine("====== Multiplication table ======");

                Console.Write("Enter a number (1-10): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number) && (number <= 10 && number >= 1))
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        Console.WriteLine($"{number} x {i} = {number * i}");
                    }

                    Console.WriteLine("Press any key to countinue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\nInvalid Input! \nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            // Exercise 2
            {
                Console.WriteLine("====== Sum from 1 to N ======");

                Console.Write("Enter N: ");
                string input = Console.ReadLine();
                int sum = 0;
                if (int.TryParse(input, out int number) && number > 0)
                {
                    for (int i = 1; i <= number; i++)
                    {
                        sum += i;
                    }
                    Console.WriteLine($"Sum: {sum}");
                    Console.WriteLine("Press any key to countinue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\nInvalid Input! \nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            // Exercise 3
            {
                Console.WriteLine("====== Guess the number ======");
                Random rnd = new Random();
                int target = rnd.Next(1, 101);

                bool guessed = false;
                int count = 0;

                while (!guessed)
                {
                    count++;
                    Console.Write("Guess the number: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                    {
                        if (number == target)
                        {
                            Console.WriteLine($"Correct! You got it in {count} tries.");
                            guessed = true;

                        }
                        if (number < target)
                        {
                            Console.WriteLine("Too low!");                       
                        }
                        else
                        {
                            Console.WriteLine("Too high!");                      
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input! \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }

            // Exercise 4
            {
                Console.WriteLine("====== Menu with Exit ======");
                int choice = 0;
                do
                {
                    Console.WriteLine("1. Say Hello\n" +
                        "2. Show Current Time\n" +
                        "3. Exit");

                    Console.Write("Choice: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                    {
                        choice = number;
                        string message = choice switch
                        {
                            1 => "Hello!",
                            2 => $"{DateTime.Now}",
                            3 => "Goodbye!",
                            _ => "Invalid option"
                        };
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input! \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                while (choice != 3);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            // Exercise 5
            {
                Console.WriteLine("====== FizzBuzz ======");

                /* Solution 1
                for (int i = 1; i <= 100; i++)
                {
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        Console.WriteLine("FizzBuzz");
                    }
                    else if (i % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    else if (i % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                    else
                    {
                        Console.WriteLine(i);
                    }

                }
                */

                for (int i = 1; i <= 100; i++)
                {
                    string str = "";
                    if (i % 3 == 0)
                    {
                        str = "Fizz";
                    }
                    if (i % 5 == 0)
                    {
                        str += "Buzz";
                    }
                    if (str == "")
                    {
                        str = $"{i}";
                    }
                    Console.WriteLine(str);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
