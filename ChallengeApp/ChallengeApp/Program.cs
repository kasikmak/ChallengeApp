using ChallengeApp;
using System;

var employee1 = new Employee("A", "Z");
var employee2 = new Employee("Kasia", "Kowalska");
var employee3 = new Employee("X", "Y");

employee1.AddGrades(2);
employee1.AddGrades(5);
employee1.AddGrades(9);
employee1.AddGrades(6);
employee1.AddGrades(8);

employee2.AddGrades(9);
employee2.AddGrades(1);
employee2.AddGrades(3);
employee2.AddGrades(6);
employee2.AddGrades(7);

employee3.AddGrades(3);
employee3.AddGrades(8);
employee3.AddGrades(1);
employee3.AddGrades(7);
employee3.AddGrades(4);

var statistics1 = employee1.GetStatistics();
var statistics2 = employee2.GetStatistics();
var statistics3 = employee3.GetStatistics();

Console.WriteLine($"Employee1:\nAverage {statistics1.Average:N2}\nMax {statistics1.Max}\nMin {statistics1.Min}");
Console.WriteLine($"Employee2:\nAverage {statistics2.Average:N2}\nMax {statistics2.Max}\nMin {statistics2.Min}");
Console.WriteLine($"Employee3:\nAverage {statistics3.Average:N2}\nMax {statistics3.Max}\nMin {statistics3.Min}");

