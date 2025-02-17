using UI.Window.StartWindow.Elements;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartWindowView : AbstractWindowView
{
    [SerializeField] private LevelProgressBar _levelProgressBar;
    [SerializeField] private Button _startButton;
    [SerializeField] private int _currentLevelIndex;

    public void SubscribeButton(UnityAction onStartButtonClick)
    {
        _startButton.onClick.AddListener(onStartButtonClick);
    }

    public void SetupProgressBar()
    {
        _levelProgressBar.Setup(_currentLevelIndex);
    }
}