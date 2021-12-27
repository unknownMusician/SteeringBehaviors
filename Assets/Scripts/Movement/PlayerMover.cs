using System;
using SteeringBehaviors.SourceGeneration;
using UnityEngine;

namespace SteeringBehaviors.Movement
{
    [GenerateMonoBehaviour]
    public class PlayerMover : Mover, IPlayerMover
    {
        public virtual Vector3 Direction { get; set; }

        protected override void MoveFrame() => Move(Direction);

        public PlayerMover([FromThisObject] Transform movable, float maxSpeed) : base(movable, maxSpeed)
            => MoveAsync();
    }
}
