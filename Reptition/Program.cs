

static void Fight()
{


  int p1Hp = 100;
  int p2Hp = 100;
  string p1Name = "";
  string p2Name = "";
  string svar;
  bool p1namnchecker = true;
  bool p2namnchecker = true;
  while (p1namnchecker == true)
  {
    Console.Write("Ange namn på spelare 1: ");
    p1Name = Console.ReadLine() ?? "Spelare 1";
    if (string.IsNullOrWhiteSpace(p1Name))
    {
      Console.WriteLine("Du måste skriva ett namn för p1");
    }
    else
    {
      p1namnchecker = false;
    }
  }
  while (p2namnchecker == true)
  {
    Console.Write("Ange namn på spelare 2: ");
    p2Name = Console.ReadLine() ?? "Spelare 2";
    if (string.IsNullOrWhiteSpace(p2Name))
    {
      Console.WriteLine("Du måste skriva ett namn för p2");
    }
    else
    {
      p2namnchecker = false;
    }
  }
  while (p1Hp > 0 && p2Hp > 0)
  {
    Console.WriteLine($"{p1Name}: {p1Hp}");
    Console.WriteLine($"{p2Name}: {p2Hp}");
    p2Hp -= Random.Shared.Next(10, 25); // p1 slår p2
    p1Hp -= Random.Shared.Next(10, 25); // p2 slår p1
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

  bool restart = true;
  while (restart == true)
  {
    Console.WriteLine("Vill du köra igen?");
    Console.WriteLine("1 = Ja  2 = Nej");

    int resultat;
    svar = Console.ReadLine();
    bool lyckad = int.TryParse(svar, out resultat);

    if (resultat == 1)
    {
      p1Hp = 100;
      p2Hp = 100;
      Fight();
    }
    else if (resultat == 2)
    {
      restart = false;
    }
    else
    {
      Console.WriteLine("Det där var ingen av alternativen!");
    }

  }

}

Fight();