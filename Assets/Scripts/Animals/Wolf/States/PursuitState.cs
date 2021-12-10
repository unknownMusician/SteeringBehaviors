using System;
using System.Linq;
using SteeringBehaviors.Animals.Settings;
using SteeringBehaviors.Hunt;
using UnityEngine;

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
            FindHunterOrNearestVictim(out Transform target);
            float lengthToTarget = (AnimalInfo.AnimalTransform.position - target.position).magnitude;
            if (TryKillTarget(target, lengthToTarget))
            {
                // todo stop wolf moving of 2 sec
            }
            // todo continue pursue target
            // AnimalInfo.Mover.Pursue(target, _wolfSettings.WolfDetectionRadius, _wolfSettings.MaxPursuitTime);
        }

        private Transform FindNearestVictim()
        {
            return AnimalInfo.EnemiesTransforms
                .OrderBy(transform => (AnimalInfo.AnimalTransform.position - transform.position).magnitude)
                .First();
        }

        private void FindHunterOrNearestVictim(out Transform victim)
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