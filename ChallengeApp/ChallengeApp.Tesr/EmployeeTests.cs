using System.Reflection.Metadata;

namespace ChallengeApp.Tesr
{
    public class EmployyeTests
    {
       
        [Test]
        public void WhenEmployeeGetsPoints_ShouldCorrectResult()
        {
            var employee = new Employee("Kasia", "Kowalska", 35);
            employee.AddPoints(5);
            employee.AddPoints(3);
            employee.AddPoints(-4);

            var result = employee.Result;
                        
            Assert.AreEqual(4, result);
        }
    }
}