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
            new SourceGenerator(new FileWriter(), new SourceGeneratorUtil()).Inspect(AssemblyHelper.GameAssembly);
        }
    }

    public static class AssemblyHelper
    {
        public static readonly Assembly GameAssembly = AppDomain.CurrentDomain.GetAssemblies()
                                                                .First(
                                                                    assembly => assembly.GetName().Name
                                                                     == "Assembly-CSharp"
                                                                );
    }
}
