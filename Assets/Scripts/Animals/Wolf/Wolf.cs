using System.Linq;
using System.Threading.Tasks;
using Generated.SteeringBehaviors.Hunt;
using SteeringBehaviors.Animals.Settings;
using SteeringBehaviors.Hunt;
using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Animals.Wolf
{
    [GenerateMonoBehaviour]
    public class Wolf : Animal<WolfSettings>
    {
        public Wolf(
            Mover mover,
            WolfSettings wolfSettings,
            [FromThisObject] Transform transform) : base(mover, transform, wolfSettings) 
        {
            
        }
        
        protected override async Task SeekForEntities()
        {
            Transform[] preys;
            while (IsAlive)
            {
                AnimalInfo.Mover.Preys.Clear();
                if (TryFindPreys(out preys))
                {
                    AnimalInfo.Mover.Preys.AddRange(preys);
                }

                if (TryFindKillableEnemy(out Killable victim))
                {
                    victim.KillMe(1f);
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

        private bool TryFindKillableEnemy(out Killable victim)
        {
            Transform[] enemies = Physics.OverlapSphere(
                    AnimalInfo.AnimalTransform.position, 
                    AnimalSettings.AttackDistance,
                    AnimalSettings.EnemiesLayers.value)
                .Select(collider => collider.transform)
                .ToArray();
            victim = enemies.FirstOrDefault()?.GetComponent<KillableComponent>().Killable;

            return victim != null;
        }
    }
}