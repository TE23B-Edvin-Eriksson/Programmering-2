public class Tamagotchi
{
    private int hunger = 10;
    private int boredom = 10;
    private List<string> words = [];
    private List<string> Games = ["You play Fetch with", "You play cards with", "You start dancing with",];
    private List<string> Food = ["You give chicken nuggets to", "You give Pineapple to", "You give a hamburger to",];
    public string name = "";

    public void Start()
    {
        GetAlive();
    }

    public void Tick()
    {
        hunger--;
        boredom++;
    }

    public void Feed()
    {
        hunger++;
        int r = Random.Shared.Next(0, 3);
        Console.WriteLine($"{Food[r]}" + $"{name}");
        Thread.Sleep(2000);
    }

    public void Play()
    {
        boredom--;
        int r = Random.Shared.Next(0, 3);
        Console.WriteLine($"{Games[r]}" + $"{name}");
        Thread.Sleep(2000);
    }


    public void Teach()
    {
        Console.WriteLine($"What word do you want to teach {name}");
        words.Add(Console.ReadLine());
        Thread.Sleep(1000);
        Console.WriteLine($"You have taught {name} {words.Last()}!");
        Thread.Sleep(1000);
    }

    public void Printstats()
    {
        Console.WriteLine($"Boredom: {boredom}, hunger:{hunger}");
        Thread.Sleep(1000);
    }

    public bool GetAlive()
    {
        return IsAlive();
    }

    public bool IsAlive()
    {
        if (hunger < 0 || boredom < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}