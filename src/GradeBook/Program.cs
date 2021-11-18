using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Simons book");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);
            PrintStatistics(book);
        }

        private static void PrintStatistics(Book book)
        {
            var stats = book.GetStatistics();

            Console.WriteLine($"For the book {book.Name}");
            Console.WriteLine($"Average grade is: {stats.Average:N2}");
            Console.WriteLine($"Lowest grade is: {stats.LowestGrade:N2}");
            Console.WriteLine($"Highest grade is: {stats.HighestGrade:N2}");
            Console.WriteLine($"Letter grade is: {stats.Letter}");
        }

        private static void EnterGrades(Book book)
        {
            while (true)
            {
                Console.WriteLine("Please entere a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine($"A grade was miracly added. Holy fuck!");
        }
    }
}
