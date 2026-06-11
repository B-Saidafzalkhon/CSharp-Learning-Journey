namespace _07_employee
{
    internal class Program
    {
        public class Employee
        {
            private const decimal baseSalary = 5000m; // Done intentionally to avoid magic numbers
            public string Name {  get; set; }        
            public Employee(string name) 
            {
                Name = name;
            }
            public virtual decimal CalculateSalary()
            {             
                return baseSalary;      
            }
            public override string ToString()
            {
                return $"{GetType().Name,-10} :{Name,-10} | Salary: {CalculateSalary()}";
            }
        }

        public sealed class Manager : Employee // The class cannot be inherted from
        {
            public Manager(string name) : base(name) { }
            public override decimal CalculateSalary()
            {
                decimal baseSalary = base.CalculateSalary();
                return baseSalary + (baseSalary * 0.5m);
            }
        }

        public class Developer : Employee
        {     
            public Developer(string name) : base (name) { }
            public override decimal CalculateSalary()
            {
                decimal baseSalary = base.CalculateSalary();
                decimal bonus = baseSalary * 0.3m;

                return baseSalary + bonus;
            }
        }
        static void Main(string[] args)
        {
            List<Employee> list = new()
            {
                new Employee("David"),
                new Manager("Alice"),
                new Developer("Nathan")
            };

            foreach (Employee emp in list)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
