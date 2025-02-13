using System;
using Obstacle;
using Type;
using UI;
using UI.Window;
using UI.Window.StartWindow;
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

        private AudioManager _audioManager;
        private UIController _uiController;

        private StartWindow _startWindow;
        private FailWindow _failWindow;
        private MainWindow _mainWindow;

        [Inject]
        private void Construct(AudioManager audioManager, UIController uiController)
        {
            _audioManager = audioManager;
            _uiController = uiController;
        }

        private void Awake()
        {
            _startWindow = _uiController.GetWindow<StartWindow>();
            _startWindow.StartButtonPressed += StartWindowOnStartButtonPressed;
            _failWindow = _uiController.GetWindow<FailWindow>();
            _failWindow.RetryButtonPressed += FailWindowOnRetryButtonPressed;
            _failWindow.NoTryButtonPressed += FailWindowOnNoTryButtonPressed;
            _mainWindow = _uiController.GetWindow<MainWindow>();
        }
        
        public void StartGame()
        {
            _uiController.ShowWindow<MainWindow>();
            _audioManager.PlayBackgroundMusic();
            GameStarted?.Invoke();
        }

        public void FinishGame()
        {
            _uiController.ShowWindow<FinishWindow>();
            _audioManager.StopMusic();
            _audioManager.PlaySound(SoundType.Finish);
            GameFinished?.Invoke();
        }

        public void RestartGame()
        {
            _uiController.ShowWindow<MainWindow>();
            _obstacleController.ResetObstacle();
            GameRestarted?.Invoke();
            StartGame();
        }

        public void ExitGame()
        {
            _uiController.ShowWindow<StartWindow>();
            _obstacleController.ResetObstacle();
            GameExited?.Invoke();
        }
        

        private void StartWindowOnStartButtonPressed()
        {
            StartGame();
        }
        
        private void FailWindowOnNoTryButtonPressed()
        {
            ExitGame();
        }

        private void FailWindowOnRetryButtonPressed()
        {
            RestartGame();
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
        }
#endif
    }
}