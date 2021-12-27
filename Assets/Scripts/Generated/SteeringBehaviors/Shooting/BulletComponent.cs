// Generated

namespace Generated.SteeringBehaviors.Shooting
{
    public sealed class BulletComponent : global::UnityEngine.MonoBehaviour, global::SteeringBehaviors.SourceGeneration.IComponent<global::SteeringBehaviors.Shooting.Bullet>
    {
        [global::UnityEngine.SerializeField] private global::UnityEngine.Rigidbody _rigidbody;
        [global::UnityEngine.SerializeField] private float _velocity;

        public global::SteeringBehaviors.Shooting.Bullet HeldType { get; private set; }

        private void Awake()
        {
            HeldType = new global::SteeringBehaviors.Shooting.Bullet(gameObject, transform, _rigidbody, _velocity);
        }
            
        private void OnTriggerEnter(global::UnityEngine.Collider other)
        {
            HeldType.OnTriggerEnter(other);
        }

        private void OnDestroy()
        {
            HeldType.Dispose();
        }
    }
}
