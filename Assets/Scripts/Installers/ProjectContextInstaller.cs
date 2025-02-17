using Services.Storage;
using Zenject;

namespace Installers
{
    public class ProjectContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IStorageData>().To<PlayerStorageData>().AsSingle().WithArguments(StorageDataNames.PLAYER_STORAGE_DATA_KEY);

            Container.Bind<IStorageService, IInitializable>().To<StorageService>().AsSingle().NonLazy();
        }
    }
}
