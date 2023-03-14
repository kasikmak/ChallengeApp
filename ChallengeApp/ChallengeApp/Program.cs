using ChallengeApp;
using System;
using System.Runtime.CompilerServices;

Console.WriteLine("Welcome to aplication for grading employees");
Console.WriteLine("-------------------------------------------");

bool exit = false;

while (!exit)
{
    Console.WriteLine("You have to choose how to store data for each employee:");
    Console.WriteLine("In memory - 1");
    Console.WriteLine("In seprate file for each employee .txt - 2");
    Console.WriteLine("Exit aplication - X");
    var input = Console.ReadLine();
    switch (input)
    {
        case "1":
            AddGradesInMemory();
            break;
        case "2":
            AddGradesInFile();
            break;
        case "X" or "x":
            exit = true;
            break;
        default:
            Console.WriteLine("Wrong data. Enter 1, 2 lub X");
            break;
    }
}
    
void EmployeeGradeAdded(object sender, EventArgs args)
   {
        Console.WriteLine("Grade added");
   }

void EmployeeGreatScore(object sender, EventArgs args)
    {
    Console.WriteLine("Great score. Congratulation!");
    }

void AddGradesInMemory()
{
    Console.WriteLine("Enter employee's name");
    string name = Console.ReadLine();
    Console.WriteLine("Enter employee's surname");
    string surname = Console.ReadLine();
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var employeeInMemory = new EmpolyeeInMemory(name, surname);
        employeeInMemory.GradeAdded += EmployeeGradeAdded;
        EnterGrade(employeeInMemory);
        employeeInMemory.GetStatistics();
        employeeInMemory.ShowStaticstics();
        employeeInMemory.GreatScore += EmployeeGreatScore;
    }
    else
    {
        Console.WriteLine("You have to enter employee's name and surname");
    }
}

void AddGradesInFile()
{
    Console.WriteLine("Enter employee's name");
    string name = Console.ReadLine();
    Console.WriteLine("Enter employee's surname");
    string surname = Console.ReadLine();
    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var employeeInFile = new EmployeeInFile(name, surname);
        employeeInFile.GradeAdded += EmployeeGradeAdded;
        EnterGrade(employeeInFile);
        employeeInFile.GetStatistics();
        employeeInFile.ShowStaticstics();
    }
    else
    {
        Console.WriteLine("You have to enter employee's name and surname");
    }
}

static void EnterGrade(IEmployee employee)
{
    while (true)
    {
        Console.WriteLine($"Enter grade for: {employee.Name} {employee.Surname} between 0-100 or A-E. To finish enter q");
        var input = Console.ReadLine();

        if (input == "q" || input == "Q")
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

