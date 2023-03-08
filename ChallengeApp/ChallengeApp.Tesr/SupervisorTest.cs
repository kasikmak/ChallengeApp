using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp.Test
{
    public class SupervisorTest
    {

        [Test]
        public void AddingGradesForSupervisor()
        {
            var supervisor = new Supervisor("x", "Y", 'x');
            supervisor.AddGrades("-6");
            supervisor.AddGrades("4");
            supervisor.AddGrades("2+");

            var statisctics = supervisor.GetStatistics();

            Assert.AreEqual(60, statisctics.Average);
        }
        
        
    }
}
