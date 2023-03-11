using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
    public class EmpolyeeInMemory : EmployeeBase
    {
        public EmpolyeeInMemory(string name, string surname)
            : base(name, surname)
        {
        }

        private List<float> grades = new List<float>();

        public override void AddGrades(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new Exception("Invalid grade value");
            }
        }

        public override void AddGrades(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                this.AddGrades(result);
            }
            else if (char.TryParse(grade, out char Letter))
            {
                this.AddGrades(Letter);
            }
            else
            {
                throw new Exception("String is not a float");
            }
        }

        public override void AddGrades(double grade)
        {
            var DoubleAsFloat = (float)grade;
            this.AddGrades(DoubleAsFloat);
        }

        public override void AddGrades(long grade)
        {
            var LongAsFloat = (float)grade;
            this.AddGrades(LongAsFloat);
        }

        public override void AddGrades(char grade)
        {
            switch (grade)
            {
                case 'A'or 'a':
                    this.grades.Add(100);
                    break;
                case 'B' or 'b':
                    this.grades.Add(80);
                    break;
                case 'C' or 'c':
                    this.grades.Add(60);
                    break;
                case 'D' or 'd':
                    this.grades.Add(40);
                    break;
                case 'E' or'e':
                    this.grades.Add(20);
                    break;
                default:
                    throw new Exception("Wrong letter");
            }
        }

        public override Statistics GetStatistics()
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
