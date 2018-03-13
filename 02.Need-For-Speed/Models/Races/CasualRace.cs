using System.Collections.Generic;
using System.Linq;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) 
        : base(length, route, prizePool) { }

    public override Dictionary<Car, int> GetWinners()
    {
        var winners = new Dictionary<Car, int>();
        foreach (var car in base.Participants)
        {
            int points = (car.Value.Horsepower / car.Value.Acceleration) +
                         (car.Value.Suspension + car.Value.Durability);
            winners.Add(car.Value, points);
        }

        return winners.OrderByDescending(c => c.Value).Take(3).ToDictionary(g => g.Key, g => g.Value);
    }
}
