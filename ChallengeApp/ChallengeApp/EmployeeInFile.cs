using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
    internal class EmployeeInFile : EmployeeBase
    {
        public EmployeeInFile
            (string name, string surname)
            : base(name, surname)
        {
        }

        private const string fileName = "grades.txt";

        public override void AddGrades(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
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
            var DecimalAsFloat = (float)grade;
            this.AddGrades(DecimalAsFloat);
        }

        public override void AddGrades(char grade)
        {
            switch (grade)
            {
                case 'A' or 'a':
                    this.AddGrades((float)100);
                    break;
                case 'B' or 'b':
                    this.AddGrades((float)80);
                    break;
                case 'C' or 'c':
                    this.AddGrades((float)60);
                    break;
                case 'D' or 'd':
                    this.AddGrades((float)40);
                    break;
                case 'E' or 'e':
                    this.AddGrades((float)20);
                    break;
                default:
                    throw new Exception("Wrong letter");
            }
        }

        public override Statistics GetStatistics()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var statistics = this.CountStatistics(gradesFromFile);
            return statistics;
        }

        private List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;  
        }

        private Statistics CountStatistics(List<float> grades)
        {

            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Min = float.MaxValue;
            statistics.Max = float.MinValue;

            foreach (var grade in grades)
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
