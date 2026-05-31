string str;
while (true)
{
    Console.Write("Enter a string: ");
    string? input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input))
    {
        input = input.Trim().Replace(" ", "").ToLower();
        str = input;
        break;
    }
    else
    {
        Console.WriteLine("Invalid input! Try again!");
    }
}

int left = 0;
int right = str.Length - 1;
bool isPalindrome = true;

while (left < right)
{
    if (str[left] != str[right])
    {
        isPalindrome = false;
        break;
    }

    left += 1;
    right -= 1;
}

if (isPalindrome)
{
    Console.WriteLine($"\"{str}\" is a palindrome");
}
else
{
    Console.WriteLine($"\"{str}\" is not a palindrome");
}
