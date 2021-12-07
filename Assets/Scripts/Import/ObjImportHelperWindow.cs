#if UNITY_EDITOR

using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SteeringBehaviors.Import
{
    public class ObjImportHelperWindow : EditorWindow
    {
        protected const string DefaultModelsPath = "Assets/Models/Voxel/";
        protected readonly ObjImportHelper ImportHelper = new ObjImportHelper();

        protected string ModelsPath = DefaultModelsPath;

        [MenuItem("Window/SteeringBehaviors/.obj Import Helper")]
        public static void ShowWindow() => GetWindow<ObjImportHelperWindow>();

        protected virtual void OnGUI()
        {
            //GUILayout.Label("Base Settings", EditorStyles.boldLabel);
            string newPath = EditorGUILayout.TextField("Models Path", ModelsPath);
            ModelsPath = string.IsNullOrEmpty(newPath) ? DefaultModelsPath : newPath;

            if (GUILayout.Button("Palette to Materials"))
            {
                ChangePaletteToMaterialsInDirectoryAndSubdirectories(ModelsPath);
            }
        }

        protected virtual void ChangePaletteToMaterialsInDirectoryAndSubdirectories(string modelsPath)
        {
            foreach (string file in Directory.GetFiles(modelsPath)
                                             .Where(file => file.EndsWith(".obj", StringComparison.Ordinal))
                                             .Select(file => file.Replace(@"\", "/")))
            {
                ImportHelper.ChangePaletteToMaterials(file);
                Debug.Log($"Updated {file}");
            }

            foreach (string directory in Directory.GetDirectories(modelsPath).Select(dir => dir.Replace(@"\", "/")))
            {
                ChangePaletteToMaterialsInDirectoryAndSubdirectories(directory);
            }
        }
    }

    // todo
}

#endif
