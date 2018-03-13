using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int
        yearOfProduction, int horsepower, int acceleration, int suspension, int
        durability)
    {
        switch (type.ToLower())
        {
            case "performance":
                Car car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                cars.Add(id, car);
                break;
            case "show":
                Car cr = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                cars.Add(id, cr);
                break;
        }
    }

    public string Check(int id)
    {
        Car car = cars[id];
        return car.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        switch (type.ToLower())
        {
            case "casual":
                Race race = new CasualRace(length, route, prizePool);
                races.Add(id, race);
                break;
            case "drag":
                Race rac = new DragRace(length, route, prizePool);
                races.Add(id, rac);
                break;
            case "drift":
                Race ra = new DriftRace(length, route, prizePool);
                races.Add(id, ra);
                break;
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!garage.ParkedCars.Contains(carId))
        {
            Car car = cars[carId];
            races[raceId].AddParticipant(carId, car);
        }
    }

    public string Start(int id)
    {
        StringBuilder result = new StringBuilder();
        if (races[id].Participants.Count != 0)
        {
            result.AppendLine($"{races[id].Route} - {races[id].Length}");
            var winners = races[id].GetWinners();
            int count = 1;
            foreach (var car in winners)
            {
                if (count == 1)
                {
                    result.AppendLine($"{count}. {car.Key.Brand} {car.Key.Model} {car.Value}PP - ${races[id].PrizePool * 0.5}");
                }
                if (count == 2)
                {
                    result.AppendLine($"{count}. {car.Key.Brand} {car.Key.Model} {car.Value}PP - ${races[id].PrizePool * 0.3}");
                }
                if (count == 3)
                {
                    result.AppendLine($"{count}. {car.Key.Brand} {car.Key.Model} {car.Value}PP - ${races[id].PrizePool * 0.2}");
                }
                count++;
            }
            races.Remove(id);
        }
        else
        {
            result.AppendLine("Cannot start the race with zero participants.");
        }

        return result.ToString().Trim();
    }

    public void Park(int id)
    {
        bool isRacer = false;
        foreach (var race in this.races)
        {
            if (race.Value.Participants.ContainsKey(id))
            {
                isRacer = true;
            }
        }

        if (!isRacer)
        {
            this.garage.Add(id);
        }
    }

    public void Unpark(int id)
    {
        this.garage.Remove(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var id in this.garage.ParkedCars)
        {
            this.cars[id].Upgrade(tuneIndex, addOn);
        }
    }

}
