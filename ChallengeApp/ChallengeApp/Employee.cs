using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
    public class Employee
    {
        public Employee(string name, string surname, int age)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }

        public Employee(string name)
        {
            this.Name = name; 
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public int Age { get; private set; }

        private List<int> points = new List<int>();


    public void AddPoints(int points)
        {
            this.points.Add(points);
        }

        public int Result
        {
            get
            {
                return this.points.Sum();
            }

        }
    }
}
