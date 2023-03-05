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

        public Employee()
        {

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
                throw new Exception("Invalid grade value");
            }
        }

        public void AddGrades(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                this.AddGrades(result);
            }
            else if(char.TryParse(grade, out char Letter))
            {
                this.AddGrades(Letter);
            }
            else
            {
                throw new Exception("String is not a float");
            }
        }

        public void AddGrades(double grade)
        {
            var DoubleAsFloat = (float)grade;
            this.AddGrades(DoubleAsFloat);
        }

        public void AddGrades(decimal grade)
        {
            var DecimalAsFloat = (float)grade;
            this.AddGrades(DecimalAsFloat);
        }

        public void AddGrades(long grade)
        {
            var LongAsFloat = (float)grade;
            this.AddGrades(LongAsFloat);
        }

        public void AddGrades(char grade)
        {
            switch (grade)
            {
                case 'A':
                case 'a':
                    this.grades.Add(100);
                    break;
                case 'B':
                case 'b':
                    this.grades.Add(80);
                    break;
                case 'C':
                case 'c':
                    this.grades.Add(60);
                    break;
                case 'D':
                case 'd':
                    this.grades.Add(40);
                    break;
                case 'E':
                case 'e':
                    this.grades.Add(20);
                    break;
                default:
                    throw new Exception("Wrong letter");
            }
        }

        public Statistics GetStatistics()
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

            switch (statistics.Average)
            {
                case var average when average  >= 80:
                        statistics.Letter = 'A';
                    break;
                case var average when average >= 60:
                    statistics.Letter = 'B';
                    break;
                case var average when average >= 40:
                    statistics.Letter = 'C';
                    break;
                case var average when average >= 20:
                    statistics.Letter = 'D';
                    break;
                default:               
                    statistics.Letter = 'E';
                    break;
            }

            return statistics;
        }
    }
}