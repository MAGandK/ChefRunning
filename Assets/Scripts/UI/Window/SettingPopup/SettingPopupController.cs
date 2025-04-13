using Audio;
using UI.Window.StartWindow;

namespace UI.Window.SettingPopup
{
    public class SettingPopupController : AbstractWindowController<SettingPopupView>
    {
        private readonly SettingPopupView _view;
        private readonly IAudioManager _audioManager;

        public SettingPopupController(SettingPopupView view, IAudioManager audioManager) : base(view)
        {
            _audioManager = audioManager;
            _view = view;
        }

        public override void Initialize()
        {
            base.Initialize();

            _view.MuteSoundButton.onClick.AddListener(OnMuteSoundButtonClick);
            _view.MuteMusicButton.onClick.AddListener(OnMuteMusicButtonClick);
            _view.BackButton.onClick.AddListener(OnBackButtonClick);
            
            _view.MuteSoundButton.SetActiveState(!_audioManager.IsSoundMuted);
            _view.MuteMusicButton.SetActiveState(!_audioManager.IsMusicMuted);
        }

        private void OnBackButtonClick()
        {
            _uiController.ShowWindow<StartWindowController>();
        }

        private void OnMuteMusicButtonClick()
        {
            _audioManager.SetMuteMusic(_view.MuteMusicButton.IsActiveState);
        }

        private void OnMuteSoundButtonClick()
        {
            _audioManager.SetMuteSound(_view.MuteSoundButton.IsActiveState);
        }
    }
}