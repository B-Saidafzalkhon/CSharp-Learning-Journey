int number;
int sum = 0;

Console.Write("Enter a number: ");
while (true)
{
    string? input = Console.ReadLine();
    if (int.TryParse(input, out int value))
    {
        number = value;
        break;
    }
    else
    {
        Console.WriteLine("Invalid input. Try again!");
    }
}

number = Math.Abs(number);
while (number > 0)
{
    int lastDigit = number % 10;
    sum += lastDigit;
    number /= 10;
}
Console.WriteLine($"Sum: {sum}");