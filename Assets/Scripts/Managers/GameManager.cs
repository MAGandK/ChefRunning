using System;
using Obstacle;
using Type;
using UI;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public event Action GameRestarted;
        public event Action GameFinished;
        public event Action GameStarted;
        
        private AudioManager _audioManager;
        private UIController _uiController;
        
        [SerializeField] private ObstacleController _obstacleController;

        private bool _isGameStarted = false;
        private bool _isGameFinished = false;

        [Inject]
        private void Construct( AudioManager audioManager, UIController uiController)
        {
            _audioManager = audioManager;
            _uiController = uiController;
        }

        public void StartGame()
        {
            _isGameStarted = true;
            _uiController.ShowWindow(WindowType.MainWindow);
            _audioManager.PlayBackgroundMusic();
            GameStarted?.Invoke();
        }

        public void FinishGame()
        {
            _isGameFinished = true;
            _uiController.ShowWindow(WindowType.FinishWindow);
            _audioManager.StopMusic();
            _audioManager.PlaySound(SoundType.Finish);
            GameFinished?.Invoke();
        }

        public void RestartGame()
        {
            _isGameFinished = false;
            _uiController.ShowWindow(WindowType.MainWindow);
            _obstacleController.ResetObstacle();
            GameRestarted?.Invoke();
            StartGame();
        }
        
#if UNITY_EDITOR
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_isGameStarted && !_isGameFinished)
            {
                StartGame();
            }

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
