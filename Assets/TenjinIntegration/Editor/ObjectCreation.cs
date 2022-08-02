using System.IO;
using TenjinIntegration.Scripts;
using UnityEditor;
using UnityEngine;

namespace TenjinIntegration.Editor
{
    public class ObjectCreation 
    {
        [MenuItem("Tenjin/Create Tenjin Manager GameObject")]
        public static void AddTenjinManager()
        {
            if (Object.FindObjectOfType<TenjinMono>() != null)
            {
                Debug.LogWarning("A <color=green>Tenjin</color> gameObject is already present in scene");
                return;
            }
            GameObject gameObject =
                PrefabUtility.InstantiatePrefab(
                    AssetDatabase.LoadAssetAtPath(FindManagerPrefab("TenjinManager.prefab"),
                        typeof(GameObject))) as GameObject;
            Debug.Log("A <color=green>Tenjin</color> gameObject has been created");
        }
        
        private static string FindManagerPrefab(string file)
        {
            string[] assets = {Path.DirectorySeparatorChar + "Assets" + Path.DirectorySeparatorChar};
            FileInfo[] myFile = new DirectoryInfo("Assets").GetFiles(file, SearchOption.AllDirectories);
            string[] temp = myFile[0].ToString().Split(assets, 2, System.StringSplitOptions.None);
            return "Assets" + Path.DirectorySeparatorChar + temp[1];
        }
    }
}
