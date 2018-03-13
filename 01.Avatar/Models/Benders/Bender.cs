public abstract class Bender
{
    public Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name { get; protected set; }

    public int Power { get; protected set; }

    public abstract double GetTotalPower();
}
