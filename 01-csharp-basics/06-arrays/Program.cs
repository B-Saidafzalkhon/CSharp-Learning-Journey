namespace _06_arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Exercise 1
            {
                Console.WriteLine("====== Array Filling and Output ======");
                int[] numbers = new int[5];

                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write($"Number #{i + 1}: ");
                    string? input = Console.ReadLine();

                    if (int.TryParse(input, out int number))
                    {
                        numbers[i] = number;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Try again!");
                        i--;
                    }
                }

                Console.WriteLine("Your numbers: ");
                int count = 0;
                foreach (int values in numbers)
                {
                    Console.WriteLine($"[{++count}]: {values}");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            // Exercise 2
            {
                Console.WriteLine("====== Array Statistics ======");

                int arrayLength = 0;
                bool notDigit = true;
                while (notDigit)
                {
                    Console.Write("Amount of numbers: ");
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                    {
                        arrayLength = number;
                        notDigit = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Try again!");
                    }
                }

                int[] numbers = new int[arrayLength];
                for (int i = 0; i < arrayLength; i++)
                {
                    Console.Write($"Number #{i + 1}: ");
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                    {
                        numbers[i] = number;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Try again!");
                        i--;
                    }
                }

                // Solution 1
                int sum = 0;
                double average = 0;
                int min = numbers[0], max = numbers[0];

                for (int i = 0; i < numbers.Length; i++)
                {
                    sum += numbers[i];

                    if (numbers[i] < min)
                    {
                        min = numbers[i];
                    }

                    if (numbers[i] > max)
                    {
                        max = numbers[i];
                    }
                }
                average = sum / (double)numbers.Length;
                Console.WriteLine($"Sum: {sum}\n" +
                    $"Average: {average}\n" +
                    $"Min: {min}\n" +
                    $"Max: {max}");

                /* Solution 2
                int sumMethod = numbers.Sum();
                int minMethod = numbers.Min();
                int maxMethod = numbers.Max();
                double averageMethod = numbers.Average();

                Console.WriteLine($"Sum: {sumMethod}\n" +
                    $"Average: {averageMethod}\n" +
                    $"Min: {minMethod}\n" +
                    $"Max: {maxMethod}");
                */

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            // Exercise 3
            {
                Console.WriteLine("====== Reverse Order ======");

                string[] names = new string[5];

                int count = 0;
                Console.WriteLine("Enter 5 names: ");
                for (int i = 0; i < names.Length; i++)
                {
                    Console.Write($"Name #{++count}: ");
                    string? input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        names[i] = input;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Try again!");
                        i++;
                    }
                }

                Console.WriteLine("\nReversed: ");
                for (int i = names.Length - 1; i >= 0; i--)
                {
                    Console.WriteLine(names[i]);
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            // Exercise 4
            {
                Console.WriteLine("====== Element Search ======");

                Console.WriteLine("Enter 5 numbers: ");
                int[] numbers = new int[5];
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write($"Number #{i + 1}: ");
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int value))
                    {
                        numbers[i] = value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Try again!");
                        i--;
                    }
                }

                int searchingNumber;
                while (true)
                {
                    Console.Write("Search for: ");
                    string? inputSearchingNumber = Console.ReadLine();
                    if (int.TryParse(inputSearchingNumber, out int value))
                    {
                        searchingNumber = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Try again!");
                    }
                }

                int searchingNumberIndex = -1;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == searchingNumber)
                    {
                        searchingNumberIndex = i;
                        break;
                    }
                }

                if (searchingNumberIndex != -1)
                {
                    Console.WriteLine($"Found at index: {searchingNumberIndex + 1}");
                }
                else
                {
                    Console.WriteLine("Not found...");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            // Exercise 5
            {
                Console.WriteLine("====== Separate Even and Odd Numbers ======");

                // I will use a solution with two loops here instead of two extra arrays just to save RAM resources.
                // Also they are unnecessary here - "anti-pattern"
                int[] numbers = new int[10];

                Console.WriteLine("Enter 10 numbers: ");
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write($"Number {i + 1}: ");
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int value))
                    {
                        numbers[i] = value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Try again!");
                        i--;
                    }
                }

                // Separate Even Numbers
                Console.Write("Even numbers: ");
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }

                // Separate Odd Numbers
                Console.Write("\nOdd numbers: ");
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 != 0)
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            // Exercise 6
            {
                Console.WriteLine("====== Minimum and its position ======");

                int[] numbers = new int[7];

                Console.WriteLine("Enter 7 numbers: ");
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write($"Number {i + 1}: ");
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int value))
                    {
                        numbers[i] = value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Try again!");
                        i--;
                    }
                }

                int min = numbers[0];
                int position = 1;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] < min)
                    {
                        min = numbers[i];
                        position = i + 1;
                    }
                }

                Console.WriteLine($"Minimum value: {min}\n" +
                    $"Position: {position}");
            }

            /*
             * The repeated code blocks are the parts with "waiting for input before continuing" 
             * and "clearing the console". 
             * Also, entering values for the array and validating them before use is repeated, 
             * as well as iterating through the array.
             */
        }
    }
}
