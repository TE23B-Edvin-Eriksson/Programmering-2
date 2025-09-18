static void Main()
{
    Weapon sword = new()
    {
        Name = "Svärd",
        Durability = 300,
        Damage = 15
    };

    Enemy eddi = new()
    {
        Name = "Eddi",
        Hp = 100,
        Damage = 5
    };

    Enemy gustav = new()
    {
        Name = "Gustav",
        Hp = 100,
        Damage = 5
    };

    Console.WriteLine("Välj fiende att attackera: (1) Eddi eller (2) Gustav");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        eddi.TakeDamage(sword.Damage);
        sword.TakeDurability(sword.Durability);
    }
    else if (choice == "2")
    {
        gustav.TakeDamage(sword.Damage);
    }
    else
    {
        Console.WriteLine("Ogiltigt val!");
    }
    Console.ReadLine();
}

Main();