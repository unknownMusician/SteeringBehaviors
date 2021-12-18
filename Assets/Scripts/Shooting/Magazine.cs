#nullable enable

using UnityEngine;

namespace SteeringBehaviors.Shooting
{
    public class Magazine : IMagazine
    {
        public readonly int MaxBulletsInWeaponAmount;
        
        public int BulletsInStockAmount { get; private set; }
        public int BulletsInWeaponAmount { get; private set; }

        public Magazine(int bulletsInStockAmount, int bulletsInWeaponAmount, int maxBulletsInWeaponAmount)
        {
            if (bulletsInWeaponAmount > MaxBulletsInWeaponAmount)
            {
                throw new System.ArgumentException(
                    "Max amount of bullets in weapon is " + MaxBulletsInWeaponAmount
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

        public bool IsStockEmpty() => BulletsInStockAmount == 0;

        public bool IsWeaponEmpty() => BulletsInWeaponAmount == 0;

        public void PickUpBullets(int amountOfBullets) => BulletsInStockAmount += amountOfBullets;

        public void ReloadWeapon()
        {
            if (IsStockEmpty())
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
