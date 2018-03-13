public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression { get; protected set; }

    public override string ToString()
    {
        return $"Fire Bender: {base.Name}, Power: {base.Power}, Heat Aggression: {this.HeatAggression:F2}";
    }

    public override double GetTotalPower()
    {
        return base.Power * this.HeatAggression;
    }
}
