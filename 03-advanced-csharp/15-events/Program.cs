namespace _15_events
{
    internal class Program
    {
        public class Stock
        {
            private decimal _price;

            public event Action<decimal>? PriceChanged;

            public Stock(decimal price)
            {
                _price = price;
            }

            public void SetPrice(decimal newPrice)
            {
                _price = newPrice;

                // Invoke calls all methods/lambdas subscribed to the event.
                // The ?. operator means: call Invoke only if PriceChanged is not null.
                PriceChanged?.Invoke(newPrice);
            }
        }

        static void Main(string[] args)
        {
            Stock stock = new Stock(100);

            // += subscribes a lambda/method to the event.
            // This lambda will be called every time PriceChanged is invoked.
            stock.PriceChanged += price =>
            {
                Console.WriteLine($"Price changed. New price: {price}");
            };

            // += adds one more subscriber to the same event.
            // Both subscribers will be called when the price changes.
            stock.PriceChanged += price =>
            {
                if (price > 150)
                {
                    Console.WriteLine("Warning: price is higher than 150!");
                }
            };

            stock.SetPrice(120);
            stock.SetPrice(160);
            stock.SetPrice(90);
        }
    }
}