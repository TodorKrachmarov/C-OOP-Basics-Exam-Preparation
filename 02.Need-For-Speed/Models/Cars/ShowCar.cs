using System.Text;

public class ShowCar : Car
{
    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
    }

    public int Stars { get; protected set; }

    public override void Upgrade(int tuneIndex, string addOn)
    {
        base.Horsepower += tuneIndex;
        base.Suspension += ((tuneIndex * 50) / 100);
        this.Stars += tuneIndex;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"{this.Stars} *");

        return sb.ToString().Trim();
    }
}
