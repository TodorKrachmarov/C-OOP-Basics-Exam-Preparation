public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity) : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity { get; protected set; }

    public override string ToString()
    {
        return $"Fire Monument: {base.Name}, Fire Affinity: {this.FireAffinity}";
    }

    public override int GetAffinity()
    {
        return this.FireAffinity;
    }
}
