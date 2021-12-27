// Generated

namespace Generated.SteeringBehaviors.Movement
{
    public sealed class PlayerMoverComponent : global::UnityEngine.MonoBehaviour, global::SteeringBehaviors.SourceGeneration.IComponent<global::SteeringBehaviors.Movement.PlayerMover>
    {
        [global::UnityEngine.SerializeField] private float _maxSpeed;

        public global::SteeringBehaviors.Movement.PlayerMover HeldType { get; private set; }

        private void Awake()
        {
            HeldType = new global::SteeringBehaviors.Movement.PlayerMover(transform, _maxSpeed);
        }

        private void OnDestroy()
        {
            HeldType.Dispose();
        }
    }
}
