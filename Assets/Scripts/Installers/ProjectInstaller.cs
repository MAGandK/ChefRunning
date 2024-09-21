using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private GameObject[] scenePrefabs;
    public override void InstallBindings()
    {
        Container.Bind<SceneLoader>().AsSingle();
        Container.BindInstance(scenePrefabs).AsSingle();
    }
}