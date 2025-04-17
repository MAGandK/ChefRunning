using System.Collections;
using Audio;
using Audio.Types;
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
        private IAudioManager _audioManager;

        [Inject]
        private void Construct(ILevelLoader levelLoader, IAudioManager audioManager)
        {
            _audioManager = audioManager;
            _levelLoader = levelLoader;
        }

        private void Start()
        {
            StartCoroutine(LoadSceneCor());
        }

        private IEnumerator LoadSceneCor()
        {
            yield return SceneManager.LoadSceneAsync(_uiSceneName, LoadSceneMode.Additive);

            yield return _levelLoader.LoadCurrentLevel();

            _audioManager.Play(MusicType.Background1);

            yield return SceneManager.UnloadSceneAsync(0);
        }
    }
}