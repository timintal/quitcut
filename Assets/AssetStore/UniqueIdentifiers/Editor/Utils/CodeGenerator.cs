using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace UniqueIdentifier.Editor
{
    internal static class CodeGenerator
    {
        private const string GeneratedFileSuffix = "_g.cs";
        private const string NamespaceToken = "##NAMESPACE##";
        private const string ClassNameToken = "##CLASS_NAME##";
        private const string FieldsToken = "##FIELDS##";
        private const string NewIdToken = "##NEW_ID##";
        private const string NewGuidToken = "##NEW_GUID##";

        private const string CarambaIdClassTemplate = @"using KoalaRosada.UniqueIdentifier;
using System;

namespace ##NAMESPACE##
{
    [Serializable]
    public partial class ##CLASS_NAME## : CarambaId
    {
        public ##CLASS_NAME##() : base(LongGuid.None) { }
        public ##CLASS_NAME##(LongGuid guid) : base(guid) { }
    }
}
";
        
        private const string PartialClassTemplate = @"// Auto-generated partial class

using Caramba.UniqueId;

namespace ##NAMESPACE##
{
    public partial class ##CLASS_NAME##
    {
##FIELDS##
    }
}
";

        private const string FieldTemplate = "        public static readonly ##CLASS_NAME## ##NEW_ID## = new(new LongGuid(##NEW_GUID##));";

        public static void GenerateCarambaIdClass(string className, string classNamespace, string destinationDirectory)
        {
            var classDefinitionFilePath = Path.Combine(destinationDirectory, $"{className}.cs");
            if (File.Exists(classDefinitionFilePath))
            {
                Debug.LogError($"Source file already exist: {classDefinitionFilePath}");
                return;
            }
            
            var generatedContent = CarambaIdClassTemplate
                .Replace(NamespaceToken, classNamespace)
                .Replace(ClassNameToken, className);
            
            File.WriteAllText(classDefinitionFilePath, generatedContent);
            Debug.Log($"Generated file: {classDefinitionFilePath}");
        }
        
        public static void GenerateIdEntriesPartialClass(
            string classDefinitionFilePath,
            string membersDefinitionFilePath,
            string classNamespace, 
            string className, 
            List<IdEntry> idEntries)
        {
            if (!File.Exists(classDefinitionFilePath))
            {
                Debug.Log($"Source file does not exist: {classDefinitionFilePath}");
                return;
            }
            
            if (string.IsNullOrEmpty(className))
            {
                Debug.Log("Could not find a class in the provided file.");
                return;
            }
            
            var newFileName = $"{className}{GeneratedFileSuffix}";
            var newFilePath = Path.Combine(membersDefinitionFilePath, newFileName);

            var generatedFields = new StringBuilder();
            foreach (var entry in idEntries)
            {
                var (v1, v2) = entry.Guid.GetRawValues();
                generatedFields.AppendLine(FieldTemplate
                    .Replace(ClassNameToken, className)
                    .Replace(NewIdToken, entry.FieldName)
                    .Replace(NewGuidToken, $"{v1}, {v2}"));
            }
            
            var generatedContent = PartialClassTemplate
                .Replace(NamespaceToken, classNamespace)
                .Replace(ClassNameToken, className)
                .Replace(FieldsToken, generatedFields.ToString());
            
            File.WriteAllText(newFilePath, generatedContent);
            Debug.Log($"Generated file: {newFilePath}");
        }

        public static string GetClassDefinitionDirectoryPath(string classDefinitionFilePath)
        {
            var directory = Path.GetDirectoryName(classDefinitionFilePath);
            if (directory != null)
            {
                return directory;
            }
            
            Debug.Log($"Could not find the directory of the provided file. {classDefinitionFilePath}");
            return string.Empty;
        }
    }
}