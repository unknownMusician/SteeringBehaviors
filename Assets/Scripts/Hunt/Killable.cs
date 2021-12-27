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

        public void KillMe()
        {
            Object.Destroy(_thisObject);
        }
    }
}