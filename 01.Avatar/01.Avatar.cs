using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        NationsBuilder nationBuilder = new NationsBuilder();
        string input;
        while ((input = Console.ReadLine()) != "Quit")
        {
            List<string> commandTolk = input.Split(new []{' '},StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = commandTolk[0];
            commandTolk.RemoveAt(0);
            string nation = string.Empty;
            string result = string.Empty;

            switch (command)
            {
                case "Bender":
                    nationBuilder.AssignBender(commandTolk);
                    break;
                case "Monument":
                    nationBuilder.AssignMonument(commandTolk);
                    break;
                case "Status":
                    nation = commandTolk[0];
                    result = nationBuilder.GetStatus(nation);
                    Console.WriteLine(result);
                    break;
                case "War":
                    nation = commandTolk[0];
                    nationBuilder.IssueWar(nation);
                    break;
            }
        }

        string finalResult = nationBuilder.GetWarsRecord();
        Console.WriteLine(finalResult);
    }
}
