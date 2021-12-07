#nullable enable

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace SteeringBehaviors.Import
{
    public class ObjImportHelper
    {
        protected StringBuilder Builder = new StringBuilder();
        protected Dictionary<int, StringBuilder> MaterialFaces = new Dictionary<int, StringBuilder>();
        protected string fileName = "";

        public virtual void ChangePaletteToMaterials(string objPath)
        {
            if (!File.Exists(objPath))
            {
                throw new FileNotFoundException();
            }

            string objBody = File.ReadAllText(objPath);

            fileName = GetFileName(objPath, out _);

            File.WriteAllText(objPath, UpdateFileBody(objBody, fileName, out string mtlBody));

            File.WriteAllText(
                objPath.Substring(0, objPath.LastIndexOf(".", StringComparison.Ordinal)) + ".mtl",
                mtlBody
            );
        }

        protected virtual string GetFileName(string filePath, out int fileNameIndex)
        {
            fileNameIndex = filePath.LastIndexOf('/') + 1;

            return filePath.Substring(fileNameIndex, filePath.LastIndexOf('.') - fileNameIndex);
        }

        protected virtual string UpdateFileBody(string objBody, string fileName, out string mtlBody)
        {
            Builder = new StringBuilder();
            MaterialFaces = new Dictionary<int, StringBuilder>();

            string[] lines = objBody.Split('\n');

            Builder.Append($"mtllib {fileName}.mtl\n");

            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    ProcessLine(lines[i], i);
                }
                catch (Exception ex)
                {
                    throw new SyntaxErrorException($"File: {fileName}, line: {i}", ex);
                }
            }

            mtlBody = ToMtlBody(MaterialFaces);

            return Builder.ToString();
        }

        protected virtual string ToMtlBody(Dictionary<int, StringBuilder> materialFaces)
        {
            var mtlBuilder = new StringBuilder();

            foreach (KeyValuePair<int, StringBuilder> face in materialFaces)
            {
                Builder.Append($"usemtl M{face.Key}\n");
                Builder.Append(face.Value);

                mtlBuilder.Append($"newmtl M{face.Key}\n");
            }

            return mtlBuilder.ToString();
        }

        protected virtual void ProcessLine(string line, int lineIndex)
        {
            if (line.StartsWith("#", StringComparison.Ordinal)) { }

            if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
            {
                return;
            }

            if (line.StartsWith("mtllib", StringComparison.Ordinal)
             || line.StartsWith("usemtl", StringComparison.Ordinal))
            {
                return;
            }

            if (line.StartsWith("o", StringComparison.Ordinal))
            {
                Builder.Append($"g {fileName}\n");

                return;
            }

            if (line.StartsWith("f", StringComparison.Ordinal))
            {
                int startIndex = line.IndexOf('/') + 1;
                int endIndex = line.IndexOf('/', startIndex);
                string textureIndexAsString = line.Substring(startIndex, endIndex - startIndex);

                if (string.IsNullOrEmpty(textureIndexAsString))
                {
                    return;
                }

                int textureIndex = int.Parse(textureIndexAsString);
                Append(MaterialFaces, textureIndex, line + '\n');

                return;
            }

            Builder.Append(line + '\n');
        }

        protected virtual void Append(Dictionary<int, StringBuilder> builders, int key, string value)
        {
            if (!builders.TryGetValue(key, out StringBuilder builder))
            {
                builder = new StringBuilder();
                builders[key] = builder;
            }

            builder.Append(value);
        }
    }
}
