using System.Text;

namespace _16_solid_srp
{
    internal class Program
    {
        /*
         Incorrect SRP example.

         The Report class has three reasons to change:

         1. Data structure changes:
            For example, if we add Title, Department, Status, etc.

         2. Formatting rules change:
            For example, if we want another text layout, JSON, HTML, or table format.

         3. Saving logic changes:
            For example, if we save to a real file, database, cloud storage, or change the file path.

         That is why this class violates SRP.
        */

        /*
        class Report
        {
            public string ReporterName { get; set; }
            public DateTime ReportDate { get; set; }
            public string ReportDescription { get; set; }

            public Report(string reporterName, string reportDescription)
            {
                ReporterName = reporterName;
                ReportDate = DateTime.Now;
                ReportDescription = reportDescription;
            }

            public string FormatReport()
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Reporter Name: {ReporterName}");
                sb.AppendLine($"Report Description: {ReportDescription}");
                sb.AppendLine($"Report Date: {ReportDate}");

                return sb.ToString();
            }

            public void Save()
            {
                Console.WriteLine("Saving report to file...");
                Console.WriteLine(FormatReport());
                Console.WriteLine("Saved to: {FilePath/...}");
            }
        }
        */

        class Report
        {
            public string ReporterName { get; set; }
            public DateTime ReportDate { get; set; }
            public string ReportDescription { get; set; }

            public Report(string reporterName, string reportDescription)
            {
                ReporterName = reporterName;
                ReportDate = DateTime.Now;
                ReportDescription = reportDescription;
            }
        }
        class ReportFormatter
        {
            public string Format(Report report)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Reporter Name: {report.ReporterName}");
                sb.AppendLine($"Report Description: {report.ReportDescription}");
                sb.AppendLine($"Report Date: {report.ReportDate}");

                return sb.ToString();
            }
        }
        class ReportSaver
        {
            public void Save(string formattedReport)
            {
                Console.WriteLine("====== Saving report ======");
                Console.WriteLine(formattedReport);
                Console.WriteLine("Saved to: {FilePath/...}");
            }
        }

        static void Main(string[] args)
        {
            Report report = new Report("Alex Alexandrov", "Some report description...");

            ReportFormatter formatter = new ReportFormatter();
            ReportSaver saver = new ReportSaver();

            string formattedReport = formatter.Format(report);

            Console.WriteLine("Report message:");
            Console.WriteLine(formattedReport);

            saver.Save(formattedReport);
        }
    }
}