using System;

namespace SteeringBehaviors.Movement
{
    [Serializable]
    public struct MoveImpactInfos
    {
        public MoveImpactInfo Wander;
        public MoveImpactInfo EscapeEnemy;
        public MoveImpactInfo PursuePrey;
        public MoveImpactInfo FollowFriend;
        public MoveImpactInfo EscapeFriend;
        public MoveImpactInfo KeepBounds;
    }
}
