using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    [SerializeField] private string _uiSceneName;
    [SerializeField] private string _gameSceneName;

    private void Awake()
    {
        StartCoroutine(LoadSceneCor());
    }

    private IEnumerator LoadSceneCor()
    {
        yield return SceneManager.LoadSceneAsync(_uiSceneName, LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync(_gameSceneName, LoadSceneMode.Additive);

        yield return SceneManager.UnloadSceneAsync(0);

        var sceneByName = SceneManager.GetSceneByName(_gameSceneName);

        SceneManager.SetActiveScene(sceneByName);
    }
}
