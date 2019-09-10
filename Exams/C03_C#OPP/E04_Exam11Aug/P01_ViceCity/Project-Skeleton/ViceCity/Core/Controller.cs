using System;
using System.Linq;
using System.Collections.Generic;

using ViceCity.Models.Guns;
using ViceCity.Core.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private IPlayer mainPlayer;
        private ICollection<IPlayer> civilPlayers;

        private ICollection<IGun> guns;

        private INeighbourhood neighbourhood;

        public Controller()
        {
            guns = new List<IGun>();
            mainPlayer = new MainPlayer();
            civilPlayers = new List<IPlayer>();
            neighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;
            if (type == "Pistol")
            {
                gun = new Pistol(name);
                guns.Add(gun);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
                guns.Add(gun);
            }
            else
            {
                return "Invalid gun type!";
            }

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (name == "Vercetti")
            {
                if (guns.Count != 0)
                {
                    var gun = guns.First();
                    mainPlayer.GunRepository.Add(gun);

                    guns.Remove(gun);

                    return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
                }
                else
                {
                    return "There are no guns in the queue!";
                }
            }
            else
            {
                var civil = civilPlayers.FirstOrDefault(c => c.Name == name);

                if (civil == null)
                {
                    return "Civil player with that name doesn't exists!";
                }
                else
                {
                    if (guns.Count != 0)
                    {
                        var gun = guns.First();
                        civil.GunRepository.Add(gun);

                        guns.Remove(gun);

                        return $"Successfully added {gun.Name} to the Civil Player: {name}";
                    }
                    else
                    {
                        return "There are no guns in the queue!";
                    }
                }
            }
        }

        public string AddPlayer(string name)
        {
            if (civilPlayers.FirstOrDefault(c => c.Name == name) == null)
            {
                var civil = new CivilPlayer(name);

                civilPlayers.Add(civil);

                return $"Successfully added civil player: {name}!";
            }

            return string.Empty;
        }

        public string Fight()
        {
            var countOfCivilPlayers = civilPlayers.Count;
            var lifePointOfFirstCivil = civilPlayers.First().LifePoints;

            neighbourhood.Action(mainPlayer, civilPlayers);

            if (mainPlayer.IsAlive &&
                countOfCivilPlayers == civilPlayers.Count &&
                lifePointOfFirstCivil == civilPlayers.First().LifePoints)
            {
                return "Everything is okay!";
            }
            else
            {
                return $"A fight happened:" + Environment.NewLine +
                    $"Tommy live points: {mainPlayer.LifePoints}!" + Environment.NewLine +
                    $"Tommy has killed: {Math.Abs(civilPlayers.Count - countOfCivilPlayers)} players!" + Environment.NewLine +
                    $"Left Civil Players: {civilPlayers.Count}!";
            }
        }
    }
}
