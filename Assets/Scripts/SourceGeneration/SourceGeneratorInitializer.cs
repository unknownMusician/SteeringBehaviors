using UnityEditor;

namespace SteeringBehaviors.SourceGeneration
{
    [InitializeOnLoad]
    internal static class SourceGeneratorInitializer
    {
        static SourceGeneratorInitializer()
        {
            new SourceGenerator(new FileWriter()).Inspect();
        }
    }
}
