using System;
using System.Collections;
using Constants;
using Services.Storage;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace LevelLogic
{
    public class LevelLoader : ILevelLoader
    {
        private readonly LevelProgressStorageData _levelProgressStorageData;
        private readonly ILevelSettings _levelSettings;
        private readonly MonoBehaviour _monoBehaviour;
        private readonly ILevelModel _levelModel;
        
        private string _oldSceneName;
        private DiContainer _diContainer;

        public LevelLoader(
            IStorageService storageService,
            ILevelSettings levelSettings,
            MonoBehaviour monoBehaviour,
            ILevelModel levelModel
        )
        {
            _levelModel = levelModel;
            _levelSettings = levelSettings;
            _monoBehaviour = monoBehaviour;

            _levelProgressStorageData =
                storageService.GetData<LevelProgressStorageData>(StorageDataNames.LEVEL_PROGRESS_STORAGE_DATA_KEY);
        }

        public void LoadCurrentLevel(Action onFinished = null)
        {
            _monoBehaviour.StartCoroutine(LoadCurrentLevelCor(onFinished));
        }

        public void LoadNextLevel(Action onFinished = null)
        {
            _monoBehaviour.StartCoroutine(LoadNextLevelCor(onFinished));
        }

        private IEnumerator LoadCurrentLevelCor(Action onFinished = null)
        {
            var sceneName = _levelSettings.GetSceneName(_levelProgressStorageData.LevelIndex);

            if (_oldSceneName != null)
            {
                var sceneByName = SceneManager.GetSceneByName(_oldSceneName);
                yield return SceneManager.UnloadSceneAsync(sceneByName);
            }

            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

            _oldSceneName = sceneName;
            _levelModel.SetState(LevelState.Loaded);
            onFinished?.Invoke();
        }

        private IEnumerator LoadNextLevelCor(Action onFinished = null)
        {
            _levelProgressStorageData.IncrementLevelIndex();

            yield return LoadCurrentLevelCor(onFinished);
        }
    }
}