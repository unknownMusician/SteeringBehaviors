using SteeringBehaviors.Animals.Settings;
using UnityEngine;

namespace SteeringBehaviors.Animals.Rabbit.States
{
    public class WanderingState : AnimalState<AnimalInfo>
    {
        //todo change general rabbit settings constructor parameter to only necessary
        private readonly RabbitSettings _rabbitSettings;
        public WanderingState(AnimalInfo animalInfo, RabbitSettings rabbitSettings) : base(animalInfo)
        {
            _rabbitSettings = rabbitSettings;
        }
        
        public override void StartMoving()
        {
            #region WorkingVariant
            
            AnimalInfo.Mover.WanderAsync(_rabbitSettings.WanderingSpeed);
            
            #endregion
            
            #region TestVariant
            
            // AnimalInfo.Mover.WalkAsync(AnimalInfo.AnimalTransform.position, _rabbitSettings.DetectionRadius, 1f);
            // AnimalInfo.Mover.MoveAsync(-AnimalInfo.AnimalTransform.right);

            #endregion
        }
    }
}