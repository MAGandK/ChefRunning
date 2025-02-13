using UI;
using UI.Window;
using UI.Window.MainWindow;
using UI.Window.StartWindow;
using Zenject;

namespace Installers
{
    public class UIContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindWindow<StartWindowController, StartWindowView>();
            BindWindow<MainWindowController, MainWindowView>();

            Container.Bind<IUIController>().To<UIController>().AsSingle().NonLazy();
        }

        private void BindWindow<TController, TWindowView>()
            where TController : IWindowController
            where TWindowView : IWindowView
        {
            Container.Bind(typeof(IWindowController), typeof(IInitializable)).To<TController>().AsSingle();
            Container.Bind<TWindowView>().FromComponentInHierarchy().AsSingle();
        }
    }
}