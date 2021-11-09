using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.HighestGrade = double.MinValue;
            result.LowestGrade = double.MaxValue;
            foreach (var grade in grades)
            {
                result.HighestGrade = Math.Max(result.HighestGrade, grade);
                result.LowestGrade = Math.Min(result.LowestGrade, grade);
                result.Average += grade;
            }
            result.Average /= grades.Count;
            return result;
        }


        private List<double> grades;
        public string Name;
    }
}