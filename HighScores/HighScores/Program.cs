List<string> names = ["Micke", "Martin"];
names.Add("Karim");

Console.WriteLine("Skriv namnet på en lärare");
string teacher = Console.ReadLine();
names.Add(teacher);

Console.Clear();

foreach (string name in names)
{
    Console.WriteLine(name);
}

Console.ReadLine();