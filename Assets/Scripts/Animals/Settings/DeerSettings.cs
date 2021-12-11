using UnityEngine;

namespace SteeringBehaviors.Animals.Settings
{
    [CreateAssetMenu(fileName = "DeerSettings", menuName = "AnimalsSettings/DeerSettings", order = 0)]
    public class DeerSettings : ScriptableObject
    {
        [Header("Deer settings")]
        [SerializeField] private float _maxSpeed = 3f;
        [SerializeField] private float _wanderingSpeed = 1f;
        [SerializeField] private float _enemyDetectionRadius = 5f;
        [SerializeField] private float _groupDetectionRadius = 5f;
        [SerializeField] private LayerMask _enemiesLayers  = default;
        [SerializeField] private LayerMask _deerGroupLayers  = default;
        [SerializeField] private float _safeDistance = 10f;
        

        public float MaxSpeed => _maxSpeed;

        public float WanderingSpeed => _wanderingSpeed;

        public float EnemyDetectionRadius => _enemyDetectionRadius;

        public LayerMask EnemiesLayers => _enemiesLayers;

        public LayerMask DeerGroupLayers => _deerGroupLayers;

        public float GroupDetectionRadius => _groupDetectionRadius;
    }
}