public class Enemy
{
    public int Hp;
    public int Damage;
    public float X;
    public string Name;

        public void TakeDamage(int amount)
    {
        Hp -= amount;
        if (Hp < 0) Hp = 0;
        Console.WriteLine($"{Name} tog {amount} skada! HP kvar: {Hp}");
    }
}