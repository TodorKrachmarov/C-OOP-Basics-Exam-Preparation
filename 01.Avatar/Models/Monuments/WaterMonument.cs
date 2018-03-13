public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity { get; protected set; }

    public override string ToString()
    {
        return $"Water Monument: {base.Name}, Water Affinity: {this.WaterAffinity}";
    }

    public override int GetAffinity()
    {
        return this.WaterAffinity;
    }
}
