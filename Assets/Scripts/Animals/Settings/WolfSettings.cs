using UnityEngine;

namespace SteeringBehaviors.Animals.Settings
{
    [CreateAssetMenu(fileName = "WolfSettings", menuName = "AnimalsSettings/WolfSettings", order = 0)]
    public class WolfSettings : ScriptableObject
    {
        [Header("Speed parameters")]
        [SerializeField] private float _maxSpeed = 2f;
        [SerializeField] private float _wanderingSpeed = 1f;
        
        [Header("Detection circles")]
        [SerializeField] private float _detectionRadius = 8f;
        [SerializeField] private float _friendsDetectionRadius = 1f;
        
        [Header("Entity layers")]
        [SerializeField] private LayerMask _enemiesLayers  = default;
        [SerializeField] private LayerMask _friendsLayers  = default;

        [Header("Pursuit parameters")]
        [SerializeField] private float _attackDistance = 1f;
        [SerializeField] private float _maxPursuitTime = 10f;
        [SerializeField] private float _preyLostDistance = 8f;

        [Header("Other")]
        [SerializeField] private float _lifetimeWithoutKills = 60f;

        
        public float MaxSpeed => _maxSpeed;

        public float WanderingSpeed => _wanderingSpeed;

        public float DetectionRadius => _detectionRadius;

        public LayerMask EnemiesLayers => _enemiesLayers;

        public float AttackDistance => _attackDistance;

        public float LifetimeWithoutKills => _lifetimeWithoutKills;

        public float MaxPursuitTime => _maxPursuitTime;

        public float PreyLostDistance => _preyLostDistance;

        public float FriendsDetectionRadius => _friendsDetectionRadius;

        public LayerMask FriendsLayers => _friendsLayers;
    }
}