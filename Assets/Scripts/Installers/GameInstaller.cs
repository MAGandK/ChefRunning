using JoystickControls;
using Managers;
using PlayerLogics;
using UI;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<UIController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Joystick>().FromComponentInHierarchy().AsSingle();
            Container.Bind<LevelPrefabManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<AudioManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CameraController>().FromComponentInHierarchy().AsSingle();
        }
    }
}