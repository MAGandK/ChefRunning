using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerPrefab;
    
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<UIController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AnimatorController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Joystick>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LevelPrefabManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        
       // Container.Bind<Player>().FromComponentInNewPrefab(playerPrefab).AsSingle().NonLazy();
    }
}
