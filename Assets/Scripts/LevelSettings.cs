using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create LevelSettings", fileName = "LevelSettings", order = 0)]

public class LevelSettings : ScriptableObject
{
    [field : SerializeField]

    public string[] SceneNames
    {
        get;

        private set;
    }

    public string GetSceneName(int levelIndex)
    {
        string sceneName;

        var sceneNamesLength = SceneNames.Length;

        if (levelIndex < sceneNamesLength)
        {
            sceneName = SceneNames[levelIndex % sceneNamesLength];
        }
        else
        {
            sceneName = SceneNames[levelIndex % sceneNamesLength];
        }

        return sceneName;
    }

    internal object GetSceneName(object levelIndex)
    {
        throw new System.NotImplementedException();
    }
}
