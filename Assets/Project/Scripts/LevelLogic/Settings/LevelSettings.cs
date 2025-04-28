using UnityEngine;

namespace LevelLogic
{
    [CreateAssetMenu(menuName = "Create LevelSettings", fileName = "LevelSettings", order = 0)]
    public class LevelSettings : ScriptableObject, ILevelSettings
    {
        [field: SerializeField] public string TestLevel { get; private set; }

        [field: SerializeField] public string[] SceneNames { get; private set; }

        public string GetSceneName(int levelIndex)
        {
            if (TestLevel != string.Empty)
            {
                return TestLevel;
            }
            
            var sceneNamesLength = SceneNames.Length;

            return SceneNames[levelIndex % sceneNamesLength];
        }
    }
}