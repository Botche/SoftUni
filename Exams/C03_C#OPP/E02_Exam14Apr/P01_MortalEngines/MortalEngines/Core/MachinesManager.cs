namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IMachine> machines;
        private readonly List<IPilot> pilots;

        public MachinesManager()
        {
            machines = new List<IMachine>();
            pilots = new List<IPilot>();
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

            return string.Format(OutputMessages.PilotHired, name);
        }

        public string PilotReport(string name)
        {
            var pilot = pilots.FirstOrDefault(p => p.Name == name);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, name);
            }

            return pilot.Report();
        }

        public string MachineReport(string name)
        {
            var machine = machines.FirstOrDefault(m => m.Name == name);

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, name);
            }

            return machine.ToString();
        }

        public string ManufactureTank(string name, double attack, double defence)
        {
            var tank =(ITank) machines.FirstOrDefault(m => m.Name == name);

            if (tank != null)
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            tank = new Tank(name, attack, defence);

            machines.Add(tank);

            return string.Format(OutputMessages.TankManufactured, name, attack, defence);
        }

        public string ToggleTankDefenseMode(string name)
        {
            var machine = (ITank)machines.FirstOrDefault(m => m.Name == name);

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, name);
            }

            machine.ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful, name);
        }

        public string ManufactureFighter(string name, double attack, double defence)
        {
            var fighter = (IFighter)machines.FirstOrDefault(m => m.Name == name);

            if (fighter != null)
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            fighter = new Fighter(name, attack, defence);

            machines.Add(fighter);

            var aggresiveMode = string.Empty;

            if (fighter.AggressiveMode)
            {
                aggresiveMode = "ON";
            }
            else
            {
                aggresiveMode = "OFF";
            }

            return string.Format(OutputMessages.FighterManufactured,
                name,
                attack,
                defence,
                aggresiveMode);
        }

        public string ToggleFighterAggressiveMode(string name)
        {
            var fighter = (IFighter)machines.FirstOrDefault(m => m.Name == name);

            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, name);
            }

            fighter.ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, name);
        }

        public string EngageMachine(string pilotName, string machineName)
        {
            var pilot = pilots.FirstOrDefault(p => p.Name == pilotName);
            var machine = machines.FirstOrDefault(m => m.Name == machineName);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, pilotName);
            }
            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, machineName);
            }
            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, machineName);
            }

            machine.Pilot = pilot;
            pilot.AddMachine(machine);

            return string.Format(OutputMessages.MachineEngaged, pilotName, machineName);
        }

        public string AttackMachines(string attackerName, string defenderName)
        {
            var attacker = machines.FirstOrDefault(m => m.Name == attackerName);
            var defender = machines.FirstOrDefault(m => m.Name == defenderName);

            if (attacker == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackerName);
            }
            if (defender == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defenderName);
            }
            if (attacker.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackerName);
            }
            if (defender.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defenderName);
            }

            attacker.Targets.Add(defenderName);

            attacker.Attack(defender);

            return string.Format(OutputMessages.AttackSuccessful, defenderName, attackerName, defender.HealthPoints);
        }
    }
}