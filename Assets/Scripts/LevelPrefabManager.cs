using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelPrefabManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listScene;
    internal List<GameObject> _coins = new List<GameObject>();
    internal List<GameObject> _obstacle = new List<GameObject>();
    internal List<GameObject> _hammer= new List<GameObject>();
    private GameObject _currentScene;
    private Vector3 _startPosition = new Vector3(100.7371f, -279.3909f, 585.5648f);
    
    private void OnEnable()
    { 
        GameManager.IsStartGame += StartFirstScene;
        GameManager.IsRestartGame +=ReloadScene;
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
        if (_currentScene != null)
        {
            _currentScene.SetActive(false);
            _currentScene.SetActive(true);
        }

        if (_coins != null && _coins.Count > 0)
        {
            foreach (var coin in _coins)
            {
                if (coin != null)
                {
                    coin.SetActive(true);
                }
            }
        }

        if (_obstacle != null && _obstacle.Count > 0)
        {
            foreach (var obstacles in _obstacle)
            {
                if (obstacles != null)
                {
                    obstacles.SetActive(true);
                    obstacles.GetComponent<ObstacleBarrel>().ResetObstacle();
                }
            }
        }
        if (_hammer != null &&_hammer.Count > 0)
        {
            foreach (var hammer in _hammer)
            {
                if (hammer != null)
                {
                    hammer.SetActive(true);
                    hammer.GetComponent<ObstacleHammer>().ResetObstacle();       
                }
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
