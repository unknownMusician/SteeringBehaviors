using System;
using System.Linq;
using SteeringBehaviors.Animals.Settings;
using SteeringBehaviors.Hunt;
using UnityEngine;
using UnityEngine.Rendering;

namespace SteeringBehaviors.Animals.Wolf.States
{
    public class PursuitState : AnimalState
    {
        private readonly WolfSettings _wolfSettings;
        private const float TargetDeathDelay = 1f;
        
        public PursuitState(AnimalInfo animalInfo, WolfSettings wolfSettings) : base(animalInfo)
        {
            _wolfSettings = wolfSettings;
        }

        public override void StartMoving()
        {
            #region WorkingVariant
            // Transform target = FindNearestVictim();
            // AnimalInfo.Mover.PursueAsync(target, 
            //     _wolfSettings.PreyLostDistance, _wolfSettings.MaxPursuitTime, _wolfSettings.MaxSpeed);
            
            #endregion
            
            #region TestVariant
            
            // Transform target = FindNearestVictim();
            // AnimalInfo.Mover.PursueAsync(target, 
            //     _wolfSettings.PreyLostDistance, _wolfSettings.MaxPursuitTime);
            //
            // // float lengthToTarget = Vector3.Distance(AnimalInfo.AnimalTransform.position, target.position);
            // // if (TryKillTarget(target, lengthToTarget))
            // // {
            // //     // todo stop wolf moving of 2 sec
            // // }
            // // // todo continue pursue target
            // // AnimalInfo.Mover.PursueAsync(target, _wolfSettings.WolfDetectionRadius, _wolfSettings.MaxPursuitTime);

            #endregion
        }

        private Transform FindNearestVictim()
        {
            return AnimalInfo.EnemiesTransforms
                .OrderBy(transform => (AnimalInfo.AnimalTransform.position - transform.position).magnitude)
                .First();
        }

        private bool FindHunterOrNearestVictim(out Transform victim)
        {
            throw new NotImplementedException();
        }

        private bool TryKillTarget(Transform target, float lengthToTarget)
        {
            if (lengthToTarget < _wolfSettings.AttackDistance)
            {
                // todo replace GetComponent from update
                if (!target.TryGetComponent(out Killable killable))
                {
                    throw new Exception("Target GameObject hasn't Killable component");
                }

                killable.KillMe(TargetDeathDelay);
                return true;
            }

            return false;
        }
    }
}