using Constants;
using Level;
using Services.Inventory;
using Services.Storage;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectContextInstaller : MonoInstaller
    {
        [SerializeField] private LevelSettings _levelSettings;
        [SerializeField] private InventoryConfig _inventoryConfig;
        
        public override void InstallBindings()
        {
            BindStorage();
            
            BindLevelLoader();
            
            BindInventory();
        }

        private void BindInventory()
        {
            Container.Bind<InventoryConfig>().FromInstance(_inventoryConfig).AsSingle();
            Container.Bind<IInventoryService>().To<InventoryService>().AsSingle();
        }

        private void BindLevelLoader()
        {
            Container.Bind<ILevelSettings>().FromInstance(_levelSettings).AsSingle();
            Container.Bind<ILevelLoader>().To<LevelLoader>().AsSingle();
        }

        private void BindStorage()
        {
            Container.Bind<IStorageData>().To<LevelProgressStorageData>().AsSingle().WithArguments(StorageDataNames.LEVEL_PROGRESS_STORAGE_DATA_KEY);
            Container.Bind<IStorageData>().To<WalletStorageData>().AsSingle().WithArguments(StorageDataNames.WALLET_STORAGE_DATA_KEY);
            Container.Bind<IStorageData>().To<InventoryData>().AsSingle().WithArguments(StorageDataNames.INVENTORY_DATA);
  
            Container.Bind(typeof(IStorageService), typeof(IInitializable)).To<StorageService>()
                .AsSingle()
                .NonLazy();
        }
    }
}