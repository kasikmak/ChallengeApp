using ChallengeApp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
    public class Employee
    {
        public Employee(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        private List<float> grades = new List<float>();

        public void AddGrades(float grades)
        {
            if (grades >= 0 && grades <= 100)
            {
                this.grades.Add(grades);
            }
            else
            {
                Console.WriteLine(grades + " " + "Invalid grade value");
            }
        }

        public void AddGrades(string grades)
        {
            if (float.TryParse(grades, out float result))
            {
                this.AddGrades(result);
            }
            else
            {
                Console.WriteLine(result + " " + "String is not a float");
            }
        }

        public void AddGrades(double grades)
        {
            var DoubleAsFloat = (float)grades;
            this.AddGrades(DoubleAsFloat);
        }

        public void AddGrades(decimal grades)
        {
            var DecimalAsFloat = (float)grades;
            this.AddGrades(DecimalAsFloat);
        }

        public void AddGrades(long grades)
        {
            var LongAsFloat = (float)grades;
            this.AddGrades(LongAsFloat);
        }

        public Statistics GetStatisticsWithForeach()
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Min = float.MaxValue;
            statistics.Max = float.MinValue;

            foreach (var grade in this.grades)
            {
                statistics.Min = Math.Min(statistics.Min, grade);
                statistics.Max = Math.Max(statistics.Max, grade);
                statistics.Average += grade;
            }
            statistics.Average /= grades.Count;

            return statistics;
        }

        public Statistics GetStatisticsWithFor()
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Min = float.MaxValue;
            statistics.Max = float.MinValue;

            for (int i = 0; i < grades.Count; i++)
            {
                statistics.Min = Math.Min(statistics.Min, grades[i]);
                statistics.Max = Math.Max(statistics.Max, grades[i]);
                statistics.Average += grades[i];
            }
            statistics.Average /= grades.Count;

            return statistics;
        }

        public Statistics GetStatisticsWithDoWhile()
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Min = float.MaxValue;
            statistics.Max = float.MinValue;

            var i = 0;

            do
            {
                statistics.Min = Math.Min(statistics.Min, grades[i]);
                statistics.Max = Math.Max(statistics.Max, grades[i]);
                statistics.Average += grades[i];
                i++;
            } while (i < grades.Count);

            return statistics;
        }

        public Statistics GetStatisticsWithWhile()
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Min = float.MaxValue;
            statistics.Max = float.MinValue;

            var i = 0;

            while (i < grades.Count)
            {
                statistics.Min = Math.Min(statistics.Min, grades[i]);
                statistics.Max = Math.Max(statistics.Max, grades[i]);
                statistics.Average += grades[i];
                i++;
            }

            return statistics;
        }
    }
}