var name = "Kasia";
var age = 29;
bool women = true;

if (women == true)
{
    if (age == 33 && name == "Ewa")
    {
        Console.WriteLine("Ewa, lat 33");
    }
    else if (age < 30)
    {
        Console.WriteLine("KObieta poniżej 30 lat");
    }
}
else
{
    if (age < 18)
    {
        Console.WriteLine("Niepełnoletni mężczyzna");
    }
}
