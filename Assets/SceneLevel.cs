using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SceneLevel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listScene;
    private GameObject _currentScene; 
    
    private void OnEnable()
    {
        GameManager.IsStartGame += StartGame;
        GameManager.IsRestartGame += RestartScene;
    }

    private void StartGame()
    {
        StartScene(); 
        LoadScene();  
    }
    private void StartScene()
    {
        if (_listScene.Count > 0)
        {
            _listScene[0].SetActive(true); 
            _currentScene = _listScene[0]; 
            Debug.Log("Стартовая сцена активна: " + _listScene[0].name);
        }
    }

    private void LoadScene()
    {
        if (_listScene.Count > 0)
        {
            _listScene[0].SetActive(false);
        }
        int randomIndex = Random.Range(1, _listScene.Count);
        _currentScene = _listScene[randomIndex];

        _currentScene.SetActive(true);

        _currentScene.transform.position = new Vector3(100.7371f, -279.3909f, 585.5648f);
        Debug.Log("Загружен уровень: " + _currentScene.name);
    }
    
    public void RestartScene() 
    {
        if (_currentScene != null)
        {
            _currentScene.SetActive(false);
            _currentScene.SetActive(true); 
            Debug.Log("Перезагружена сцена: " + _currentScene.name);
        }
    }

    private void OnDisable()
    {
        GameManager.IsStartGame -= StartGame;
        GameManager.IsRestartGame -= RestartScene;
    }
}
