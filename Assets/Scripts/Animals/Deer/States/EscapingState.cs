using SteeringBehaviors.Animals.Settings;

namespace SteeringBehaviors.Animals.Deer.States
{
    public class EscapingState : AnimalState<GroupAnimalInfo>
    {
        private readonly DeerSettings _deerSettings;
        public EscapingState(GroupAnimalInfo animalInfo, DeerSettings deerSettings) : base(animalInfo)
        {
            _deerSettings = deerSettings;
        }

        public override void StartMoving()
        {
            #region WorkingVariant
            
            AnimalInfo.Mover.EscapeWithGroupAsync(
                AnimalInfo.EnemiesTransforms, 
                AnimalInfo.FriendsTransforms, 
                _deerSettings.EscapingSafeDistance, 
                _deerSettings.WanderingSpeed);
            
            #endregion
            
            #region TestVariant
            
            // AnimalInfo.Mover.MoveAsync(-AnimalInfo.AnimalTransform.right);

            #endregion
        }
    }
}