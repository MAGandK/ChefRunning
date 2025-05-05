using Constants;
using LevelLogic.LevelModel;
using Services.Price;
using Services.Storage;
using Services.Storage.Data.Implementation;
using UI.WindowsLogic.Window.OfflineGift;
using UI.WindowsLogic.Window.SettingPopup;

namespace UI.WindowsLogic.Window.StartWindow
{
    public class StartWindowController : AbstractWindowController<StartWindowView>
    {
        private readonly StartWindowView _view;
        private readonly LevelProgressStorageData _levelProgressStorageData;
        private ILevelModel _levelModel;

        public StartWindowController(
            StartWindowView view,
            IStorageService storageService,
            ILevelModel levelModel) : base(view)
        {
            _view = view;
            _levelModel = levelModel;
            _levelProgressStorageData = storageService.GetData<LevelProgressStorageData>(StorageDataNames.LEVEL_PROGRESS_STORAGE_DATA_KEY);
        }

        public override void Initialize()
        {
            base.Initialize();

            _view.StartButton.onClick.AddListener(OnStartButtonClick);
            _view.SettingWindowButton.onClick.AddListener(OnSettingButtonClick);
            _view.GiftButton.onClick.AddListener(OnGiftButtonClick);

            _view.BalanceView.Setup(CurrencyType.coin, CurrencyType.rybi);
        }

        private void OnGiftButtonClick()
        {
            _uiController.ShowWindow<OfflineGiftPopupController>();
        }

        private void OnSettingButtonClick()
        {
            _uiController.ShowWindow<SettingPopupController>();
        }

        protected override void OnShow()
        {
            base.OnShow();
            _view.SetupProgressBar(_levelProgressStorageData.LevelIndex);
        }

        private void OnStartButtonClick()
        {
            _levelModel.SetState(LevelState.Start);
        }
    }
}