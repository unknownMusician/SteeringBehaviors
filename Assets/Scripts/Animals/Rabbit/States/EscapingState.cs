using SteeringBehaviors.Animals.Settings;
using UnityEngine;

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
            #region WorkingVariant

            AnimalInfo.Mover.EscapeFromAsync(
                AnimalInfo.EnemiesTransforms,
                _rabbitSettings.SafeDistance,
                _rabbitSettings.MaxSpeed);
            
            #endregion
            
            #region TestVariant
            
            // AnimalInfo.Mover.MoveAsync(GetEscapeDirection());

            #endregion
        }

        private Vector3 GetEscapeDirection()
        {
            Vector3 escapeDirection = default;
            foreach (Transform enemy in AnimalInfo.EnemiesTransforms)
            {
                Vector3 fromEnemyDirection = AnimalInfo.AnimalTransform.position - enemy.position;
                escapeDirection += fromEnemyDirection;
            }

            return escapeDirection.normalized;
        }
    }
}