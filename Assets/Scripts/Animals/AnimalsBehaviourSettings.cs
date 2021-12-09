using UnityEngine;
using UnityEngine.Serialization;

namespace SteeringBehaviors.Animals
{
    [CreateAssetMenu(fileName = "Settings", menuName = "AnimalsBehaviourSettings", order = 0)]
    public class AnimalsBehaviourSettings : ScriptableObject
    {
        [Header("Rabbits settings")]
        [SerializeField] private float _rabbitVelocity = 3f;
        [SerializeField] private float _rabbitDetectionRadius = 5f;
        [SerializeField] private LayerMask _rabbitDetectionLayers  = default;

        [FormerlySerializedAs("_rabbitVelocity")]
        [Header("Wolves settings")]
        [SerializeField] private float _wolfVelocity = 2f;
        [SerializeField] private float _wolfDetectionRadius = 10f;
        [SerializeField] private LayerMask _wolfDetectionLayers = default;
        [SerializeField] private float _wolfLifeTimeWithoutKills = 60;
        [SerializeField] private float _wolfPursueTime = 10f;
        // public readonly float WolfLostDistance = ;
        
        [Header("Deer settings")]
        [SerializeField] private float _deerVelocity = 1f;
        [SerializeField] private float _deerDetectionRadius = 13f;
        [SerializeField] private LayerMask _deerDetectionLayers = default;

        public float RabbitDetectionRadius => _rabbitDetectionRadius;
        public LayerMask RabbitDetectionLayers => _rabbitDetectionLayers;
        public float RabbitVelocity => _rabbitVelocity;


        public float WolfDetectionRadius => _wolfDetectionRadius;
        public LayerMask WolfDetectionLayers => _wolfDetectionLayers;
        public float WolfLifeTimeWithoutKills => _wolfLifeTimeWithoutKills;
        public float WolfPursueTime => _wolfPursueTime;
        public float WolfVelocity => _wolfVelocity;

        
        public float DeerDetectionRadius => _deerDetectionRadius;
        public LayerMask DeerDetectionLayers => _deerDetectionLayers;
        public float DeerVelocity => _deerVelocity;
    }
}