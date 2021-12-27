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
        private readonly DeerSettings _deerSettings;

        public Deer(
            AnimalMover mover,
            DeerSettings deerSettings,
            [FromThisObject] Transform transform) : base(mover, transform, deerSettings)
        {
            
        }
        
        protected override async Task SeekForEntities()
        {
            Transform[] friends;
            Transform[] dangers;
            while (IsAlive)
            {
                if (TryFindFriends(out friends))
                {
                    AnimalInfo.Mover.Friends.Clear();
                    AnimalInfo.Mover.Friends.AddRange(friends);
                }
                
                if (TryFindDangers(out dangers))
                {
                    AnimalInfo.Mover.Dangers.Clear();
                    AnimalInfo.Mover.Friends.AddRange(dangers);
                }
                
                await Task.Yield();
            }
        }
        
        private bool TryFindDangers(out Transform[] enemies)
        {
            enemies = Physics.OverlapSphere(
                    AnimalInfo.AnimalTransform.position, 
                    _deerSettings.DetectionRadius,
                    _deerSettings.EnemiesLayers)
                .Select(collider => collider.transform)
                .ToArray();
            
            return enemies.Any();
        }
        
        private bool TryFindFriends(out Transform[] nearestDeer)
        {
            nearestDeer = Physics.OverlapSphere(
                    AnimalInfo.AnimalTransform.position, 
                    _deerSettings.CohesionRadius,
                    _deerSettings.DeerGroupLayers)
                .Select(collider => collider.transform)
                .Where(transform => transform != AnimalInfo.AnimalTransform)
                .ToArray();
            
            return nearestDeer.Any();
        }
    }
}