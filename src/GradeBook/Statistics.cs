using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double HighestGrade;
        public double LowestGrade;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'A';

                    case var d when d >= 80:
                        return 'B';

                    case var d when d >= 70:
                        return 'C';

                    case var d when d >= 60:
                        return 'D';

                    default:
                        return 'F';
                }
            }

        }
        public double Sum;
        public int Count;

        public void AddGrade(double grade)
        {
            HighestGrade = Math.Max(HighestGrade, grade);
            LowestGrade = Math.Min(LowestGrade, grade);
            Sum += grade;
            Count += 1;
        }
        public Statistics()
        {
            HighestGrade = double.MinValue;
            LowestGrade = double.MaxValue;
            Sum = 0.0;
            Count = 0;
        }
    }
}