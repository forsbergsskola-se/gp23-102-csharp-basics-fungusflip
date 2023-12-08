using System;

namespace CalculateTheMonths
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parse is objectively better
            Console.Write("Enter the number of seconds: ");
            int seconds = int.Parse(Console.ReadLine());

            // I listened marc!
            int days = seconds / (24 * 3600);
            seconds %= (24 * 3600);
            int hours = seconds / 3600;
            seconds %= 3600;
            int minutes = seconds / 60;
            seconds %= 60;

            // Niceprint
            Console.WriteLine("Days: " + days);
            Console.WriteLine("Hours: " + hours);
            Console.WriteLine("Minutes: " + minutes);
            Console.WriteLine("Seconds: " + seconds);

            // the asked format
            string formattedTime = $"{days}.{hours:D2}:{minutes:D2}:{seconds:D2}";
            Console.WriteLine("Formatted Time: " + formattedTime);

            // Print how many days that is in total as a fraction
            double totalDays = days + (hours / 24.0) + (minutes / 1440.0) + (seconds / 86400.0);
            Console.WriteLine("Total Days" + totalDays);

            Console.ReadLine(); // Pause to view the output
        }
    }
}