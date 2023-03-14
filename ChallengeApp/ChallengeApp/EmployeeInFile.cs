using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
    internal class EmployeeInFile : EmployeeBase
    {

        private const string fileName = "grades.txt";
        private string fileNameWithUSerName;

        public EmployeeInFile
            (string name, string surname)
            : base(name, surname)
        {
            fileNameWithUSerName = $"{name}_{surname}_{fileName}.txt";
        }

        public override event GradeAddedDelegate GradeAdded;

        public override event GreatScoreDelegate GreatScore;

        public override void AddGrades(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                using (var writer = File.AppendText(fileNameWithUSerName))
                {
                    writer.WriteLine(grade);
                }
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
            var statistics = this.GetStatistics(gradesFromFile);
            return statistics;
        }

        private List<float> ReadGradesFromFile()
        {
            var grade = new List<float>();
            if (File.Exists(fileNameWithUSerName))
            {
                using (var reader = File.OpenText(fileNameWithUSerName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        grade.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grade;  
        }

        private Statistics GetStatistics(List<float> grades)
        {

            var statistics = new Statistics();
        

            foreach (var grade in grades)
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
                Console.WriteLine($"Ocena pracownika {Name} {Surname}:\nAverage {stat.Average:N2}\nMax {stat.Max}\nMin {stat.Min}\nOcena literowa: {stat.Letter}");
            }
            else
            {
                Console.WriteLine($"Brak ocen dla prcownika {Name} {Surname}");
            }
        }
    }
}
