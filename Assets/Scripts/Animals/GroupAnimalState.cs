using System;
using UnityEngine;

namespace SteeringBehaviors.Animals
{
    public abstract class GroupAnimalState : AnimalState 
    {
        protected readonly GroupAnimalInfo GroupAnimalInfo;

        protected GroupAnimalState(GroupAnimalInfo groupAnimalInfo) : base(groupAnimalInfo)
        {
            GroupAnimalInfo = groupAnimalInfo;
        }

    }
}