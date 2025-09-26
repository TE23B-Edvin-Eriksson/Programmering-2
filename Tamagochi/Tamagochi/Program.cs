using System.Formats.Asn1;

Console.WriteLine("Welcome to Tamagotchi");

Tamagotchi tama = new();
tama.Start();

Console.WriteLine("Write the name of your Pet");
tama.name = Console.ReadLine();

while (tama.GetAlive() == true)
{
    Console.Clear();
    tama.Printstats();
    Console.WriteLine($"What do you want to do?");
    Console.WriteLine($"1. Feed {tama.name}");
    Console.WriteLine($"2. Play with {tama.name}");
    Console.WriteLine($"3. Teach {tama.name} a word");
    Console.WriteLine($"4.PrintStats");
    Console.WriteLine($"5. Do Nothing");

    string answer = Console.ReadLine();

    if (answer == "1")
    {
        tama.Feed();
    }
    else if (answer == "2")
    {
        tama.Play();
    }
    else if (answer == "3")
    {
        tama.Teach();
    }
    else if (answer == "4")
    {
        tama.Printstats();
    }
    else if (answer == "5")
    {

    }
    else
    {

    }
    tama.Tick();

}

Console.ReadLine();