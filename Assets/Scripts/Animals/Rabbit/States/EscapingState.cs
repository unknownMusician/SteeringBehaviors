using SteeringBehaviors.Animals.Settings;

namespace SteeringBehaviors.Animals.Rabbit.States
{
    public class EscapingState : AnimalState
    {
        private readonly RabbitSettings _rabbitSettings;
        public EscapingState(AnimalInfo animalInfo, RabbitSettings rabbitSettings) : base(animalInfo)
        {
            _rabbitSettings = rabbitSettings;
        }

        public override void StartMoving()
        {
            throw new System.NotImplementedException();
        }
    }
}