using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private List<Bender> airBenders;
    private List<Monument> airMonuments;
    private List<Bender> fireBenders;
    private List<Monument> fireMonuments;
    private List<Bender> waterBenders;
    private List<Monument> waterMonuments;
    private List<Bender> earthBenders;
    private List<Monument> earthMonuments;
    private List<string> warRecords;

    public NationsBuilder()
    {
        this.airBenders = new List<Bender>();
        this.airMonuments = new List<Monument>();
        this.fireBenders = new List<Bender>();
        this.fireMonuments = new List<Monument>();
        this.waterBenders = new List<Bender>();
        this.waterMonuments = new List<Monument>();
        this.earthBenders = new List<Bender>();
        this.earthMonuments = new List<Monument>();
        this.warRecords = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double spetialPower = double.Parse(benderArgs[3]);

        switch (type.ToLower())
        {
            case "air":
                this.airBenders.Add(new AirBender(name,power,spetialPower));
                break;
            case "water":
                this.waterBenders.Add(new WaterBender(name, power, spetialPower));
                break;
            case "fire":
                this.fireBenders.Add(new FireBender(name, power, spetialPower));
                break;
            case "earth":
                this.earthBenders.Add(new EarthBender(name, power, spetialPower));
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        switch (type.ToLower())
        {
            case "air":
                this.airMonuments.Add(new AirMonument(name, affinity));
                break;
            case "water":
                this.waterMonuments.Add(new WaterMonument(name, affinity));
                break;
            case "fire":
                this.fireMonuments.Add(new FireMonument(name, affinity));
                break;
            case "earth":
                this.earthMonuments.Add(new EarthMonument(name, affinity));
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        string result = string.Empty;

        switch (nationsType.ToLower())
        {
            case "air":
                result = StatusGetter(this.airBenders, this.airMonuments, nationsType);
                break;
            case "water":
                result = StatusGetter(this.waterBenders, this.waterMonuments, nationsType);
                break;
            case "fire":
                result = StatusGetter(this.fireBenders, this.fireMonuments, nationsType);
                break;
            case "earth":
                result = StatusGetter(this.earthBenders, this.earthMonuments, nationsType);
                break;
        }

        return result;
    }

    private string StatusGetter(List<Bender> benders, List<Monument> monuments, string nationsType)
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"{nationsType} Nation");
        if (benders.Count != 0)
        {
            result.AppendLine("Benders:");
            foreach (var bender in benders)
            {
                result.AppendLine($"###{bender}");
            }
        }
        else
        {
            result.AppendLine("Benders: None");
        }
        if (monuments.Count != 0)
        {
            result.AppendLine("Monuments:");
            foreach (var monument in monuments)
            {
                result.AppendLine($"###{monument}");
            }
        }
        else
        {
            result.AppendLine("Monuments: None");
        }

        return result.ToString().Trim();
    }

    public void IssueWar(string nationsType)
    {
        this.warRecords.Add(nationsType);

        double airNationPower = GetNationPower(this.airBenders, this.airMonuments);
        double fireNationPower = GetNationPower(this.fireBenders, this.fireMonuments);
        double waterNationPower = GetNationPower(this.waterBenders, this.waterMonuments);
        double earthNationPower = GetNationPower(this.earthBenders, this.earthMonuments);

        if (airNationPower > fireNationPower && airNationPower > waterNationPower && airNationPower > earthNationPower)
        {
            this.fireBenders.Clear();
            this.fireMonuments.Clear();
            this.waterBenders.Clear();
            this.waterMonuments.Clear();
            this.earthBenders.Clear();
            this.earthMonuments.Clear();
        }
        else if (fireNationPower > airNationPower && fireNationPower > waterNationPower && fireNationPower > earthNationPower)
        {
            this.airBenders.Clear();
            this.airMonuments.Clear();
            this.waterBenders.Clear();
            this.waterMonuments.Clear();
            this.earthBenders.Clear();
            this.earthMonuments.Clear();
        }
        else if (waterNationPower > fireNationPower && waterNationPower > airNationPower && waterNationPower > earthNationPower)
        {
            this.fireBenders.Clear();
            this.fireMonuments.Clear();
            this.airBenders.Clear();
            this.airMonuments.Clear();
            this.earthBenders.Clear();
            this.earthMonuments.Clear();
        }
        else if (earthNationPower > airNationPower && earthNationPower > fireNationPower && earthNationPower > waterNationPower)
        {
            this.airBenders.Clear();
            this.airMonuments.Clear();
            this.fireBenders.Clear();
            this.fireMonuments.Clear();
            this.waterBenders.Clear();
            this.waterMonuments.Clear();
        }
    }

    private double GetNationPower(List<Bender> benders, List<Monument> monuments)
    {
        double benderPower = benders.Sum(b => b.GetTotalPower());
        int monumentPower = monuments.Sum(m => m.GetAffinity());
        double bonus = (benderPower / 100) * monumentPower;

        return benderPower + bonus;
    }

    public string GetWarsRecord()
    {
        StringBuilder result = new StringBuilder();
        int num = 1;
        foreach (var name in this.warRecords)
        {
            result.AppendLine($"War {num} issued by {name}");
            num++;
        }

        return result.ToString().Trim();
    }

}
