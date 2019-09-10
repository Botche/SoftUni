using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private int currentCapacityOfGun = initialBulletsPerBarrel;

        private const int initialBulletsPerBarrel = 50;
        private const int initialTotalBullets = 500;

        public Rifle(string name)
            : base(name, initialBulletsPerBarrel, initialTotalBullets)
        {
        }

        public override int Fire()
        {
            int firePerGun = 5;

            if (currentCapacityOfGun == 0)
            {
                currentCapacityOfGun = this.BulletsPerBarrel;
                this.TotalBullets -= this.BulletsPerBarrel;
            }
            else
            {
                currentCapacityOfGun -= 5;
            }

            return firePerGun;
        }
    }
}
