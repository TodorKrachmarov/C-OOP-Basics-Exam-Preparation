public class AirMonument : Monument
{
    public AirMonument(string name, int airAffinity) : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity { get; protected set; }

    public override string ToString()
    {
        return $"Air Monument: {base.Name}, Air Affinity: {this.AirAffinity}";
    }

    public override int GetAffinity()
    {
        return this.AirAffinity;
    }
}
