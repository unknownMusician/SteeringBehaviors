// Generated

namespace Generated.SteeringBehaviors.Shooting
{
    public sealed class MagazineComponent : global::UnityEngine.MonoBehaviour, global::SteeringBehaviors.SourceGeneration.IComponent<global::SteeringBehaviors.Shooting.Magazine>
    {
        [global::UnityEngine.SerializeField] private int _bulletsInStockAmount;
        [global::UnityEngine.SerializeField] private int _bulletsInWeaponAmount;
        [global::UnityEngine.SerializeField] private int _maxBulletsInWeaponAmount;

        public global::SteeringBehaviors.Shooting.Magazine HeldType { get; private set; }

        private void Awake()
        {
            HeldType = new global::SteeringBehaviors.Shooting.Magazine(_bulletsInStockAmount, _bulletsInWeaponAmount, _maxBulletsInWeaponAmount);
        }
    }
}
