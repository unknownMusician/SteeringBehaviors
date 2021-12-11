using UnityEngine;


namespace SteeringBehaviors.Movement
{
    public sealed class ForceCalculator
    {
        private const float _wanderAngleStep = 15f;
        private const float _wanderCircleDistance = 1f;
        private const float _wanderCircleRadius = 1f;
        
        public Vector3 GetVelocityFromEnemies(Transform[] escapingFrom)
        {
            return default;
        }

        public Vector3 Wandering(Vector3 currentPosition, Vector3 currentDirection)
        {
            var rnd = Random.value;
            if (rnd < 0.5)
            {
                angle+= angleChangeStep;
            } else if (rnd < 1)
            {
                angle-= angleChangeStep;
            }
            
            Vector3 futurePosition = currentPosition + currentDirection * _wanderCircleDistance;
            var vector = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad),0, Mathf.Sin(angle * Mathf.Deg2Rad)) * _wanderCircleRadius;

            return (futurePos + vector - transform.position).normalized * Vehicle.VelocityLimit;
        }
    }
}