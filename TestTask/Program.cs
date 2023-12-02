using Microsoft.EntityFrameworkCore;
using TestTask;

Console.WriteLine("Enter the connection string for the database");

string connectionString = Console.ReadLine();

using (ApplicationContext db = new ApplicationContext(connectionString))
{
    try
    {
        var week = DateTime.Now.CurrentWeek();

        foreach (var date in week)
        {
            var timeReportsByDateAndEmployee = db.TimeReports.Include(timeReport => timeReport.Employee)
                .Where(timeReport => timeReport.Date == date)
                .GroupBy(timeReport => timeReport.EmployeeId)
                .ToList();

            var timeReportsSortedByHours = timeReportsByDateAndEmployee
                .OrderByDescending(timeReport => timeReport.Sum(t => t.Hours))
                .Take(3);

            var dayReport = $"| {date.DayOfWeek} | ";

            if (!timeReportsSortedByHours.Any())
            {
                dayReport += "No time reports for this day";
            }
            else
            {
                foreach (var timeReport in timeReportsSortedByHours)
                {
                    dayReport += $"{timeReport.First().Employee.Name} ({Math.Round(timeReport.Sum(t => t.Hours), 2)} hours), ";
                }

                dayReport = dayReport.Remove(dayReport.Length - 2);
            }

            dayReport += " |";

            Console.WriteLine(dayReport);
        }
    }
    catch
    {
        Console.WriteLine("Check the connection string and try again");
    }
}