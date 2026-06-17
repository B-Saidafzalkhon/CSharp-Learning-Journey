namespace _06_generic_box
{
    internal class Program
    {
        public class Box<T>
        {
            private T _value;
            
            public Box(T value)
            {
                _value = value;
            }

            public void Put(T item) { _value = item; }
            public T GetItem() { return _value; }
        }
        static void Main(string[] args)
        {
            Box<int> intBox = new Box<int>(10);
            Box<string> stringBox = new Box<string>("Apple");
            Box<double> doubleBox = new Box<double>(3.14);

            Console.WriteLine(intBox.GetItem());
            Console.WriteLine(stringBox.GetItem());
            Console.WriteLine(doubleBox.GetItem());

            intBox.Put(25);
            Console.WriteLine(intBox.GetItem());
        }
    }
}
