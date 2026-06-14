namespace _15_solid_dip
{
    internal class Program
    {
        interface IMessageSender
        {
            void Send(string text);
        }
        class EmailSender : IMessageSender
        {
            public void Send(string text) => Console.WriteLine($"Message: \"{text}\" \nSendet via Email...");
        }
        class SmsSender : IMessageSender
        {
            public void Send(string text) => Console.WriteLine($"Message: \"{text}\" \nSendet via Sms...");
        }
        class NotificationService
        {
            private readonly IMessageSender _sender;
            public NotificationService(IMessageSender sender)
            {
                _sender = sender;
            }
            public void Notify(string message)
            {
                _sender.Send(message);
            }
        }
        static void Main(string[] args)
        {
            NotificationService emailService = new NotificationService(new EmailSender());
            emailService.Notify("Your order has been shipped");

            Console.WriteLine();

            NotificationService smsService = new NotificationService(new SmsSender());
            smsService.Notify("Your order has been shipped");
        }
    }
}
