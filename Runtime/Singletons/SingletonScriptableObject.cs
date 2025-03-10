using System.IO;
using System.Reflection;
using AssetLoader.Runtime;
using UnityEditor;
using UnityEngine;

namespace CustomClasses.Runtime.Singletons
{
    /// <summary>
    /// Base class for ScriptableObjects that follow the Singleton pattern.
    /// Requires a ResourceAttribute to specify the asset location.
    /// Automatically creates the asset in the editor if it doesn't exist.
    /// </summary>
    /// <typeparam name="T">The type of ScriptableObject to make a singleton.</typeparam>
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance)
                    return _instance;

                var attribute = typeof(T).GetCustomAttribute<ResourceAttribute>();
                if (attribute == null)
                {
                    Debug.LogError($"[SingletonScriptableObject] {typeof(T).Name} missing ResourceAttribute");
                    return null;
                }

                if (attribute.TryGetFullResourcePath(out var path))
                    _instance = Resources.Load<T>(path);

#if UNITY_EDITOR
                if (_instance)
                    return _instance;

                _instance = CreateInstance<T>();
                SaveInstance(attribute);
#endif
                return _instance;
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStaticVariables() => _instance = null;

#if UNITY_EDITOR
        private static void SaveInstance(ResourceAttribute attr)
        {
            var name = string.IsNullOrEmpty(attr.Name) ? typeof(T).Name : attr.Name;
            var assetPath = string.IsNullOrEmpty(attr.AssetPath)
                ? $"Assets/{name}.asset"
                : $"{attr.AssetPath}/{name}.asset";

            var directory = Path.GetDirectoryName(assetPath);
            if (string.IsNullOrEmpty(directory) is false && Directory.Exists(directory) is false)
                Directory.CreateDirectory(directory);

            AssetDatabase.CreateAsset(_instance, assetPath);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}