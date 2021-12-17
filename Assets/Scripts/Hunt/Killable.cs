using SteeringBehaviors.Movement;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Hunt
{
    [GenerateMonoBehaviour]
    public sealed class Killable
    {
        private readonly GameObject _thisObject;
        private Mover _mover;
        
        public Killable(
            [FromThisObject] GameObject thisObject, 
            [FromThisObject] Mover mover)
        {
            _thisObject = thisObject;
            _mover = mover;
        }

        public void KillMe(float deathDelay)
        {
            // todo stop killable target moving on death delay
            Object.Destroy(_thisObject, deathDelay);
        }
    }
}