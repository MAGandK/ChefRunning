using Animations;
using Managers;
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
            Container.Bind<AnimatorController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Joystick.Joystick>().FromComponentInHierarchy().AsSingle();
            Container.Bind<LevelPrefabManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Player.Player>().FromComponentInHierarchy().AsSingle();
            Container.Bind<AudioManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}