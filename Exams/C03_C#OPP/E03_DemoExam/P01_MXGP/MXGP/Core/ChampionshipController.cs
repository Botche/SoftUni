using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly RiderRepository riderRepository;
        private readonly RaceRepository raceRepository;
        private readonly MotorcycleRepository motorcycleRepository;

        public ChampionshipController()
        {
            riderRepository = new RiderRepository();
            raceRepository = new RaceRepository();
            motorcycleRepository = new MotorcycleRepository();
        }

        public string CreateRider(string riderName)
        {
            var rider = riderRepository.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            var riderToAdd = new Rider(riderName);

            riderRepository.Add(riderToAdd);

            return string.Format(OutputMessages.RiderCreated, riderName);
        }
        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var motor = motorcycleRepository.GetByName(model);

            if (motor != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            if (type == "Speed")
            {
                motor = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motor = new PowerMotorcycle(model, horsePower);
            }

            motorcycleRepository.Add(motor);

            return string.Format(OutputMessages.MotorcycleCreated, motor.GetType().Name, model);
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = riderRepository.GetByName(riderName);
            var motor = motorcycleRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (motor == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motor);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = raceRepository.GetByName(raceName);
            var rider = riderRepository.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }


        public string CreateRace(string name, int laps)
        {
            var race = raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var raceToAdd = new Race(name, laps);

            raceRepository.Add(raceToAdd);

            return string.Format(OutputMessages.RaceCreated, name);
        }


        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var winners = race.Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .ToArray();

            winners[0].WinRace();
            var result = new StringBuilder();
            result.AppendLine(string.Format(OutputMessages.RiderFirstPosition, winners[0].Name, race.Name))
                .AppendLine(string.Format(OutputMessages.RiderSecondPosition, winners[1].Name, race.Name))
                .AppendLine(string.Format(OutputMessages.RiderThirdPosition, winners[2].Name, race.Name));

            raceRepository.Remove(race);

            return result.ToString().TrimEnd();
        }
    }
}
