using UI.Other;
using UnityEngine;
using UnityEngine.UI;

namespace UI.WinodwsLogic.Window.SettingPopup
{
    public class SettingPopupView : AbstractWindowView
    {
        [SerializeField] private ToggleButton _muteSoundButton;
        [SerializeField] private ToggleButton _muteMusicButton;
        [SerializeField] private Button _backButton;
        
        public ToggleButton MuteSoundButton => _muteSoundButton;
        public ToggleButton MuteMusicButton => _muteMusicButton;
        public Button BackButton => _backButton;
    }
}