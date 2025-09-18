public class Weapon
{
    public int Durability;
    public int Damage;
    public string Name;
    public void TakeDurability(int amount)
    {
        Durability -= amount;
        if (Durability < 0) Durability = 0;
        Console.WriteLine($"{Name}et tog såhär mycket damage {amount} vapnet har bara så här mycket durability kvar {Durability}");
    }
}