// Generated

namespace Generated.SteeringBehaviors.Movement
{
    public sealed class PlayerMoverInputComponent : global::UnityEngine.MonoBehaviour, global::SteeringBehaviors.SourceGeneration.IComponent<global::SteeringBehaviors.Movement.PlayerMoverInput>
    {
        [global::UnityEngine.SerializeField] private global::Generated.SteeringBehaviors.Movement.PlayerMoverComponent _mover;

        public global::SteeringBehaviors.Movement.PlayerMoverInput HeldType { get; private set; }

        private void Awake()
        {
            HeldType = new global::SteeringBehaviors.Movement.PlayerMoverInput(_mover.HeldType);
        }

        private void OnDestroy()
        {
            HeldType.Dispose();
        }
    }
}
