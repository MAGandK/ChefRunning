using JoystickControls;
using UI;
using UI.Window.FailWindow;
using UI.Window.GameWindow;
using UI.Window.StartWindow;
using UI.Window.WinWindow;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class UIContextInstaller : MonoInstaller
    {
        [SerializeField] private Joystick _joystick;
        public override void InstallBindings()
        {
            Container.Bind<Joystick>().FromInstance(_joystick).AsSingle();
            
            BindWindow<StartWindowController, StartWindowView>();
            BindWindow<GameWindowController, GameWindowView>();
            BindWindow<FailWindowController, FailWindowView>();
            BindWindow<WinWindowController, WinWindowView>();

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