using UnityEngine;

namespace SteeringBehaviors.Animals.Settings
{
    [CreateAssetMenu(fileName = "WolfSettings", menuName = "AnimalsSettings/WolfSettings", order = 0)]
    public class WolfSettings : ScriptableObject
    {
        [Header("Wolves settings")]
        [SerializeField] private float _wolfVelocity = 2f;
        [SerializeField] private float _wolfDetectionRadius = 10f;
        [SerializeField] private LayerMask _wolfDetectionLayers = default;
        [SerializeField] private float _wolfLifeTimeWithoutKills = 60f;
        [SerializeField] private float _attackDistance = 0.2f;
        [SerializeField] private float _maxPursuitTime = 10f;
        
        public float WolfDetectionRadius => _wolfDetectionRadius;
        public LayerMask WolfDetectionLayers => _wolfDetectionLayers;
        
        public float WolfLifeTimeWithoutKills => _wolfLifeTimeWithoutKills;
        
        public float WolfVelocity => _wolfVelocity;
        public float AttackDistance => _attackDistance;

        public float MaxPursuitTime => _maxPursuitTime;
    }
}