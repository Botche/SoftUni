using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (mainPlayer.GunRepository.Models.Count != 0 && civilPlayers.Count != 0)
            {
                var currentGun = mainPlayer.GunRepository.Models.FirstOrDefault();
                var currentCivil = civilPlayers.FirstOrDefault();

                if (currentGun == null)
                {
                    break;
                }

                while (currentGun.CanFire && currentCivil.IsAlive)
                {
                    currentCivil.TakeLifePoints(currentGun.Fire());
                }

                if (!currentGun.CanFire)
                {
                    mainPlayer.GunRepository.Remove(currentGun);
                }

                if (!currentCivil.IsAlive)
                {
                    civilPlayers.Remove(currentCivil);
                }
            }

            if (civilPlayers.Count != 0)
            {
                while (mainPlayer.IsAlive && civilPlayers.Count != 0)
                {
                    var currentCivil = civilPlayers.FirstOrDefault();
                    var currentGunOfCivil = currentCivil.GunRepository.Models.FirstOrDefault();

                    if (currentGunOfCivil == null)
                    {
                        break;
                    }

                    while (mainPlayer.IsAlive && currentGunOfCivil.CanFire)
                    {
                        mainPlayer.TakeLifePoints(currentGunOfCivil.Fire());
                    }

                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }
                    if (!currentGunOfCivil.CanFire)
                    {
                        if (currentCivil.GunRepository.Models.Count == 0)
                        {
                            civilPlayers.Remove(currentCivil);
                        }
                        else
                        {
                            currentCivil.GunRepository.Remove(currentGunOfCivil);
                        }
                    }
                }
            }
        }
    }
}
