using UnityEngine;

namespace SteeringBehaviors.Movement.Settings
{
    [CreateAssetMenu(fileName = "MovementSettings", menuName = "MovementSettings", order = 0)]
    public sealed class MovementSettings : ScriptableObject
    {
        [Header("Groups settings")]
        [SerializeField, Range(0, 1)] private float _cohesionWeight = 1f;
        [SerializeField, Range(0, 1)] private float _separationWeight = 1f;
        [SerializeField, Range(0, 1)] private float _alignmentWeight = 1f;
        
        [Header("Wandering")]
        [SerializeField] private int _angleStep = 3;
        [SerializeField] private float _circleDistance = 3f;
        [SerializeField] private float _circleRadius = 1f;
        

        public float CohesionWeight => _cohesionWeight;

        public float SeparationWeight => _separationWeight;

        public float AlignmentWeight => _alignmentWeight;

        public int AngleStep => _angleStep;

        public float CircleDistance => _circleDistance;

        public float CircleRadius => _circleRadius;
    }
}