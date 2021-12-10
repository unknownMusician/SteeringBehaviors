using UnityEngine;

namespace SteeringBehaviors.Animals.Settings
{
    [CreateAssetMenu(fileName = "DeerSettings", menuName = "AnimalsSettings/DeerSettings", order = 0)]
    public class DeerSettings : ScriptableObject
    {
        [Header("Deer settings")]
        [SerializeField] private float _deerVelocity = 1f;
        [SerializeField] private float _deerDetectionRadius = 13f;
        [SerializeField] private LayerMask _deerDetectionLayers = default;
        
        public float DeerDetectionRadius => _deerDetectionRadius;
        public LayerMask DeerDetectionLayers => _deerDetectionLayers;
        public float DeerVelocity => _deerVelocity;
    }
}