using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MortalEngines.Core.Contracts
{
    public class Engine : IEngine
    {
        private IMachinesManager machinesManager;

        public Engine()
        {
            machinesManager = new MachinesManager();
        }

        public void Run()
        {
            string command = string.Empty;
            string result = string.Empty;
            while ((command = Console.ReadLine()) != "Quit")
            {
                try
                {
                    var tokens = command.Split();
                    var commandName = tokens[0];
                    string name = tokens[1];

                    switch (commandName)
                    {
                        case "HirePilot":
                            result = machinesManager.HirePilot(name);
                            break;
                        case "PilotReport":
                            result = machinesManager.PilotReport(name);
                            break;
                        case "ManufactureTank":
                            double attackPoints = double.Parse(tokens[2]);
                            double defencePoints = double.Parse(tokens[3]);

                            result = machinesManager.ManufactureTank(name, attackPoints, defencePoints);
                            break;
                        case "ManufactureFighter":
                            attackPoints = double.Parse(tokens[2]);
                            defencePoints = double.Parse(tokens[3]);

                            result = machinesManager.ManufactureFighter(name, attackPoints, defencePoints);
                            break;
                        case "MachineReport":
                            result = machinesManager.MachineReport(name);
                            break;
                        case "AggressiveMode":
                            result = machinesManager.ToggleFighterAggressiveMode(name);
                            break;
                        case "DefenseMode":
                            result = machinesManager.ToggleTankDefenseMode(name);
                            break;
                        case "Engage":
                            string machineName = tokens[2];

                            result = machinesManager.EngageMachine(name, machineName);
                            break;
                        case "Attack":
                            string defenderName = tokens[2];

                            result = machinesManager.AttackMachines(name, defenderName);
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(result);
                }
                catch (TargetInvocationException ex)
                {
                    Console.WriteLine($"Error: {ex.InnerException.Message}");
                }
            }
        }
    }
}
