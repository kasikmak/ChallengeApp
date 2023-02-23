

namespace ChallengeApp.Test
{
    public class TypeTests
    {
        [Test]
        public void RefrenceTypeTest()
        {
            var employee1 = GetEmployee ("Kasia");
            var employee2 = GetEmployee ("Kasia");

            Assert.AreNotEqual(employee1, employee2);
        }

        private Employee GetEmployee(string name)
        {
            return new Employee(name);
        }


        [Test]
        public void RefrenceTypeTest2()
        {
            var employee1 = GetEmployee("Kasia");
            var employee2 = GetEmployee("Kasia");

            Assert.AreEqual(employee1.Name, employee2.Name);
        }

        [Test]
        public void ValueTypeTest()
        {
            int points1 = 5;
            int points2 = 8;

            Assert.AreNotEqual(points1, points2);
        }

        [Test]
        public void ValueTypeTest2()
        {
            float number1 = 4.2f;
            float number2 = 9.8f;

            Assert.AreNotEqual(number2, number1);
        }
    }
}

