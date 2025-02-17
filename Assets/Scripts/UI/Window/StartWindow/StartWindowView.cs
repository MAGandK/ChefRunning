using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Window.StartWindow
{
    public class StartWindowView : AbstractWindowView
    {
        [SerializeField] private LevelProgressBar _levelProgressBar;
        [SerializeField] private Button _startButton;

        public void SubscribeButton(UnityAction onStartButtonClick)
        {
            _startButton.onClick.AddListener(onStartButtonClick);
        }

        public void SetupProgressBar(int levelIndex)
        {
            _levelProgressBar.Setup(levelIndex);
        }
    }
}
