using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Hunt
{
    [GenerateMonoBehaviour]
    public sealed class Killable
    {
        private readonly GameObject _thisObject;
        
        public Killable([FromThisObject] Transform transform)
        {
            _thisObject = transform.gameObject;
        }

        public void KillMe(float deathDelay)
        {
            // todo stop killable target moving on death delay
            Object.Destroy(_thisObject, deathDelay);
        }
    }
}