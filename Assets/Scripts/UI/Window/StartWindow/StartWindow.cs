using System;
using UI.Window.StartWindow.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Window.StartWindow
{
    public class StartWindow : WindowBase
    {
        public event Action StartButtonPressed;

        [SerializeField] private LevelProgressBar _levelProgressBar;
        [SerializeField] private Button _startButton;
        [SerializeField] private int _currentLevelIndex;

        private void Awake()
        {
            _startButton.onClick.AddListener(OnStartButtonClick);
        }

        public override void ShowWindow()
        {
            base.ShowWindow();

            _levelProgressBar.Setup(_currentLevelIndex);
        }

        private void OnValidate()
        {
            _levelProgressBar.Setup(_currentLevelIndex);
        }

        private void OnStartButtonClick()
        {
            StartButtonPressed?.Invoke();
        }
    }
}