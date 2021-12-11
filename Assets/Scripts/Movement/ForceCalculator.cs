using UnityEngine;


namespace SteeringBehaviors.Movement
{
    public sealed class ForceCalculator
    {
        private const int _wanderAngleStep = 3;
        private const float _wanderCircleDistance = 3f;
        private const float _wanderCircleRadius = 1f;
        
        public Vector3 GetEscapingVelocity(Transform[] escapingFrom, float escapingSpeed, Vector3 currentPosition)
        {
            Vector3 escapingDirection = default;
            foreach (Transform enemy in escapingFrom)
            {
                Vector3 fromEnemyDirection = currentPosition - enemy.position;
                escapingDirection += fromEnemyDirection;
            }

            return escapingDirection.normalized * escapingSpeed;
        }

        public Vector3 GetWanderingVelocity(float wanderingSpeed, Vector3 currentPosition, Vector3 currentDirection, ref int angle)
        {
            var rnd = Random.value;
            if (rnd < 0.5)
            {
                angle+= _wanderAngleStep;
            } else if (rnd < 1)
            {
                angle-= _wanderAngleStep;
            }
            
            Vector3 futurePosition = currentPosition + currentDirection * _wanderCircleDistance;
            var vector = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad),0, Mathf.Sin(angle * Mathf.Deg2Rad)) * _wanderCircleRadius;

            return (futurePosition + vector - currentPosition).normalized * wanderingSpeed;
        }
    }
}