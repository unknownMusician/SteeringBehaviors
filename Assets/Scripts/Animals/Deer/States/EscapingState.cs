using SteeringBehaviors.Animals.Settings;

namespace SteeringBehaviors.Animals.Deer.States
{
    public class EscapingState : AnimalState
    {
        private readonly DeerSettings _deerSettings;
        public EscapingState(AnimalInfo animalInfo, DeerSettings deerSettings) : base(animalInfo)
        {
            _deerSettings = deerSettings;
        }

        public override void StartMoving()
        {
            throw new System.NotImplementedException();
        }
    }
}