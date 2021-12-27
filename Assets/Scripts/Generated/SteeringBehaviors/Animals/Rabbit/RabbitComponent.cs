// Generated

namespace Generated.SteeringBehaviors.Animals.Rabbit
{
    public sealed class RabbitComponent : global::UnityEngine.MonoBehaviour, global::SteeringBehaviors.SourceGeneration.IComponent<global::SteeringBehaviors.Animals.Rabbit.Rabbit>
    {
        [global::UnityEngine.SerializeField] private global::Generated.SteeringBehaviors.Movement.AnimalMoverComponent _mover;
        [global::UnityEngine.SerializeField] private global::SteeringBehaviors.Animals.Settings.RabbitSettings _rabbitSettings;

        public global::SteeringBehaviors.Animals.Rabbit.Rabbit HeldType { get; private set; }

        private void Awake()
        {
            HeldType = new global::SteeringBehaviors.Animals.Rabbit.Rabbit(_mover.HeldType, _rabbitSettings, transform);
        }

        private void OnDestroy()
        {
            HeldType.Dispose();
        }
    }
}
