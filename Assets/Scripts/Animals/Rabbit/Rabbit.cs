using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using SteeringBehaviors.Animals.Settings;
using SteeringBehaviors.Hunt;
using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Animals.Rabbit
{
    [GenerateMonoBehaviour]
    public class Rabbit : Animal<RabbitSettings>
    {
        // public readonly Killable Killable;
        public Rabbit(
            Mover mover,
            // Killable killable,
            RabbitSettings rabbitSettings,
            [FromThisObject] Transform transform) : base(mover, transform, rabbitSettings)
        {
            // Killable = transform.gameObject.AddComponent<KillableComponent>().Killable;
            // Killable = killable;
        }

        protected override async Task SeekForEntities()
        {
            Transform[] dangers;
            while (IsAlive)
            {
                AnimalInfo.Mover.Dangers.Clear();
                if (TryFindDangers(out dangers))
                {
                    AnimalInfo.Mover.Dangers.AddRange(dangers);
                }

                // Debug.Log(AnimalInfo.Mover.Dangers.Count);
                await Task.Yield();
            }
        }

        private bool TryFindDangers(out Transform[] dangers)
        {
            dangers = Physics.OverlapSphere(
                    AnimalInfo.AnimalTransform.position,
                    AnimalSettings.DangerDetectionRadius)
                .Select(collider => collider.transform)
                .Where(transform => transform != AnimalInfo.AnimalTransform)
                .ToArray();
            return dangers.Any();
        }
    }
}