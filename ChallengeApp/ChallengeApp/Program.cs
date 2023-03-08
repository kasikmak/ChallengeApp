using ChallengeApp;
using System;

Console.WriteLine("Witamy w programie do oceny pracowników");
Console.WriteLine("---------------------------------------");
Console.WriteLine();

var employee = new Employee("no name", "no surname", 'x');
var supervisor = new Supervisor("no name", "no surname", 'x');

while (true)
{
    Console.WriteLine("Podaj ocenę pracownika w zakresie 0-100 lub A-E. Zakończ ocenianie wpisując q");
    var input = Console.ReadLine();
    if (input == "q")
    {
        break;
    }

    try
    {
        employee.AddGrades(input);
    }
    catch (Exception e)
    {

        Console.WriteLine($"( {e.Message})"); ;
    }
}

while (true)
{
    Console.WriteLine("Podaj ocenę kierownika w zakresie 1-6 z + lub -. Zakończ ocenianie wpisując q");
    var input = Console.ReadLine();
    if (input == "q")
    {
        break;
    }

    try
    {
        supervisor.AddGrades(input);
    }
    catch (Exception e)
    {

        Console.WriteLine($"( {e.Message})"); ;
    }
}

var statistics1 = employee.GetStatistics();
var statistics2 = supervisor.GetStatistics();

Console.WriteLine("---------------------------------------");
Console.WriteLine($"Ocena pracownika:\nAverage {statistics1.Average:N2}\nMax {statistics1.Max}\nMin {statistics1.Min}\nOcena literowa: {statistics1.Letter}");
Console.WriteLine();
Console.WriteLine($"Ocena kierownika:\nAverage {statistics2.Average:N2}\nMax {statistics2.Max}\nMin {statistics2.Min}\nOcena literowa: {statistics2.Letter}");