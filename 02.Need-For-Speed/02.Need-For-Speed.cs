using System;

public class Program
{
    static void Main()
    {
        CarManager manager = new CarManager();
        string input;
        while ((input = Console.ReadLine()) != "Cops Are Here")
        {
            string[] tolkens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string command = tolkens[0];
            string result = string.Empty;
            switch (command.ToLower())
            {
                case "register":
                    manager.Register(int.Parse(tolkens[1]), tolkens[2], tolkens[3],tolkens[4],int.Parse(tolkens[5]), int.Parse(tolkens[6]), int.Parse(tolkens[7]), int.Parse(tolkens[8]), int.Parse(tolkens[9]));
                    break;
                case "check":
                    result = manager.Check(int.Parse(tolkens[1]));
                    Console.WriteLine(result);
                    break;
                case "open":
                    manager.Open(int.Parse(tolkens[1]),tolkens[2], int.Parse(tolkens[3]),tolkens[4], int.Parse(tolkens[5]));
                    break;
                case "participate":
                    manager.Participate(int.Parse(tolkens[1]), int.Parse(tolkens[2]));
                    break;
                case "start":
                    result = manager.Start(int.Parse(tolkens[1]));
                    Console.WriteLine(result);
                    break;
                case "park":
                    manager.Park(int.Parse(tolkens[1]));
                    break;
                case "unpark":
                    manager.Unpark(int.Parse(tolkens[1]));
                    break;
                case "tune":
                    manager.Tune(int.Parse(tolkens[1]), tolkens[2]);
                    break;
            }
        }
    }
}
