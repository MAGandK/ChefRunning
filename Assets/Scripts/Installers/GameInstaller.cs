using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<UIController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AnimatorController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<DynamicJoystick>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LevelPrefabManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<MovementController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AudioManager>().FromComponentInHierarchy().AsSingle();
    }
}