using SteeringBehaviors.Animals.Settings;

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
            AnimalInfo.Mover.StartWalking(AnimalInfo.AnimalTransform.position, _wolfSettings.WolfDetectionRadius);
        }
    }
}