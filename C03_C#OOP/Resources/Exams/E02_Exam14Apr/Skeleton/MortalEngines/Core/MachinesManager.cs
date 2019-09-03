namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private readonly IList<IPilot> pilots;
        private readonly IList<IMachine> machines;
        private string result;

        public MachinesManager()
        {
            pilots = new List<IPilot>();
            machines = new List<IMachine>();
            result = string.Empty;
        }

        public string HirePilot(string name)
        {
            var pilot = pilots.FirstOrDefault(p => p.Name == name);
            if (pilot != null)
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            pilot = new Pilot(name);

            pilots.Add(pilot);

            result = string.Format(OutputMessages.PilotHired, name);

            return result;
        }

        public string PilotReport(string pilotReporting)
        {
            return pilots.FirstOrDefault(p => p.Name == pilotReporting).Report();
        }

        public string MachineReport(string machineName)
        {
            return machines.FirstOrDefault(m => m.Name == machineName).ToString();
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var tank = (ITank)machines.FirstOrDefault(m => m.Name == name && m.GetType().Name == nameof(Tank));
            if (tank != null)
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            tank = new Tank(name, attackPoints, defensePoints);

            machines.Add(tank);

            result = string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);

            return result;
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = (ITank)machines.FirstOrDefault(m => m.Name == tankName && m.GetType().Name == nameof(Tank));
            if (tank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            tank.ToggleDefenseMode();

            result = string.Format(OutputMessages.TankOperationSuccessful, tankName);

            return result;
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            var fighter = (IFighter)machines.FirstOrDefault(m => m.Name == name && m.GetType().Name == nameof(Fighter));
            if (fighter != null)
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            fighter = new Fighter(name, attackPoints, defensePoints);

            machines.Add(fighter);

            result = string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, fighter.AggressiveMode == true ? "ON" : "OFF");

            return result;
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = (IFighter)machines.FirstOrDefault(m => m.Name == fighterName && m.GetType().Name == nameof(Fighter));
            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            fighter.ToggleAggressiveMode();

            result = string.Format(OutputMessages.FighterOperationSuccessful, fighterName);

            return result;
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            var machine = machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }
            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }
            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            machine.Pilot = pilot;
            pilot.AddMachine(machine);

            result = string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);

            return result;
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attacker = machines.FirstOrDefault(m => m.Name == attackingMachineName);
            var defender = machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            if (defender == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }
            if (attacker.HealthPoints==0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            if (defender.HealthPoints==0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attacker.Attack(defender);

            result = string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defender.HealthPoints);

            return result;
        }
    }
}