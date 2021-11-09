using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Simons book");
            book.AddGrade(11.2);
            book.AddGrade(33.4);
            book.AddGrade(52.2);
            var stats = book.GetStatistics();

            Console.WriteLine($"Average grade is: {stats.Average:N2}");
            Console.WriteLine($"Lowest grade is: {stats.LowestGrade:N2}");
            Console.WriteLine($"Highest grade is: {stats.HighestGrade:N2}");
        }
    }
}
