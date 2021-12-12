#nullable enable

using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using UnityEngine;

namespace SteeringBehaviors.Movement
{
    public interface IMover
    {
        // Task MoveAsync(Vector3 direction);
        // Task MoveToPointAsync(Vector3 worldPoint, float speedMultiplier = 1.0f);
        // Task WalkAsync(Vector3 center, float radius, float speedMultiplier);
        // Task EscapeFromAsync(Transform enemy, float safeDistance);
        // Task PursueAsync(Transform prey, float lostDistance);
        // Task PursueForAsync(Transform transform, float time);
        // Task PursueAsync(Transform prey, float lostDistance, float time);

        // todo Mobik's methods
        Task WanderAsync(float wanderingSpeed);
        Task WanderWithGroupAsync(float wanderingSpeed, Transform[] group);
        
        Task EscapeFromAsync(Transform[] enemies, float safeDistance, float escapingSpeed);
        Task EscapeWithGroupAsync(Transform[] enemies, Transform[] group, float safeDistance, float escapingSpeed);

        Task PursueAsync(Transform prey, float lostDistance, float time, float pursuitSpeed);


        void StopMoving();
    }
}
