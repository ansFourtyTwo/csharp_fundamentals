using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var sum_of_grades = 0.0;
            var highestGrade = double.MinValue;
            var lowestGrade = double.MaxValue;
            foreach (var grade in grades)
            {
                highestGrade = Math.Max(highestGrade, grade);
                lowestGrade = Math.Min(lowestGrade, grade);
                sum_of_grades += grade;
            }

            if (grades.Count == 0)
            {
                Console.WriteLine("No grades available for printing statistics");
                return;
            }

            var average = sum_of_grades / grades.Count;
            Console.WriteLine($"Average grade is: {average:N2}");
            Console.WriteLine($"Lowest grade is {lowestGrade:N2}");
            Console.WriteLine($"Highest grade is: {highestGrade:N2}");


        }


        private List<double> grades;
        private string name;
    }
}