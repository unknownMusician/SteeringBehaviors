#nullable enable

using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Shooting
{
    [GenerateMonoBehaviour]
    public class Magazine : IMagazine
    {
        public readonly int MaxBulletsInWeaponAmount;
        
        public int BulletsInStockAmount { get; private set; }
        public int BulletsInWeaponAmount { get; private set; }

        public bool IsStockEmpty => BulletsInStockAmount == 0;
        public bool IsWeaponEmpty => BulletsInWeaponAmount == 0;

        public Magazine(int bulletsInStockAmount, int bulletsInWeaponAmount, int maxBulletsInWeaponAmount)
        {
            if (bulletsInWeaponAmount > maxBulletsInWeaponAmount)
            {
                throw new System.ArgumentException(
                    "Max amount of bullets in weapon is " + maxBulletsInWeaponAmount
                );
            }

            BulletsInStockAmount = bulletsInStockAmount;
            BulletsInWeaponAmount = bulletsInWeaponAmount;
            MaxBulletsInWeaponAmount = maxBulletsInWeaponAmount;
        }

        public void DropBullets(int amountOfDropBullets)
        {
            if (BulletsInStockAmount >= amountOfDropBullets)
            {
                BulletsInStockAmount -= amountOfDropBullets;
            }
        }

        public void HandleShoot(int amountOfShotBullets)
        {
            if (BulletsInWeaponAmount >= amountOfShotBullets)
            {
                BulletsInWeaponAmount -= amountOfShotBullets;
            }
        }

        public void PickUpBullets(int amountOfBullets) => BulletsInStockAmount += amountOfBullets;

        public void ReloadWeapon()
        {
            if (IsStockEmpty)
            {
                return;
            }

            int neededBullets = MaxBulletsInWeaponAmount - BulletsInWeaponAmount;

            int amountOfReloadedBullets = Mathf.Min(BulletsInStockAmount, neededBullets);

            BulletsInStockAmount -= amountOfReloadedBullets;
            BulletsInWeaponAmount += amountOfReloadedBullets;
        }
    }
}
