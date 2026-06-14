namespace _17_solid_ocp
{
    internal class Program
    {
        /*
         Incorrect OCP example.

         This method violates OCP because every time we add a new customer type,
         we must modify this method.

         For example, if we add "premium", we must add a new else if.

        static decimal CalculateFinalPrice(string customerType, decimal amount)
        {
            if (customerType == "regular")
            {
                return amount - (amount * 0.2m);
            }
            else if (customerType == "vip")
            {
                return amount - (amount * 0.4m);
            }
            else if (customerType == "premium")
            {
                return amount - (amount * 0.5m);
            }

            return amount;
        }
        */

        interface IDiscount
        {
            decimal GetFinalPrice();
        }

        class RegularCustomer : IDiscount
        {
            private decimal _amount;
            public RegularCustomer(decimal amount)
            {
                _amount = amount;
            }
            public decimal GetFinalPrice()
            {
                return _amount - (_amount * 0.2m);
            }

            public override string ToString() =>  $"Regular Customer: ${_amount,-20}";
        }
        class VipCustomer : IDiscount
        {
            private decimal _amount;
            public VipCustomer(decimal amount)
            {
                _amount = amount;
            }
            public decimal GetFinalPrice()
            {
                return _amount - (_amount * 0.5m);
            }
            public override string ToString() => $"Vip Customer: ${_amount,-24}";
        }
        class PremiumCustomer : IDiscount
        {
            private decimal _amount;
            public PremiumCustomer(decimal amount)
            {
                _amount = amount;
            }
            public decimal GetFinalPrice()
            {
                return _amount - (_amount * 0.4m);
            }
            public override string ToString() => $"Premium Customer: ${_amount,-20}";
        }

        static void Main(string[] args)
        {
            List<IDiscount> discounts = new()
            {
                new RegularCustomer(1000),
                new VipCustomer(1000),
                new PremiumCustomer(1000)
            };

            foreach (IDiscount discount in discounts)
            {
                Console.WriteLine($"{discount} | Discount: {discount.GetFinalPrice()}");
            }
        }
    }
}
