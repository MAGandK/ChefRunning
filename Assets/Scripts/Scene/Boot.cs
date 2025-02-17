using System.Collections;
using System.Collections.Generic;
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
        yield return  SceneManager.LoadSceneAsync(_uiSceneName, LoadSceneMode.Additive);
        yield return new WaitForSeconds(5);
        
        yield return SceneManager.LoadSceneAsync(_gameSceneName, LoadSceneMode.Additive);
        yield return new WaitForSeconds(5);
        
        SceneManager.UnloadSceneAsync(0);
    }
}