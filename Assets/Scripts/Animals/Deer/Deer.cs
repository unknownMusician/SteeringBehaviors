using System.Linq;
using System.Threading.Tasks;
using SteeringBehaviors.Animals.Settings;
using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Animals.Deer
{
    [GenerateMonoBehaviour]
    public sealed class Deer : Animal<DeerSettings>
    {
        public Deer(
            AnimalMover mover,
            DeerSettings deerSettings,
            [FromThisObject] Transform transform) : base(mover, transform, deerSettings)
        {
            
        }
        
        protected override async Task SeekForEntities()
        {
            // Transform[] friends;
            // Transform[] dangers;
            while (IsAlive)
            {
                AnimalInfo.Mover.Friends.Clear();
                if (TryFindFriends(out Transform[] friends))
                {
                    AnimalInfo.Mover.Friends.AddRange(friends);
                }
                
                AnimalInfo.Mover.Dangers.Clear();
                if (TryFindDangers(out Transform[] dangers))
                {
                    AnimalInfo.Mover.Dangers.AddRange(dangers);
                }
                
                await Task.Yield();
            }
        }
        
        private bool TryFindDangers(out Transform[] enemies)
        {
            enemies = Physics.OverlapSphere(
                    AnimalInfo.AnimalTransform.position, 
                    AnimalSettings.DangerDetectionRadius,
                    AnimalSettings.DangersLayers)
                .Select(collider => collider.transform)
                .ToArray();
            
            return enemies.Any();
        }
        
        private bool TryFindFriends(out Transform[] nearestDeer)
        {
            nearestDeer = Physics.OverlapSphere(
                    AnimalInfo.AnimalTransform.position, 
                    AnimalSettings.FriendsDetectionRadius,
                    AnimalSettings.FriendsLayers)
                .Select(collider => collider.transform)
                .Where(transform => transform != AnimalInfo.AnimalTransform)
                .ToArray();
            
            return nearestDeer.Any();
        }
    }
}