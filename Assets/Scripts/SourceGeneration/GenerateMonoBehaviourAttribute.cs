using System;

namespace SteeringBehaviors.SourceGeneration
{
    // todo: struct?
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class GenerateMonoBehaviourAttribute : Attribute { }

    // public sealed class ComponentForAttribute : Attribute
    // {
    //     private readonly Type _type;
    //
    //     public ComponentForAttribute(Type type) => _type = type;
    // }
}
