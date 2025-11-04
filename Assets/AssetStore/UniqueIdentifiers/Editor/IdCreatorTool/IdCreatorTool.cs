using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace UniqueIdentifier.Editor
{
    public class IdCreatorTool : OdinEditorWindow
    {
        [Title("Class Generator Settings"),
         LabelText("Class Name"),
         GUIColor(1f, 1f, 1f)]
        public string className = "NewClass";

        [LabelText("Namespace")]
        public string classNamespace = "MyNamespace";

        [LabelText("Save Folder"),
         FolderPath(RequireExistingPath = true, AbsolutePath = false)]
        public string folderPath = "Assets/Scripts";
        private string absoluteDestinationPath = string.Empty;
        
        [Button("Generate Class", ButtonSizes.Large)]
        private void GenerateClass()
        {
            var unityProjectDirectory = Path.GetDirectoryName(Application.dataPath);
            absoluteDestinationPath = Path.Combine(unityProjectDirectory, folderPath);
            if (!IsValidInput)
            {
                EditorUtility.DisplayDialog("Invalid Input", "Please provide a valid class name and folder.", "OK");
                return;
            }

            Debug.Log($"Generating class '{className}' in namespace '{classNamespace}' at '{folderPath}'");

            CodeGenerator.GenerateCarambaIdClass(className, classNamespace, absoluteDestinationPath);
            
            AssetDatabase.ImportAsset(Path.Combine(folderPath, $"{className}.cs"), ImportAssetOptions.ForceSynchronousImport);
        }

        
        [MenuItem("Caramba/Unique Id/Create new CarambaId")]
        public static void CreateNewCarambaId() => GetWindow<IdCreatorTool>("CarambaId Creator");
        
        private bool IsValidInput => !string.IsNullOrWhiteSpace(className) && Directory.Exists(absoluteDestinationPath);
    }
}