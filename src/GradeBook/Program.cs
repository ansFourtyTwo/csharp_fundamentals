using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Simons book");

            string input;
            do
            {
                Console.WriteLine("Please entere a grade or 'q' to quit");
                input = Console.ReadLine();
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            } while (input != "q" && input != "Q");

            var stats = book.GetStatistics();

            Console.WriteLine($"Average grade is: {stats.Average:N2}");
            Console.WriteLine($"Lowest grade is: {stats.LowestGrade:N2}");
            Console.WriteLine($"Highest grade is: {stats.HighestGrade:N2}");
            Console.WriteLine($"Letter grade is: {stats.Letter}");
        }
    }
}
