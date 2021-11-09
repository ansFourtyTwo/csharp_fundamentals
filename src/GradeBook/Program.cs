using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Simons book");
            book.ShowStatistics();
            book.AddGrade(11.2);
            book.AddGrade(33.4);
            book.AddGrade(52.2);
            book.ShowStatistics();

        }
    }
}
