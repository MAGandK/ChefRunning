using System.Collections.Generic;
using Constants;
using Services.Price;
using Services.Storage;
using Services.Storage.Data.Implementation;

namespace DebugConsole.Controllers
{
    public class DevConsoleCurrencyController : AbstractDevConsoleController
    {
        private readonly WalletStorageData _walletStorageData;

        private readonly Dictionary<CurrencyType, int> _debugCurrencyValue = new()
        {
            { CurrencyType.rybi, 0 }
        };

        protected override string GroupName => "Currency";
        public override int GroupPriority => 0;

        public DevConsoleCurrencyController(IStorageService storageService)
        {
            _walletStorageData = storageService.GetData<WalletStorageData>(StorageDataNames.WALLET_STORAGE_DATA_KEY);
        }

        public override void Init()
        {
            AddButton("Add currency", AddCurrency);

            AddSlider("Rubi value", () => _debugCurrencyValue[CurrencyType.rybi],
                i => _walletStorageData.AddCurrency(CurrencyType.rybi, i));

            AddInfo("???", () => _walletStorageData.GetBalance(CurrencyType.rybi));
        }

        private void AddCurrency()
        {
            _walletStorageData.AddCurrency(CurrencyType.rybi, 100);
        }
    }
}