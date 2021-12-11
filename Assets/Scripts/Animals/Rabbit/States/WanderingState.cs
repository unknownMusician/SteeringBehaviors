using SteeringBehaviors.Animals.Settings;
using UnityEngine;

namespace SteeringBehaviors.Animals.Rabbit.States
{
    public class WanderingState : AnimalState
    {
        //todo change general rabbit settings constructor parameter to only necessary
        private readonly RabbitSettings _rabbitSettings;
        public WanderingState(AnimalInfo animalInfo, RabbitSettings rabbitSettings) : base(animalInfo)
        {
            _rabbitSettings = rabbitSettings;
        }
        
        public override void StartMoving()
        {
            AnimalInfo.Mover.WalkAsync(AnimalInfo.AnimalTransform.position + Vector3.forward, _rabbitSettings.RabbitDetectionRadius);
            // AnimalInfo.Mover.MoveAsync(AnimalInfo.AnimalTransform.forward); 
        }
    }
}