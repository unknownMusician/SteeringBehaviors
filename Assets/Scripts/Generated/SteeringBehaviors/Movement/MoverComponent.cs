// Generated

using SteeringBehaviors.Movement;
using UnityEngine;

namespace Generated.SteeringBehaviors.Movement
{
    public sealed class MoverComponent : MonoBehaviour
    {
        [SerializeField] private Transform movable;
        [SerializeField] private float maxSpeed;

        public Mover Mover { get; private set; }

        private void Awake()
        {
            Mover = new Mover(movable, maxSpeed);
        }
    }
}
