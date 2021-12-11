using UnityEngine;

namespace SteeringBehaviors.Animals.Settings
{
    [CreateAssetMenu(fileName = "RabbitSettings", menuName = "AnimalsSettings/RabbitSettings", order = 0)]
    public class RabbitSettings : ScriptableObject
    {
        [Header("Rabbits settings")]
        [SerializeField] private float _maxSpeed = 3f;
        [SerializeField] private float _wanderingSpeed = 1f;
        [SerializeField] private float _detectionRadius = 5f;
        // [SerializeField] private LayerMask _enemiesLayers  = default;
        [SerializeField] private float _safeDistance = 10f;


        public float MaxSpeed => _maxSpeed;

        public float WanderingSpeed => _wanderingSpeed;
        public float DetectionRadius => _detectionRadius;

        // public LayerMask EnemiesLayers => _enemiesLayers;

        public float SafeDistance => _safeDistance;
    }
}