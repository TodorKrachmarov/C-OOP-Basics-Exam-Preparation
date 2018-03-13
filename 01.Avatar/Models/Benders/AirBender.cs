public class AirBender : Bender
{
    public AirBender(string name, int power, double aerialIntegrity) : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity { get; protected set; }

    

    public override string ToString()
    {
        return $"Air Bender: {base.Name}, Power: {base.Power}, Aerial Integrity: {this.AerialIntegrity:F2}";
    }

    public override double GetTotalPower()
    {
        return base.Power * this.AerialIntegrity;
    }
}
