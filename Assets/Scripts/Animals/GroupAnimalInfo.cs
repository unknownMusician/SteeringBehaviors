using System;
using SteeringBehaviors.Movement;
using UnityEngine;

namespace SteeringBehaviors.Animals
{
    public sealed class GroupAnimalInfo : AnimalInfo
    {
        public Transform[] FriendsTransforms;

        public GroupAnimalInfo(IMover mover, Transform animalTransform) : base(mover, animalTransform)
        {
            FriendsTransforms = Array.Empty<Transform>();
        }
    }
}