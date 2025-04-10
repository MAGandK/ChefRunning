using Constants;
using Level;
using Pool;
using Services.Storage;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectContextInstaller : MonoInstaller
    {
        [SerializeField] private LevelSettings _levelSettings;
        public override void InstallBindings()
        {
            BindStorage();
            BindLevelloader();
            BindPools();
        }
        
        private void BindLevelloader()
        {
            Container.Bind<ILevelSettings>().FromInstance(_levelSettings).AsSingle();
            Container.Bind<ILevelLoader>().To<LevelLoader>().AsSingle();
        }

        private void BindStorage()
        {
            Container.Bind<IStorageData>().To<LevelProgressStorageData>().AsSingle().WithArguments(StorageDataNames.LEVEL_PROGRESS_STORAGE_DATA_KEY);
            Container.Bind<IStorageData>().To<WalletStorageData>().AsSingle().WithArguments(StorageDataNames.WALLET_STORAGE_DATA_KEY);
            
            Container.Bind(typeof(IStorageService), typeof(IInitializable)).To<StorageService>()
                .AsSingle()
                .NonLazy();
        }
        
        private void BindPools()
        {
            Container.Bind<IPool>().To<Pool.Pool>().AsSingle().NonLazy();
        }
    }
}