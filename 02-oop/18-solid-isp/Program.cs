namespace _18_solid_isp
{
    internal class Program
    {
        /*
         Incorrect ISP example.

         This interface is too fat.
         It forces every machine to implement Print(), Scan(), and Fax(),
         even if the machine cannot scan or fax.

        interface IMachine
        {
            string Print();
            string Scan();
            string Fax();
        }

        class OldPrinter : IMachine
        {
            public string Print() => "Can print...";

            public string Scan()
            {
                throw new NotImplementedException();
            }

            public string Fax()
            {
                throw new NotImplementedException();
            }
        }

         This is bad because OldPrinter is forced to implement methods
         that it does not support.

         A class should not depend on methods that it does not use.
        */

        interface IPrinter
        {
            string Print();
        }
        interface IScanner
        {
            string Scan();
        }
        interface IFax
        {
            string Fax();
        }

        class OldPrinter : IPrinter
        {
            public string Print() => "Can Print...";
        }
        class ModernMFP : IPrinter, IScanner, IFax
        {
            public string Print() => "Can Print...";
            public string Scan() => "Can Scan...";
            public string Fax() => "Can Fax...";
        }
        static void Main(string[] args)
        {
            ModernMFP mFP = new ModernMFP();
            Console.WriteLine($"Modern Printer: {mFP.Print()} | {mFP.Scan()} | {mFP.Fax()}");

            OldPrinter oldPrinter = new OldPrinter();
            Console.WriteLine($"Old Printer: {oldPrinter.Print()}");
        }
    }
}
