namespace SteeringBehaviors.Shooting
{
    public interface IMagazine
    {
        void PickUpBullets(int amountOfBullets);
        void ReloadWeapon();
        void DropBullets(int amountOfBullets);

        bool IsWeaponEmpty();

        bool IsStockEmpty();
    }
}
