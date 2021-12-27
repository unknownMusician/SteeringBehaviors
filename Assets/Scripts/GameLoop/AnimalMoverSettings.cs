using UnityEngine;

namespace SteeringBehaviors.GameLoop
{
    [CreateAssetMenu(fileName = "FieldBoundsKiller Settings", menuName = "Steering Behaviors/FieldBoundsKiller Settings", order = 0)]
    public class AnimalMoverSettings : ScriptableObject
    {
        [field: SerializeField] public Bounds Bounds { get; protected set; }
    }
}
