using UnityEngine;

namespace SteeringBehaviors.Animals.Settings
{
    [CreateAssetMenu(fileName = "RabbitSettings", menuName = "AnimalsSettings/RabbitSettings", order = 0)]
    public class RabbitSettings : ScriptableObject
    {
        [Header("Rabbits settings")]
        [SerializeField] private float _rabbitVelocity = 3f;
        [SerializeField] private float _rabbitDetectionRadius = 5f;
        [SerializeField] private LayerMask _rabbitDetectionLayers  = default;
        
        public float RabbitDetectionRadius => _rabbitDetectionRadius;
        public LayerMask RabbitDetectionLayers => _rabbitDetectionLayers;
        public float RabbitVelocity => _rabbitVelocity;
    }
}