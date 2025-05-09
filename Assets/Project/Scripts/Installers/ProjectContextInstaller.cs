using Audio;
using Audio.Storage;
using Constants;
using DebugConsole;
using DebugConsole.Controllers;
using LevelLogic.LevelLoader;
using LevelLogic.LevelModel;
using LevelLogic.Settings;
using Pool;
using Services.Storage;
using Services.Storage.Data;
using Services.Storage.Data.Implementation;
using UnityEngine;
using Zenject;
using AudioSettings = Audio.Settings.AudioSettings;

namespace Installers
{
    public class ProjectContextInstaller : MonoInstaller
    {
        [SerializeField] private LevelSettings _levelSettings;
        [SerializeField] private AudioSettings _audioSettings;

        public override void InstallBindings()
        {
            BindStorage();
            BindLevelloader();
            BindPools();
            BindSound();

            BindDebug();
        }

        private void BindDebug()
        {
            Container.Bind(typeof(IDevConsoleController), typeof(ITickable)).To<LevelDevConsoleController>().AsSingle()
                .NonLazy();
            Container.Bind<IDevConsoleController>().To<WalletDevConsoleController>().AsSingle().NonLazy();
            
            Container.Bind(typeof(IDevConsole), typeof(IInitializable)).To<DevConsole>().AsSingle().NonLazy();
        }

        private void BindSound()
        {
            Container.Bind<IAudioSettings>().FromInstance(_audioSettings);
            Container.Bind(typeof(IAudioManager), typeof(IInitializable)).To<AudioManager>().AsSingle()
                .WithArguments(this);
        }

        private void BindLevelloader()
        {
            Container.Bind<ILevelModel>().To<LevelModel>().AsSingle();
            Container.Bind<ILevelSettings>().FromInstance(_levelSettings).AsSingle();
            Container.Bind<ILevelLoader>().To<LevelLoader>().AsSingle().WithArguments(this);
        }

        private void BindStorage()
        {
            Container.Bind<IStorageData>().To<LevelProgressStorageData>().AsSingle()
                .WithArguments(StorageDataNames.LEVEL_PROGRESS_STORAGE_DATA_KEY);

            Container.Bind<IStorageData>().To<WalletStorageData>().AsSingle()
                .WithArguments(StorageDataNames.WALLET_STORAGE_DATA_KEY);

            Container.Bind<IStorageData>().To<AudioStorageData>().AsSingle()
                .WithArguments(StorageDataNames.AUDIO_DATA_KEY);

            Container.Bind(typeof(IStorageService), typeof(IInitializable)).To<StorageService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindPools()
        {
            Container.Bind<IPool>().To<Pool.Pool>().AsSingle().NonLazy();
        }
    }
}