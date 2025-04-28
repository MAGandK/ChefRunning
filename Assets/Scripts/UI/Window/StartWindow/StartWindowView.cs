using UI.Other;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Window.StartWindow
{
    public class StartWindowView : AbstractWindowView
    {
        [SerializeField] private LevelProgressBar _levelProgressBar;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingWindowButton;
        [SerializeField] private Button _giftWindowButton;
        [SerializeField] private BalanceView _balanceView;

        public BalanceView BalanceView => _balanceView;
        public Button StartButton => _giftWindowButton;
        public Button GiftButton => _giftWindowButton;
        public Button SettingWindowButton => _settingWindowButton;
        
        public void SetupProgressBar(int levelIndex)
        {
            _levelProgressBar.Setup(levelIndex);
        }
    }
}