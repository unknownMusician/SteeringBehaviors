// Generated

namespace Generated.SteeringBehaviors.Movement
{
    public sealed class AnimalMoverComponent : global::UnityEngine.MonoBehaviour, global::SteeringBehaviors.SourceGeneration.IComponent<global::SteeringBehaviors.Movement.AnimalMover>
    {
        [global::UnityEngine.SerializeField] private global::Generated.SteeringBehaviors.Movement.AnimalMoverSettings _settings;

        public global::SteeringBehaviors.Movement.AnimalMover HeldType { get; private set; }

        private void Awake()
        {
            HeldType = new global::SteeringBehaviors.Movement.AnimalMover(transform, _settings.MaxSpeed, _settings.ImpactInfos, _settings.Bounds);
        }

        private void OnDestroy()
        {
            HeldType.Dispose();
        }
    }
}
