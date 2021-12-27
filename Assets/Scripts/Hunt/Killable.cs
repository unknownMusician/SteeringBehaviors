using System;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SteeringBehaviors.Hunt
{
    [GenerateMonoBehaviour]
    public sealed class Killable
    {
        public readonly GameObject ThisObject;
        public event Action<GameObject> OnKill;
        
        public Killable([FromThisObject] Transform transform)
        {
            ThisObject = transform.gameObject;
        }

        public void KillMe(GameObject killer)
        {
            OnKill?.Invoke(killer);
            Object.Destroy(ThisObject);
        }
    }
}