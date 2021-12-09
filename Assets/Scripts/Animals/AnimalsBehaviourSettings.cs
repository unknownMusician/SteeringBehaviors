using UnityEngine;

namespace SteeringBehaviors.Animals
{
    [CreateAssetMenu(fileName = "Settings", menuName = "AnimalsBehaviourSettings", order = 0)]
    public class AnimalsBehaviourSettings : ScriptableObject
    {
        [Header("Rabbits settings")]
        public float RabbitDetectionRadius = 5f;
        public LayerMask RabbitDetectionLayers  = default;

        [Header("Wolves settings")]
        public float WolfDetectionRadius = 10f;
        public LayerMask WolfDetectionLayers = default;
        public float WolfLifeTimeWithoutKills = 60;
        public float WolfPursueTime = 10f;
        // public readonly float WolfLostDistance = ;
        
        [Header("Deer settings")]
        public float DeerDetectionRadius = 13f;
        public LayerMask DeerDetectionLayers = default;

    }
}