using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var listOfPrivates = new Dictionary<string, Private>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] tokens = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                    string soldierType = tokens[0];
                    string id = tokens[1];
                    string firstName = tokens[2];
                    string lastName = tokens[3];

                    switch (soldierType)
                    {
                        case "Private":
                            decimal salary = decimal.Parse(tokens[4]);

                            Private priv = new Private(id, firstName, lastName, salary);

                            listOfPrivates.Add(id, priv);

                            Console.WriteLine(priv);
                            break;
                        case "LieutenantGeneral":
                            salary = decimal.Parse(tokens[4]);

                            var lieutenantGeneral = new LieutenantGeneral
                                (id, firstName, lastName, salary);

                            string[] idsOfPrivatesToAdd = tokens.Skip(5).ToArray();
                            foreach (var idToCheck in idsOfPrivatesToAdd)
                            {
                                if (listOfPrivates.ContainsKey(idToCheck))
                                {
                                    lieutenantGeneral.AddPrivate(listOfPrivates[idToCheck]);
                                }
                            }

                            Console.WriteLine(lieutenantGeneral);
                            break;
                        case "Engineer":
                            salary = decimal.Parse(tokens[4]);
                            string corps = tokens[5];
                            var engineer = new Engineer
                                 (id, firstName, lastName, salary, corps);

                            string[] repairsToAdd = tokens.Skip(6).ToArray();
                            for (int i = 0; i < repairsToAdd.Length; i += 2)
                            {
                                string partName = repairsToAdd[i];
                                int hoursWorked = int.Parse(repairsToAdd[i + 1]);

                                var repair = new Repair(partName, hoursWorked);

                                engineer.AddRepair(repair);
                            }

                            Console.WriteLine(engineer);
                            break;
                        case "Commando":
                            salary = decimal.Parse(tokens[4]);
                            corps = tokens[5];

                            var commando = new Commando
                                 (id, firstName, lastName, salary, corps);

                            string[] missionsToAdd = tokens.Skip(6).ToArray();
                            for (int i = 0; i < missionsToAdd.Length; i += 2)
                            {
                                string codeName = missionsToAdd[i];
                                string state = missionsToAdd[i + 1];

                                
                                var mission = new Mission(codeName, state);
                                if (mission.CheckMissionState(state))
                                {
                                    commando.AddMission(mission);
                                }
                            }

                            Console.WriteLine(commando);
                            break;
                        case "Spy":
                            int codeNumber = int.Parse(tokens[4]);

                            var spy = new Spy(id, firstName, lastName, codeNumber);

                            Console.WriteLine(spy);
                            break;
                        default:
                            break;
                    }
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
