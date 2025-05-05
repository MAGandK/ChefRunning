using UI.Other;
using UI.WindowsLogic.Window.StartWindow.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace UI.WindowsLogic.Window.StartWindow
{
    public class StartWindowView : AbstractWindowView
    {
        [SerializeField] private LevelProgressBar _levelProgressBar;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingWindowButton;
        [SerializeField] private Button _giftButton;
        [SerializeField] private BalanceView _balanceView;

        public BalanceView BalanceView => _balanceView;

        public Button SettingWindowButton => _settingWindowButton;
        public Button GiftButton => _giftButton;
        public Button StartButton => _startButton;
        
        public void SetupProgressBar(int levelIndex)
        {
            _levelProgressBar.Setup(levelIndex);
        }
    }
}