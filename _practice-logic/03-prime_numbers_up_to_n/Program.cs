int n = 0;
while (true)
{
    Console.Write("Enter N: ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out int number))
    {
        n = number;
        break;
    }
    Console.WriteLine("Invalid input. Try again!");
}

for (int i = 2; i <= n; i++)
{
    bool isPrime = true;
    double limit = Math.Sqrt(i);
    for (int j = 2; j <= limit; j++)
    {
        if (i % j == 0)
        {
            isPrime = false;
            break;
        }
    }
    if (isPrime)
    {
        Console.WriteLine(i);
    }
}
