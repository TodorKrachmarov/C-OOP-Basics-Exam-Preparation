using System.Collections.Generic;

public class Garage
{
    private List<int> parkedCars;

    public Garage()
    {
        this.parkedCars = new List<int>();
    }

    public IReadOnlyList<int> ParkedCars { get { return this.parkedCars.AsReadOnly(); } }

    public void Add(int id)
    {
        this.parkedCars.Add(id);
    }

    public void Remove(int id)
    {
        this.parkedCars.Remove(id);
    }
}
