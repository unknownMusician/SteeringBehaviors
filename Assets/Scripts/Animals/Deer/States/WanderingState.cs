using SteeringBehaviors.Animals.Settings;

namespace SteeringBehaviors.Animals.Deer.States
{
    public class WanderingState : GroupAnimalState
    {
        private readonly DeerSettings _deerSettings;
        public WanderingState(GroupAnimalInfo animalInfo, DeerSettings deerSettings) : base(animalInfo)
        {
            _deerSettings = deerSettings;
        }

        public override void StartMoving()
        {
            #region WorkingVariant
            
            AnimalInfo.Mover.WanderWithGroupAsync(_deerSettings.WanderingSpeed, GroupAnimalInfo.FriendsTransforms);
            
            #endregion
            
            #region TestVariant
            
            // AnimalInfo.Mover.MoveAsync(-AnimalInfo.AnimalTransform.right);

            #endregion
        }
    }
}