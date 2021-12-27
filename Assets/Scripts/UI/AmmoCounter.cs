using SteeringBehaviors.Shooting;
using UnityEngine;
using UnityEngine.UI;

namespace SteeringBehaviors
{
    public class AmmoCounter
    {

        [SerializeField] private Text _ammoCounterText;
        private Magazine _magazine;
        private Shooter _shooter;

        public void Intialize(Magazine magazine,Shooter shooter)
        {
            _magazine = magazine;
            _shooter = shooter;
            _shooter.OnShot += HandleChange;
            _shooter.OnReload += HandleChange;
            HandleChange();

        }

        public void HandleChange()
        {
            _ammoCounterText.text = $"{_magazine.BulletsInStockAmount}/{_magazine.BulletsInWeaponAmount}";
        }

    }
}
