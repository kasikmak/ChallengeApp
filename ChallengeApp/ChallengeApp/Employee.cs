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
            this.grades.Add(grades);
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