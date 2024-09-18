using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<UIController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AnimatorController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerController>().FromComponentInHierarchy().AsSingle();
        
        Container.Bind<MainWindow>().FromComponentInHierarchy().AsSingle();
        Container.Bind<FailWindow>().FromComponentInHierarchy().AsSingle();
        Container.Bind<FinishWindow>().FromComponentInHierarchy().AsSingle();
    }
}
