namespace _02_bank_account
{
    internal class Program
    {
        public class BankAccount
        {
            private decimal _balance;
            public decimal Balance { 
                get 
                { 
                    return _balance; 
                }
            }
            public BankAccount(decimal balance)
            {
                if (balance <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(balance), "Cannot be < 0!");
                }
                else
                {
                    _balance = balance;
                }
            }

            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                    return;
                _balance += amount;
            }

            public void Withdraw(decimal amount)
            {
                if (amount < 0)
                    return;
                if (amount > _balance)
                    throw new ArgumentOutOfRangeException(nameof(amount), "Input is out of the range!");

                _balance -= amount;
            }
        }

        static decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal value))
                    return value;

                Console.WriteLine("Invalid input!");
            }
        }
        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Invalid input!");
            }
        }
        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("====== Bank Account Class ======");

            decimal balance = ReadDecimal("Enter balance: ");
            BankAccount a = new BankAccount(balance);

            while (true)
            {
                Console.WriteLine($"Current balance: {a.Balance}");

                Console.WriteLine("1. Deposit\n" +
                    "2. Withdraw\n" +
                    "3. Exit");

                int choice = ReadInt("\nChoice: ");
                switch (choice)
                {
                    case 1:
                        {
                            decimal amount = ReadDecimal("Enter the amount: ");
                            a.Deposit(amount);
                            Pause();
                        }
                        break;

                    case 2:
                        {
                            try
                            {
                                decimal amount = ReadDecimal("Enter the amount: ");
                                a.Withdraw(amount);
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Pause();
                        }
                        break;

                    case 3:
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid input!");
                        Pause();
                        break;
                }
            }
        }
    }
}
