public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation) : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation { get; protected set; }

    public override string ToString()
    {
        return $"Earth Bender: {base.Name}, Power: {base.Power}, Ground Saturation: {this.GroundSaturation:F2}";
    }

    public override double GetTotalPower()
    {
        return base.Power * this.GroundSaturation;
    }
}
