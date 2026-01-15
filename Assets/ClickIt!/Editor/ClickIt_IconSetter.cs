using UnityEditor;
using UnityEngine;

namespace ClickIt.Editor {
    [InitializeOnLoad]
    public class ClickItIconSetter {
        private static bool hasSetIcons = false;
        private static readonly string componentIconFilePath = "Assets/ClickIt!/Editor/ClickItIcon.png";
        private static readonly string[] componentFilePaths = {
            "Assets/ClickIt!/Components/BasicClickableObject.cs",
            "Assets/ClickIt!/Components/BasicReleaseableObject.cs",
            "Assets/ClickIt!/Components/BasicClickAwayObject.cs",
            "Assets/ClickIt!/Components/ClickableObject.cs",
            "Assets/ClickIt!/Components/ReleaseableObject.cs",
            "Assets/ClickIt!/Components/ClickAwayObject.cs"
        };


        static ClickItIconSetter() {
            if (hasSetIcons) return;

            EditorApplication.delayCall += SetIcons;
        }

        private static void SetIcons() {
            if (hasSetIcons) return;

            Texture2D icon = AssetDatabase.LoadAssetAtPath<Texture2D>(componentIconFilePath);
            if (icon == null) {
                Debug.LogWarning($"ClickIt: Could not find component icon at {componentIconFilePath}");
                return;
            }

            foreach (var filePath in componentFilePaths) {
                var script = AssetDatabase.LoadAssetAtPath<MonoScript>(filePath);
                if (script == null) {
                    Debug.LogWarning($"ClickIt: Could not find component script at {filePath}");
                    continue;
                }

                MonoImporter importer = (MonoImporter)AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(script));
                if (importer.GetIcon() != icon) {
                    importer.SetIcon(icon);
                    importer.SaveAndReimport();
                }
            }

            hasSetIcons = true;
        }
    }
}