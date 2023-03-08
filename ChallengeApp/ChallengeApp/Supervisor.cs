using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
    public class Supervisor : IEmployee
    {
        public Supervisor(string name, string surname, char sex)
        {
            this.Name = name;
            this.Surname = surname;
            this.Sex = sex;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public char Sex { get; private set; }

        private List<float> grades = new List<float>();

        public void AddGrades(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new Exception("Invalid grade value");
            }
        }

        public void AddGrades(string grade)
        {
            switch (grade)
            {
                case "6":
                    this.grades.Add(100);
                    break;
                case "6-" or "-6":
                    this.grades.Add(95);
                    break;
                case "5+" or "+5":
                    this.grades.Add(85);
                    break;
                case "5":
                    this.grades.Add(80);
                    break;
                case "-5" or "5-":
                    this.grades.Add(75);
                    break;
                case "4+" or "+4":
                    this.grades.Add(65);
                    break;
                case "4":
                    this.grades.Add(60);
                    break;
                case "4-" or "-4":
                    this.grades.Add(55);
                    break;
                case "3+" or "+3":
                    this.grades.Add(45);
                    break;  
                case "3":
                    this.grades.Add(40);
                    break;
                case "3-" or "-3":
                    this.grades.Add(35);
                    break;
                case "2+" or "+2":
                    this.grades.Add(25);
                    break;
                case "2":
                    this.grades.Add(20);
                    break;
                case "-2" or "2-":
                    this.grades.Add(15);
                    break;
                case "1":
                    this.grades.Add(0);
                    break;
                default:
                    throw new Exception("Wrong number");
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
                case var average when average >= 80:
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