using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{ 
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower + ((horsepower * 50) / 100), acceleration, suspension - ((suspension * 25) / 100), durability)
    {
        this.addOns = new List<string>();
    }

    public IReadOnlyList<string> AddOns { get { return this.addOns.AsReadOnly(); } }

    public override void Upgrade(int tuneIndex, string addOn)
    {
        base.Horsepower += tuneIndex;
        base.Suspension += ((tuneIndex * 50) / 100);
        this.addOns.Add(addOn);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        if (this.addOns.Count != 0)
        {
            sb.AppendLine($"Add-ons: {string.Join(", ", this.addOns)}");
        }
        else
        {
            sb.AppendLine("Add-ons: None");
        }

        return sb.ToString().Trim();
    }
}
