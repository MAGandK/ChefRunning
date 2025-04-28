using LevelLogic;
using Services.Storage;
using UI.WinodwsLogic.Window.StartWindow;

namespace UI.WinodwsLogic.Window.WinWindow
{
    public class WinWindowController : AbstractWindowController<WinWindowView>
    {
        private readonly WinWindowView _winView;
        private readonly LevelProgressStorageData _levelProgressStorageData;
        private readonly ILevelLoader _levelLoader;

        public WinWindowController(WinWindowView view,
            ILevelLoader levelLoader) : base(view)
        {
            _levelLoader = levelLoader;
            _winView = view;
        }

        public override void Initialize()
        {
            base.Initialize();

            _winView.SubscribeButton(OnContinueButtonClick, OnRewardButtonClick);
        }

        private void OnContinueButtonClick()
        {
            _uiController.ShowWindow<StartWindowController>();
            _levelLoader.LoadNextLevel();
        }

        private void OnRewardButtonClick()
        {
        }
    }
}