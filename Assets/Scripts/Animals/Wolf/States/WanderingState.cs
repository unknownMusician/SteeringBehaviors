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
            // Vector3 wanderingDirection =
            //     (AnimalInfo.AnimalTransform.rotation *= new Quaternion(0f, 1f, 0f, 0f)).eulerAngles;
            // AnimalInfo.Mover.MoveAsync(wanderingDirection);
            
            AnimalInfo.Mover.MoveAsync(-AnimalInfo.AnimalTransform.forward); 

            // AnimalInfo.Mover.StartWalking(AnimalInfo.AnimalTransform.position, _wolfSettings.WolfDetectionRadius);
        }
    }
}