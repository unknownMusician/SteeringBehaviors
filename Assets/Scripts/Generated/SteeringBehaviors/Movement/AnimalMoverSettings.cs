using UnityEngine;

namespace Generated.SteeringBehaviors.Movement
{
    [CreateAssetMenu(fileName = "Animal Mover Settings", menuName = "Steering Behaviors/Animal Mover Settings", order = 0)]
    public class AnimalMoverSettings : ScriptableObject
    {
        [field: SerializeField] public float MaxSpeed { get; protected set; }
        [field: SerializeField] public global::SteeringBehaviors.Movement.MoveImpactInfos ImpactInfos { get; protected set; }
        [field: SerializeField] public Bounds Bounds { get; protected set; }
    }
}
