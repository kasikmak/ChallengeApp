namespace ChallengeApp.Test
{
    public class EmployeeTests
    {
        [Test]
        public void CorrectStatisticsAverage()
        {
            var employee = new Employee("Kasia", "Kowalska");
            employee.AddGrades(5);
            employee.AddGrades(3);
            employee.AddGrades(4);

            var statistics = employee.GetStatistics();

            Assert.AreEqual(4, statistics.Average);
        }

        [Test]
        public void CorrectStatisticsMin()
        {
            var employee = new Employee("Kasia", "Kowalska");
            employee.AddGrades(5);
            employee.AddGrades(3);
            employee.AddGrades(4);

            var statistics = employee.GetStatistics();

            Assert.AreEqual(3, statistics.Min);
        }

        [Test]
        public void CorrectStatisticsMax()
        {
            var employee = new Employee("Kasia", "Kowalska");
            employee.AddGrades(5);
            employee.AddGrades(3);
            employee.AddGrades(4);

            var statistics = employee.GetStatistics();

            Assert.AreEqual(5, statistics.Max);
        }

        [Test]
        public void CorrectGradeIfGivingLetter()
        {
            var employee = new Employee("k", "k");
            employee.AddGrades("a");
            employee.AddGrades("d");

            var statistics = employee.GetStatistics();

            Assert.AreEqual(70, statistics.Average);


        }

        [Test]
        public void CorrectAverageGradeAsLetter()
        {
            var employee = new Employee("x", "y");
            employee.AddGrades(50);
            employee.AddGrades(20);

            var statistics = employee.GetStatistics();

            Assert.AreEqual('D', statistics.Letter);
        }
    }
}

