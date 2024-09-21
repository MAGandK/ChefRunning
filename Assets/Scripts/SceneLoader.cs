using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] scenePrefabs;
    private DiContainer _container;
    private List<GameObject> _loadedScenes = new List<GameObject>();

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
        foreach (var scene in _loadedScenes)
        {
            Destroy(scene);
        }
        _loadedScenes.Clear();
        
        yield return new WaitForSeconds(0.5f);
        GameObject newScene = _container.InstantiatePrefab(scenePrefabs[sceneIndex]);
        _loadedScenes.Add(newScene);
    }
}
