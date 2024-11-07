using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class LevelPrefabManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listScene;
    [SerializeField] internal List<GameObject> _coinsList = new List<GameObject>();
    private GameObject _currentScene;
    private Vector3 _startPosition = new Vector3(101f, -280f, 586f);
    
  
    private void OnEnable()
    {
        GameManager.IsStartGame += StartFirstScene;
        GameManager.IsRestartGame += ReloadScene;
        GameManager.IsFinishGame += NewScene;
    }
    
    private void Start()
    {
        _currentScene = _listScene[1];
        StartScene();
    }

    public void StartScene()
    {
        if (_listScene.Count > 0)
        {
            _currentScene = _listScene[0];
            _currentScene.SetActive(true);
        }
    }

    public void StartFirstScene()
    {
        _currentScene.SetActive(false);
        if (_currentScene.name == _listScene[0].name)
        {
            _currentScene = _listScene[1];
        }

        _currentScene.SetActive(true);
    }

    public void NewScene()
    {
        foreach (var scenes in _listScene)
        {
            scenes.SetActive(false);
        }

        int randomIndex = Random.Range(1, _listScene.Count);
        _currentScene = _listScene[randomIndex];
        _currentScene.SetActive(true);
        _currentScene.transform.position = _startPosition;
    }

    public void ReloadScene()
    {
        _currentScene.SetActive(false);
        _currentScene.SetActive(true);

        if (_coinsList.Count > 0)
        {
            foreach (var coin in _coinsList)
            {
                    coin.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        GameManager.IsStartGame -= StartFirstScene;
        GameManager.IsRestartGame -= ReloadScene;
        GameManager.IsFinishGame -= NewScene;
    }
}
