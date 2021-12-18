using UnityEngine;

namespace SteeringBehaviors.Animals.Settings
{
    [CreateAssetMenu(fileName = "DeerSettings", menuName = "AnimalsSettings/DeerSettings", order = 0)]
    public class DeerSettings : ScriptableObject
    {
        [Header("Speed parameters")]
        [SerializeField] private float _maxSpeed = 8f;
        [SerializeField] private float _wanderingSpeed = 4f;
        
        [Header("Detection circles")]
        [SerializeField] private float _dangerDetectionRadius = 10f;
        [SerializeField] private float _friendsDetectionRadius = 8f;
        // [SerializeField] private float _separationRadius = 1f;
        // [SerializeField] private float _cohesionRadius = 3f;
        // [SerializeField] private float _groupDetectionRadius = 5f;
        
        [Header("Entity layers")]
        [SerializeField] private LayerMask _dangersLayers  = default;
        [SerializeField] private LayerMask _friendsLayers  = default;
        
        [Header("Escaping parameters")]
        [SerializeField] private float _escapingSafeDistance = 10f;
        

        public float MaxSpeed => _maxSpeed;

        public float WanderingSpeed => _wanderingSpeed;

        public float DangerDetectionRadius => _dangerDetectionRadius;

        public LayerMask DangersLayers => _dangersLayers;

        public LayerMask FriendsLayers => _friendsLayers;

        public float EscapingSafeDistance => _escapingSafeDistance;

        public float FriendsDetectionRadius => _friendsDetectionRadius;
    }
}