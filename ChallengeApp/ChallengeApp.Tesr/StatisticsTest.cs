namespace ChallengeApp.Test
{
    public class StatisticsTests
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
    }
}

