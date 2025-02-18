using Services.Storage;
using Zenject;

namespace Installers
{
    public class ProjectContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IStorageData>().To<StorageData>().AsSingle();
  
            Container.Bind(typeof(IStorageService), typeof(IInitializable)).To<StorageService>()
                .AsSingle()
                .NonLazy();
        }
    }
}