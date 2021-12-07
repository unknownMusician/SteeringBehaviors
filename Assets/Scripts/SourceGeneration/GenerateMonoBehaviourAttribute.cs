#nullable enable

using System;
using UnityEngine.Scripting;

namespace SteeringBehaviors.SourceGeneration
{
    // todo: struct?
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class GenerateMonoBehaviourAttribute : PreserveAttribute { }

    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class FromThisObjectAttribute : PreserveAttribute { }

    // public sealed class ComponentForAttribute : Attribute
    // {
    //     private readonly Type _type;
    //
    //     public ComponentForAttribute(Type type) => _type = type;
    // }
}
