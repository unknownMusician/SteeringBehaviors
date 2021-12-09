namespace SteeringBehaviors.Animals.States
{
    public sealed class WanderingState : AnimalState, IState
    {
        public WanderingState(AnimalInfo animalInfo) : base(animalInfo)
        {
            
        }
        
        public override void StartMoving()
        {
            AnimalInfo.Mover.StopMoving();
            AnimalInfo.Mover.StartWalking(AnimalInfo.AnimalTransform.position, 
                AnimalInfo.AnimalBehaviourSettings.AnimalDetectionRadius);
        }
    }
}