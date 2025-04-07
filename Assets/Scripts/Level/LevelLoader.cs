using System.Collections;
using Constants;
using Services.Storage;
using UnityEngine.SceneManagement;

namespace Level
{
    public class LevelLoader : ILevelLoader
    {
        private readonly LevelProgressStorageData _levelProgressStorageData;
        private readonly ILevelSettings _levelSettings;

        private string _oldSceneName;

        public LevelLoader(IStorageService storageService, ILevelSettings levelSettings)
        {
            _levelSettings = levelSettings;
            _levelProgressStorageData = storageService.GetData<LevelProgressStorageData>(StorageDataNames.LEVEL_PROGRESS_STORAGE_DATA_KEY);
        }
        
        public IEnumerator LoadCurrentLevel()
        {
            var sceneName = _levelSettings.GetSceneName(_levelProgressStorageData.LevelIndex);
            
            if (_oldSceneName != null)
            {
                var sceneByName = SceneManager.GetSceneByName(_oldSceneName);
                SceneManager.UnloadSceneAsync(sceneByName);
            }
            
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            
            _oldSceneName = sceneName;
        }

        public IEnumerator LoadNextLevel()
        {
            _levelProgressStorageData.IncrementLevelIndex();
            
            var sceneName = _levelSettings.GetSceneName(_levelProgressStorageData.LevelIndex);
            
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            
            if (_oldSceneName != null)
            {
                var sceneByName = SceneManager.GetSceneByName(_oldSceneName);
                SceneManager.UnloadSceneAsync(sceneByName);
            }
            
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            
            _oldSceneName = sceneName;
        }
    }
}