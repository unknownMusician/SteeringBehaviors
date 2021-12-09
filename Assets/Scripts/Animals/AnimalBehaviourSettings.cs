using UnityEngine;

namespace SteeringBehaviors.Animals
{
    public class AnimalBehaviourSettings
    {
        public readonly float AnimalDetectionRadius;
        public readonly LayerMask AnimalDetectionLayers;

        public AnimalBehaviourSettings(float animalDetectionRadius, LayerMask animalDetectionLayers)
        {
            AnimalDetectionRadius = animalDetectionRadius;
            AnimalDetectionLayers = animalDetectionLayers;
        }
    }
}