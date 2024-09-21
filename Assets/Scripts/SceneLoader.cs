using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] scenePrefabs;
    private DiContainer _container;

    [Inject]
    public void Construct(DiContainer container)
    {
        _container = container;
    }

    public void LoadScene(int sceneIndex)
    {
        if (sceneIndex < 0 || sceneIndex >= scenePrefabs.Length)
        {
            Debug.LogError("Invalid scene index.");
            return;
        }

        StartCoroutine(LoadSceneCoroutine(sceneIndex));
    }

    private IEnumerator LoadSceneCoroutine(int sceneIndex)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject newScene = _container.InstantiatePrefab(scenePrefabs[sceneIndex]);
        yield return null;
    }
}
