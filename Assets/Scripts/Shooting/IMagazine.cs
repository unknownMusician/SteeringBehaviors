namespace SteeringBehaviors.Shooting
{
    public interface IMagazine
    {
        int BulletsInStockAmount { get; }
        int BulletsInWeaponAmount { get; }

        bool IsWeaponEmpty { get; }
        bool IsStockEmpty { get; }
        
        void PickUpBullets(int amountOfBullets);
        void ReloadWeapon();
        void HandleShoot(int amountOfShotBullets);
        void DropBullets(int amountOfBullets);
    }
}
