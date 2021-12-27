// Generated

using Generated.SteeringBehaviors.Hunt;

namespace Generated.SteeringBehaviors.Animals.Wolf
{
    public sealed class WolfComponent : global::UnityEngine.MonoBehaviour, global::SteeringBehaviors.SourceGeneration.IComponent<global::SteeringBehaviors.Animals.Wolf.Wolf>
    {
        [global::UnityEngine.SerializeField] private global::Generated.SteeringBehaviors.Movement.AnimalMoverComponent _mover;
        [global::UnityEngine.SerializeField] private global::SteeringBehaviors.Animals.Settings.WolfSettings _wolfSettings;

        public global::SteeringBehaviors.Animals.Wolf.Wolf HeldType { get; private set; }

        private void Awake()
        {
            HeldType = new global::SteeringBehaviors.Animals.Wolf.Wolf(_mover.HeldType, _wolfSettings, transform, GetComponent<KillableComponent>().HeldType);
        }

        private void OnDestroy()
        {
            HeldType.Dispose();
        }
    }
}
