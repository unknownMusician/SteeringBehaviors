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
            while (IsAlive)
            {
                AnimalInfo.Mover.Preys.Clear();
                if (TryFindPrey(out Transform prey))
                {
                    AnimalInfo.Mover.Preys.Add(prey);
                }

                AnimalInfo.Mover.Friends.Clear();
                if (TryFindFriends(out Transform[] friends))
                {
                    AnimalInfo.Mover.Friends.AddRange(friends);
                }
                
                if (TryFindKillableEnemy(out Killable victim))
                {
                    victim.KillMe();
                    AnimalInfo.Mover.Preys.Clear();
                }
                
                
                await Task.Yield();
            }
        }
        
        // private bool TryFindPreys(out Transform[] enemies)
        // {
        //     enemies = Physics.OverlapSphere(
        //             AnimalInfo.AnimalTransform.position, 
        //             AnimalSettings.DetectionRadius,
        //             AnimalSettings.EnemiesLayers.value)
        //         .Select(collider => collider.transform)
        //         .ToArray();
        //     return enemies.Any();
        // }
        
        private bool TryFindPrey(out Transform enemy)
        {
            Transform[] enemies = Physics.OverlapSphere(
                    AnimalInfo.AnimalTransform.position,
                    AnimalSettings.DetectionRadius,
                    AnimalSettings.EnemiesLayers.value)
                .Select(collider => collider.transform)
                .ToArray();
            enemy = enemies
                .OrderBy(transform => Vector3.Distance(transform.position, AnimalInfo.AnimalTransform.position))
                .FirstOrDefault();
            return enemy != null;
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
        
        private bool TryFindFriends(out Transform[] otherWolves)
        {
            otherWolves = Physics.OverlapSphere(
                    AnimalInfo.AnimalTransform.position, 
                    AnimalSettings.FriendsDetectionRadius,
                    AnimalSettings.FriendsLayers.value)
                .Select(collider => collider.transform)
                .Where(transform => transform != AnimalInfo.AnimalTransform)
                .ToArray();
            
            return otherWolves.Any();
        }
    }
}