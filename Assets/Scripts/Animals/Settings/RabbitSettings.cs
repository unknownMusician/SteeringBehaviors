using UnityEngine;

namespace SteeringBehaviors.Animals.Settings
{
    [CreateAssetMenu(fileName = "RabbitSettings", menuName = "AnimalsSettings/RabbitSettings", order = 0)]
    public class RabbitSettings : ScriptableObject
    {
        [Header("Speed parameters")]
        [SerializeField] private float _maxSpeed = 10f;
        [SerializeField] private float _wanderingSpeed = 5f;
        
        [Header("Detection circles")]
        [SerializeField] private float _dangerDetectionRadius = 5f;
        
        [Header("Entity layers")]
        [SerializeField] private LayerMask _enemiesLayers  = default;
        
        [Header("Escaping parameters")]
        [SerializeField] private float _escapingSafeDistance = 10f;


        public float MaxSpeed => _maxSpeed;

        public float WanderingSpeed => _wanderingSpeed;
        public float DangerDetectionRadius => _dangerDetectionRadius;

        public float EscapingSafeDistance => _escapingSafeDistance;

        public LayerMask EnemiesLayers => _enemiesLayers;
    }
}