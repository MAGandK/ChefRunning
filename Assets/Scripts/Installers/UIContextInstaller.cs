using UI;
using UI.Other.Joystick;
using UI.Window;
using UI.Window.FailWindow;
using UI.Window.MainWindow;
using UI.Window.StartWindow;
using Zenject;

namespace Installers
{
    public class UIContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IJoystickController>().FromComponentInHierarchy().AsSingle();

            BindWindow<StartWindowController, StartWindowView>();
            BindWindow<FailWindowController, FailWindowView>();
            BindWindow<GameWindowController, GameWindowView>();

            Container.Bind<IUIController, IInitializable>().To<UIController>().AsSingle().NonLazy();
        }

        private void BindWindow<TController, TWindowView>()
            where TController : IWindowController
            where TWindowView : IWindowView
        {
            Container.Bind<IWindowController, IInitializable>().To<TController>().AsSingle();
            Container.Bind<TWindowView>().FromComponentInHierarchy().AsSingle();
        }
    }
}
