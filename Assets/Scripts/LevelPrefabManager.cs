using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class LevelPrefabManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listScene;
    private GameObject _currentScene;
    private Vector3 _startPosition = new Vector3(100.7371f, -279.3909f, 585.5648f);
    private ObstacleBase _obstacleBase;
    
    [Inject]
    private void Construct(ObstacleBase obstacleBase)
    {
        _obstacleBase = obstacleBase;
    }
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

        if (_obstacleBase._coins.Count > 0)
        {
            foreach (var coin in _obstacleBase._coins)
            {
                if (coin != null)
                {
                    coin.SetActive(true);
                }
            }
        }
        
        if (_obstacleBase._obstacle.Count > 0)
        {
            Debug.Log("1234");
            foreach (var obstacle in _obstacleBase._obstacle)
            {
                obstacle.SetActive(true); 
                var obstacleComponent = obstacle.GetComponent<ObstacleBase>();
                if (obstacleComponent != null)
                {
                    obstacleComponent.ResetObstacle();
                }
            }
        
            if (_obstacleBase._hammer != null && _obstacleBase._hammer.Count >= 0)
            {
                foreach (var hammers in _obstacleBase._hammer)
                {
                    if (hammers != null)
                    {
                        hammers.SetActive(true);
                        var hammerComponent = hammers.GetComponent<ObstacleHammer>();
                        if (hammerComponent != null)
                        {
                            hammerComponent.ResetObstacle();
                        }
                    }
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
