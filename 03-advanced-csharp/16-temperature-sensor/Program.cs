namespace _16_temperature_sensor
{
    internal class Program
    {
        public class TemperatureSensor
        {
            private double _temperature;
            public event Action<double>? TemperatureChanged;
            public TemperatureSensor(double temperature)
            {
                _temperature = temperature;
            }

            public void SetTemperature(double newTemp)
            {
                _temperature = newTemp;
                TemperatureChanged?.Invoke(newTemp);
            }
        }
        static void Main(string[] args)
        {
            TemperatureSensor sensor = new TemperatureSensor(36.6);

            sensor.TemperatureChanged += newTemp =>
            {
                Console.WriteLine($"Temperature: {newTemp:F2}");
                if (newTemp > 50)
                {
                    Console.WriteLine($"Temperature [{newTemp:F2}]  is out of the range (Too high!)");
                }
                else if (newTemp < 0)
                {
                    Console.WriteLine($"Temperature [{newTemp:F2}] is out of the range (Too Low!)");
                }
            };

            sensor.SetTemperature(40.0);
            sensor.SetTemperature(50.10);
            sensor.SetTemperature(-10.1);
        }
    }
}
