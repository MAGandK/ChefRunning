using Audio;
using Audio.Stoarge;
using Constants;
using Level;
using Pool;
using Services.Storage;
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
        }

        private void BindSound()
        {
            Container.Bind<IAudioSettings>().FromInstance(_audioSettings);
            Container.Bind(typeof(IAudioManager), typeof(IInitializable)).To<AudioManager>().AsSingle().WithArguments(this);
        }

        private void BindLevelloader()
        {
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