using Generated.SteeringBehaviors.Shooting;
using SteeringBehaviors.Shooting;
using UnityEngine;
using UnityEngine.UI;

namespace SteeringBehaviors
{
    public class AmmoCounterUI : MonoBehaviour
    {
        [SerializeField] private Text _ammoCounterText;
        [SerializeField] private ShooterComponent _shooterComponent;

        private Shooter _shooter;
        private IMagazine _magazine;

        public void Awake()
        {
            _shooter = _shooterComponent.HeldType;
            _magazine = _shooter.Magazine;
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
