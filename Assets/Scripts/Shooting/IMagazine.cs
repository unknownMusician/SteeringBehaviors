namespace SteeringBehaviors.Shooting
{
    public interface IMagazine
    {
        bool IsWeaponEmpty { get; }
        bool IsStockEmpty { get; }
        
        void PickUpBullets(int amountOfBullets);
        void ReloadWeapon();
        void HandleShoot(int amountOfShotBullets);
        void DropBullets(int amountOfBullets);
    }
}
