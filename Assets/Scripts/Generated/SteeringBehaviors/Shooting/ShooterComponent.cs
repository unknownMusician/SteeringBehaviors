// Generated

namespace Generated.SteeringBehaviors.Shooting
{
    public sealed class ShooterComponent : global::UnityEngine.MonoBehaviour, global::SteeringBehaviors.SourceGeneration.IComponent<global::SteeringBehaviors.Shooting.Shooter>
    {
        [global::UnityEngine.SerializeField] private global::UnityEngine.GameObject _bulletPrefab;
        [global::UnityEngine.SerializeField] private global::UnityEngine.Vector3 _offset;
        [global::UnityEngine.SerializeField] private global::Generated.SteeringBehaviors.Shooting.MagazineComponent _magazine;

        public global::SteeringBehaviors.Shooting.Shooter HeldType { get; private set; }

        private void Awake()
        {
            HeldType = new global::SteeringBehaviors.Shooting.Shooter(transform, _bulletPrefab, _offset, _magazine.HeldType);
        }

        private void OnDestroy()
        {
            HeldType.Dispose();
        }
    }
}
