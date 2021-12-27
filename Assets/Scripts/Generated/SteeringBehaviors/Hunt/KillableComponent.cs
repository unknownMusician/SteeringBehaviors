// Generated

namespace Generated.SteeringBehaviors.Hunt
{
    public sealed class KillableComponent : global::UnityEngine.MonoBehaviour, global::SteeringBehaviors.SourceGeneration.IComponent<global::SteeringBehaviors.Hunt.Killable>
    {
        public global::SteeringBehaviors.Hunt.Killable HeldType { get; private set; }

        private void Awake()
        {
            HeldType = new global::SteeringBehaviors.Hunt.Killable(transform);
        }
    }
}
