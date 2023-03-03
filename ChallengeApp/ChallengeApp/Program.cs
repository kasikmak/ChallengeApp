using ChallengeApp;
using System;

Console.WriteLine("Witamy w programie do oceny pracowników");
Console.WriteLine("---------------------------------------");
Console.WriteLine();

var employee = new Employee();

while (true)
{
    Console.WriteLine("Podaj ocenę pracownika w zakresie 0-100 lub A-E. Zakończ ocenianie wpisując q");
    var input = Console.ReadLine();
    if (input == "q")
    {
        break;
    }
    employee.AddGrades(input);
}   

var statistics1 = employee.GetStatistics();

Console.WriteLine("---------------------------------------");
Console.WriteLine($"Ocena pracownika:\nAverage {statistics1.Average:N2}\nMax {statistics1.Max}\nMin {statistics1.Min}\nOcena literowa: {statistics1.Letter}");