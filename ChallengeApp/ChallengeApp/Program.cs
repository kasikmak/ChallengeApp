using ChallengeApp;
using System;

Console.WriteLine("Witamy w programie do oceny pracowników");
Console.WriteLine("---------------------------------------");

var employee = new EmployeeInFile("A", "B");
employee.AddGrades(0.5);
employee.AddGrades(2);
employee.AddGrades(5.5f);
employee.AddGrades('d');

//var supervisor = new Supervisor("Y", "Z");

while (true)
{
    Console.WriteLine("Podaj ocenę pracownika w zakresie 0-100 albo A-E. Zakończ ocenianie wpisując q");
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

/*while (true)
{
    Console.WriteLine("Podaj ocenę kierownika w zakresie 1-6 z + (+5pkt) lub - (-5pkt). Zakończ ocenianie wpisując q");
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
}*/

var statistics1 = employee.GetStatistics();
//var statistics2 = supervisor.GetStatistics();

Console.WriteLine("---------------------------------------");
Console.WriteLine($"Ocena pracownika:\nAverage {statistics1.Average:N2}\nMax {statistics1.Max}\nMin {statistics1.Min}\nOcena literowa: {statistics1.Letter}");
Console.WriteLine();
//Console.WriteLine($"Ocena kierownika:\nAverage {statistics2.Average:N2}\nMax {statistics2.Max}\nMin {statistics2.Min}\nOcena literowa: {statistics2.Letter}");