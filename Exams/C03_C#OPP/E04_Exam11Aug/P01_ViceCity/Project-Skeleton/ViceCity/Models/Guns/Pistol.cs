using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private int currentCapacityOfGun = initialBulletsPerBarrel;

        private const int initialBulletsPerBarrel = 10;
        private const int initialTotalBullets = 100;

        public Pistol(string name)
            : base(name, initialBulletsPerBarrel, initialTotalBullets)
        {
        }

        public override int Fire()
        {
            int firePerGun = 1;

            if (currentCapacityOfGun == 0)
            {
                currentCapacityOfGun = this.BulletsPerBarrel;
                this.TotalBullets -= this.BulletsPerBarrel;
            }
            else
            {
                currentCapacityOfGun--;
            }

            return firePerGun;
        }
    }
}
