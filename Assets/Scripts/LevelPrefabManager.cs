using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelPrefabManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listScene;
    internal List<GameObject> _coins = new List<GameObject>();
    private GameObject _currentScene;
    private Vector3 _startPosition = new Vector3(100.7371f, -279.3909f, 585.5648f);
    
    private void OnEnable()
    {
        GameManager.IsStartGame += StartGame;
        GameManager.IsRestartGame += RestartScene;
        GameManager.IsFinishGame += LoadScene;
        GameManager.IsPlayerDie += RestartScene;
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
        _currentScene.transform.position = _startPosition;
        Debug.Log("Загружен уровень: " + _currentScene.name);
    }
    
    public void RestartScene() 
    {
        if (_currentScene != null)
        {
            _currentScene.SetActive(false); 
            Debug.Log("деактивация при рестарте уровень: " + _currentScene.name);
        }
        
        if (_currentScene != null)
        {
            _currentScene.SetActive(true);
            Debug.Log("Перезагружен уровень: " + _currentScene.name);
        }

        foreach (var coins in _coins)
        {
            coins.SetActive(true);
        }
    }

    private void OnDisable()
    {
        GameManager.IsStartGame -= StartGame;
        GameManager.IsRestartGame -= RestartScene;
        GameManager.IsFinishGame -= LoadScene;
    }
}
