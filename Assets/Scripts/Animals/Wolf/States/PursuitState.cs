using SteeringBehaviors.Animals.Settings;

namespace SteeringBehaviors.Animals.Wolf.States
{
    public class PursuitState : AnimalState
    {
        private readonly WolfSettings _wolfSettings;
        public PursuitState(AnimalInfo animalInfo, WolfSettings wolfSettings) : base(animalInfo)
        {
            _wolfSettings = wolfSettings;
        }

        public override void StartMoving()
        {
            throw new System.NotImplementedException();
        }
    }
}