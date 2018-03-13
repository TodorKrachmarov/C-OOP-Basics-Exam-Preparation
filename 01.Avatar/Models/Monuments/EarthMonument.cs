public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity) : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    public int EarthAffinity { get; protected set; }

    public override string ToString()
    {
        return $"Earth Monument: {base.Name}, Earth Affinity: {this.EarthAffinity}";
    }

    public override int GetAffinity()
    {
        return this.EarthAffinity;
    }
}
