namespace _10_keyvalue_store
{
    internal class Program
    {
        public class KeyValueStore<TKey, TValue>
        {
            private readonly Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();
            public int Count => _dictionary.Count;
            public void Set(TKey key, TValue value)
            {
                _dictionary[key] = value;
            }
            public TValue? Get(TKey key)
            {
                if (_dictionary.TryGetValue(key, out TValue? value))
                    return value;

                return default;
            }
            public bool Has(TKey key)
            {
                return _dictionary.ContainsKey(key);
            }
            public bool Remove(TKey key)
            {
                return _dictionary.Remove(key);
            }
        }
        static void Main(string[] args)
        {
            KeyValueStore<string, int> ages = new KeyValueStore<string, int>();

            ages.Set("Ali", 20);
            ages.Set("Madina", 25);
            ages.Set("Rustam", 30);

            Console.WriteLine("Store: name -> age");
            Console.WriteLine($"Ali's age: {ages.Get("Ali")}");
            Console.WriteLine($"Does Madina exist? {ages.Has("Madina")}");
            Console.WriteLine($"Does Hasan exist? {ages.Has("Hasan")}");
            Console.WriteLine($"Count before removal: {ages.Count}");

            ages.Remove("Rustam");

            Console.WriteLine($"Count after removing Rustam: {ages.Count}");
            Console.WriteLine();


            KeyValueStore<int, string> products = new KeyValueStore<int, string>();

            products.Set(1, "Laptop");
            products.Set(2, "Phone");
            products.Set(3, "Monitor");

            Console.WriteLine("Store: product number -> product name");
            Console.WriteLine($"Product #2: {products.Get(2)}");
            Console.WriteLine($"Does product #3 exist? {products.Has(3)}");
            Console.WriteLine($"Does product #5 exist? {products.Has(5)}");
            Console.WriteLine($"Count before removal: {products.Count}");

            products.Remove(1);

            Console.WriteLine($"Count after removing product #1: {products.Count}");
        }
    }
}
