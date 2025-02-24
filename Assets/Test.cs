using System;
using Constants;
using Services.Price;
using Services.Storage;
using UI;
using UI.Window.StartWindow;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Test : MonoBehaviour
{
   /*private IUIController _uiController;
   
   [Inject]
   private void Construct(IUIController uiController)
   {
       _uiController = uiController;
   }

   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.V))
       {
           _uiController.ShowWindow<StartWindowController>();
       }
   }*/
   public Button _addCoins;
   public Button _addRuby;

   private WalletStopageData _walletStopageData;

   [Inject] private IStorageService _service;

   private void Awake()
   {
       _walletStopageData = _service.GetData<WalletStopageData>(StorageDataNames.WALLET_STORAGE_DATA_KEY);
   }

   private void Start()
   {
       _addCoins.onClick.AddListener(AddCoins);
       _addCoins.onClick.AddListener(AddRuby);
       
   }

   private void AddRuby()
   {
       _walletStopageData.AddCurrency(CurrencyType.rybi, 1);
   }

   private void AddCoins()
   {
       _walletStopageData.AddCurrency(CurrencyType.coin, 1);
   }
}
