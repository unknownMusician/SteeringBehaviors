// Generated

namespace Generated.SteeringBehaviors.Shooting
{
    public sealed class ShooterInputComponent : global::UnityEngine.MonoBehaviour, global::SteeringBehaviors.SourceGeneration.IComponent<global::SteeringBehaviors.Shooting.ShooterInput>
    {
        [global::UnityEngine.SerializeField] private global::Generated.SteeringBehaviors.Shooting.ShooterComponent _shooter;

        public global::SteeringBehaviors.Shooting.ShooterInput HeldType { get; private set; }

        private void Awake()
        {
            HeldType = new global::SteeringBehaviors.Shooting.ShooterInput(_shooter.HeldType);
        }

        private void OnDestroy()
        {
            HeldType.Dispose();
        }
    }
}
