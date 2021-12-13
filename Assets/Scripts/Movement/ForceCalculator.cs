using System;
using System.Linq;
using SteeringBehaviors.Movement.Settings;
using UnityEngine;
using Random = UnityEngine.Random;


namespace SteeringBehaviors.Movement
{
    public sealed class ForceCalculator
    {
        private readonly MovementSettings _movementSettings;
        
        public ForceCalculator(MovementSettings movementSettings)
        {
            _movementSettings = movementSettings;
        }

        #region Wandering

        public Vector3 GetWanderingVelocity(float wanderingSpeed, Vector3 currentPosition, Vector3 currentDirection,
            ref int angle)
        {
            var rnd = Random.value;
            if (rnd < 0.5)
            {
                angle += _movementSettings.AngleStep;
            }
            else if (rnd < 1)
            {
                angle -= _movementSettings.AngleStep;
            }

            Vector3 futurePosition = currentPosition + currentDirection * _movementSettings.CircleDistance;
            var vector = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad)) *
                         _movementSettings.CircleRadius;

            return (futurePosition + vector - currentPosition).normalized * wanderingSpeed;
        }

        public Vector3 GetWanderingWithGroupVelocity(Transform animal, Transform[] group, ref int angle,
            float wanderingSpeed)
        {
            // Vector3 wanderingVelocity =
            //     GetWanderingVelocity(wanderingSpeed, animal.position, animal.forward, ref angle);
            // foreach (Transform friend in group)
            // {
            //     wanderingVelocity += 
            // }
            return default;
        }

        #endregion

        #region Escaping

        public Vector3 GetEscapingVelocity(Transform animal, Transform[] escapingFrom, float escapingSpeed)
        {
            Vector3 escapingDirection = default;
            foreach (Transform enemy in escapingFrom)
            {
                Vector3 fromEnemyDirection = animal.position - enemy.position;
                escapingDirection += fromEnemyDirection;
            }

            return escapingDirection.normalized * escapingSpeed;
        }

        public Vector3 GetEscapingWithGroupVelocity(Transform animal, Transform[] enemies, Transform[] friends,
            float escapingSpeed)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Pursuit

        public Vector3 GetPursuitVelocity(Transform animal, Transform prey, float pursuitSpeed)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region GroupVelocity

        private Vector3 GetCohesionVelocity(Transform animal, Transform[] group)
        {
            Vector3 centerPoint = default;
            foreach (Transform friend in group)
            {
                centerPoint += friend.position;
            }
            centerPoint /= group.Length;
            Vector3 toCenter = centerPoint - animal.position;
            return toCenter.normalized;
        }

        private Vector3 GetSeparationDirection(Transform animal, Transform[] group)
        {
            return -GetCohesionVelocity(animal, group);
        }

        // private Vector3 GetAlignmentDirection(Transform animal, Transform[] group)
        // {
        //     Vector3 alignmentDirection = default;
        //     foreach (Transform friend in group)
        //     {
        //         friend.alignmentDirection += (friend.position - animal.position);
        //     }
        //
        //     return alignmentDirection.normalized;
        // }

        #endregion
    }
}