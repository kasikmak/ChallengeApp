using ChallengeApp;
using System;

var employee1 = new Employee("Jan", "Nowak");
var employee2 = new Employee("Kasia", "Kowalska");
var employee3 = new Employee("X", "Y");
var employee4 = new Employee("A", "Z");

employee1.AddGrades(2000f);
employee1.AddGrades("4");
employee1.AddGrades("nine");
employee1.AddGrades(60m);
employee1.AddGrades(8.99);
employee1.AddGrades(100L);

employee2.AddGrades(9);
employee2.AddGrades(1);
employee2.AddGrades(3);
employee2.AddGrades(6);
employee2.AddGrades(-7);

employee3.AddGrades(3);
employee3.AddGrades(8);
employee3.AddGrades(1);
employee3.AddGrades(7);
employee3.AddGrades(4);

employee4.AddGrades(9);
employee4.AddGrades(1.2);
employee4.AddGrades("2.8");
employee4.AddGrades(102L);
employee4.AddGrades(5.99);

var statistics1 = employee1.GetStatisticsWithForeach();
var statistics2 = employee2.GetStatisticsWithFor();
var statistics3 = employee3.GetStatisticsWithDoWhile();
var statistics4 = employee4.GetStatisticsWithWhile();

Console.WriteLine($"Foreach:\nEmployee1:\nAverage {statistics1.Average:N2}\nMax {statistics1.Max}\nMin {statistics1.Min}");
Console.WriteLine($"For:\nEmployee2:\nAverage {statistics2.Average:N2}\nMax {statistics2.Max}\nMin {statistics2.Min}");
Console.WriteLine($"DoWhile:\nEmployee3:\nAverage {statistics3.Average:N2}\nMax {statistics3.Max}\nMin {statistics3.Min}");
Console.WriteLine($"While:\nEmployee4:\nAverage {statistics4.Average:N2}\nMax {statistics4.Max}\nMin {statistics4.Min}");

