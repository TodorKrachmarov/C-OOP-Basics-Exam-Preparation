using System.Collections.Generic;

public abstract class Race
{
    private Dictionary<int, Car> participants;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.participants = new Dictionary<int, Car>();
    }

    public int Length { get; protected set; }

    public string Route { get; protected set; }

    public int PrizePool { get; protected set; }

    public IReadOnlyDictionary<int, Car> Participants { get { return this.participants; } }

    public void AddParticipant(int id, Car car)
    {
        this.participants.Add(id, car);
    }

    public abstract Dictionary<Car, int> GetWinners();
}
