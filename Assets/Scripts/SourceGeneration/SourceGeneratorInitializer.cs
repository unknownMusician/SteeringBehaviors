using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;

namespace SteeringBehaviors.SourceGeneration
{
    [InitializeOnLoad]
    internal static class SourceGeneratorInitializer
    {
        static SourceGeneratorInitializer()
        {
            Assembly assembly = AppDomain.CurrentDomain.GetAssemblies()
                                         .First(assembly => assembly.GetName().Name == "Assembly-CSharp");

            new SourceGenerator(new FileWriter(), new SourceGeneratorUtil()).Inspect(assembly);
        }
    }
}
