using JoystickControls;
using UI;
using UI.UIController;
using UI.WindowsLogic;
using UI.WindowsLogic.Window.FailWindow;
using UI.WindowsLogic.Window.GameWindow;
using UI.WindowsLogic.Window.OfflineGift;
using UI.WindowsLogic.Window.SettingPopup;
using UI.WindowsLogic.Window.StartWindow;
using UI.WindowsLogic.Window.WinWindow;
using Zenject;

namespace Installers
{
    public class UIContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IJoystickController>().To<Joystick>().FromComponentInHierarchy().AsSingle();

            BindWindow<StartWindowController, StartWindowView>();
            BindWindow<GameWindowController, GameWindowView>();
            BindWindow<FailWindowController, FailWindowView>();
            BindWindow<WinWindowController, WinWindowView>();
            BindWindow<SettingPopupController, SettingPopupView>();
            BindWindow<OfflineGiftPopupController, OfflineGiftPopupView>();

            Container.Bind<IUIController>().To<UIController>().AsSingle().NonLazy();
            Container.Bind(typeof(ILevelStateWindowHandler), typeof(IInitializable)).To<LevelStateStateWindowHandler>().AsSingle().NonLazy();
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