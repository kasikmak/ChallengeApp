using ChallengeApp;
using System;
using System.Collections.Generic;
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
            if(grades >= 0 && grades <=100)
            {
                this.grades.Add(grades);
            }
            else
            {
                Console.WriteLine("Invalid grade value");   
            }
        }

        public void AddGrades(string grades)
        {
            if(float.TryParse(grades, out float result))
            {
                this.AddGrades(result);
            }
            else
            {
                Console.WriteLine("String is not a float");
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

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Min = float.MaxValue;
            statistics.Max = float.MinValue;

            foreach(var grade in this.grades)
            {
                statistics.Min = Math.Min(statistics.Min, grade);
                statistics.Max = Math.Max(statistics.Max, grade);
                statistics.Average += grade;
            }
            statistics.Average /= grades.Count;

            return statistics;
        }
      
    }
}