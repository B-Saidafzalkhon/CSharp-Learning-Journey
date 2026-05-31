namespace _04_conditions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Exercise 1
            {
                Console.WriteLine("====== Even/odd ======");

                Console.Write("Enter a number: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    if (number % 2 == 0)
                    {
                        Console.WriteLine($"\"{number}\" is Even");
                    }
                    else
                    {
                        Console.WriteLine($"\"{number}\" is Odd");
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid number!");
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }


            // Exercise 2
            {
                Console.WriteLine("====== Score ======");

                Console.Write("Enter score (0-100): ");
                string? input = Console.ReadLine();           

                if (int.TryParse(input, out int score))
                {
                    if (score >= 90)
                    {
                        Console.WriteLine("Grade: A");
                    }
                    else if (score >= 80)
                    {
                        Console.WriteLine("Grade: B");
                    }
                    else if (score >= 70)
                    {
                        Console.WriteLine("Grade: C");
                    }
                    else if (score >= 60)
                    {
                        Console.WriteLine("Grade: D");
                    }
                    else if (score >= 0)
                    {
                        Console.WriteLine("Grade: F");
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid number!");
                    return;
                }
             
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            // Exercise 3
            {
                Console.Write("Enter day number (1-7): ");
                string? input = Console.ReadLine();
                int dayNumber = 0;

                if (int.TryParse(input, out int number))
                {
                    dayNumber = number;
                }
                else
                {
                    Console.WriteLine("Not a valid number!");
                }

                string dayName = dayNumber switch
                {
                    1 => "Monday",
                    2 => "Tuesday",
                    3 => "Wednesday",
                    4 => "Thursday",
                    5 => "Friday",
                    6 => "Saturday",
                    7 => "Sunday",
                    _ => "Invalid"
                };
                Console.WriteLine($"{input} is: {dayName}");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            
            // Exercise 4
            {
                Console.Write("Username: ");
                string? username = Console.ReadLine();
                Console.Write("Password: ");
                string? password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Username cannot be empty!");
                }

                if (string.IsNullOrEmpty(password) || password.Length < 6)
                {
                    Console.WriteLine("Password must be at least 6 characters.");
                }

                if (!string.IsNullOrWhiteSpace(username) && password.Length >= 6)
                {
                    Console.WriteLine("Login successful!");
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            // Exercise 5
            {
                Console.Write("First number: ");
                string? input1 = Console.ReadLine();

                Console.Write("Second number: ");
                string? input2 = Console.ReadLine();

                decimal firstNumber = 0, secondNumber = 0;
                if (decimal.TryParse(input1, out decimal number1))
                {
                    firstNumber = number1;
                }
                else
                {
                    Console.WriteLine("Not a valid number!");
                }

                if (decimal.TryParse(input2, out decimal number2))
                {
                    secondNumber = number2;
                }
                else
                {
                    Console.WriteLine("Not a valid number!");
                }

                string? input3 = Console.ReadLine();
                char operation = ' ';
                if (char.TryParse(input3, out char op))
                {
                    operation = op;
                }
                else
                {
                    Console.WriteLine("Not a valid character!");
                }

                decimal? result = operation switch
                {
                    '+' => firstNumber + secondNumber,
                    '-' => firstNumber - secondNumber,
                    '*' => firstNumber * secondNumber,
                    '/' when secondNumber != 0 => firstNumber / secondNumber,                
                    _ => null
                };

                if (result.HasValue)
                {
                    Console.WriteLine($"Result: {result.Value:F2}");
                }
                else
                {
                    Console.WriteLine("Cannot compute result (invalid operator or division by zero).");
                }
            }
        }
    }
}
