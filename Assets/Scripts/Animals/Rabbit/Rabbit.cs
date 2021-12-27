using System.Linq;
using System.Threading.Tasks;
using SteeringBehaviors.Animals.Settings;
using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Animals.Rabbit
{
    [GenerateMonoBehaviour]
    public class Rabbit : Animal<RabbitSettings>
    {
        public Rabbit(
            AnimalMover mover,
            RabbitSettings rabbitSettings,
            [FromThisObject] Transform transform) : base(mover, transform, rabbitSettings)
        {
        
        }

        protected override async Task SeekForEntities()
        {
            // Transform[] dangers;
            while (IsAlive)
            {
                AnimalInfo.Mover.Dangers.Clear();
                if (TryFindDangers(out Transform[] dangers))
                {
                    AnimalInfo.Mover.Dangers.AddRange(dangers);
                }

                await Task.Yield();
            }
        }

        private bool TryFindDangers(out Transform[] dangers)
        {
            dangers = Physics.OverlapSphere(
                    AnimalInfo.AnimalTransform.position,
                    AnimalSettings.DangerDetectionRadius,
                    AnimalSettings.EnemiesLayers.value)
                .Select(collider => collider.transform)
                .Where(transform => transform != AnimalInfo.AnimalTransform)
                .ToArray();
            return dangers.Any();
        }
    }
}