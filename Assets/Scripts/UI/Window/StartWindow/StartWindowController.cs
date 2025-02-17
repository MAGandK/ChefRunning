using Services.Storage;
using UI.Window.MainWindow;

namespace UI.Window.StartWindow
{
    public class StartWindowController : AbstractWindowController<StartWindowView>
    {
        private readonly StartWindowView _view;
        private readonly PlayerStorageData _playerStorageData;

        public StartWindowController(
            StartWindowView view,
            IStorageService storageService) : base(view)
        {
            _view = view;

            _playerStorageData = storageService.GetData<PlayerStorageData>(StorageDataNames.PLAYER_STORAGE_DATA_KEY);
        }

        public override void Initialize()
        {
            base.Initialize();
            _view.SubscribeButton(OnStartButtonClick);
        }

        protected override void OnShow()
        {
            base.OnShow();

            _view.SetupProgressBar(_playerStorageData.LevelIndex);
        }

        private void OnStartButtonClick()
        {
            _uiController.ShowWindow<GameWindowController>();
        }
    }
}
