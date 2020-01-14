using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string commandPostfix = "Command";
        public string Read(string inputLine)
        {
            string[] cmdTokens = inputLine
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = cmdTokens[0] + commandPostfix;
            string[] commandArgs = cmdTokens
                .Skip(1)
                .ToArray();

            var assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();
            Type typeToCreate = types
                .FirstOrDefault(t => t.Name == commandName);

            if (typeToCreate==null)
            {
                throw new InvalidOperationException("Invalid Command Type");
            }

            Object instance = Activator.CreateInstance(typeToCreate);

            ICommand command = (ICommand)instance;
            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
