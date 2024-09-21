using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject initialScenePrefab; 
    [SerializeField] private GameObject[] scenePrefabs;    

    private GameObject _currentScene;
    private bool _isFirstSceneLoaded = false; 

    private void OnEnable()
    {
        GameManager.IsStartGame += LoadInitialScene;
        GameManager.IsRestartGame += LoadRandomScene;
    }
    private void LoadInitialScene()
    {
        if (_currentScene != null)
        {
            Destroy(_currentScene); 
        }

        _currentScene = Instantiate(initialScenePrefab); 
        _isFirstSceneLoaded = true; 
    }

    public void LoadRandomScene()
    {
        if (_currentScene != null)
        {
            Destroy(_currentScene); 
        }

        int randomIndex = Random.Range(0, scenePrefabs.Length);
        _currentScene = Instantiate(scenePrefabs[randomIndex]); 
    }
    private void OnDisable()
    {
        GameManager.IsStartGame -= LoadInitialScene;
        GameManager.IsRestartGame -= LoadRandomScene;
    }
}
