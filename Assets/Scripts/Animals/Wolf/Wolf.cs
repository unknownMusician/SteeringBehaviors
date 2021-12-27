using System.Linq;
using System.Threading.Tasks;
using SteeringBehaviors.Animals.Settings;
using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Animals.Wolf
{
    [GenerateMonoBehaviour]
    public sealed class Wolf : Animal<WolfSettings>
    {
        public Wolf(
            AnimalMover mover,
            WolfSettings wolfSettings,
            [FromThisObject] Transform transform) : base(mover, transform, wolfSettings) 
        {
            
        }
        
        protected override async Task SeekForEntities()
        {
            Transform[] preys;
            while (IsAlive)
            {
                if (TryFindPreys(out preys))
                {
                    AnimalInfo.Mover.Preys.Clear();
                    AnimalInfo.Mover.Preys.AddRange(preys);
                }
                
                await Task.Yield();
            }
        }
        
        private bool TryFindPreys(out Transform[] enemies)
        {
            enemies = Physics.OverlapSphere(
                    AnimalInfo.AnimalTransform.position, 
                    AnimalSettings.DetectionRadius,
                    AnimalSettings.EnemiesLayers.value)
                .Select(collider => collider.transform)
                .ToArray();
            return enemies.Any();
        }
    }
}