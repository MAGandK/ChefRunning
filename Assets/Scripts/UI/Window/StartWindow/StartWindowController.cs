using System;
using Constants;
using Services.Price;
using Services.Storage;
using UI.Window.GameWindow;

namespace UI.Window.StartWindow
{
    public class StartWindowController : AbstractWindowController<StartWindowView>
    {
        public event Action StartClicked;

        private readonly StartWindowView _view;
        private LevelProgressStorageData _levelProgressStorageData;

        public StartWindowController(
            StartWindowView view,
            IStorageService storageService) : base(view)
        {
            _view = view;
            _levelProgressStorageData =
                storageService.GetData<LevelProgressStorageData>(StorageDataNames.LEVEL_PROGRESS_STORAGE_DATA_KEY);
        }

        public override void Initialize()
        {
            base.Initialize();

            _view.SubscribeButton(OnStartButtonClick);
            _view.BalanceView.Setup(CurrencyType.coin, CurrencyType.rybi);
        }

        protected override void OnShow()
        {
            base.OnShow();
            _view.SetupProgressBar(_levelProgressStorageData.LevelIndex);
        }

        private void OnStartButtonClick()
        {
            _uiController.ShowWindow<GameWindowController>();
            StartClicked?.Invoke();
        }
    }
}