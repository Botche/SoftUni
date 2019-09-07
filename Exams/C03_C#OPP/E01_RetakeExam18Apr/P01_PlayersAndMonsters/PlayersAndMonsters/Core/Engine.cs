using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController managerController;

        public Engine()
        {
            managerController = new ManagerController();
        }

        public void Run()
        {
            var sb = new StringBuilder();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Exit")
            {
                try
                {
                    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string commandName = tokens[0];

                    var method = typeof(ManagerController)
                        .GetMethod(commandName);

                    List<object> requiredParams = new List<object>();

                    foreach (var commandArg in tokens.Skip(1))
                    {
                        requiredParams.Add(commandArg);
                    }

                    string result = (string)method.Invoke(this.managerController, requiredParams.ToArray());

                    sb.AppendLine(result);
                }
                catch (TargetInvocationException ae)
                {
                    sb.AppendLine(ae.InnerException.Message);
                }
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
