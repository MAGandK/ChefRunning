using System;
using Level;
using Obstacle;
using Services.Storage;
using UI;
using UI.Window.FailWindow;
using UI.Window.GameWindow;
using UI.Window.StartWindow;
using UI.Window.WinWindow;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public event Action GameRestarted;
        public event Action GameFinished;
        public event Action GameStarted;
        public event Action GameExited;

        [SerializeField] private ObstacleController _obstacleController;
        
        private IUIController _uiController;
        private IStorageService _storageService;
        private StartWindowController _startWindow;
        private FailWindowController _failWindow;
        private GameWindowController _gameWindow;
        private WinWindowController _winWindow;
        private LevelProgressStorageData _levelProgressStorageData;
        private ILevelLoader _levelLoader;

        [Inject]
        private void Construct(
            IUIController uiController,
            IStorageService storageService,
            ILevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
            _uiController = uiController;
            _storageService = storageService;

            _startWindow = _uiController.GetWindow<StartWindowController>();
            _failWindow = _uiController.GetWindow<FailWindowController>();
            _winWindow = _uiController.GetWindow<WinWindowController>();
        }

        private void OnEnable()
        {
            _startWindow.StartClicked += StartWindowOnStartClicked;
            _failWindow.RetryClicked += FailWindowOnRetryClicked;
            _winWindow.Won += WinWindowOnWon;
        }

        private void OnDisable()
        {
            _startWindow.StartClicked -= StartWindowOnStartClicked;
            _failWindow.RetryClicked -= FailWindowOnRetryClicked;
            _winWindow.Won -= WinWindowOnWon;
        }

        public void StartGame()
        {
            _uiController.ShowWindow<GameWindowController>();
            // _audioManager.PlayBackgroundMusic();
            GameStarted?.Invoke();
        }

        public void FinishGame()
        {
            _levelProgressStorageData.IncrementLevelIndex();
            _uiController.ShowWindow<WinWindowController>();
            // _audioManager.StopMusic();
            //  _audioManager.PlaySound(SoundType.Finish);
            GameFinished?.Invoke();
            StartCoroutine(_levelLoader.LoadNextLevel());
        }

        public void RestartGame()
        {
            _uiController.ShowWindow<GameWindowController>();
            _obstacleController.ResetObstacle();
            GameRestarted?.Invoke();
            StartGame();
            StartCoroutine(_levelLoader.LoadCurrentLevel());
        }

        public void ExitGame()
        {
            _uiController.ShowWindow<StartWindowController>();
            _obstacleController.ResetObstacle();
            GameExited?.Invoke();
        }
        
        private void StartWindowOnStartClicked()
        {
            StartGame();
        }

        private void FailWindowOnRetryClicked()
        {
            RestartGame();
        }
        
        private void WinWindowOnWon()
        {
           FinishGame();
        }

#if UNITY_EDITOR

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                FinishGame();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                RestartGame();
            }
            
            if (Input.GetKeyDown(KeyCode.V))
            {
                StartGame();
            }
        }
#endif
    }
}