namespace SteeringBehaviors.Animals.States
{
    public sealed class EscapingState : AnimalState, IState
    {
        public EscapingState(AnimalInfo animalInfo) : base(animalInfo)
        {
            
        }
        
        public override void StartMoving()
        {
            AnimalInfo.Mover.StopMoving();
            AnimalInfo.Mover.StartEscapingFrom(AnimalInfo.EnemiesTransforms, 
                AnimalInfo.AnimalBehaviourSettings.AnimalDetectionRadius);
        }
    }
}