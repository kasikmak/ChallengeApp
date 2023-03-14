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

        public override event GradeAddedDelegate GradeAdded;

        public override event GreatScoreDelegate GreatScore;

        private List<float> grades = new List<float>();

        public override void AddGrades(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
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
                case 'A' or 'a':
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
                case 'E' or 'e':
                    this.grades.Add(20);
                    break;
                default:
                    throw new Exception("Wrong letter");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }

        public override void ShowStaticstics()
        {
            var stat = GetStatistics();
            if (stat != null)
            {
                Console.WriteLine($"Employee's score {Name} {Surname}:\nAverage {stat.Average:N2}\nMax {stat.Max}\nMin {stat.Min}\nAverage as letter: {stat.Letter}\n----------------------------------------------");
                if(stat.Letter == 'A')
                {
                    GreatScoreEvent();                }
                }
            else
            {
                Console.WriteLine($"No grades entered for {Name} {Surname}");
            }
        }

        private void GreatScoreEvent()
        {
            if (GreatScore != null)
            {
                GreatScore(this, new EventArgs());
            }
        }
    }
}
