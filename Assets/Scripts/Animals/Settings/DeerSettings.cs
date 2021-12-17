using UnityEngine;

namespace SteeringBehaviors.Animals.Settings
{
    [CreateAssetMenu(fileName = "DeerSettings", menuName = "AnimalsSettings/DeerSettings", order = 0)]
    public class DeerSettings : ScriptableObject
    {
        [Header("Speed parameters")]
        [SerializeField] private float _maxSpeed = 3f;
        [SerializeField] private float _wanderingSpeed = 1f;
        
        [Header("Detection circles")]
        [SerializeField] private float _detectionRadius = 5f;
        [SerializeField] private float _separationRadius = 1f;
        [SerializeField] private float _cohesionRadius = 3f;
        // [SerializeField] private float _groupDetectionRadius = 5f;
        
        [Header("Entity layers")]
        [SerializeField] private LayerMask _enemiesLayers  = default;
        [SerializeField] private LayerMask _deerGroupLayers  = default;
        
        [Header("Other")]
        [SerializeField] private float _escapingSafeDistance = 10f;
        

        public float MaxSpeed => _maxSpeed;

        public float WanderingSpeed => _wanderingSpeed;

        public float DetectionRadius => _detectionRadius;

        public LayerMask EnemiesLayers => _enemiesLayers;

        public LayerMask DeerGroupLayers => _deerGroupLayers;

        // public float GroupDetectionRadius => _groupDetectionRadius;

        public float SeparationRadius => _separationRadius;

        public float CohesionRadius => _cohesionRadius;

        public float EscapingSafeDistance => _escapingSafeDistance;
    }
}