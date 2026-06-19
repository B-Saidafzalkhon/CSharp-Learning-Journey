using System.Text;

namespace _11_generic_stack
{
    internal class Program
    {
        public class MyStack<T>
        {
            private readonly List<T> _values = new List<T>();
            public int Count => _values.Count;
            public void Push(T item) => _values.Add(item);
            public T Pop()
            {
                if(_values.Count == 0)
                    throw new InvalidOperationException("Stack is empty");

                T current = _values[_values.Count - 1];
                _values.RemoveAt(_values.Count - 1);
                return current;
            }
            public T Peek()
            {
                if (_values.Count == 0)
                    throw new InvalidOperationException("Stack is empty");

                T current = _values[_values.Count - 1];
                return current;
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                for (int i = _values.Count - 1; i >= 0; i--)
                {
                    sb.AppendLine($"Element number {i + 1} | {_values[i]}");
                }
                
                return sb.ToString();
            }
        }
        static void Main(string[] args)
        {
            // Int Example
            {
                MyStack<int> ints = new MyStack<int>();

                Console.WriteLine("=== Original Stack ===");
                for (int i = 0; i <= 10; i++)            
                    ints.Push(i);
                Console.WriteLine(ints);
                Console.WriteLine($"\nElement: {ints.Pop()} removed\n " +
                    $"Press any key to update the Stack...");
                Console.ReadKey(true);
                Console.Clear();

                Console.WriteLine("=== Updated Stack ===");
                Console.WriteLine(ints);
                Console.WriteLine($"\nElement: {ints.Peek()} showed but not removed!\n" +
                    $"Press any key to continue...");

                Console.ReadKey(true);
                Console.Clear();
            }

            // String Example
            {
                MyStack<string> strings = new MyStack<string>();
                Console.WriteLine("=== Original Stack ===");
                for (int i = 0; i <= 10; i++)
                {
                    strings.Push($"String #{i}");           
                }
                Console.WriteLine(strings);
                Console.WriteLine($"\nElement: {strings.Pop()} removed\n " +
                    $"Press any key to update the Stack...");
                Console.ReadKey(true);
                Console.Clear();

                Console.WriteLine("=== Updated Stack ===");
                Console.WriteLine(strings);
                Console.WriteLine($"\nElement: {strings.Peek()} showed but not removed!");
            }
        }
    }
}
