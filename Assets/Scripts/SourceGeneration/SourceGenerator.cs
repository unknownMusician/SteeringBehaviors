#nullable enable

using System;
using System.Linq;
using System.Reflection;
using System.Text;
using SteeringBehaviors.Movement;

namespace SteeringBehaviors.SourceGeneration
{
    public class SourceGenerator
    {
        protected readonly FileWriter Writer;

        public SourceGenerator(FileWriter writer) => Writer = writer;

        // todo
        public virtual Type[] InspectType()
        {
            return Assembly.GetAssembly(typeof(SourceGenerator))
                           .GetTypes()
                           .Where(type => type.TryGetCustomAttribute<GenerateMonoBehaviourAttribute>(out _))
                           .ToArray();
        }

        public virtual void HandleType(Type type)
        {
            Writer.WriteAllText(Writer.GetFilePath(type, "Component"), GenerateMonoBehaviour(type));
        }

        public virtual void Inspect()
        {
            foreach (Type type in InspectType())
            {
                if (type.TryGetCustomAttribute(out GenerateMonoBehaviourAttribute attribute))
                {
                    HandleType(type);
                }
            }
        }

        public virtual string GenerateMonoBehaviour(Type type)
        {
            if (type.IsAbstract)
            {
                throw new ArgumentException(
                    $"Cannot generate MonoBehaviour for {type.Name} because it is abstract."
                );
            }

            ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            // if (constructors.Any() && constructors.All(ctor => ctor.GetParameters().Length != 0))
            // {
            //     throw new ArgumentException(
            //         $"Cannot generate MonoBehaviour for {type.Name} because it is has no public parameterless constructor."
            //     );
            // }

            if (constructors.Length > 1)
            {
                throw new ArgumentException(
                    $"Cannot generate MonoBehaviour for {type.Name} because it has more than one constructor."
                );
            }

            ParameterInfo[] constructorParameters = Array.Empty<ParameterInfo>();

            if (constructors.Length == 1)
            {
                constructorParameters = constructors.First().GetParameters();
            }

            string fields = GetParametersAsFields(constructorParameters);
            string parameters = GetParametersAsInvocationParameters(constructorParameters);

            return $@"// Generated

using {type.Namespace};
using UnityEngine;

namespace Generated.{type.Namespace}
{{
    public sealed class {type.Name}Component : MonoBehaviour
    {{{fields}
        public {type.Name} {type.Name} {{ get; private set; }}

        private void Awake()
        {{
            {type.Name} = new {type.Name}({parameters});
        }}{(!typeof(IDisposable).IsAssignableFrom(type) ? string.Empty : $@"

        private void OnDestroy()
        {{
            {type.Name}.Dispose();
        }}")}
    }}
}}
";
        }

        protected virtual string GetParametersAsInvocationParameters(ParameterInfo[] parameters)
        {
            var invocation = new StringBuilder();

            foreach (ParameterInfo parameter in parameters)
            {
                string parameterName = '_' + parameter.Name;

                if (parameter.ParameterType.TryGetCustomAttribute(out GenerateMonoBehaviourAttribute _))
                {
                    parameterName += '.' + parameter.ParameterType.Name;
                }

                if (parameter.TryGetCustomAttribute(out FromThisObjectAttribute _))
                {
                    parameterName = $"GetComponent<{GetAliasName(parameter.ParameterType)}>()";
                }

                invocation.Append($"{parameterName}, ");
            }

            if (invocation.Length > 0)
            {
                invocation.Remove(invocation.Length - 2, 2);
            }

            return invocation.ToString();
        }

        protected virtual string GetParametersAsFields(ParameterInfo[] parameters)
        {
            var fields = new StringBuilder();

            foreach (ParameterInfo parameter in parameters)
            {
                if (!parameter.TryGetCustomAttribute(out FromThisObjectAttribute _))
                {
                    fields.Append(
                        $@"
        [SerializeField] private {GetAliasName(parameter.ParameterType)}{(parameter.ParameterType.TryGetCustomAttribute(out GenerateMonoBehaviourAttribute _) ? "Component" : string.Empty)} _{parameter.Name};"
                    );
                }
            }

            if (fields.Length > 0)
            {
                fields.Append(
                    @"
"
                );
            }

            return fields.ToString();
        }

        protected virtual string GetAliasName(Type type)
        {
            if (type.Namespace == nameof(UnityEngine))
            {
                return type.Name;
            }

            return type.FullName switch
            {
                nameof(System) + "." + nameof(Boolean) => "string",
                nameof(System) + "." + nameof(Byte) => "byte",
                nameof(System) + "." + nameof(SByte) => "sbyte",
                nameof(System) + "." + nameof(Char) => "char",
                nameof(System) + "." + nameof(Decimal) => "decimal",
                nameof(System) + "." + nameof(Double) => "double",
                nameof(System) + "." + nameof(Single) => "float",
                nameof(System) + "." + nameof(Int32) => "int",
                nameof(System) + "." + nameof(UInt32) => "uint",
                //nameof(System) + "." + nameof(IntPtr) => "nint",
                //nameof(System) + "." + nameof(UIntPtr) => "nuint",
                nameof(System) + "." + nameof(Int64) => "long",
                nameof(System) + "." + nameof(UInt64) => "ulong",
                nameof(System) + "." + nameof(Int16) => "short",
                nameof(System) + "." + nameof(UInt16) => "ushort",
                nameof(System) + "." + nameof(Object) => "object",
                nameof(System) + "." + nameof(String) => "string",
                null => throw new ArgumentException($"Cannot get FullName of type {type.Name}"),
                _ => type.FullName,
            };
        }
    };
}
