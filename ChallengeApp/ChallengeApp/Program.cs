using ChallengeApp;
using System;
Employee employee1 = new Employee("Jan", "Nowak", 30);
Employee employee2 = new Employee("Kasia", "Kowalska", 40);
Employee employee3 = new Employee("X", "Y", 50);

employee1.AddPoints(2);
employee1.AddPoints(5);
employee1.AddPoints(9);
employee1.AddPoints(1);
employee1.AddPoints(8);

employee2.AddPoints(9);
employee2.AddPoints(1);
employee2.AddPoints(3);
employee2.AddPoints(6);
employee2.AddPoints(7);

employee3.AddPoints(3);
employee3.AddPoints(8);
employee3.AddPoints(1);
employee3.AddPoints(7);
employee3.AddPoints(4);

List<Employee> employees = new List<Employee>()
 {
    employee1, employee2, employee3
 };

/*int maxResult = 0;
Employee bestEmployee = null;

foreach (var employee in employees)
{
    if (maxResult < employee.Result)
    {
        maxResult = employee.Result;
        bestEmployee = employee;
    }
}*/

List<int> employeesResults = new List<int>(); 

foreach (var employee in employees)
{
    employeesResults.Add(employee.Result);
}

int maXResult = employeesResults.Max();
Employee bestEmployee = null;

foreach (var employee in employees)
{
    if (employee.Result == maXResult)
    {
        bestEmployee = employee;    
    }
}

Console.WriteLine("Pracownik z największą liczbą punktów to: \n" + bestEmployee.Name + " " + bestEmployee.Surname + " lat " + bestEmployee.Age + " \nWynik: " + bestEmployee.Result);


