using Constants;
using Services.Price;
using Services.Storage;
using UI.Window.GameWindow;

namespace UI.Window.StartWindow
{
    public class StartWindowController : AbstractWindowController<StartWindowView>
    {
        private readonly StartWindowView _view;
        private LevelProgressStorageData _levelProgressStorageData;
        private WalletStopageData _walletStopageData;

        public StartWindowController(
            StartWindowView view, 
            IStorageService storageService) : base(view)
        {
            _view = view;
            _levelProgressStorageData =
                storageService.GetData<LevelProgressStorageData>(StorageDataNames.LEVEL_PROGRESS_STORAGE_DATA_KEY);
            _walletStopageData = storageService.GetData<WalletStopageData>(StorageDataNames.WALLET_STORAGE_DATA_KEY);
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

          //  _levelProgressStorageData.IncrementLevelIndex();
            _walletStopageData.Changed += WalletStopageDataOnChanged;
        }

        protected override void OnHide()
        {
            base.OnHide();
            _walletStopageData.Changed -= WalletStopageDataOnChanged;
        }
        private void OnStartButtonClick()
        {
            _uiController.ShowWindow<GameWindowController>();
        }
        
        private void WalletStopageDataOnChanged(string obj)
        {
            foreach (var walletItem in _walletStopageData.Balance)
            {
                _view.BalanceView.Refresh(walletItem.Type, walletItem.Value);
            }
        }
    }
}