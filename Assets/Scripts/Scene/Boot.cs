using System.Collections;
using Level;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Scene
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private string _uiSceneName;
        [SerializeField] private string _gameSceneName;

        private ILevelLoader _levelLoader;
        
        [Inject]
        private void Construct(ILevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }
        private void Awake()
        {
            StartCoroutine(LoadSceneCor());
        }

        private IEnumerator LoadSceneCor()
        {
            yield return  SceneManager.LoadSceneAsync(_uiSceneName, LoadSceneMode.Additive);

            yield return _levelLoader.LoadCurrentLevel();
         
            yield return SceneManager.UnloadSceneAsync(0);
        }
    }
}