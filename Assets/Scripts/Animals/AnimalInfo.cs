using System;
using SteeringBehaviors.Movement;
using UnityEngine;

namespace SteeringBehaviors.Animals
{
    public sealed class AnimalInfo
    {
        public readonly IMover Mover;
        public readonly Transform AnimalTransform;
        public Transform[] EnemiesTransforms;
        public readonly AnimalBehaviourSettings AnimalBehaviourSettings;

        public AnimalInfo(IMover mover, Transform animalTransform,  AnimalBehaviourSettings animalBehaviourSettings)
        {
            Mover = mover;
            AnimalTransform = animalTransform;
            AnimalBehaviourSettings = animalBehaviourSettings;
            EnemiesTransforms = Array.Empty<Transform>();
        }
    }
}