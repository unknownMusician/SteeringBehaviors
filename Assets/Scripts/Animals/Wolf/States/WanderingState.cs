using SteeringBehaviors.Animals.Settings;
using UnityEngine;

namespace SteeringBehaviors.Animals.Wolf.States
{
    public class WanderingState : AnimalState
    {
        //todo change general wolf settings constructor parameter to only necessary
        private readonly WolfSettings _wolfSettings;
        public WanderingState(AnimalInfo animalInfo, WolfSettings wolfSettings) : base(animalInfo)
        {
            _wolfSettings = wolfSettings;
        }
        
        public override void StartMoving()
        {
            #region WorkingVariant
            
            // AnimalInfo.Mover.WanderAsync(_wolfSettings.WanderingSpeed);
            
            #endregion
            
            #region TestVariant
            
            // AnimalInfo.Mover.MoveAsync(AnimalInfo.AnimalTransform.right);

            #endregion
        }
    }
}