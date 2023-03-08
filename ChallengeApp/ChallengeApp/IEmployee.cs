using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
    public interface IEmployee
    {
        public string Name { get; }
        public string Surname { get; }
        public char Sex { get; }

        public void AddGrades(float grade);

        public void AddGrades(string grade);

        public void AddGrades(double grade);

        public void AddGrades(long grade);

        public void AddGrades(char grade);

        public Statistics GetStatistics();
    }
}
