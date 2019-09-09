using MXGP.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IChampionshipController championship;
        public Engine()
        {
            championship = new ChampionshipController();
        }

        public void Run()
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string result = string.Empty;
                    string[] tokens = command.Split(" ").ToArray();
                    string methodName = tokens[0];
                    string name = tokens[1];

                    if (methodName == "CreateRider")
                    {
                        result = championship.CreateRider(name);
                    }
                    else if (methodName == "CreateMotorcycle")
                    {
                        var model = tokens[2];
                        var horsepower = int.Parse(tokens[3]);

                        result = championship.CreateMotorcycle(name, model, horsepower);
                    }
                    else if (methodName == "AddMotorcycleToRider")
                    {
                        var motorName = tokens[2];

                        result = championship.AddMotorcycleToRider(name, motorName);
                    }
                    else if (methodName == "AddRiderToRace")
                    {
                        var riderName = tokens[2];

                        result = championship.AddRiderToRace(name, riderName);
                    }
                    else if (methodName == "CreateRace")
                    {
                        var laps = int.Parse(tokens[2]);

                        result = championship.CreateRace(name, laps);
                    }
                    else if (methodName == "StartRace")
                    {
                        result = championship.StartRace(name);
                    }
                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (TargetInvocationException tie)
                {
                    Console.WriteLine(tie.InnerException.Message);
                }
            }
            //Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
 }
