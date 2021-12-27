// Generated

namespace Generated.SteeringBehaviors.Animals.Deer
{
    public sealed class DeerComponent : global::UnityEngine.MonoBehaviour, global::SteeringBehaviors.SourceGeneration.IComponent<global::SteeringBehaviors.Animals.Deer.Deer>
    {
        [global::UnityEngine.SerializeField] private global::Generated.SteeringBehaviors.Movement.AnimalMoverComponent _mover;
        [global::UnityEngine.SerializeField] private global::SteeringBehaviors.Animals.Settings.DeerSettings _deerSettings;

        public global::SteeringBehaviors.Animals.Deer.Deer HeldType { get; private set; }

        private void Awake()
        {
            HeldType = new global::SteeringBehaviors.Animals.Deer.Deer(_mover.HeldType, _deerSettings, transform);
        }

        private void OnDestroy()
        {
            HeldType.Dispose();
        }
    }
}
