using Constants;
using Services.Storage;
using Zenject;

namespace Installers
{
    public class ProjectContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IStorageData>().To<LevelProgressStorageData>().AsSingle().WithArguments(StorageDataNames.LEVEL_PROGRESS_STORAGE_DATA_KEY);
            Container.Bind<IStorageData>().To<WalletStopageData>().AsSingle().WithArguments(StorageDataNames.WALLET_STORAGE_DATA_KEY);
  
            Container.Bind(typeof(IStorageService), typeof(IInitializable)).To<StorageService>()
                .AsSingle()
                .NonLazy();
        }
    }
}