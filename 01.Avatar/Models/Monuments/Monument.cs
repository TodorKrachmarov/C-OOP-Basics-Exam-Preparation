public abstract class Monument
{
    public Monument(string name)
    {
        this.Name = name;
    }

    public string Name { get; protected set; }

    public abstract int GetAffinity();
}
