using UnityEngine;

namespace Level
{
    [CreateAssetMenu(menuName = "Create LevelSettings", fileName = "LevelSettings", order = 0)]
    public class LevelSettings : ScriptableObject, ILevelSettings
    {
        [field: SerializeField] public string[] SceneNames { get; private set; }

        public string GetSceneName(int levelIndex)
        {
            var sceneNamesLength = SceneNames.Length;

            return SceneNames[levelIndex % sceneNamesLength];
        }
    }
}