using System;

namespace SteeringBehaviors.Movement
{
    [Serializable]
    public struct MoveImpactInfo
    {
        public float Priority;
        public Range<float> Distance;
    }
}
