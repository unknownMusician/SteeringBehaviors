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
        [SerializeField] private float _wolfLifeTimeWithoutKills = 60;
        [SerializeField] private float _wolfPursueTime = 10f;
        
        public float WolfDetectionRadius => _wolfDetectionRadius;
        public LayerMask WolfDetectionLayers => _wolfDetectionLayers;
        public float WolfLifeTimeWithoutKills => _wolfLifeTimeWithoutKills;
        public float WolfPursueTime => _wolfPursueTime;
        public float WolfVelocity => _wolfVelocity;
    }
}