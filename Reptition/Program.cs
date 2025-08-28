

static void Fight()
{


int p1Hp = 100;
int p2Hp = 100;

string p1Name = "";
string p2Name = "";

Console.Write("Ange namn på spelare 1: ");
p1Name = Console.ReadLine() ?? "Spelare 1";
Console.Write("Ange namn på spelare 2: ");
p2Name = Console.ReadLine() ?? "Spelare 2";
while (p1Hp > 0 && p2Hp > 0)
{
    Console.WriteLine($"{p1Name}: {p1Hp}");
    Console.WriteLine($"{p2Name}: {p2Hp}");
    p2Hp -= Random.Shared.Next(10, 25); // Alex slår Calin
    p1Hp -= Random.Shared.Next(10, 25); // Calin slår Alex
    Console.ReadLine();
}

if (p1Hp > 0)
{
  Console.WriteLine($"{p1Name} vann!");
}
else if (p1Hp <= 0 && p2Hp <= 0)
{
  Console.WriteLine("Oavgjort!");
}
else
{
  Console.WriteLine($"{p2Name} vann!");
}

Console.ReadLine();
}