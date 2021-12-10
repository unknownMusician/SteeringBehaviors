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

        public AnimalInfo(IMover mover, Transform animalTransform)
        {
            Mover = mover;
            AnimalTransform = animalTransform;
            EnemiesTransforms = Array.Empty<Transform>();
        }
    }
    // public sealed class AnimalInfo<TSettings> where TSettings : ScriptableObject
    // {
    //     public readonly IMover Mover;
    //     public readonly Transform AnimalTransform;
    //     // public readonly AnimalBehaviourSettings AnimalBehaviourSettings;
    //     public readonly TSettings AnimalSettings;
    //     public Transform[] EnemiesTransforms;
    //
    //     public AnimalInfo(IMover mover, Transform animalTransform, TSettings animalSettings)
    //     {
    //         Mover = mover;
    //         AnimalTransform = animalTransform;
    //         AnimalSettings = animalSettings;
    //         EnemiesTransforms = Array.Empty<Transform>();
    //     }
    // }
}