namespace SteeringBehaviors.Shooting
{
    public class Magazine : IMagazine
    {
        public int AmountOfBulletsInStock {get; private set;}
        public int AmountOfBulletsInWeapon {get; private set;}
        public readonly int MaxAmountOfBulletsInWeapon;
        
        public Magazine(int amountOfBulletsInStock, int amountOfBulletsInWeapon,int maxAmountOfBulletsInWeapon)
        {
            MaxAmountOfBulletsInWeapon = maxAmountOfBulletsInWeapon;

            if(amountOfBulletsInWeapon > MaxAmountOfBulletsInWeapon)
            {
                throw new System.ArgumentException("Max amount of bullets in weapon is " + MaxAmountOfBulletsInWeapon);
            }

            AmountOfBulletsInStock = amountOfBulletsInStock;
            AmountOfBulletsInWeapon = amountOfBulletsInWeapon;
        }

        public void DropBullets(int amountOfDropBullets)
        {
            if (!IsStockEmpty() && AmountOfBulletsInStock >= amountOfDropBullets)
            {
                AmountOfBulletsInStock -= amountOfDropBullets;
            }
        }


        public bool IsStockEmpty()
        {
            return (AmountOfBulletsInStock == 0);
        }

        public bool IsWeaponEmpty()
        {
            return (AmountOfBulletsInWeapon == 0);
        }

        private bool IsInStockMoreOrEqualThanMaxAmountOfBulletsInWeapon()
        {
            return AmountOfBulletsInStock >= MaxAmountOfBulletsInWeapon;
            
        }

        public void PickUpBullets(int amountOfBullets)
        {
            AmountOfBulletsInStock += amountOfBullets;
        }

        public void ReloadWeapon()
        {
            if (!IsStockEmpty())
            {
                int amountOfReloadedBullets = AmountOfBulletsInStock;
                if (IsInStockMoreOrEqualThanMaxAmountOfBulletsInWeapon())
                {
                    amountOfReloadedBullets = MaxAmountOfBulletsInWeapon;
                }

                AmountOfBulletsInStock -= amountOfReloadedBullets;
                AmountOfBulletsInWeapon += amountOfReloadedBullets;
                
            }
        }
    }   
}

