using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Managers
{
    public class LevelPrefabManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _listScene;
        [SerializeField] internal List<GameObject> _coinsList = new List<GameObject>();
        private GameObject _currentScene;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void OnEnable()
        {
            _gameManager.GameStarted += StartFirstScene;
            _gameManager.GameRestarted += ReloadScene;
            _gameManager.GameFinished += NewScene;
        }

        private void OnDisable()
        {
            _gameManager.GameStarted -= StartFirstScene;
            _gameManager.GameRestarted -= ReloadScene;
            _gameManager.GameFinished -= NewScene;
        }

        private void Start()
        {
            _currentScene = _listScene[0];
            StartScene();
        }

        private void StartScene()
        {
            if (_listScene.Count > 0)
            {
                _currentScene = _listScene[0];
                _currentScene.SetActive(true);
            }
        }

        private void StartFirstScene()
        {
            _currentScene.SetActive(false);
            if (_currentScene.name == _listScene[0].name)
            {
                _currentScene = _listScene[0];
            }

            _currentScene.SetActive(true);
        }

        private void NewScene()
        {
            foreach (var scenes in _listScene)
            {
                scenes.SetActive(false);
            }

            int randomIndex = Random.Range(1, _listScene.Count);
            _currentScene = _listScene[randomIndex];
            _currentScene.SetActive(true);
        }

        private void ReloadScene()
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
    }
}