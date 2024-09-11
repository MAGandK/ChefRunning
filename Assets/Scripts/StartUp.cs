using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    public static string LevelKey = "LevelKey";

    private void Awake()
    {
        var levelIndex = PlayerPrefs.GetInt(LevelKey, 0);

        var sceneName = SettingManager.Instance.LevelSettings.GetSceneName(levelIndex);

        SceneManager.LoadScene(sceneName);
    }
}
