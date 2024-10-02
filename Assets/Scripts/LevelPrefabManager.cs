using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelPrefabManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listScene;
    private GameObject _currentScene; 
    
    private void OnEnable()
    {
        GameManager.IsStartGame += StartGame;
        GameManager.IsRestartGame += RestartScene;
        GameManager.IsFinishGame += LoadScene;
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
            _currentScene = _listScene[0];
            _currentScene.SetActive(true); 
            Debug.Log("Стартовая сцена активна: " + _currentScene.name);
        }
    }

    public void LoadScene()
    {
        if (_currentScene != null)
        {
            _currentScene.SetActive(false); 
            Debug.Log("Деактивирован уровень: " + _currentScene.name);
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
            Debug.Log("Деактивирован уровень: " + _currentScene.name);
        }

        if (_currentScene != null)
        {
            _currentScene.SetActive(true);
            Debug.Log("Перезагружен уровень: " + _currentScene.name);
        }
    }

    private void OnDisable()
    {
        GameManager.IsStartGame -= StartGame;
        GameManager.IsRestartGame -= RestartScene;
        GameManager.IsFinishGame -= LoadScene;
    }
}
